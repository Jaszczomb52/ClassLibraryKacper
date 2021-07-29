using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibraryKacper;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Features feat = new Features();
            string temp = Console.ReadLine();
            if (temp == "help")
                feat.GetHelp();
            else if (temp.Trim() == "help ls")
                feat.GetFeatureHelp(temp);
            Console.ReadKey();
        }
    }
}
