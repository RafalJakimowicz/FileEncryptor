using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using api_encryping.aes;
using api_encryping.secure.password;

namespace api_encryping.secure
{
    public class SecureFile
    {
        private string path;

        public string Path { get => path; set => path = value; }

        private static string FOLDER = "./cache/secured";
        AESCrypting a;
        public SecureFile()
        {
            a = new AESCrypting(true);
            if (Directory.Exists(FOLDER))
            {
                Directory.CreateDirectory(FOLDER);
            }
        }

        public void AddToSecure(string _path)
        {
            Path = _path;
            FileInfo fi = new FileInfo(path);
            try
            {
                a.FileEncrypt(path, GetPassword.getPass(), FOLDER + fi.Name);
                File.Delete(path);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }

        public void GetAccess(string _path)
        {
            Path = _path;
            FileInfo fi = new FileInfo(path);
            try
            {
                a.FileDecrypt(FOLDER + fi.Name, GetPassword.getPass(), path);
                File.Delete(path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }  
        }
    }
}
