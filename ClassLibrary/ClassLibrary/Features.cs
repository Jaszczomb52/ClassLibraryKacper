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
            features.Add("ls", new ls(new string[] { "ls - wyswietlenie plikow", "ls -l - nie dziala", "ls -la - wyswietlenie" +
                "wszystkich plikow, w tym ukrytych, oraz folderow" }));
            features.Add("cd", new cd(new string[] { "cd - przemieszczanie sie po sciezkach. napisz 'cd ..' aby wyjsc" +
                "z aktualnej sciezki, lub 'cd [folder]' aby wejsc do folderu."}));
            features.Add("md5sum", new md5sum(new string[] { "md5sum - wyliczenie sumy kontrolnej pliku z aktualnego folderu." +
                " Skladnia 'md5sum [file]'"}));
            features.Add("sha256sum", new sha256sum(new string[] { "sha256sum - wyliczenie sumy kontrolnej pliku" +
                "z aktualnego folderu. Skladnia 'sha256sum [file]'"}));
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
            string[] temp = new string[4];
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
                md5sum md5sum = (md5sum)features["md5sum"];
                sha256sum sha = (sha256sum)features["sha256sum"];
                features.TryGetValue(command.Split(' ')[0], out temp);
                if (temp is cd)
                {
                    cd.Handler(command);
                }
                else if (temp is ls)
                {
                    ls = (ls)temp;
                    ls.Path = cd.Path;
                    ls.Handler(command);
                }
                else if(temp is md5sum)
                {
                    md5sum.Path = cd.Path;
                    md5sum.Handler(command);
                }
                else if(temp is sha256sum)
                {
                    sha.Path = cd.Path;
                    sha.Handler(command);
                }
                else
                    temp.ToString();
            }
        }

    }
}
