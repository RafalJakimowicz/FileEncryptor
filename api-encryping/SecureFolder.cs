using api_encryping.aes;
using api_encryping.secure.password;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace api_encryping.secure
{
    public class SecureFolder
    {
        private string path;

        public string Path { get => path; set => path = value; }

        private static string FOLDER = "./cache/secured";
        AESCrypting a;
        public SecureFolder()
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
            a.Ziping(_path);
            FileInfo fi = new FileInfo(_path);
            try
            {
                a.FileEncrypt(_path, GetPassword.getPass(), FOLDER + fi.Name);
                File.Delete(_path);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public void GetAccess(string _path)
        {
            
        }
    }
}
