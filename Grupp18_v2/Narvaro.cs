using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using System.Windows.Forms;

namespace Grupp18_v2
{
    public class Narvaro
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        public int Traning;
        public int Medlem;
        string Medlem_namn;
        List<Narvaro> Närvarolist = new List<Narvaro>();
        public string Shownarvaro { get { return Medlem_namn + "       Deltar!"; } }
        public Narvaro(int traning, int medlem)
        {
            Traning = traning;
            Medlem = medlem;
        
        }
        public Narvaro(int traning, int medlem, string medlem_namn)
        {
            Traning = traning;
            Medlem = medlem;
            Medlem_namn = medlem_namn;
        }
        

        public Narvaro Addnarvaro(int traning, int medlem)
        {
            conn.Open();
            try
            {

                cmd = new NpgsqlCommand("INSERT INTO narvaro (tranings_id, medlems_id) SELECT @tid, @mid WHERE NOT EXISTS ( SELECT tranings_id FROM narvaro WHERE tranings_id = @tid AND medlems_id=@mid);", conn);


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


        public Narvaro Removenarvaro(int traning, int medlem)
        {
            conn.Open();
            try
            {

                cmd = new NpgsqlCommand("DELETE from narvaro WHERE tranings_id = @tid AND medlems_id=@mid;", conn);


                cmd.Parameters.AddWithValue("@tid", traning);
                cmd.Parameters.AddWithValue("@mid", medlem);
                cmd.ExecuteNonQuery();
                return new Narvaro(traning, medlem);

            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
