using api_encryping.aes;
using api_encryping.jsons;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_encryping.secure
{
    public class SecureFolder
    {
        private string path;

        public string Path { get => path; set => path = value; }

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

        }

        private void StartEncrypting()
        {

        }

        public void GetAccess(string _path)
        {

        }
    }
}
