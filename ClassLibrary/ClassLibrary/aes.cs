using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ClassLibrary
{
    class aes : Feature
    {
        public aes(string[] help) : base(help)
        {

        }

        public void Handler(string command)
        {
            string file = command.Substring(9).Trim();
            Encrypt(Path + "\\" + file,new byte[] { 0},new byte[] { 0});
        }

        private void Encrypt(string path, byte[] key, byte[] IV)
        {
            Random rand = new Random();
            try
            {
                byte[] encrypted;
                using (Stream s = File.OpenRead(path))
                {
                    AesManaged aes = new AesManaged();
                    aes.Mode = CipherMode.CBC;
                    aes.IV = IV;
                    aes.Key = key;
                    aes.Padding = PaddingMode.None;

                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    {
                        using (MemoryStream msEncrypt = new MemoryStream())
                        {
                            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt,encryptor,CryptoStreamMode.Write))
                            {
                                using(StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                                {
                                    swEncrypt.WriteLine(File.ReadAllText(path));
                                }
                                encrypted = msEncrypt.ToArray();
                            }
                        }
                    }
                }
                string result = "";
                foreach (byte bajt in encrypted)
                    result += String.Format("{0:x2}", bajt);
                File.WriteAllText(path.Substring(0, path.Length - 4) + "Encrypted" + ".txt",result);
            }
            catch (Exception)
            {
                Console.WriteLine("bledna sciezka pliku");
            }
        }
        
    }
}
