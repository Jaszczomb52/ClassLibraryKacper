using System;
using System.Collections.Generic;
using System.IO;
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
            
            features.Add("ls", new ls(new string[] { "ls", "ls -l", "ls -la" }));
            features.Add("cd", new cd(new string[] { "cd"}));
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
            if (!features.ContainsKey(command.Split(' ')[0]))
                Console.WriteLine("brak komendy dla " + command);
            else
            {
                Feature temp;
                ls ls;
                cd cd = (cd)features["cd"];
                features.TryGetValue(command.Split(' ')[0], out temp);
                if (temp is cd)
                {
                    cd.Handler(command);
                }
                else if (temp.help.Contains(command))
                {
                    if (temp is ls)
                    {
                        ls = (ls)temp;
                        ls.Path = cd.Path;
                        ls.Handler(command);
                    }
                }
                else
                    temp.ToString();
            }
        }

    }
}
