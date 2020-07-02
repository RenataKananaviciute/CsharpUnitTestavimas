using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestavimoUzduotis
{
    public class Skaiciuotuvas
    {
        public double Sudeti(double x, double y)
        {
            return x + y;
        }

        public double Atimti(double x, double y)
        {
            if (y == 0)
            {
                throw new ArgumentException("Dalyba is 0 negalima");
            }
            return x / y;
        }

        public double PridetiLimitus(double x, double y, double minValue, double maxValue)
        {
            if (x > maxValue || x < minValue)
            {
                throw new ArgumentOutOfRangeException("x", $"x yra uz apibrezto limito");
            }

            if (y > maxValue || y < minValue)
            {
                throw new ArgumentOutOfRangeException("y", $"y yra uz apibrezto limito");
            }

            return x + y;
        }
    }
}
