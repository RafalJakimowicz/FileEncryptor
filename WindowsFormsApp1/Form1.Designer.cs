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
            this.lblPassword = new System.Windows.Forms.Label();
            this.rbFileOrFolder = new System.Windows.Forms.RadioButton();
            this.rbDisc = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbDontDelete = new System.Windows.Forms.RadioButton();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.lblParent = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblProgress = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.bwEncrypt = new System.ComponentModel.BackgroundWorker();
            this.bwDecrypt = new System.ComponentModel.BackgroundWorker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tscbLang = new System.Windows.Forms.ToolStripComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEncrypt.Location = new System.Drawing.Point(396, 323);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(156, 57);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDecrypt.Location = new System.Drawing.Point(6, 323);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(145, 57);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txbPath
            // 
            this.txbPath.Enabled = false;
            this.txbPath.Location = new System.Drawing.Point(9, 75);
            this.txbPath.Name = "txbPath";
            this.txbPath.Size = new System.Drawing.Size(497, 20);
            this.txbPath.TabIndex = 2;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(512, 72);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(40, 25);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(116, 248);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(222, 20);
            this.txbPass.TabIndex = 4;
            this.txbPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblPassword.Location = new System.Drawing.Point(32, 248);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(78, 20);
            this.lblPassword.TabIndex = 5;
            this.lblPassword.Text = "Password";
            // 
            // rbFileOrFolder
            // 
            this.rbFileOrFolder.AutoSize = true;
            this.rbFileOrFolder.Location = new System.Drawing.Point(90, 169);
            this.rbFileOrFolder.Name = "rbFileOrFolder";
            this.rbFileOrFolder.Size = new System.Drawing.Size(41, 17);
            this.rbFileOrFolder.TabIndex = 6;
            this.rbFileOrFolder.TabStop = true;
            this.rbFileOrFolder.Text = "File";
            this.rbFileOrFolder.UseVisualStyleBackColor = true;
            // 
            // rbDisc
            // 
            this.rbDisc.AutoSize = true;
            this.rbDisc.Location = new System.Drawing.Point(222, 169);
            this.rbDisc.Name = "rbDisc";
            this.rbDisc.Size = new System.Drawing.Size(90, 17);
            this.rbDisc.TabIndex = 7;
            this.rbDisc.TabStop = true;
            this.rbDisc.Text = "Disc or Folder";
            this.rbDisc.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(157, 356);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(233, 24);
            this.progressBar1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDontDelete);
            this.groupBox1.Controls.Add(this.rbDelete);
            this.groupBox1.Controls.Add(this.lblParent);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(396, 123);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(156, 173);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // rbDontDelete
            // 
            this.rbDontDelete.AutoSize = true;
            this.rbDontDelete.Location = new System.Drawing.Point(56, 125);
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
            this.rbDelete.Location = new System.Drawing.Point(56, 82);
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
            this.lblParent.Location = new System.Drawing.Point(11, 32);
            this.lblParent.Name = "lblParent";
            this.lblParent.Size = new System.Drawing.Size(106, 15);
            this.lblParent.TabIndex = 0;
            this.lblParent.Text = "Delete parent files";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblProgress);
            this.groupBox2.Controls.Add(this.btnStop);
            this.groupBox2.Controls.Add(this.txbPath);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.btnEncrypt);
            this.groupBox2.Controls.Add(this.progressBar1);
            this.groupBox2.Controls.Add(this.btnDecrypt);
            this.groupBox2.Controls.Add(this.rbDisc);
            this.groupBox2.Controls.Add(this.btnChoose);
            this.groupBox2.Controls.Add(this.rbFileOrFolder);
            this.groupBox2.Controls.Add(this.txbPass);
            this.groupBox2.Controls.Add(this.lblPassword);
            this.groupBox2.Location = new System.Drawing.Point(12, 30);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(558, 386);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            // 
            // lblProgress
            // 
            this.lblProgress.AutoSize = true;
            this.lblProgress.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lblProgress.Location = new System.Drawing.Point(200, 28);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(170, 20);
            this.lblProgress.TabIndex = 11;
            this.lblProgress.Text = "Dont working right now";
            // 
            // btnStop
            // 
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(236, 323);
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
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tscbLang});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 27);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tscbLang
            // 
            this.tscbLang.Items.AddRange(new object[] {
            "English",
            "Polish"});
            this.tscbLang.Name = "tscbLang";
            this.tscbLang.Size = new System.Drawing.Size(121, 23);
            this.tscbLang.Text = "Language";
            this.tscbLang.SelectedIndexChanged += new System.EventHandler(this.tscbLang_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 422);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.menuStrip1);
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
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.RadioButton rbFileOrFolder;
        private System.Windows.Forms.RadioButton rbDisc;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDontDelete;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.Label lblParent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.ComponentModel.BackgroundWorker bwEncrypt;
        private System.ComponentModel.BackgroundWorker bwDecrypt;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label lblProgress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripComboBox tscbLang;
    }
}

