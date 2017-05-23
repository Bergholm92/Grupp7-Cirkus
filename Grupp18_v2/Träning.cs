using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp18_v2
{
   public class Träning
    {
        public int Tränings_id { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Tid { get; set; }
        public string Beskrivning { get; set;}
        public int Träningsgrupp { get; set; }
        public int Plats { get; set; }

    }
}
