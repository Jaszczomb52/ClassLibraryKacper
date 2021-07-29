using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryKacper
{
    public class Features
    {
        static Dictionary<string, Feature> features = new Dictionary<string, Feature>();
        public Features()
        {
            features.Add("ls", new Feature(new string[] { "ls", "ls -l", "ls -la" }));
        }
        
        public void GetFeatureHelp(string command)
        {
            if (features.ContainsKey(command))
                Console.WriteLine(features[command]);
            else
                Console.WriteLine("Brak komendy");
        }

        public void GetHelp()
        {
            string[] temp = new string[1];
            features.Keys.CopyTo(temp,0);
            foreach(string key in temp)
                Console.WriteLine(key);
        }

        public void CommandHandler(string command)
        {
            Console.WriteLine("brak komendy dla " + command);
        }

    }
}
