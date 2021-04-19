using api_encryping.aes;
using api_encryping.jsons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace api_encryping.secure
{
    public class SecureFolder
    {
        private FILEPATH paths;
        private string password;

        private static string FOLDER = "./cache/secured";
        AESCrypting a;
        JsonsToPaths jtp;
        public SecureFolder()
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
                        MessageBox.Show("That folder is already secured");
                        return;
                    }
                }
            }
            else
            {
                lf = new List<FILEPATH>();
            }
            a.Ziping(_path);
            string pathToZip = _path + ".zip";
            byte[] fileBytes = File.ReadAllBytes(pathToZip);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashBytes = sha.ComputeHash(fileBytes);
            var FileName = new StringBuilder();
            foreach (byte b in hashBytes)
            {
                FileName.Append(b.ToString("x2"));
            }
            string newFileFullPath = FOLDER +"/"+ FileName.ToString() + ".zip.tge";
            paths = new FILEPATH() { NewFile = newFileFullPath, PrevFile = pathToZip };
            password = FileName.ToString();
            lf.Add(paths);
            jtp.Serialize(lf);
            Thread t = new Thread(StartEncrypting);
            t.Start();
        }

        private void StartEncrypting()
        {
            a.FileEncrypt(paths.PrevFile, password, paths.NewFile);
            File.Delete(paths.PrevFile);
        }

        public void GetAccess(string _path)
        {
            List<FILEPATH> lf = jtp.Deserialize();
            foreach (var item in lf)
            {
                if(_path == item.PrevFile)
                {
                    paths = item;
                    FileInfo fi = new FileInfo(item.NewFile);
                    password = Path.GetFileNameWithoutExtension(fi.Name);
                    Thread t = new Thread(StartDecrypting);
                    t.Start();
                }
            }
        }

        private void StartDecrypting()
        {
            a.FileDecrypt(paths.NewFile, paths.PrevFile, password);
            a.Unziping(paths.PrevFile);
            File.Delete(paths.PrevFile);
        }
    }
}
