namespace KeLi.RetryUsage.App
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.nupWaitTimeout = new System.Windows.Forms.NumericUpDown();
            this.pnlTop = new System.Windows.Forms.Panel();
            this.labRetryCount = new System.Windows.Forms.Label();
            this.btnClearRecord = new System.Windows.Forms.Button();
            this.labWaitTimeout = new System.Windows.Forms.Label();
            this.nupRetryCount = new System.Windows.Forms.NumericUpDown();
            this.pnlBottom = new System.Windows.Forms.Panel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.lbRecord = new System.Windows.Forms.ListBox();
            ((System.ComponentModel.ISupportInitialize)(this.nupWaitTimeout)).BeginInit();
            this.pnlTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRetryCount)).BeginInit();
            this.pnlBottom.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStart.Location = new System.Drawing.Point(495, 24);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(69, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.BtnStart_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(588, 24);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // nupWaitTimeout
            // 
            this.nupWaitTimeout.Location = new System.Drawing.Point(137, 12);
            this.nupWaitTimeout.Name = "nupWaitTimeout";
            this.nupWaitTimeout.Size = new System.Drawing.Size(89, 21);
            this.nupWaitTimeout.TabIndex = 3;
            this.nupWaitTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // pnlTop
            // 
            this.pnlTop.Controls.Add(this.labRetryCount);
            this.pnlTop.Controls.Add(this.btnClearRecord);
            this.pnlTop.Controls.Add(this.labWaitTimeout);
            this.pnlTop.Controls.Add(this.nupRetryCount);
            this.pnlTop.Controls.Add(this.nupWaitTimeout);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Name = "pnlTop";
            this.pnlTop.Size = new System.Drawing.Size(684, 42);
            this.pnlTop.TabIndex = 4;
            // 
            // labRetryCount
            // 
            this.labRetryCount.AutoSize = true;
            this.labRetryCount.Location = new System.Drawing.Point(234, 16);
            this.labRetryCount.Name = "labRetryCount";
            this.labRetryCount.Size = new System.Drawing.Size(65, 12);
            this.labRetryCount.TabIndex = 6;
            this.labRetryCount.Text = "RetryCount";
            // 
            // btnClearRecord
            // 
            this.btnClearRecord.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearRecord.Location = new System.Drawing.Point(558, 11);
            this.btnClearRecord.Name = "btnClearRecord";
            this.btnClearRecord.Size = new System.Drawing.Size(105, 23);
            this.btnClearRecord.TabIndex = 2;
            this.btnClearRecord.Text = "Clear Record";
            this.btnClearRecord.UseVisualStyleBackColor = true;
            this.btnClearRecord.Click += new System.EventHandler(this.BtnClearRecord_Click);
            // 
            // labWaitTimeout
            // 
            this.labWaitTimeout.AutoSize = true;
            this.labWaitTimeout.Location = new System.Drawing.Point(42, 16);
            this.labWaitTimeout.Name = "labWaitTimeout";
            this.labWaitTimeout.Size = new System.Drawing.Size(89, 12);
            this.labWaitTimeout.TabIndex = 5;
            this.labWaitTimeout.Text = "WaitTimeout(s)";
            // 
            // nupRetryCount
            // 
            this.nupRetryCount.Location = new System.Drawing.Point(309, 12);
            this.nupRetryCount.Name = "nupRetryCount";
            this.nupRetryCount.Size = new System.Drawing.Size(88, 21);
            this.nupRetryCount.TabIndex = 4;
            this.nupRetryCount.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // pnlBottom
            // 
            this.pnlBottom.Controls.Add(this.progressBar);
            this.pnlBottom.Controls.Add(this.btnCancel);
            this.pnlBottom.Controls.Add(this.btnStart);
            this.pnlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlBottom.Location = new System.Drawing.Point(0, 413);
            this.pnlBottom.Name = "pnlBottom";
            this.pnlBottom.Size = new System.Drawing.Size(684, 57);
            this.pnlBottom.TabIndex = 5;
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.progressBar.ForeColor = System.Drawing.SystemColors.HotTrack;
            this.progressBar.Location = new System.Drawing.Point(0, 0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(684, 17);
            this.progressBar.TabIndex = 3;
            // 
            // lbRecord
            // 
            this.lbRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRecord.FormattingEnabled = true;
            this.lbRecord.ItemHeight = 12;
            this.lbRecord.Location = new System.Drawing.Point(0, 42);
            this.lbRecord.Name = "lbRecord";
            this.lbRecord.Size = new System.Drawing.Size(684, 371);
            this.lbRecord.TabIndex = 6;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 470);
            this.Controls.Add(this.lbRecord);
            this.Controls.Add(this.pnlBottom);
            this.Controls.Add(this.pnlTop);
            this.MinimumSize = new System.Drawing.Size(553, 271);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Retry Window";
            ((System.ComponentModel.ISupportInitialize)(this.nupWaitTimeout)).EndInit();
            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nupRetryCount)).EndInit();
            this.pnlBottom.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown nupWaitTimeout;
        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.NumericUpDown nupRetryCount;
        private System.Windows.Forms.Panel pnlBottom;
        private System.Windows.Forms.ListBox lbRecord;
        private System.Windows.Forms.Label labWaitTimeout;
        private System.Windows.Forms.Label labRetryCount;
        private System.Windows.Forms.Button btnClearRecord;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

