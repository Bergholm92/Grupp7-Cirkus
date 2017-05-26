using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace Grupp18_v2
{
    public class Narvaro
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlDataReader dr;
        int Tranings_id;
        int Medlems_id;

        public Narvaro(int tranings_id, int medlems_id)
        {
            Tranings_id = tranings_id;
            Medlems_id = medlems_id;
        }

        public Narvaro Addnarvaro(int traning, int medlem)
        {
            conn.Open();
            try
            {

                cmd = new NpgsqlCommand("INSERT INTO narvaro (tranings_id, medlems_id) VALUES (@tid, @mid)", conn);


                cmd.Parameters.AddWithValue("@tid", traning);
                cmd.Parameters.AddWithValue("@mid", medlem);
                cmd.ExecuteNonQuery();
                return new Narvaro(traning, medlem);

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
