using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace ClassLibraryKacper
{
    class md5sum : Feature
    {
        public md5sum(string[] help) : base(help)
        {

        }

        public void Handler(string command)
        {
            string file = command.Substring(6).Trim();
            CalculateSum(Path + "\\" + file);
        }

        private void CalculateSum(string path)
        {
            using (MD5 md5 = MD5.Create())
            {
                try
                {
                    using (Stream s = File.OpenRead(path))
                    {
                        foreach (byte bajt in md5.ComputeHash(s))
                        {
                            Console.Write(String.Format("{0:x2}", bajt));
                        }
                    }
                }
                catch(Exception)
                {
                    Console.WriteLine("bledna sciezka pliku");
                }
            }
        }
    }
}