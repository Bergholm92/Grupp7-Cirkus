using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Grupp18_v2
{
    public class Ingar
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        public int Medlems_id { get; set; }
        public int Traningsgrupp_id { get; set; }
        public Ingar(int medlems_id, int traningsgrupp_id)
        {
            Medlems_id = medlems_id;
            Traningsgrupp_id = traningsgrupp_id;
        }
        public Ingar Addingar(int medlems_id, int traningsgrupp_id)
        {
            conn.Open();
            try
            {

                cmd = new NpgsqlCommand("INSERT INTO ingar (medlems_id, traningsgrupp_id) SELECT @mid, @tid WHERE NOT EXISTS ( SELECT traningsgrupp_id FROM ingar WHERE medlems_id = @mid AND traningsgrupp_id=@tid);", conn);


                cmd.Parameters.AddWithValue("@mid", medlems_id);
                cmd.Parameters.AddWithValue("@tid", traningsgrupp_id);
                cmd.ExecuteNonQuery();
                return new Ingar(medlems_id, traningsgrupp_id);

            }
            catch
            {
                return null;
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
