using System;
using System.IO;

namespace Euroopa_riigid {
    class Program
    {
        public static void Main() {

            string readText = File.ReadAllText("C:\\Users\\opilane\\Source\\Repos\\Aleksander_Kaasik\\C# test\\Euroopa_riigid\\riigid_pealinnd.txt");
            //Console.WriteLine(readText);

            Dictionary<string, string> riik_pealinn = new Dictionary<string, string>();

            foreach (string name in readText.Split("\n")){
                string[] Euroopa = new string[2];
                Euroopa = name.Replace("-ja-", "_ja_").Split("-");              
                riik_pealinn[Euroopa[0]] = Euroopa[1];
            }

            Console.WriteLine( readText.Replace("-ja-", "-ja-").Split("-")[0] );

            bool ProgramOnner = true;
            Functions.Help();
            while ( ProgramOnner ) 
            {
                string mode = Console.ReadLine();
                if (mode == "" ){ mode = " "; }
                switch (mode[0])
                {
                    case 'q': ProgramOnner = false; break;
                    case 'h': Functions.Help();break;
                    case 's': Functions.Show(riik_pealinn); break;
                    default: Console.WriteLine("Error"); break;
                };
            }
        }
    }
}