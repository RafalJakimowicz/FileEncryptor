﻿using api_encryping.aes;
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
            List<FILEPATH> lf = jtp.Deserialize();
            foreach (var item in lf)
            {
                if(item.PrevFile == _path)
                {
                    MessageBox.Show("That folder is already secured");
                    return;
                }
            }
            a.Ziping(_path);
            string pathToZip = _path + ".zip";
            byte[] fileBytes = File.ReadAllBytes(pathToZip);
            SHA1 sha = new SHA1CryptoServiceProvider();
            byte[] hashBytes = sha.ComputeHash(fileBytes);
            string name = BitConverter.ToString(hashBytes);
            string newFileFullPath = FOLDER +"/"+ name + ".zip";
            paths = new FILEPATH() { NewFile = pathToZip, PrevFile = _path };
            password = name;
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

                }
            }
        }

        private void StartDecrypting()
        {
            
        }
    }
}
