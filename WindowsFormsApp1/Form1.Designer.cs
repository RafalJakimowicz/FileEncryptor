namespace WindowsFormsApp1
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.rbFile = new System.Windows.Forms.RadioButton();
            this.rbDisc = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDontDelete = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.lblParent = new System.Windows.Forms.Label();
            this.lblPercent = new System.Windows.Forms.Label();
            this.txbPercent = new System.Windows.Forms.TextBox();
            this.txbConfirm = new System.Windows.Forms.TextBox();
            this.rbFolder = new System.Windows.Forms.RadioButton();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.bwEncrypt = new System.ComponentModel.BackgroundWorker();
            this.bwDecrypt = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tscbLang = new System.Windows.Forms.ToolStripComboBox();
            this.tcEncrypting = new System.Windows.Forms.TabControl();
            this.tbEncrypt = new System.Windows.Forms.TabPage();
            this.tbSecure = new System.Windows.Forms.TabPage();
            this.lbSecuredFiles = new System.Windows.Forms.ListBox();
            this.lblSecured = new System.Windows.Forms.Label();
            this.btnGetAccess = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.tcEncrypting.SuspendLayout();
            this.tbEncrypt.SuspendLayout();
            this.tbSecure.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.BackColor = System.Drawing.Color.FloralWhite;
            this.btnEncrypt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEncrypt.Location = new System.Drawing.Point(569, 317);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(156, 57);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = false;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.BackColor = System.Drawing.Color.FloralWhite;
            this.btnDecrypt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDecrypt.Location = new System.Drawing.Point(50, 317);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(145, 57);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = false;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txbPath
            // 
            this.txbPath.Enabled = false;
            this.txbPath.Location = new System.Drawing.Point(50, 60);
            this.txbPath.Name = "txbPath";
            this.txbPath.Size = new System.Drawing.Size(629, 20);
            this.txbPath.TabIndex = 2;
            // 
            // btnChoose
            // 
            this.btnChoose.BackColor = System.Drawing.Color.Transparent;
            this.btnChoose.Location = new System.Drawing.Point(685, 57);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(40, 25);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "...";
            this.btnChoose.UseVisualStyleBackColor = false;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txbPass
            // 
            this.txbPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbPass.Location = new System.Drawing.Point(144, 173);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(322, 26);
            this.txbPass.TabIndex = 4;
            this.txbPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.txbPass.Enter += new System.EventHandler(this.txbPass_Enter);
            this.txbPass.Leave += new System.EventHandler(this.txbPass_Leave);
            // 
            // rbFile
            // 
            this.rbFile.AutoSize = true;
            this.rbFile.Location = new System.Drawing.Point(210, 126);
            this.rbFile.Name = "rbFile";
            this.rbFile.Size = new System.Drawing.Size(41, 17);
            this.rbFile.TabIndex = 6;
            this.rbFile.TabStop = true;
            this.rbFile.Text = "File";
            this.rbFile.UseVisualStyleBackColor = true;
            // 
            // rbDisc
            // 
            this.rbDisc.AutoSize = true;
            this.rbDisc.Location = new System.Drawing.Point(293, 126);
            this.rbDisc.Name = "rbDisc";
            this.rbDisc.Size = new System.Drawing.Size(46, 17);
            this.rbDisc.TabIndex = 7;
            this.rbDisc.TabStop = true;
            this.rbDisc.Text = "Disc";
            this.rbDisc.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.BackColor = System.Drawing.Color.White;
            this.progressBar1.Location = new System.Drawing.Point(201, 350);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(362, 24);
            this.progressBar1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDontDelete);
            this.groupBox1.Controls.Add(this.rbDelete);
            this.groupBox1.Controls.Add(this.lblParent);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(569, 84);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 230);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbDontDelete
            // 
            this.rbDontDelete.AutoSize = true;
            this.rbDontDelete.Location = new System.Drawing.Point(51, 149);
            this.rbDontDelete.Name = "rbDontDelete";
            this.rbDontDelete.Size = new System.Drawing.Size(44, 21);
            this.rbDontDelete.TabIndex = 2;
            this.rbDontDelete.TabStop = true;
            this.rbDontDelete.Text = "No";
            this.rbDontDelete.UseVisualStyleBackColor = true;
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(51, 106);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(50, 21);
            this.rbDelete.TabIndex = 1;
            this.rbDelete.TabStop = true;
            this.rbDelete.Text = "Yes";
            this.rbDelete.UseVisualStyleBackColor = true;
            // 
            // lblParent
            // 
            this.lblParent.AutoSize = true;
            this.lblParent.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblParent.Location = new System.Drawing.Point(17, 56);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(48, 15);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "Backup";
            // 
            // lblPercent
            // 
            this.lblPercent.AutoSize = true;
            this.lblPercent.Location = new System.Drawing.Point(241, 259);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(48, 13);
            this.lblPercent.TabIndex = 16;
            this.lblPercent.Text = "Progress";
            // 
            // txbPercent
            // 
            this.txbPercent.Enabled = false;
            this.txbPercent.Location = new System.Drawing.Point(293, 256);
            this.txbPercent.Name = "txbPercent";
            this.txbPercent.Size = new System.Drawing.Size(70, 20);
            this.txbPercent.TabIndex = 15;
            // 
            // txbConfirm
            // 
            this.txbConfirm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.txbConfirm.Location = new System.Drawing.Point(144, 210);
            this.txbConfirm.Name = "txbConfirm";
            this.txbConfirm.Size = new System.Drawing.Size(322, 26);
            this.txbConfirm.TabIndex = 13;
            this.txbConfirm.TextChanged += new System.EventHandler(this.txbConfirm_TextChanged);
            this.txbConfirm.Enter += new System.EventHandler(this.txbConfirm_Enter);
            this.txbConfirm.Leave += new System.EventHandler(this.txbConfirm_Leave);
            // 
            // rbFolder
            // 
            this.rbFolder.AutoSize = true;
            this.rbFolder.Location = new System.Drawing.Point(373, 126);
            this.rbFolder.Name = "rbFolder";
            this.rbFolder.Size = new System.Drawing.Size(54, 17);
            this.rbFolder.TabIndex = 12;
            this.rbFolder.TabStop = true;
            this.rbFolder.Text = "Folder";
            this.rbFolder.UseVisualStyleBackColor = true;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblProgress.Location = new System.Drawing.Point(347, 26);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(95, 20);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.Text = "Wait to start";
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(351, 317);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(76, 23);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "STOP";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // bwEncrypt
            // 
            this.bwEncrypt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwEncrypt_DoWork);
            this.bwEncrypt.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwEncrypt_ProgressChanged);
            this.bwEncrypt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwEncrypt_RunWorkerCompleted);
            // 
            // bwDecrypt
            // 
            this.bwDecrypt.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDecrypt_DoWork);
            this.bwDecrypt.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwDecrypt_ProgressChanged);
            this.bwDecrypt.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDecrypt_RunWorkerCompleted);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.OldLace;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbLang});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(805, 27);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tscbLang
            // 
            this.tscbLang.BackColor = System.Drawing.SystemColors.Window;
            this.tscbLang.Items.AddRange(new object[] {
            "English",
            "Polish"});
            this.tscbLang.Name = "tscbLang";
            this.tscbLang.Size = new System.Drawing.Size(121, 23);
            this.tscbLang.Text = "Language";
            this.tscbLang.SelectedIndexChanged += new System.EventHandler(this.tscbLang_SelectedIndexChanged);
            // 
            // tcEncrypting
            // 
            this.tcEncrypting.Controls.Add(this.tbEncrypt);
            this.tcEncrypting.Controls.Add(this.tbSecure);
            this.tcEncrypting.Location = new System.Drawing.Point(8, 30);
            this.tcEncrypting.Name = "tcEncrypting";
            this.tcEncrypting.SelectedIndex = 0;
            this.tcEncrypting.Size = new System.Drawing.Size(782, 437);
            this.tcEncrypting.TabIndex = 12;
            // 
            // tbEncrypt
            // 
            this.tbEncrypt.BackColor = System.Drawing.Color.White;
            this.tbEncrypt.Controls.Add(this.lblPercent);
            this.tbEncrypt.Controls.Add(this.lblProgress);
            this.tbEncrypt.Controls.Add(this.txbPercent);
            this.tbEncrypt.Controls.Add(this.txbPass);
            this.tbEncrypt.Controls.Add(this.txbConfirm);
            this.tbEncrypt.Controls.Add(this.rbFile);
            this.tbEncrypt.Controls.Add(this.rbFolder);
            this.tbEncrypt.Controls.Add(this.btnChoose);
            this.tbEncrypt.Controls.Add(this.rbDisc);
            this.tbEncrypt.Controls.Add(this.btnStop);
            this.tbEncrypt.Controls.Add(this.btnDecrypt);
            this.tbEncrypt.Controls.Add(this.txbPath);
            this.tbEncrypt.Controls.Add(this.progressBar1);
            this.tbEncrypt.Controls.Add(this.groupBox1);
            this.tbEncrypt.Controls.Add(this.btnEncrypt);
            this.tbEncrypt.Location = new System.Drawing.Point(4, 22);
            this.tbEncrypt.Name = "tbEncrypt";
            this.tbEncrypt.Padding = new System.Windows.Forms.Padding(3);
            this.tbEncrypt.Size = new System.Drawing.Size(774, 411);
            this.tbEncrypt.TabIndex = 0;
            this.tbEncrypt.Text = "Encrypt";
            // 
            // tbSecure
            // 
            this.tbSecure.BackColor = System.Drawing.Color.White;
            this.tbSecure.Controls.Add(this.lbSecuredFiles);
            this.tbSecure.Controls.Add(this.lblSecured);
            this.tbSecure.Controls.Add(this.btnGetAccess);
            this.tbSecure.Location = new System.Drawing.Point(4, 22);
            this.tbSecure.Margin = new System.Windows.Forms.Padding(0);
            this.tbSecure.Name = "tbSecure";
            this.tbSecure.Padding = new System.Windows.Forms.Padding(3);
            this.tbSecure.Size = new System.Drawing.Size(774, 411);
            this.tbSecure.TabIndex = 1;
            this.tbSecure.Text = "Secure";
            // 
            // lbSecuredFiles
            // 
            this.lbSecuredFiles.FormattingEnabled = true;
            this.lbSecuredFiles.Location = new System.Drawing.Point(0, 109);
            this.lbSecuredFiles.Name = "lbSecuredFiles";
            this.lbSecuredFiles.Size = new System.Drawing.Size(774, 303);
            this.lbSecuredFiles.TabIndex = 4;
            this.lbSecuredFiles.SelectedIndexChanged += new System.EventHandler(this.lbSecuredFiles_SelectedIndexChanged);
            this.lbSecuredFiles.DragDrop += new System.Windows.Forms.DragEventHandler(this.lbSecuredFiles_DragDrop);
            this.lbSecuredFiles.DragEnter += new System.Windows.Forms.DragEventHandler(this.lbSecuredFiles_DragEnter);
            // 
            // lblSecured
            // 
            this.lblSecured.AutoSize = true;
            this.lblSecured.Location = new System.Drawing.Point(7, 93);
            this.lblSecured.Name = "lblSecured";
            this.lblSecured.Size = new System.Drawing.Size(71, 13);
            this.lblSecured.TabIndex = 3;
            this.lblSecured.Text = "Secured Files";
            // 
            // btnGetAccess
            // 
            this.btnGetAccess.BackColor = System.Drawing.Color.OldLace;
            this.btnGetAccess.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetAccess.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnGetAccess.Location = new System.Drawing.Point(335, 16);
            this.btnGetAccess.Name = "btnGetAccess";
            this.btnGetAccess.Size = new System.Drawing.Size(104, 71);
            this.btnGetAccess.TabIndex = 1;
            this.btnGetAccess.Text = "Get Access";
            this.btnGetAccess.UseVisualStyleBackColor = false;
            this.btnGetAccess.Click += new System.EventHandler(this.btnGetAccess_Click);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(805, 480);
            this.Controls.Add(this.tcEncrypting);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Encryptor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tcEncrypting.ResumeLayout(false);
            this.tbEncrypt.ResumeLayout(false);
            this.tbEncrypt.PerformLayout();
            this.tbSecure.ResumeLayout(false);
            this.tbSecure.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.RadioButton rbFile;
        private System.Windows.Forms.RadioButton rbDisc;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDontDelete;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.Label lblParent;
        private System.ComponentModel.BackgroundWorker bwEncrypt;
        private System.ComponentModel.BackgroundWorker bwDecrypt;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox tscbLang;
        private System.Windows.Forms.RadioButton rbFolder;
        private System.Windows.Forms.TextBox txbConfirm;
        private System.Windows.Forms.Label lblPercent;
        private System.Windows.Forms.TextBox txbPercent;
        private System.Windows.Forms.TabControl tcEncrypting;
        private System.Windows.Forms.TabPage tbEncrypt;
        private System.Windows.Forms.TabPage tbSecure;
        private System.Windows.Forms.Button btnGetAccess;
        private System.Windows.Forms.Label lblSecured;
        private System.Windows.Forms.ListBox lbSecuredFiles;
    }
}

