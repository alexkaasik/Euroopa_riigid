using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace Euroopa_riigid {
    class Functions {

        public static bool Contain( string sona, List<string> item ) {
            foreach ( string value in item) {
                if ( sona == value ) {
                    return true;
                }
            }
            return false;
        }

        public static bool IsNumber(string number)
        {
            foreach (char c in number)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public static void Help() {
            Console.WriteLine("h = Help");
            Console.WriteLine("f = Find");
            Console.WriteLine("s = Show");
            Console.WriteLine("e = Edit");
            Console.WriteLine("g = Game");
            Console.WriteLine("q = Quit");
            Console.WriteLine("c = save");
        }

        public static void Show(Dictionary<string, string> item) {
            int line = 1;
            foreach (var value in item) {
                Console.WriteLine(line+": "+value.Key + ":" + value.Value);
                line++;
            }
        }

        public static void Find(Dictionary<string, string> item) {

            int index=0;
            string sona = "";
            string sona2="";
            do {
                Console.Write("Enter a word:");
                sona = Console.ReadLine().ToLower();
            } while (sona == "");

            sona = char.ToUpper(sona[0]) + sona.Substring(1);
            if ( Contain(sona, item.Keys.ToList() ) ) {
                index = item.Keys.ToList().IndexOf(sona);
                sona2 = item.Values.ToList()[index];
                Console.WriteLine("riik -> pealinn");
            }
            else if ( Contain(sona, item.Values.ToList() ) ) {
                index = item.Values.ToList().IndexOf(sona);
                sona2 = item.Keys.ToList()[index];
                Console.WriteLine("pealinn -> riik");
            } 
            else {  
                // To add code
                Console.WriteLine("Do you want add this country or city?");
                char option = Console.ReadLine().ToLower()[0];
                if (option == 'y'){
                    Add(item, sona);
                    option = 'n';
                }
            }

            Console.WriteLine(char.ToUpper(sona[0] )+ sona.Substring(1) + " -> "  + sona2);
        }
        public static void Add(Dictionary<string, string> riik_pealinn, string sona) {
            char option;
            char IsThisRight;
            string riik="";
            string pealinn="";

            do {
                Console.Write("R/L: ");
                option = Console.ReadLine().ToLower()[0];
            } while ( option != 'r' && option != 'l' );
            
            do {
                if ( option == 'l' ) {
                    pealinn = sona;
                    Console.Write("Riik nimi: ");
                    riik = Console.ReadLine().ToLower();
                }

                if ( option == 'r' ) {
                    riik = sona;
                    Console.Write("Pealinn nimi: ");
                    pealinn = Console.ReadLine().ToLower();
                }
                
                Console.Write("Do you want add trhis word?:");
                IsThisRight = Console.ReadLine().ToLower()[0];
                if ( IsThisRight == 'y' ) {
                    riik_pealinn[riik] = pealinn;
                    Console.WriteLine("no");
                }
            }
            while ( IsThisRight != 'y' && IsThisRight != 'q');
            Console.WriteLine("no");
        }

        public static void Save(Dictionary<string, string> riik_pealinn) {
            int ListMax = riik_pealinn.Keys.ToList().Count;
            File.WriteAllText("riigid_pealinnd.txt", "");
            for (int i = 0; i < ListMax; i++) {
                string Name = riik_pealinn.Keys.ToList()[i]+"-"+riik_pealinn.Keys.ToList()[i];
                File.AppendAllText("riigid_pealinnd.txt", Name+"\n");
            }    
        }
        public static void Game(Dictionary<string, string> riik_pealinn) {
            int win = 0;
            int MaxList = riik_pealinn.Keys.Count;
            string HMR = "";
            string randName;
            int randMax;
            
            do {
                Console.Write("How many round will you play?: ");
                HMR = Console.ReadLine();
            } while ( !IsNumber(HMR) );

            Random rand = new Random();

            for (int i = 0; i < int.Parse(HMR); i++) {
                randMax = rand.Next(MaxList);
                if (rand.Next(0, 1) == 0) {
                    Console.WriteLine("Riik = Pealinn?");
                    randName = riik_pealinn.Keys.ToList()[randMax];
                }
                else {
                    Console.WriteLine("Pealinn = Riik?");
                    randName = riik_pealinn.Values.ToList()[randMax];
                }

                Console.Write("Guess:");
                string answer = Console.ReadLine();
                answer = char.ToUpper(answer[0] )+ answer.Substring(1);

                if ( riik_pealinn.Values.ToList()[randMax] == answer || riik_pealinn.Keys.ToList()[randMax] == answer) {
                    win = win + 1;
                    Console.WriteLine("Good");
                }
                else {
                    Console.WriteLine("bad");
                }
            }
            Console.WriteLine( ((win/int.Parse(HMR))*100) +"% right" );
        }

        public static void Edit(Dictionary<string, string> riik_pealinn) {
            Show(riik_pealinn);
            int MaxList = riik_pealinn.Keys.ToList().Count;
            int number = MaxList+4;
            string pick = "";
            char op;

            do {
                Console.Write("Line:");
                pick = Console.ReadLine();
                if ( pick == "" ){ pick = " "; }    
                if ( pick.ToLower()[0] == 'q' ){ break; }      
                if ( IsNumber(pick) ){
                    number = int.Parse(pick);
                }

            } while ( !(0 < number && number <= MaxList ));

            string lrp = riik_pealinn.Keys.ToList()[number-1];
            do {
                
                
                Console.Write("r/L: ");
                string test = Console.ReadLine();

                if ( test == "" ){ test = " "; }
                op = Convert.ToChar(test[0]);
            
                if ( op == 'l' ){
                    Console.Write("Pealinn uues nimi: ");
                    string nimi = Console.ReadLine();
                    riik_pealinn[lrp] = nimi;
                }
                else if ( op == 'r' ){
                    Console.Write("riik uues nimi: ");
                    string riik = Console.ReadLine();
                    riik_pealinn[riik] = riik_pealinn[lrp];
                    riik_pealinn.Remove(lrp);
                }
            } while ( op != 'r' && op != 'l' );
        }
    }
}