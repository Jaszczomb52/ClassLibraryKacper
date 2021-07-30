using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClassLibrary;

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
            Console.WriteLine();
            string temp = Console.ReadLine();
            if (temp.Trim() == "help")
                feat.GetHelp();
            else if (temp.Trim() != "help" && temp != null && temp.Trim() != "")
                if (temp.Split(' ')[0] == "help")
                    feat.GetFeatureHelp(temp.Split(' ')[1]);
                else
                    feat.CommandHandler(temp);
            else
                Console.WriteLine("");
        }
    }
}
