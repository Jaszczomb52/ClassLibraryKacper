using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ClassLibrary
{
    class sha256sum : Feature
    {

        public sha256sum(string[] help) : base(help)
        {

        }

        public void Handler(string command)
        {
            string file = command.Substring(9).Trim();
            CalculateSum(Path + "\\" + file);
        }

        private void CalculateSum(string path)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                try
                {
                    using (Stream s = File.OpenRead(path))
                    {
                        foreach (byte bajt in sha256.ComputeHash(s))
                        {
                            Console.Write(String.Format("{0:x2}", bajt));
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("bledna sciezka pliku");
                }
            }
        }
    }
}
