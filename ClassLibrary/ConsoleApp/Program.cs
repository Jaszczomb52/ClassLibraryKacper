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
            while(true)
            {
                Start(feat);
            }
        }

        private static void Start(Features feat)
        {
            string temp = Console.ReadLine();
            if (temp == "help")
                feat.GetHelp();
            else if (temp.Trim() != "help" && temp != null && temp.Trim() != "")
                if(temp.Split(' ')[1] != null)
                    feat.GetFeatureHelp(temp.Split(' ')[1]);
            else
                Console.WriteLine("");
            Console.ReadKey();
        }
    }
}
