using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryKacper
{
    public class Feature
    {
        public string[] help { get; private set; }
        public Feature(string[] help)
        {
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
