using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Grupp18_v2
{
    public class Träning
    {
        public int Tränings_id { get; set; }
        public DateTime Datum { get; set; }
        public DateTime Tid { get; set; }
        public string Beskrivning { get; set; }
        public int Träningsgrupp { get; set; }
        public int Plats { get; set; }
        public string Showtraning { get { return Beskrivning + " "  + Datum +" "; } }

        public Träning(int tranings_id, DateTime datum, string beskrivning, int träningsgrupp, int plats)
        {
            Tränings_id = tranings_id;
            Datum = datum;
            // Tid = tid;
            Beskrivning = beskrivning;
            Träningsgrupp = träningsgrupp;
            Plats = plats;
        }
        
   
    }
}

