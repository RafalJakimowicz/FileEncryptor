﻿namespace WindowsFormsApp1
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
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbFileOrFolder = new System.Windows.Forms.RadioButton();
            this.rbDisc = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.rbDelete = new System.Windows.Forms.RadioButton();
            this.rbDontDelete = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEncrypt.Location = new System.Drawing.Point(336, 239);
            this.btnEncrypt.Name = "btnEncrypt";
            this.btnEncrypt.Size = new System.Drawing.Size(132, 48);
            this.btnEncrypt.TabIndex = 0;
            this.btnEncrypt.Text = "Encrypt";
            this.btnEncrypt.UseVisualStyleBackColor = true;
            this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
            // 
            // btnDecrypt
            // 
            this.btnDecrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnDecrypt.Location = new System.Drawing.Point(12, 239);
            this.btnDecrypt.Name = "btnDecrypt";
            this.btnDecrypt.Size = new System.Drawing.Size(122, 48);
            this.btnDecrypt.TabIndex = 1;
            this.btnDecrypt.Text = "Decrypt";
            this.btnDecrypt.UseVisualStyleBackColor = true;
            this.btnDecrypt.Click += new System.EventHandler(this.btnDecrypt_Click);
            // 
            // txbPath
            // 
            this.txbPath.Enabled = false;
            this.txbPath.Location = new System.Drawing.Point(9, 13);
            this.txbPath.Name = "txbPath";
            this.txbPath.Size = new System.Drawing.Size(594, 20);
            this.txbPath.TabIndex = 2;
            // 
            // btnChoose
            // 
            this.btnChoose.Location = new System.Drawing.Point(609, 11);
            this.btnChoose.Name = "btnChoose";
            this.btnChoose.Size = new System.Drawing.Size(40, 23);
            this.btnChoose.TabIndex = 3;
            this.btnChoose.Text = "...";
            this.btnChoose.UseVisualStyleBackColor = true;
            this.btnChoose.Click += new System.EventHandler(this.btnChoose_Click);
            // 
            // txbPass
            // 
            this.txbPass.Location = new System.Drawing.Point(114, 173);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(340, 20);
            this.txbPass.TabIndex = 4;
            this.txbPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(27, 173);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Password";
            // 
            // rbFileOrFolder
            // 
            this.rbFileOrFolder.AutoSize = true;
            this.rbFileOrFolder.Location = new System.Drawing.Point(117, 86);
            this.rbFileOrFolder.Name = "rbFileOrFolder";
            this.rbFileOrFolder.Size = new System.Drawing.Size(85, 17);
            this.rbFileOrFolder.TabIndex = 6;
            this.rbFileOrFolder.TabStop = true;
            this.rbFileOrFolder.Text = "File or Folder";
            this.rbFileOrFolder.UseVisualStyleBackColor = true;
            // 
            // rbDisc
            // 
            this.rbDisc.AutoSize = true;
            this.rbDisc.Location = new System.Drawing.Point(326, 86);
            this.rbDisc.Name = "rbDisc";
            this.rbDisc.Size = new System.Drawing.Size(46, 17);
            this.rbDisc.TabIndex = 7;
            this.rbDisc.TabStop = true;
            this.rbDisc.Text = "Disc";
            this.rbDisc.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(140, 239);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(190, 48);
            this.progressBar1.TabIndex = 8;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbDontDelete);
            this.groupBox1.Controls.Add(this.rbDelete);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.groupBox1.Location = new System.Drawing.Point(474, 40);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(172, 247);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(149, 34);
            this.label2.TabIndex = 0;
            this.label2.Text = "Delete uncrypted files \r\n    after encryption";
            // 
            // rbDelete
            // 
            this.rbDelete.AutoSize = true;
            this.rbDelete.Location = new System.Drawing.Point(30, 107);
            this.rbDelete.Name = "rbDelete";
            this.rbDelete.Size = new System.Drawing.Size(50, 21);
            this.rbDelete.TabIndex = 1;
            this.rbDelete.TabStop = true;
            this.rbDelete.Text = "Yes";
            this.rbDelete.UseVisualStyleBackColor = true;
            // 
            // rbDontDelete
            // 
            this.rbDontDelete.AutoSize = true;
            this.rbDontDelete.Location = new System.Drawing.Point(30, 151);
            this.rbDontDelete.Name = "rbDontDelete";
            this.rbDontDelete.Size = new System.Drawing.Size(44, 21);
            this.rbDontDelete.TabIndex = 2;
            this.rbDontDelete.TabStop = true;
            this.rbDontDelete.Text = "No";
            this.rbDontDelete.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 299);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.rbDisc);
            this.Controls.Add(this.rbFileOrFolder);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbPass);
            this.Controls.Add(this.btnChoose);
            this.Controls.Add(this.txbPath);
            this.Controls.Add(this.btnDecrypt);
            this.Controls.Add(this.btnEncrypt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Encryptor";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnEncrypt;
        private System.Windows.Forms.Button btnDecrypt;
        private System.Windows.Forms.TextBox txbPath;
        private System.Windows.Forms.Button btnChoose;
        private System.Windows.Forms.TextBox txbPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rbFileOrFolder;
        private System.Windows.Forms.RadioButton rbDisc;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbDontDelete;
        private System.Windows.Forms.RadioButton rbDelete;
        private System.Windows.Forms.Label label2;
    }
}

