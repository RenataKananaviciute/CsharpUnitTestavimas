using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestavimoUzduotis
{
    class Program
    {
        static void Main(string[] args)
        {
            TekstoZadimas testavimas = new TekstoZadimas();

            List <string> eilutes = new List<string> { "aaaaa", "bbbbb", "cccccc" };
            testavimas.SaugotiTeksta("FailoPavadinimas", eilutes);
        }
    }
}
