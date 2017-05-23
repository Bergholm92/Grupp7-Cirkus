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
        public DateTime Personnummer { get; set; }
        public int Malsman_id { get; set; }

        public string ShowMembers { get { return Förnamn + " " + Efternamn + " " + Personnummer; } }


        public Medlem(int id, string fnamn, string enamn, string adrss, string epost, int telefon,bool fotograferas, string kön, int medlems_typ, DateTime pnummer)
        {
            Medlems_id = id;
            Förnamn = fnamn;
            Efternamn = enamn;
            Adress = adrss;
            Epost = epost;
            Telefon = telefon;
            //Mobiltelefon = mobiltelefon;  Problem med hur man löser när denna faktiskt är null
            Fotograferas = fotograferas;
            Kön = kön;
            Medlemstyp_id = medlems_typ;
            //Malsman_id = malsman_id;    Problem med hur man löser när denna faktiskt är null
            Personnummer = pnummer; 
        }

        public void AddMedlem()
        {
            
           
        }
    }
}

