using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace api_encryping.secure
{
    public class SecureFile
    {
        private string path;
        public string Path { get => path; set => path = value; }
        public SecureFile()
        {
            if (Directory.Exists("./Secured"))
            {
                Directory.CreateDirectory("./Secured");
            }
        }
        public void AddToSecure(string _path)
        {
            Path = _path;
        }
    }
}
