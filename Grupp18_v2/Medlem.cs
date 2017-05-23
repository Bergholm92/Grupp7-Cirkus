using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grupp18_v2
{
    public class Medlem
    {
        public int Medlems_id { get; set; }
        public string Förnamn { get; set; }
        public string Efternamn { get; set; }
        public string Adress { get; set; }
        public string Epost { get; set; }
        public int Telefon { get; set; }
        public int Mobiltelefon { get; set; }
        public bool Fotograferas { get; set; }
        public string Kön { get; set; }
        public int Medlemstyp_id { get; set; }
        public int Malsman_id { get; set; }
        public int Personnummer { get; set; }



        public Medlem(int id, string fnamn, string enamn, string adress, string epost, int telefon, int mobiltelefon, bool fotograferas, string kön, int medlems_typ, int malsman_id, int pnummer)
        {
            Medlems_id = id;
            Förnamn = fnamn;
            Efternamn = enamn;
            Adress = adress;
            Epost = epost;
            Telefon = telefon;
            Mobiltelefon = mobiltelefon;
            Fotograferas = fotograferas;
            Kön = kön;
            Medlemstyp_id = medlems_typ;
            Malsman_id = malsman_id;
            Personnummer = pnummer;
        }
    }
}

