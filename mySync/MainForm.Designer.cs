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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
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
            resources.ApplyResources(this.lblConnInfo_iTunes, "lblConnInfo_iTunes");
            this.lblConnInfo_iTunes.Name = "lblConnInfo_iTunes";
            // 
            // btnGo
            // 
            resources.ApplyResources(this.btnGo, "btnGo");
            this.btnGo.Name = "btnGo";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // cbxDevice
            // 
            resources.ApplyResources(this.cbxDevice, "cbxDevice");
            this.cbxDevice.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxDevice.FormattingEnabled = true;
            this.cbxDevice.Name = "cbxDevice";
            // 
            // txtBitrate
            // 
            resources.ApplyResources(this.txtBitrate, "txtBitrate");
            this.txtBitrate.Name = "txtBitrate";
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // chkForceOverride
            // 
            resources.ApplyResources(this.chkForceOverride, "chkForceOverride");
            this.chkForceOverride.Checked = true;
            this.chkForceOverride.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkForceOverride.Name = "chkForceOverride";
            this.chkForceOverride.UseVisualStyleBackColor = true;
            // 
            // progress
            // 
            resources.ApplyResources(this.progress, "progress");
            this.progress.Name = "progress";
            // 
            // btnRefresh
            // 
            resources.ApplyResources(this.btnRefresh, "btnRefresh");
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblStatus
            // 
            resources.ApplyResources(this.lblStatus, "lblStatus");
            this.lblStatus.Name = "lblStatus";
            // 
            // MainForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
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