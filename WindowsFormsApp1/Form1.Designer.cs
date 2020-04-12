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
            this.btnEncrypt = new System.Windows.Forms.Button();
            this.btnDecrypt = new System.Windows.Forms.Button();
            this.txbPath = new System.Windows.Forms.TextBox();
            this.btnChoose = new System.Windows.Forms.Button();
            this.txbPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.rbFileOrFolder = new System.Windows.Forms.RadioButton();
            this.rbDisc = new System.Windows.Forms.RadioButton();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.numLevels = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numLevels)).BeginInit();
            this.SuspendLayout();
            // 
            // btnEncrypt
            // 
            this.btnEncrypt.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.btnEncrypt.Location = new System.Drawing.Point(517, 245);
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
            this.btnDecrypt.Location = new System.Drawing.Point(9, 245);
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
            this.txbPass.Location = new System.Drawing.Point(187, 176);
            this.txbPass.Name = "txbPass";
            this.txbPass.Size = new System.Drawing.Size(340, 20);
            this.txbPass.TabIndex = 4;
            this.txbPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(100, 176);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Password";
            // 
            // rbFileOrFolder
            // 
            this.rbFileOrFolder.AutoSize = true;
            this.rbFileOrFolder.Location = new System.Drawing.Point(212, 104);
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
            this.rbDisc.Location = new System.Drawing.Point(421, 104);
            this.rbDisc.Name = "rbDisc";
            this.rbDisc.Size = new System.Drawing.Size(46, 17);
            this.rbDisc.TabIndex = 7;
            this.rbDisc.TabStop = true;
            this.rbDisc.Text = "Disc";
            this.rbDisc.UseVisualStyleBackColor = true;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(137, 245);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(374, 48);
            this.progressBar1.TabIndex = 8;
            // 
            // numLevels
            // 
            this.numLevels.Location = new System.Drawing.Point(299, 212);
            this.numLevels.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numLevels.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevels.Name = "numLevels";
            this.numLevels.Size = new System.Drawing.Size(91, 20);
            this.numLevels.TabIndex = 9;
            this.numLevels.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numLevels.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 299);
            this.Controls.Add(this.numLevels);
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
            this.Text = "Form1";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.numLevels)).EndInit();
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
        private System.Windows.Forms.NumericUpDown numLevels;
    }
}

