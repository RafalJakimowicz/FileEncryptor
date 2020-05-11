using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using api_encryping.aes;
using api_encryping.jsons;

namespace api_encryping.secure
{
    public class SecureFile
    {
        private FILEPATH paths;
        public FILEPATH Paths { get => paths; set => paths = value; }

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
            foreach (var item in lf)
            {

            }
        }

        public void GetAccess(string _path)
        {
            
        }
    }
}
