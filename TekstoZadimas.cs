using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestavimoUzduotis
{
    public class TekstoZadimas : ITekstoZadimas
    {
        public void SaugotiTeksta(string kelias, List<string> linijos)
        {
            if (kelias.Length > 260)
            {
                throw new PathTooLongException("Kelio ilgis turi buti mazenis nei 261 simboliu.");
            }

            string failoPavadinimas = Path.GetFileName(kelias);

            File.WriteAllLines(failoPavadinimas, linijos);
        }
    }
}
