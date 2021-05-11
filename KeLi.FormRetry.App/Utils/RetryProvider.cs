using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;

namespace KeLi.FormRetry.App.Utils
{
    public class RetryProvider : IDisposable
    {
        public delegate void CancelledEventHandler();

        public delegate void CompletedEventHandler(bool success);

        public delegate void PerRetryBeginEventHandler(int retryIndex);

        public delegate void PerRetryEndEventHandler(int retryIndex);

        public delegate void PerRetryFailedEventHandler(Exception ex);

        public delegate void ProgressChangedEventHandler(int percent);

        private static readonly object AsyncLock = new object();

        private int _retryCount = 1;

        private int _waitTimeout;

        private BackgroundWorker BackgroupThread { get; set; }

        public bool IsBusy => BackgroupThread != null && BackgroupThread.IsBusy;

        public int WaitTimeout
        {
            get => _waitTimeout;

            private set
            {
                if (value < 0)
                    value = 0;

                _waitTimeout = value;
            }
        }

        public int RetryCount
        {
            get => _retryCount;

            private set
            {
                if (value < 1)
                    value = 1;

                _retryCount = value;
            }
        }

        public static int WmVscroll => 0x0115;

        public static int SbBottom => 7;

        public void Dispose()
        {
            Dispose(true);

            GC.SuppressFinalize(this);
        }

        public event CompletedEventHandler Completed;

        public event CancelledEventHandler Cancelled;

        public event PerRetryBeginEventHandler PerRetryBegin;

        public event PerRetryEndEventHandler PerRetryEnd;

        public event PerRetryFailedEventHandler PerRetryFailed;

        public event ProgressChangedEventHandler ProgressChanged;

        [DllImport("User32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public void StartAsync(Action target, int waitTimeout = 0, int retryCount = 1)
        {
            StartAsyncRetry(target, waitTimeout, retryCount);
        }

        public void StartAsyncFunc(Func<bool> target, int waitTimeout = 0, int retryCount = 1)
        {
            StartAsyncRetry(target, waitTimeout, retryCount);
        }

        private void StartAsyncRetry(object target, int waitTimeout, int retryCount)
        {
            if (target == null)
                throw new ArgumentNullException(nameof(target));

            if (BackgroupThread == null)
            {
                BackgroupThread = new BackgroundWorker
                {
                    WorkerSupportsCancellation = true,

                    WorkerReportsProgress = true
                };

                BackgroupThread.DoWork += OnBackgroupThreadDoWork;

                BackgroupThread.ProgressChanged += OnBackgroupThreadProgressChanged;
            }

            if (BackgroupThread.IsBusy)
                return;

            WaitTimeout = waitTimeout;

            RetryCount = retryCount;

            BackgroupThread.RunWorkerAsync(target);
        }

        private void OnBackgroupThreadProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            ProgressChanged?.Invoke(e.ProgressPercentage);
        }

        private void OnBackgroupThreadDoWork(object sender, DoWorkEventArgs e)
        {
            Start(e.Argument);
        }

        private void Start(object target)
        {
            if (target == null)
                return;

            var retryCount = RetryCount;

            lock (AsyncLock)
            {
                BackgroupThread.ReportProgress(5);

                while (!BackgroupThread.CancellationPending)
                {
                    PerRetryBegin?.Invoke(RetryCount - retryCount);

                    try
                    {
                        if (target.GetType() == typeof(Action))
                        {
                            var action = target as Action;

                            action?.Invoke();

                            InvokeCompletedEvent(true);

                            return;
                        }

                        else
                        {
                            if (target is Func<bool> func && func.Invoke())
                            {
                                InvokeCompletedEvent(true);

                                return;
                            }

                            else
                                throw new InvalidOperationException("Execute Failed.");
                        }
                    }

                    catch (Exception ex)
                    {
                        PerRetryFailed?.Invoke(ex);

                        BackgroupThread.ReportProgress((RetryCount - retryCount + 1) * 100 / RetryCount);
                    }

                    finally
                    {
                        PerRetryEnd?.Invoke(RetryCount - retryCount);
                    }

                    if (RetryCount > 0)
                    {
                        retryCount--;

                        if (retryCount == 0)
                        {
                            InvokeCompletedEvent();

                            return;
                        }
                    }

                    Thread.Sleep(WaitTimeout);
                }

                if (BackgroupThread.CancellationPending)
                    Cancelled?.Invoke();
            }
        }

        private void InvokeCompletedEvent(bool success = false)
        {
            Completed?.Invoke(success);

            BackgroupThread.ReportProgress(100);
        }

        public void Cancel()
        {
            BackgroupThread?.CancelAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                Cancel();

            BackgroupThread = null;
        }
    }
}