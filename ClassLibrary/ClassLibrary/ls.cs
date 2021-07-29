using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryKacper;

namespace ClassLibraryKacper
{
    class ls : Feature, IFeature
    {
        public ls(string[] help):base(help)
        {

        }

        public void Handler(string command)
        {
            if (command == "ls")
                ShowFiles();
        }

        private void ShowFiles()
        {
            string[] files = Directory.GetFiles(Directory.GetCurrentDirectory());
            foreach (string file in files)
                Console.WriteLine(file.Substring(Directory.GetCurrentDirectory().Length+1));
        }

        
    }
}
