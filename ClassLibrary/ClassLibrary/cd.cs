using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryKacper
{
    class cd : Feature
    {
        public cd(string[] help) : base(help)
        {
            
        }

        public void Handler(string command)
        {
            ChangePath(command.Substring(2).Trim());
            Console.Write(Path);
        }

        private void ChangePath(string path)
        {
            if (path == "..")
                Path = Directory.GetParent(Path).ToString();
            else
            {
                string[] arr = Directory.GetDirectories(Path);
                foreach (string dir in arr)
                    if (Path + "\\" + path == dir)
                      Path = dir;
                    //Console.WriteLine(dir + "\n" + Path + "\\" + path);
            }
        }
    }
}
