using System;
using System.Threading;
using System.Windows.Forms;

using KeLi.FormRetry.App.Utils;

namespace KeLi.FormRetry.App
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private RetryProvider RetryProvider { get; set; }

        private void BtnStart_Click(object sender, EventArgs e)
        {
            int.TryParse(nupWaitTimeout.Value.ToString(), out var waitTimeout);

            int.TryParse(nupRetryCount.Value.ToString(), out var retryCount);

            Start(waitTimeout, retryCount);
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            RetryProvider?.Cancel();
        }

        private void BtnClearRecord_Click(object sender, EventArgs e)
        {
            lbRecord.Items.Clear();
        }

        private void Start(int waitTimeout, int retryCount)
        {
            if (RetryProvider == null)
            {
                RetryProvider = new RetryProvider();

                RetryProvider.PerRetryFailed += PerRetryFailed;

                RetryProvider.Completed += Completed;

                RetryProvider.Cancelled += Cancelled;

                RetryProvider.PerRetryBegin += PerRetryBegin;

                RetryProvider.PerRetryEnd += PerRetryEnd;

                RetryProvider.ProgressChanged += ProgressChanged;
            }

            if (RetryProvider.IsBusy)
                return;

            btnStart.Enabled = false;

            if (lbRecord.Items.Count > 0)
                AddMsg(null);

            RetryProvider.StartAsyncFunc(ThrowExceptionMethod, waitTimeout * 1000, retryCount);
        }

        public bool ThrowExceptionMethod()
        {
            Thread.Sleep(6000);

            var random = new Random();

            var currentValue = random.Next(0, 10);

            if (currentValue < 7)
            {
                var message = $"Value={currentValue}<8, Exception GUID: {Guid.NewGuid()}";

                throw new ArgumentException(message);
            }

            return true;
        }

        private void ResetStartButtonState()
        {
            if (btnStart.InvokeRequired)
                btnStart.BeginInvoke(new MethodInvoker(() => btnStart.Enabled = true));

            else
                btnStart.Enabled = true;
        }

        private void ProgressChanged(int percent)
        {
            SetProgressValue(percent);
        }

        private void SetProgressValue(int percent)
        {
            if (progressBar.InvokeRequired)
                progressBar.BeginInvoke(new MethodInvoker(() => progressBar.Value = percent));

            else
                progressBar.Value = percent;
        }

        private void PerRetryBegin(int retryIndex)
        {
            var lineMsg = $"{GetCurrentTime()} PerRetryBegin Index: {retryIndex}";

            AddMsg(lineMsg);
        }

        private void PerRetryEnd(int retryIndex)
        {
            var lineMsg = $"{GetCurrentTime()} PerRetryEnd Index: {retryIndex}";

            AddMsg(lineMsg);
        }

        private void Completed(bool success)
        {
            AddMsg($"{success} Completed");

            ResetStartButtonState();
        }

        private void Cancelled()
        {
            var lineMsg = $"{GetCurrentTime()} Cancelled";

            AddMsg(lineMsg);

            ResetStartButtonState();
        }

        private void PerRetryFailed(Exception ex)
        {
            AddMsg(ex.Message);
        }

        private static string GetCurrentTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff");
        }

        private void AddMsg(string lineMsg)
        {
            lineMsg = lineMsg ?? string.Empty;

            if (lbRecord.InvokeRequired)
                lbRecord.BeginInvoke(new MethodInvoker(() => AddMsgLine(lineMsg)));

            else
                AddMsgLine(lineMsg);
        }

        private void AddMsgLine(string lineMsg)
        {
            lbRecord.Items.Add(lineMsg);

            RetryProvider.SendMessage(lbRecord.Handle, RetryProvider.WmVscroll, RetryProvider.SbBottom, 0);
        }
    }
}