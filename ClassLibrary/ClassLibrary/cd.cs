using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    class cd : Feature
    {
        public cd(string[] help) : base(help)
        {
            
        }

        public void Handler(string command)
        {
            ChangePath(command.Substring(2).Trim());
            Console.Write("jesteś tutaj -> " + Path);
        }

        private void ChangePath(string path)
        {
            if (path == "..")
                Path = Directory.GetParent(Path).ToString();
            else
            {
                try
                {
                    string[] arr = Directory.GetDirectories(Path);
                    bool changed = false;
                    foreach (string dir in arr)
                    {
                        if (Path + "\\" + path == dir)
                        {
                            Path = dir;
                            changed = true;
                        }

                    }
                    if (!changed)
                    {
                        try
                        {
                            if(Directory.Exists(path))
                            Path = path;
                        }
                        catch (Exception)
                        {
                            Console.WriteLine("zła ścieżka");
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("błąd przy pobieraniu ścieżki");
                }
            }
        }
    }
}
