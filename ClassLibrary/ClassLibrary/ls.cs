using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryKacper;

namespace ClassLibraryKacper
{
    class ls : Feature
    {
        public ls(string[] help):base(help)
        {

        }

        public void Handler(string command)
        {
            if (command == "ls")
                ShowFiles();
            else if (command == "ls -l")
                ShowFilesL();
            else if (command == "ls -la")
                ShowFilesLa();
            Console.Write("jesteś tutaj -> " + Path);
        }

        private void ShowFiles()
        {
            string[] files = Directory.GetFiles(Path);
            foreach (string file in files)
                if (!File.GetAttributes(file).HasFlag(FileAttributes.Hidden))
                    Console.Write(file.Substring(Path.Length+1) + "   ");
            Console.WriteLine("\n");
        }

        private void ShowFilesL()
        {
            string[] files = Directory.GetFiles(Path);
            foreach (string file in files)
            { 
                string output = file.Substring(Path.Length + 1);
                output += File.GetAccessControl(file);
                Console.WriteLine(output);
            }
        }
        
        private void ShowFilesLa()
        {
            string[] files = Directory.GetFiles(Path);
            foreach (string file in files)
                Console.WriteLine(file.Substring(Path.Length + 1));
            files = Directory.GetDirectories(Path);
            foreach (string dir in files)
                Console.WriteLine(dir.Substring(Path.Length + 1));
        }
    }
}
