using System.Collections;
using System.Collections.Generic;

namespace Euroopa_riigid
{
    class Functions
    {
        public static void Help()
        {
            Console.WriteLine("f = Find");
            Console.WriteLine("s = Show");
            Console.WriteLine("e = Edit");
            Console.WriteLine("g = Game");
            Console.WriteLine("q = Quit");
            Console.WriteLine("c = save");
        }

        public static void Show(Dictionary<string, string> item)
        {
            foreach (var value in item) {
                Console.WriteLine(value.Key + ":" + value.Value);
            }
        }

        public static void Find(Dictionary<string, string> item)
        {
            Console.Write("Enter a word:");
            string sona = Console.ReadLine().ToLower();
            if ( dict.ContainsKey(sone) ) { } 
            else if() { }
            else { }
        }
    }
}