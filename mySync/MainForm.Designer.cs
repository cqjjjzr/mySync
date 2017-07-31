namespace mySync
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
            this.lblConnInfo_iTunes = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.cbxDevice = new System.Windows.Forms.ComboBox();
            this.txtBitrate = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkForceOverride = new System.Windows.Forms.CheckBox();
            this.progress = new System.Windows.Forms.ProgressBar();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblConnInfo_iTunes
            // 
            this.lblConnInfo_iTunes.AutoSize = true;
            this.lblConnInfo_iTunes.Location = new System.Drawing.Point(13, 21);
            this.lblConnInfo_iTunes.Name = "lblConnInfo_iTunes";
            this.lblConnInfo_iTunes.Size = new System.Drawing.Size(41, 12);
            this.lblConnInfo_iTunes.TabIndex = 1;
            this.lblConnInfo_iTunes.Text = "label2";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(9, 138);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(474, 116);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "GO!";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbxDevice
            // 
            this.cbxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Location = new System.Drawing.Point(15, 52);
            this.cbxDevice.Name = "cbxDevice";
            this.cbxDevice.Size = new System.Drawing.Size(423, 20);
            this.cbxDevice.TabIndex = 3;
            // 
            // txtBitrate
            // 
            this.txtBitrate.Location = new System.Drawing.Point(15, 79);
            this.txtBitrate.Name = "txtBitrate";
            this.txtBitrate.Size = new System.Drawing.Size(399, 21);
            this.txtBitrate.TabIndex = 4;
            this.txtBitrate.Text = "128";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(420, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "Kbps";
            // 
            // chkForceOverride
            // 
            this.chkForceOverride.AutoSize = true;
            this.chkForceOverride.Checked = true;
            this.chkForceOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForceOverride.Location = new System.Drawing.Point(15, 116);
            this.chkForceOverride.Name = "chkForceOverride";
            this.chkForceOverride.Size = new System.Drawing.Size(108, 16);
            this.chkForceOverride.TabIndex = 6;
            this.chkForceOverride.Text = "Force Override";
            this.chkForceOverride.UseVisualStyleBackColor = true;
            // 
            // progress
            // 
            this.progress.Location = new System.Drawing.Point(9, 260);
            this.progress.Name = "progress";
            this.progress.Size = new System.Drawing.Size(474, 23);
            this.progress.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(445, 48);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(75, 23);
            this.btnRefresh.TabIndex = 8;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(468, 82);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(41, 12);
            this.lblStatus.TabIndex = 9;
            this.lblStatus.Text = "Ready.";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 287);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.progress);
            this.Controls.Add(this.chkForceOverride);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtBitrate);
            this.Controls.Add(this.cbxDevice);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.lblConnInfo_iTunes);
            this.Name = "MainForm";
            this.Text = "mySync by CharlieJiang";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblConnInfo_iTunes;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.ComboBox cbxDevice;
        private System.Windows.Forms.TextBox txtBitrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkForceOverride;
        private System.Windows.Forms.ProgressBar progress;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblStatus;
    }
}