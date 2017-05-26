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
        public string Beskrivning { get; set; }
        public int Träningsgrupp { get; set; }
        public int Plats { get; set; }
        public string Träningsgrupp_namn { get; set; }
        public string Plats_namn { get; set; }
        public string Showtraning { get { return Beskrivning + " | " + "Datum: " + Datum + " |  " + "Plats:" + " " + Plats_namn ; } }
        

        public Träning(int tranings_id, DateTime datum,  string beskrivning, int träningsgrupp, int plats, string träningsgrupp_namn, string plats_namn)
        {
            
            Tränings_id = tranings_id;
            Datum= datum;
            Träningsgrupp_namn = träningsgrupp_namn;
            Beskrivning = beskrivning;
            Träningsgrupp = träningsgrupp;
            Plats = plats;
            Plats_namn = plats_namn;
        }

        
   
    }
}

