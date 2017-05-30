using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
namespace Grupp18_v2
{
    public class Traningsgrupp
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        public int Traningsgrupp_id { get; set; }
        public string Namn { get; set; }
        public int Antal { get; set; }
        public string Typ { get; set; }

        public string Showtraningsgrupp { get { return Namn; } }
        public Traningsgrupp(int traningsgrupp_id, string namn, int antal, string typ)
        {
            Traningsgrupp_id = traningsgrupp_id;
            Namn = namn;
            Antal = antal;
            Typ = typ;
        }

    }
}
