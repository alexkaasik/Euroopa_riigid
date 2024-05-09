using System;
using System.IO;

namespace Euroopa_riigid {
    class Program {
        public static void Main() {
            string readText = File.ReadAllText("riigid_pealinnd.txt");
            //Console.WriteLine(readText);

            Dictionary<string, string> riik_pealinn = new Dictionary<string, string>();

            foreach (string name in readText.Split("\n")){
                string[] Euroopa = new string[2];
                Euroopa = name.Replace("-ja-", "_ja_").Split("-");              
                riik_pealinn[Euroopa[0]] = Euroopa[1].Remove(Euroopa[1].Length-1);
            }

            bool ProgramOnner = true;
            char mode = 'm';
            string test;

            Functions.Help();
            while ( ProgramOnner ) {
                Console.Write( "switch(config)#" );
                test = Console.ReadLine();
                
                if ( test == "" ){ test = " "; }
                mode = Convert.ToChar(test[0]);
                switch (mode) {
                    case 'h': Functions.Help();break;
                    case 'f': Functions.Find(riik_pealinn); break;
                    case 's': Functions.Show(riik_pealinn); break;
                    case 'e': Functions.Edit(riik_pealinn); break;
                    case 'g': Functions.Game(riik_pealinn); break;
                    case 'q': ProgramOnner = false; break;                 
                    case 'c': Functions.Save(riik_pealinn); break;
                    default: Console.WriteLine("Error"); break;
                };
            }
        }
    }
}