using Ionic.Zip;
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
        string FilePath = "";
        string Password = "";
        List<string> files = new List<string>();
        const string SALT = "*sHa256";
        const string ZIPPASSWORD = "aEs_EnCrYpToR";
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

            rbFileOrFolder.Checked = true;
            rbDontDelete.Checked = true;
            btnStop.Enabled = false;
        }

        //  Call this function to remove the key from memory after use for security
        [DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);

        /// <summary>
        /// Creates a random salt that will be used to encrypt your file. This method is required on FileEncrypt.
        /// </summary>
        /// <returns></returns>
        public static byte[] GenerateRandomSalt()
        {
            byte[] data = new byte[32];

            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                for (int i = 0; i < 10; i++)
                {
                    // Fille the buffer with the generated data
                    rng.GetBytes(data);
                }
            }

            return data;
        }

        /// <summary>
        /// Encrypts a file from its path and a plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="password"></param>
        private void FileEncrypt(string inputFile, string password)
        {
            //generate random salt
            byte[] salt = GenerateRandomSalt();

            //create output file name
            FileStream fsCrypt = new FileStream(inputFile + ".mvp", FileMode.Create);

            //convert password string to byte arrray
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(GeneratePassword(password));

            //Set Rijndael symmetric encryption algorithm
            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.PKCS7
            };


            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);


            AES.Mode = CipherMode.CFB;

            // write salt to the begining of the output file, so in this case can be random every time
            fsCrypt.Write(salt, 0, salt.Length);

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateEncryptor(), CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            //create a buffer (500mb) so only this amount will allocate in the memory and not the whole file
            byte[] buffer = new byte[536870912];
            int read;
            try
            {
                while ((read = fsIn.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents(); // -> for responsive GUI, using Task will be better!
                    cs.Write(buffer, 0, read);
                }

                // Close up
                fsIn.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                cs.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// Decrypts an encrypted file with the FileEncrypt method through its path and the plain password.
        /// </summary>
        /// <param name="inputFile"></param>
        /// <param name="outputFile"></param>
        /// <param name="password"></param>
        private void FileDecrypt(string inputFile, string outputFile, string password)
        {
            byte[] passwordBytes = System.Text.Encoding.UTF8.GetBytes(GeneratePassword(password));
            byte[] salt = new byte[32];

            FileStream fsCrypt = new FileStream(inputFile, FileMode.Open);
            fsCrypt.Read(salt, 0, salt.Length);

            RijndaelManaged AES = new RijndaelManaged
            {
                KeySize = 256,
                BlockSize = 128,
                Padding = PaddingMode.PKCS7,
                Mode = CipherMode.CFB
            };
            var key = new Rfc2898DeriveBytes(passwordBytes, salt, 50000);
            AES.Key = key.GetBytes(AES.KeySize / 8);
            AES.IV = key.GetBytes(AES.BlockSize / 8);
            

            CryptoStream cs = new CryptoStream(fsCrypt, AES.CreateDecryptor(), CryptoStreamMode.Read);

            FileStream fsOut = new FileStream(outputFile, FileMode.Create);

            int read;
            //500mb buffer
            byte[] buffer = new byte[536870912];
            try
            {
                while ((read = cs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    Application.DoEvents();
                    fsOut.Write(buffer, 0, read);
                }
            }
            catch (CryptographicException ex_CryptographicException)
            {
                Console.WriteLine("CryptographicException error: " + ex_CryptographicException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }

            try
            {
                cs.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error by closing CryptoStream: " + ex.Message);
            }
            finally
            {
                fsOut.Close();
                fsCrypt.Close();
            }
        }

        /// <summary>
        /// hashing password with salt
        /// </summary>
        /// <param name="raw"></param>
        /// <returns>password hash</returns>
        private string GeneratePassword(string raw)
        {
            using (SHA512 sha = SHA512.Create())
            {
                byte[] bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(raw + SALT));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
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

        /// <summary>
        /// compress directories to zip file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>path to zip file</returns>
        private string Ziping(string path)
        {
            using (ZipFile zip = new ZipFile())
            {
                zip.AddDirectory(path, "Files");
                zip.CompressionLevel = Ionic.Zlib.CompressionLevel.Level6;
                zip.Password = ZIPPASSWORD;
                zip.Save(path + ".zip");
                return path + ".zip";
            }
        }

        /// <summary>
        /// unzip zip file to directory and delete it
        /// </summary>
        /// <param name="path"></param>
        private void Unziping(string path)
        {
            if (new FileInfo(path).Extension == ".zip")
            {
                using (ZipFile zip = ZipFile.Read(path))
                {
                    string output = path.Substring(0, path.Length - 4);
                    Directory.CreateDirectory(output);
                    zip.Password = ZIPPASSWORD;
                    foreach (ZipEntry item in zip)
                    {
                        item.Extract(output, ExtractExistingFileAction.InvokeExtractProgressEvent);
                    }
                }
                File.Delete(path);
            }
        }

        private void btnEncrypt_Click(object sender, EventArgs e)
        {
            lblProgress.Text = "Working...";
            btnStop.Enabled = true;
            bwEncrypt.RunWorkerAsync();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Password = txbPass.Text;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            lblProgress.Text = "Working...";
            btnStop.Enabled = true;
            bwDecrypt.RunWorkerAsync();
        }

        private void btnChoose_Click(object sender, EventArgs e)
        {
            if (rbFileOrFolder.Checked)
            {
                using (OpenFileDialog opf = new OpenFileDialog())
                {
                    if (opf.ShowDialog() == DialogResult.OK)
                    {
                        FilePath = opf.FileName;
                    }
                }
                progressBar1.Maximum = 1;
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

        private void bwDecrypt_DoWork(object sender, DoWorkEventArgs e)
        {
            bwDecrypt.ReportProgress(0);
            try
            {
                int x = 0;
                if (rbFileOrFolder.Checked)
                {
                    string output = FilePath.Substring(0, FilePath.Length - 4);
                    FileDecrypt(FilePath, output, Password);//decrypt files
                    try// try unzip
                    {
                        Unziping(output);
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
                    bwDecrypt.ReportProgress(1);
                }
                else if (rbDisc.Checked)
                {
                    foreach (var item in files)
                    {
                        if (this.bwDecrypt.CancellationPending)
                        {
                            e.Cancel = true;
                            return;
                        }

                        string output = item.Substring(0, item.Length - 4);
                        FileDecrypt(item, output, Password);
                        try
                        {
                            Unziping(output);
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
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bwDecrypt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if(progressBar1.Value == progressBar1.Maximum)
            {
                bwDecrypt.CancelAsync();
            }
        }

        private void bwDecrypt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblProgress.Text = "Canceled";
            }
            else if (e.Error != null)
            {
                lblProgress.Text = "Error";
            }
            else
            {
                lblProgress.Text = "Completed";
            }
        }

        private void bwEncrypt_DoWork(object sender, DoWorkEventArgs e)
        {
            int x = 0;
            bwEncrypt.ReportProgress(0);
            try
            {
                if (rbFileOrFolder.Checked)
                {
                    
                    FileAttributes attr = File.GetAttributes(FilePath);
                    if (attr.HasFlag(FileAttributes.Directory))
                    {
                        string zipfile = Ziping(FilePath);
                        FileEncrypt(zipfile, Password);
                        File.Delete(zipfile);
                        Directory.Delete(FilePath, true);
                    }
                    else
                    {
                        FileEncrypt(FilePath, Password);
                        File.Delete(FilePath);
                    }

                    bwEncrypt.ReportProgress(1);
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
                            string zipfile = Ziping(item);
                            FileEncrypt(zipfile, Password);
                            File.Delete(zipfile);
                            Directory.Delete(item, true);
                        }
                        else
                        {
                            FileEncrypt(item, Password);
                            File.Delete(item);
                        }
                        x++;
                        bwEncrypt.ReportProgress(x);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void bwEncrypt_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            if (progressBar1.Value == progressBar1.Maximum)
            {
                bwEncrypt.CancelAsync();
            }
        }

        private void bwEncrypt_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                lblProgress.Text = "Canceled";
            }
            else if (e.Error != null)
            {
                lblProgress.Text = "Error";
            }
            else
            {
                lblProgress.Text = "Completed";
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (bwDecrypt.IsBusy)
            {
                bwDecrypt.CancelAsync();
                btnStop.Enabled = false;
                progressBar1.Value = progressBar1.Maximum;
            }
            if (bwEncrypt.IsBusy)
            {
                bwEncrypt.CancelAsync();
                btnStop.Enabled = false;
                progressBar1.Value = progressBar1.Maximum;
            }
        }
    }
}
