using api_encryping.aes;
using Encryptor;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        #region FIELDS
        string FilePath = "";
        string Password = "";
        string Confirmed = "";
        List<string> files;
        string working = "Work in progress...";
        string canceled = "Process canceled";
        string completed = "Process completed";
        bool stop = false;
        TranslateText tt;
        AESCrypting aes;
        Langs lang;
        #endregion

        public Form1()
        {
            InitializeComponent();

            #region BW SETTINGS
            bwDecrypt.DoWork += bwDecrypt_DoWork;
            bwDecrypt.ProgressChanged += bwDecrypt_ProgressChanged;
            bwDecrypt.RunWorkerCompleted += bwDecrypt_RunWorkerCompleted;
            bwDecrypt.WorkerReportsProgress = true;
            bwDecrypt.WorkerSupportsCancellation = true;

            bwEncrypt.DoWork += bwEncrypt_DoWork;
            bwEncrypt.ProgressChanged += bwEncrypt_ProgressChanged;
            bwEncrypt.RunWorkerCompleted += bwEncrypt_RunWorkerCompleted;
            bwEncrypt.WorkerReportsProgress = true;
            bwEncrypt.WorkerSupportsCancellation = true;
            #endregion

            rbFile.Checked = true;
            rbDontDelete.Checked = true;
            btnStop.Enabled = false;

            tt = new TranslateText();
            TranslateFromList(tt.TranslateToTable(Langs.lang_eng));
            lang = Langs.lang_eng;

            files = new List<string>();

            txbConfirm.ForeColor = Color.Gray;
            txbPass.ForeColor = Color.Gray;

            aes = new AESCrypting(false);
        }

        #region Encrypt

        #region Controls
        private void txbConfirm_TextChanged(object sender, EventArgs e)
        {
            Confirmed = txbConfirm.Text;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            FilePath = ((string[])e.Data.GetData(DataFormats.FileDrop, false))[0];
            txbPath.Text = FilePath;
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            stop = false;
            AllEnableFalse();
            lblProgress.Text = working;
            bwEncrypt.RunWorkerAsync();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = txbPass.Text;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            progressBar1.Maximum = files.Count;
            stop = false;
            List<string> ls = new List<string>();
            for (int i = 0; i < files.Count; i++)
            {
                FileInfo fi = new FileInfo(files[i]);
                if (fi.Extension == ".tge")
                {
                    ls.Add(files[i]);
                }
            }
            progressBar1.Maximum = ls.Count;
            files = ls;
            AllEnableFalse();
            lblProgress.Text = working;
            bwDecrypt.RunWorkerAsync();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (rbFile.Checked)
            {
                using (OpenFileDialog opf = new OpenFileDialog())
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = opf.FileName;
                        txbPath.Text = opf.FileName;
                    }
                }
                progressBar1.Maximum = 1;
            }
            else if (rbFolder.Checked)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();
                    if (result == DialogResult.OK && !string.IsNullOrEmpty(fbd.SelectedPath))
                    {
                        FilePath = fbd.SelectedPath;
                        txbPath.Text = fbd.SelectedPath;
                    }
                }
            }
            else if (rbDisc.Checked)
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                    {
                        string[] file = Directory.GetFiles(fbd.SelectedPath);
                        string[] dirs = Directory.GetDirectories(fbd.SelectedPath);
                        for (int i = 0; i < dirs.Length; i++)
                        {
                            files.Add(dirs[i]);
                        }
                        foreach (var item in file)
                        {
                            files.Add(item);
                        }
                        txbPath.Text = fbd.SelectedPath;
                    }
                }
                progressBar1.Maximum = files.Count;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stop = true;
            if (bwDecrypt.IsBusy)
            {
                bwDecrypt.CancelAsync();
                AllEnableTrue();
                progressBar1.Value = progressBar1.Maximum;
            }
            if (bwEncrypt.IsBusy)
            {
                bwEncrypt.CancelAsync();
                AllEnableTrue();
                progressBar1.Value = progressBar1.Maximum;
            }
        }

        private void tscbLang_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbLang.SelectedIndex == 1)
            {
                TranslateFromList(tt.TranslateToTable(Langs.lang_pol));
                lang = Langs.lang_pol;
            }
            else if (tscbLang.SelectedIndex == 0)
            {
                TranslateFromList(tt.TranslateToTable(Langs.lang_eng));
                lang = Langs.lang_eng;
            }
        }

        private void txbPass_Enter(object sender, EventArgs e)
        {
            if (txbPass.Text == "Hasło" || txbPass.Text == "Password")
            {
                txbPass.Text = "";
                txbPass.ForeColor = Color.Black;
            }
        }

        private void txbPass_Leave(object sender, EventArgs e)
        {
            if (txbPass.Text.Length == 0)
            {
                TranslateFromList(tt.TranslateToTable(lang));
                txbPass.ForeColor = Color.Gray;
            }
        }

        private void txbConfirm_Enter(object sender, EventArgs e)
        {
            if (txbConfirm.Text == "Potwierdź hasło" || txbConfirm.Text == "Confirm password")
            {
                txbConfirm.Text = "";
                txbConfirm.ForeColor = Color.Black;
            }
        }

        private void txbConfirm_Leave(object sender, EventArgs e)
        {
            if (txbConfirm.Text.Length == 0)
            {
                TranslateFromList(tt.TranslateToTable(lang));
                txbConfirm.ForeColor = Color.Gray;
            }
        }
        #endregion

        #region Background workers
        private void bwDecrypt_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!stop)
            {
                bwDecrypt.ReportProgress(progressBar1.Minimum);
                try
                {
                    if (Password != Confirmed)
                    {
                        stop = true;
                        MessageBox.Show("Passwords doesnt match!!!");
                        return;
                    }

                    int x = 0;
                    if (rbFile.Checked)
                    {
                        string output = FilePath.Substring(0, FilePath.Length - 4);

                        FileInfo fi = new FileInfo(FilePath);
                        if (fi.Extension != ".tge")
                        {
                            return;
                        }

                        aes.FileDecrypt(FilePath, output, Password);//decrypt files
                        try// try unzip
                        {
                            aes.Unziping(output);
                        }
                        catch (Exception ex)
                        {

                        }

                        //delete paretnt files
                        FileAttributes attr = File.GetAttributes(FilePath);
                        if (rbDelete.Checked && !attr.HasFlag(FileAttributes.Directory))
                        {
                            File.Delete(FilePath);
                        }
                        else if (rbDelete.Checked && attr.HasFlag(FileAttributes.Directory))
                        {
                            Directory.Delete(FilePath, true);
                        }
                        bwDecrypt.ReportProgress(progressBar1.Maximum);
                        stop = true;
                    }
                    else if (rbDisc.Checked)
                    {
                        foreach (var item in files)
                        {
                            string output = item.Substring(0, item.Length - 4);

                            FileInfo fi = new FileInfo(item);
                            if (fi.Extension != ".tge")
                            {
                                continue;
                            }

                            aes.FileDecrypt(item, output, Password);
                            try
                            {
                                aes.Unziping(output);
                            }
                            catch (Exception ex)
                            {

                            }

                            FileAttributes attr = File.GetAttributes(item);
                            if (rbDelete.Checked && !attr.HasFlag(FileAttributes.Directory))
                            {
                                File.Delete(item);
                            }
                            else if (rbDelete.Checked && attr.HasFlag(FileAttributes.Directory))
                            {
                                Directory.Delete(item, true);
                            }
                            x++;
                            bwDecrypt.ReportProgress(x);
                            stop = true;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                e.Cancel = true;
                bwDecrypt.CancelAsync();
            }
        }

        private void bwDecrypt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            double precenteg = Math.Round(100.0 / (double)progressBar1.Maximum, 3);
            if (e.ProgressPercentage != 0)
            {
                txbPercent.Text = $"{(precenteg * e.ProgressPercentage)}%";
            }

            if (progressBar1.Value == progressBar1.Maximum)
            {
                bwDecrypt.CancelAsync();
                stop = true;
            }
        }

        private void bwDecrypt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stop = true;
            if (e.Cancelled)
            {
                lblProgress.Text = canceled;
            }
            else if (e.Error != null)
            {
                lblProgress.Text = "Error";
            }
            else
            {
                lblProgress.Text = completed;
            }
            AllEnableTrue();
        }

        private void bwEncrypt_DoWork(object sender, DoWorkEventArgs e)
        {
            if (!stop)
            {
                int x = 0;
                bwEncrypt.ReportProgress(0);
                try
                {
                    if (Password != Confirmed)
                    {
                        stop = true;
                        MessageBox.Show("Passwords doesnt match!!!");
                        return;
                    }

                    if (rbFile.Checked || rbFolder.Checked)
                    {
                        FileAttributes attr = File.GetAttributes(FilePath);
                        if (attr.HasFlag(FileAttributes.Directory))
                        {
                            string zipfile = aes.Ziping(FilePath);
                            aes.FileEncrypt(zipfile, Password, null);
                            File.Delete(zipfile);
                        }
                        else
                        {
                            aes.FileEncrypt(FilePath, Password, null);
                        }

                        //delete paretnt files
                        if (rbDelete.Checked && !attr.HasFlag(FileAttributes.Directory))
                        {
                            File.Delete(FilePath);
                        }
                        else if (rbDelete.Checked && attr.HasFlag(FileAttributes.Directory))
                        {
                            Directory.Delete(FilePath, true);
                        }

                        bwEncrypt.ReportProgress(1);
                        stop = true;
                    }
                    else if (rbDisc.Checked)
                    {

                        foreach (var item in files)
                        {
                            if (this.bwEncrypt.CancellationPending)
                            {
                                e.Cancel = true;
                                return;
                            }

                            FileAttributes attr = File.GetAttributes(item);
                            if (attr.HasFlag(FileAttributes.Directory))
                            {
                                string zipfile = aes.Ziping(item);
                                aes.FileEncrypt(zipfile, Password, null);
                                File.Delete(zipfile);
                            }
                            else
                            {
                                aes.FileEncrypt(item, Password, null);
                            }

                            if (rbDelete.Checked && !attr.HasFlag(FileAttributes.Directory))
                            {
                                File.Delete(item);
                            }
                            else if (rbDelete.Checked && attr.HasFlag(FileAttributes.Directory))
                            {
                                Directory.Delete(item, true);
                            }

                            x++;
                            bwEncrypt.ReportProgress(x);
                        }
                        stop = true;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                e.Cancel = true;
                bwEncrypt.CancelAsync();
            }
        }

        private void bwEncrypt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            double precenteg = Math.Round(100.0 / (double)progressBar1.Maximum, 3);
            if (e.ProgressPercentage != 0)
            {
                txbPercent.Text = $"{(precenteg * e.ProgressPercentage)}%";
            }

            if (progressBar1.Value == progressBar1.Maximum)
            {
                bwEncrypt.CancelAsync();
                stop = true;
            }
        }

        private void bwEncrypt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stop = true;
            if (e.Cancelled)
            {
                lblProgress.Text = canceled;
            }
            else if (e.Error != null)
            {
                lblProgress.Text = "Error";
            }
            else
            {
                lblProgress.Text = completed;
            }
            AllEnableTrue();
        }
        #endregion

        #endregion

        #region Secure

        #endregion

        #region UI
        /// <summary>
        /// get all items enable to false
        /// </summary>
        private void AllEnableFalse()
        {
            rbDelete.Enabled = false;
            rbDisc.Enabled = false;
            rbDontDelete.Enabled = false;
            rbFile.Enabled = false;
            rbFolder.Enabled = false;
            btnChoose.Enabled = false;
            btnDecrypt.Enabled = false;
            btnEncrypt.Enabled = false;
            btnStop.Enabled = true;
            txbPass.Enabled = false;
            txbConfirm.Enabled = false;
        }

        /// <summary>
        /// get all items enable to true
        /// </summary>
        private void AllEnableTrue()
        {
            rbDelete.Enabled = true;
            rbDisc.Enabled = true;
            rbDontDelete.Enabled = true;
            rbFile.Enabled = true;
            rbFolder.Enabled = true;
            btnChoose.Enabled = true;
            btnDecrypt.Enabled = true;
            btnEncrypt.Enabled = true;
            btnStop.Enabled = false;
            txbPass.Enabled = true;
            txbConfirm.Enabled = true;
        }

        /// <summary>
        /// change all controls text to one of language from the list
        /// </summary>
        /// <param name="langTable"></param>
        private void TranslateFromList(string[] langTable)
        {
            btnEncrypt.Text = langTable[0];
            btnDecrypt.Text = langTable[1];
            lblProgress.Text = langTable[2];
            working = langTable[3];
            canceled = langTable[4];
            completed = langTable[5];
            lblParent.Text = langTable[6];
            txbPass.Text = langTable[7];
            rbFile.Text = langTable[8];
            rbDisc.Text = langTable[9];
            rbFolder.Text = langTable[10];
            rbDelete.Text = langTable[12];
            rbDontDelete.Text = langTable[11];
            this.Text = langTable[13];
            tscbLang.Items.Clear();
            tscbLang.Items.Add(langTable[14]);
            tscbLang.Items.Add(langTable[15]);
            tscbLang.Text = langTable[16];
            txbConfirm.Text = langTable[17];
            lblPercent.Text = langTable[18];
        }
        #endregion

        private void btnGetAccess_Click(object sender, EventArgs e)
        {

        }
    }
}