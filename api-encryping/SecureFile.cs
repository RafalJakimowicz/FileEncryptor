using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_encryping.aes;

namespace api_encryping.secure
{
    public class SecureFile
    {
        private string path;

        public string Path { get => path; set => path = value; }

        private static string FOLDER = "./cache/secured";

        public SecureFile()
        {
            if (Directory.Exists(FOLDER))
            {
                Directory.CreateDirectory(FOLDER);
            }
        }

        public void AddToSecure(string _path)
        {
            Path = _path;
        }
    }
}
