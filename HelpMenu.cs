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
            foreach (var value in item) {
                Console.WriteLine(value.Key + ":" + value.Value);
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
    }
}