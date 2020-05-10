using Ionic.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace api_encryping.aes
{
    public class AESCrypting
    {
        const string SALT = "*sHa256";
        const string ZIPPASSWORD = "aEs_EnCrYpToR";
        bool toSecure;
        public AESCrypting(bool _toSecure)
        {
            toSecure = _toSecure;
        }

        #region Crypting AES
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
        public void FileEncrypt(string inputFile, string password, string outputFile)
        {
            //generate random salt
            byte[] salt = GenerateRandomSalt();

            FileStream fsCrypt;
            if (!toSecure)
            {
                //create output file name
                fsCrypt = new FileStream(inputFile + ".tge", FileMode.Create);
            }
            else
            {
                fsCrypt = new FileStream(outputFile + ".tge", FileMode.Create);
            }

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
        public void FileDecrypt(string inputFile, string outputFile, string password)
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
            using (MD5 sha = MD5.Create())
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

        /// <summary>
        /// compress directories to zip file 
        /// </summary>
        /// <param name="path"></param>
        /// <returns>path to zip file</returns>
        public string Ziping(string path)
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
        public void Unziping(string path)
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
        #endregion
    }
}
