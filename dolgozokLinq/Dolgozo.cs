using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dolgozokLinq
{
    internal class Dolgozo
    {
        public Dolgozo(int azonosito, string nev, string anyjaNeve, string telepules, string cim, int fizetes, int jutalom, DateTime belepes, DateTime szuletes, string szuletesHelye)
        {
            Azonosito = azonosito;
            Nev = nev;
            AnyjaNeve = anyjaNeve;
            Telepules = telepules;
            Cim = cim;
            Fizetes = fizetes;
            Jutalom = jutalom;
            Belepes = belepes;
            Szuletes = szuletes;
            SzuletesHelye = szuletesHelye;
        }

        /*
Azonosító;Név;Anyjaneve;Település;Cím;Fizetés;Jutalom;Belépés;Születés;Születés helye
*/

        public int Azonosito { get; set; }
        public string Nev { get; set; }
        public string AnyjaNeve { get; set; }
        public string Telepules { get; set; }
        public string Cim { get; set; }
        public int Fizetes { get; set; }
        public int Jutalom { get; set; }
        public DateTime Belepes { get; set; }
        public DateTime Szuletes { get; set; }
        public string SzuletesHelye { get; set; }
    }
}
