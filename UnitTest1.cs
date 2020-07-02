using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestavimoUzduotis;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace TestavimoUzudotis_UniteTest
{
    [TestClass]
    public class Skaiciuotuvas_UniteTest
    {
        [TestMethod]
        public void Sudeti_PateiksimeReiksmes2Ir3_tikimesGautiTrue()
        {
            Skaiciuotuvas sudetis = new Skaiciuotuvas();
            var suma = sudetis.Sudeti(2, 3);

            Assert.AreEqual(5, suma);
        }
        [TestMethod]
        public void Atimti_PateiksimeReiksmes5Ir2_tikimesGautiTrue()
        {
            Skaiciuotuvas sudetis = new Skaiciuotuvas();
            var dalmuo = sudetis.Atimti(5, 2);

            Assert.AreEqual(dalmuo, 2.5);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Atimti_PateiksimeReiksmes5Ir0_tikimesGautiKlaida()
        {
            Skaiciuotuvas sudetis = new Skaiciuotuvas();
            var dalmuo = sudetis.Atimti(5, 0);
        }
        [TestMethod]
        public void PridetiLimitus_Pateikiame2ir5ReziuoseNuo1Iki10_TikimesGautiTrue()
        {
            Skaiciuotuvas limitai = new Skaiciuotuvas();
            var suma = limitai.PridetiLimitus(2, 5, 1, 10);

            Assert.AreEqual(suma, 7);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PridetiLimitus_Pateikiame1ir5ReziuoseNuo3Iki10_TikimesGautiTrue()
        {
            Skaiciuotuvas limitai = new Skaiciuotuvas();
            var suma = limitai.PridetiLimitus(1, 5, 3, 10);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PridetiLimitus_Pateikiame2ir5ReziuoseNuo1Iki4_TikimesGautiTrue()
        {
            Skaiciuotuvas limitai = new Skaiciuotuvas();
            var suma = limitai.PridetiLimitus(2, 5, 1, 4);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void PridetiLimitus_Pateikiame1ir5ReziuoseNuo2Iki4_TikimesGautiTrue()
        {
            Skaiciuotuvas limitai = new Skaiciuotuvas();
            var suma = limitai.PridetiLimitus(1, 5, 2, 4);
        }
    }

    [TestClass]
    public class TekstoZaidimas_UnitTest
    {
        [TestMethod]
        public void SaugotiTeksta_PateikiamePavadFailasIrasymui_TikimesGautiTRue()
        {
            FakeTekstoZaidimas tekstoZaidimas = new FakeTekstoZaidimas();
            List<string> eilutes = new List<string>();
            tekstoZaidimas.SaugotiTeksta("FailasIrasymui", eilutes);

            Assert.AreEqual(tekstoZaidimas.FailoPavadinimas, "FailasIrasymui");

        }
        [TestMethod]
        [ExpectedException(typeof(PathTooLongException))]
        public void SaugotiTeksta_PateikiamePavadFailasIlgesnisNei261simboliu_TikimesGautiKlaida()
        {
            string pavadinimas = "Failas";
            for (int i = 0; i < 50; i++)
            {
                pavadinimas += pavadinimas;
                if (pavadinimas.Length>262)
                {
                    break;
                }
            }
            FakeTekstoZaidimas tekstoZaidimas = new FakeTekstoZaidimas();
            List<string> eilutes = new List<string>();
            tekstoZaidimas.SaugotiTeksta(pavadinimas, eilutes);
        }


    }

    class FakeTekstoZaidimas : ITekstoZadimas
    {
        public string FailoPavadinimas;
        public void SaugotiTeksta(string kelias, List<string> linijos)
        {
            if (kelias.Length > 260)
            {
                throw new PathTooLongException("Kelio ilgis turi buti mazenis nei 261 simboliu.");
            }
            else
            {
                FailoPavadinimas = kelias;
            }
        }
    }

}
