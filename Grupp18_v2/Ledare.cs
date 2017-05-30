using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp18_v2
{
    public class Ledare
    {
        public int Medlems_id { get; set; }
        public int Tranings_id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Showledare { get { return Förnamn + " " + Efternamn; } }
        public Ledare(string förnamn, string efternamn)
        {
            Förnamn = förnamn;
            Efternamn = efternamn;
        }
    }
}
