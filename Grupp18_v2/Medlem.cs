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
        public string Telefon { get; set; }
        public string Mobiltelefon { get; set; }
        public bool Fotograferas { get; set; }
        public string Kön { get; set; }
        public int Medlemstyp_id { get; set; }
        public string Personnummer { get; set; }
        

        public string ShowMembers { get { return Förnamn + " " + Efternamn + " " ; } }


        public Medlem(int id, string fnamn, string enamn, string adrss, string epost, string telefon, string mobiltelefon, bool fotograferas, string kön, int medlems_typ, string pnummer)
        {
            Medlems_id = id;
            Förnamn = fnamn;
            Efternamn = enamn;
            Adress = adrss;
            Epost = epost;
            Telefon = telefon;
            Mobiltelefon = mobiltelefon;
            Fotograferas = fotograferas;
            Kön = kön;
            Medlemstyp_id = medlems_typ;
            Personnummer = pnummer; 
        }

        public void AddMedlem()
        {
            
           
        }
    }
}

