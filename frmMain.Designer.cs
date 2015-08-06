namespace ESPPT
{
    partial class frmMain
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
            this.cbBaudRate = new System.Windows.Forms.ComboBox();
            this.cbDatabits = new System.Windows.Forms.ComboBox();
            this.cbParity = new System.Windows.Forms.ComboBox();
            this.cbStopBits = new System.Windows.Forms.ComboBox();
            this.cbFlowControl = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnConnect = new System.Windows.Forms.Button();
            this.txtDebug = new System.Windows.Forms.TextBox();
            this.txtSend = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCom = new System.Windows.Forms.ComboBox();
            this.btnUpload = new System.Windows.Forms.Button();
            this.txtProjectPath = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.dgPaths = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnLoad = new System.Windows.Forms.Button();
            this.btnBuild = new System.Windows.Forms.Button();
            this.btnSaveConfig = new System.Windows.Forms.Button();
            this.chDoAll = new System.Windows.Forms.CheckBox();
            this.oFD = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgPaths)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbBaudRate
            // 
            this.cbBaudRate.BackColor = System.Drawing.Color.Black;
            this.cbBaudRate.ForeColor = System.Drawing.Color.White;
            this.cbBaudRate.FormattingEnabled = true;
            this.cbBaudRate.Items.AddRange(new object[] {
            "75",
            "110",
            "134",
            "150",
            "300",
            "600",
            "1200",
            "1800",
            "2400",
            "4800",
            "7200",
            "9600",
            "14400",
            "19200",
            "38400",
            "57600",
            "115200",
            "128000"});
            this.cbBaudRate.Location = new System.Drawing.Point(27, 86);
            this.cbBaudRate.Name = "cbBaudRate";
            this.cbBaudRate.Size = new System.Drawing.Size(95, 21);
            this.cbBaudRate.TabIndex = 0;
            this.cbBaudRate.Text = "115200";
            // 
            // cbDatabits
            // 
            this.cbDatabits.BackColor = System.Drawing.Color.Black;
            this.cbDatabits.ForeColor = System.Drawing.Color.White;
            this.cbDatabits.FormattingEnabled = true;
            this.cbDatabits.Items.AddRange(new object[] {
            "4",
            "5",
            "6",
            "7",
            "8"});
            this.cbDatabits.Location = new System.Drawing.Point(27, 113);
            this.cbDatabits.Name = "cbDatabits";
            this.cbDatabits.Size = new System.Drawing.Size(95, 21);
            this.cbDatabits.TabIndex = 1;
            this.cbDatabits.Text = "8";
            // 
            // cbParity
            // 
            this.cbParity.BackColor = System.Drawing.Color.Black;
            this.cbParity.ForeColor = System.Drawing.Color.White;
            this.cbParity.FormattingEnabled = true;
            this.cbParity.Items.AddRange(new object[] {
            "Even",
            "Odd",
            "None",
            "Mark",
            "Space"});
            this.cbParity.Location = new System.Drawing.Point(27, 140);
            this.cbParity.Name = "cbParity";
            this.cbParity.Size = new System.Drawing.Size(95, 21);
            this.cbParity.TabIndex = 2;
            this.cbParity.Text = "None";
            // 
            // cbStopBits
            // 
            this.cbStopBits.BackColor = System.Drawing.Color.Black;
            this.cbStopBits.ForeColor = System.Drawing.Color.White;
            this.cbStopBits.FormattingEnabled = true;
            this.cbStopBits.Items.AddRange(new object[] {
            "1",
            "1.5",
            "2"});
            this.cbStopBits.Location = new System.Drawing.Point(27, 167);
            this.cbStopBits.Name = "cbStopBits";
            this.cbStopBits.Size = new System.Drawing.Size(95, 21);
            this.cbStopBits.TabIndex = 3;
            this.cbStopBits.Text = "1";
            // 
            // cbFlowControl
            // 
            this.cbFlowControl.BackColor = System.Drawing.Color.Black;
            this.cbFlowControl.ForeColor = System.Drawing.Color.White;
            this.cbFlowControl.FormattingEnabled = true;
            this.cbFlowControl.Items.AddRange(new object[] {
            "Xon / Xoff",
            "Hardware",
            "None"});
            this.cbFlowControl.Location = new System.Drawing.Point(27, 194);
            this.cbFlowControl.Name = "cbFlowControl";
            this.cbFlowControl.Size = new System.Drawing.Size(95, 21);
            this.cbFlowControl.TabIndex = 4;
            this.cbFlowControl.Text = "None";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(128, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Baud rate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(128, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Data bits";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(128, 140);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Parity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 167);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(48, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Stop bits";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(128, 194);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Flow control";
            // 
            // btnConnect
            // 
            this.btnConnect.ForeColor = System.Drawing.Color.Black;
            this.btnConnect.Location = new System.Drawing.Point(27, 221);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(95, 23);
            this.btnConnect.TabIndex = 10;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtDebug
            // 
            this.txtDebug.BackColor = System.Drawing.Color.Black;
            this.txtDebug.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.txtDebug.Location = new System.Drawing.Point(12, 327);
            this.txtDebug.Multiline = true;
            this.txtDebug.Name = "txtDebug";
            this.txtDebug.Size = new System.Drawing.Size(521, 225);
            this.txtDebug.TabIndex = 11;
            // 
            // txtSend
            // 
            this.txtSend.BackColor = System.Drawing.Color.Black;
            this.txtSend.ForeColor = System.Drawing.Color.White;
            this.txtSend.Location = new System.Drawing.Point(12, 558);
            this.txtSend.Name = "txtSend";
            this.txtSend.Size = new System.Drawing.Size(420, 20);
            this.txtSend.TabIndex = 12;
            this.txtSend.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtSend_KeyUp);
            // 
            // btnSend
            // 
            this.btnSend.ForeColor = System.Drawing.Color.Black;
            this.btnSend.Location = new System.Drawing.Point(436, 558);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(95, 23);
            this.btnSend.TabIndex = 13;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btn_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(128, 59);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(28, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Com";
            // 
            // cbCom
            // 
            this.cbCom.BackColor = System.Drawing.Color.Black;
            this.cbCom.ForeColor = System.Drawing.Color.White;
            this.cbCom.FormattingEnabled = true;
            this.cbCom.Location = new System.Drawing.Point(27, 59);
            this.cbCom.Name = "cbCom";
            this.cbCom.Size = new System.Drawing.Size(95, 21);
            this.cbCom.TabIndex = 14;
            // 
            // btnUpload
            // 
            this.btnUpload.ForeColor = System.Drawing.Color.Black;
            this.btnUpload.Location = new System.Drawing.Point(222, 281);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(61, 23);
            this.btnUpload.TabIndex = 16;
            this.btnUpload.Text = "Upload";
            this.btnUpload.UseVisualStyleBackColor = true;
            this.btnUpload.Click += new System.EventHandler(this.btn_Click);
            // 
            // txtProjectPath
            // 
            this.txtProjectPath.BackColor = System.Drawing.Color.Black;
            this.txtProjectPath.ForeColor = System.Drawing.Color.White;
            this.txtProjectPath.Location = new System.Drawing.Point(84, 8);
            this.txtProjectPath.Name = "txtProjectPath";
            this.txtProjectPath.Size = new System.Drawing.Size(153, 20);
            this.txtProjectPath.TabIndex = 17;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Project Folder";
            // 
            // dgPaths
            // 
            this.dgPaths.BackgroundColor = System.Drawing.Color.Black;
            this.dgPaths.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPaths.Location = new System.Drawing.Point(17, 37);
            this.dgPaths.Name = "dgPaths";
            this.dgPaths.Size = new System.Drawing.Size(297, 241);
            this.dgPaths.TabIndex = 19;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnBuild);
            this.panel1.Controls.Add(this.btnSaveConfig);
            this.panel1.Controls.Add(this.chDoAll);
            this.panel1.Controls.Add(this.btnUpload);
            this.panel1.Controls.Add(this.dgPaths);
            this.panel1.Controls.Add(this.txtProjectPath);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(201, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(332, 309);
            this.panel1.TabIndex = 20;
            // 
            // btnLoad
            // 
            this.btnLoad.ForeColor = System.Drawing.Color.Black;
            this.btnLoad.Location = new System.Drawing.Point(243, 5);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(40, 23);
            this.btnLoad.TabIndex = 23;
            this.btnLoad.Text = "Load";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnBuild
            // 
            this.btnBuild.ForeColor = System.Drawing.Color.Black;
            this.btnBuild.Location = new System.Drawing.Point(155, 281);
            this.btnBuild.Name = "btnBuild";
            this.btnBuild.Size = new System.Drawing.Size(61, 23);
            this.btnBuild.TabIndex = 21;
            this.btnBuild.Text = "Build";
            this.btnBuild.UseVisualStyleBackColor = true;
            this.btnBuild.Click += new System.EventHandler(this.btn_Click);
            // 
            // btnSaveConfig
            // 
            this.btnSaveConfig.ForeColor = System.Drawing.Color.Black;
            this.btnSaveConfig.Location = new System.Drawing.Point(289, 5);
            this.btnSaveConfig.Name = "btnSaveConfig";
            this.btnSaveConfig.Size = new System.Drawing.Size(40, 23);
            this.btnSaveConfig.TabIndex = 20;
            this.btnSaveConfig.Text = "Save";
            this.btnSaveConfig.UseVisualStyleBackColor = true;
            this.btnSaveConfig.Click += new System.EventHandler(this.btn_Click);
            // 
            // chDoAll
            // 
            this.chDoAll.AutoSize = true;
            this.chDoAll.Checked = true;
            this.chDoAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chDoAll.Location = new System.Drawing.Point(55, 284);
            this.chDoAll.Name = "chDoAll";
            this.chDoAll.Size = new System.Drawing.Size(84, 17);
            this.chDoAll.TabIndex = 22;
            this.chDoAll.Text = "1 Click Build";
            this.chDoAll.UseVisualStyleBackColor = true;
            this.chDoAll.CheckedChanged += new System.EventHandler(this.chDoAll_CheckedChanged);
            // 
            // oFD
            // 
            this.oFD.FileName = "openFileDialog";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(543, 588);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCom);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.txtSend);
            this.Controls.Add(this.txtDebug);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbFlowControl);
            this.Controls.Add(this.cbStopBits);
            this.Controls.Add(this.cbParity);
            this.Controls.Add(this.cbDatabits);
            this.Controls.Add(this.cbBaudRate);
            this.ForeColor = System.Drawing.Color.White;
            this.Name = "frmMain";
            this.Text = "Remix - ESP Project Tool";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgPaths)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbBaudRate;
        private System.Windows.Forms.ComboBox cbDatabits;
        private System.Windows.Forms.ComboBox cbParity;
        private System.Windows.Forms.ComboBox cbStopBits;
        private System.Windows.Forms.ComboBox cbFlowControl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtDebug;
        private System.Windows.Forms.TextBox txtSend;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbCom;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.TextBox txtProjectPath;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView dgPaths;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSaveConfig;
        private System.Windows.Forms.Button btnBuild;
        private System.Windows.Forms.CheckBox chDoAll;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.OpenFileDialog oFD;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}

