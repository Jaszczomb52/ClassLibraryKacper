using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public partial class Feature
    {
        public string Path { get; set; }
        public string[] help { get; private set; }
        public Feature(string[] help)
        {
            Path = Directory.GetCurrentDirectory();
            this.help = help;
        }

        public void GetHelp()
        {
            foreach (string line in help)
            {
                Console.WriteLine(line);
            }
        }

        public override string ToString()
        {
            GetHelp();
            return "";
        }
    }
}
