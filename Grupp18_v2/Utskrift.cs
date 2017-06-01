using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Grupp18_v2
{
    public class Utskrift
    {
        public string Beskrivning { get; set; }
        public DateTime Datum { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Showutskrift { get { return Förnamn + " " + Efternamn + " "; } }
     //   public Utskrift(string beskrivning, DateTime datum, string förnamn, string efternamn)
        //{
        //    Beskrivning = beskrivning;
        //    Datum = datum;
        //    Förnamn = förnamn;
        //    Efternamn = efternamn;
        //}
    }
}
