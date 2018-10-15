using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gambling
{
    public class Karta
    {
        public string Mast { get; set; }
        public int Type { get; set; }
        public Karta(Karta karta)
        {
            Mast = karta.Mast;
            Type = karta.Type;
        }
        public Karta() { }
    }
}
