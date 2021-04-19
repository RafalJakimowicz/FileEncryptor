using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using api_encryping.aes;
using api_encryping.jsons;

namespace api_encryping.secure
{
    public class SecureFile
    {
        private FILEPATH paths;
        public FILEPATH Paths { get => paths; set => paths = value; }
        private string password;

        JsonsToPaths jtp;
        private static string FOLDER = "./cache/secured";
        AESCrypting a;
        public SecureFile()
        {
            jtp = new JsonsToPaths();
            a = new AESCrypting(true);
            if (Directory.Exists(FOLDER))
            {
                Directory.CreateDirectory(FOLDER);
            }
        }

        public void AddToSecure(string _path)
        {
            List<FILEPATH> lf = jtp.Deserialize();
            if(!(lf == null)) 
            {
                foreach (var item in lf)
                {
                    if (item.PrevFile == _path)
                    {
                        MessageBox.Show("That file is already secured");
                        return;
                    }
                }
            }
            else
            {
                lf = new List<FILEPATH>();
            }
            byte[] fileBytes = File.ReadAllBytes(_path);
            SHA1 hash = new SHA1CryptoServiceProvider();
            byte[] hashBytes = hash.ComputeHash(fileBytes);
            var FileName = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                FileName.Append(b.ToString("x2"));
            }
            FileInfo fi = new FileInfo(_path);
            string newFileFullPath = FOLDER + "/" + FileName.ToString() + fi.Extension + ".tge";
            FILEPATH fp = new FILEPATH() { NewFile = newFileFullPath, PrevFile = _path };
            lf.Add(fp);
            Paths = fp;
            password = FileName.ToString();
            jtp.Serialize(lf);
            Thread t = new Thread(StartEncrypting);
            t.Start();
        }

        private void StartEncrypting()
        {
            a.FileEncrypt(Paths.PrevFile, password, Paths.NewFile);
        }

        public void GetAccess(string _path)
        {
            List<FILEPATH> lf = jtp.Deserialize();
            foreach (var item in lf)
            {
                if (item.PrevFile == _path)
                {
                    Paths = item;
                    FileInfo fi = new FileInfo(Paths.NewFile);
                    string pass = Path.GetFileNameWithoutExtension(fi.Name);
                    password = pass;
                    Thread t = new Thread(StartDecrypting);
                    t.Start();
                }
            }
        }

        private void StartDecrypting()
        {
            a.FileDecrypt(Paths.NewFile, Paths.PrevFile, password);
        }
    }
}
