using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
namespace Grupp18_v2
{
    public partial class TraningsgruppForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlDataReader dr;
        List<Medlem> medlemslist = new List<Medlem>();
        List<Traningsgrupp> Traningsgrupplist = new List<Traningsgrupp>();
        int medlems_id;
        int traningsgrupp;
        
        public TraningsgruppForm()
        {
          
            InitializeComponent();
            UpdateAll();
        }

        private List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
        {

            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM medlem", conn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    medlemslist.Add(new Medlem(dr.GetInt32(dr.GetOrdinal("medlems_id")), dr["förnamn"].ToString(), dr["efternamn"].ToString(), dr["adress"].ToString(), dr["epost"].ToString(), dr["telefon"].ToString(), dr["mobiltelefon"].ToString(), dr.GetBoolean(dr.GetOrdinal("fotograferas")), dr["kön"].ToString(), dr.GetInt32(dr.GetOrdinal("medlemstyp_id")), dr.GetDateTime(dr.GetOrdinal("personnummer"))));
                }
                return medlemmar;
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

        private List<Traningsgrupp> GetTraningsgrupp(List<Traningsgrupp> traningsgrupper)
        {
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM traningsgrupp", conn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    Traningsgrupplist.Add(new Traningsgrupp(dr.GetInt32(dr.GetOrdinal("traningsgrupp_id")), dr["namn"].ToString(), dr.GetInt32(dr.GetOrdinal("antal")),dr["typ"].ToString()));
                }
                return traningsgrupper;
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



        private void UpdateAll()
        {
            lbxMedlem.Items.Clear();
            lbxTraningsgrupp.Items.Clear();
            medlemslist.Clear();
            Traningsgrupplist.Clear();
            GetTraningsgrupp(Traningsgrupplist);
            GetMedlemmar(medlemslist);
           
            foreach (Medlem m in medlemslist)
            {
                lbxMedlem.Items.Add(m);
            }
            lbxMedlem.DisplayMember = "ShowMembers";

            foreach (Traningsgrupp T in Traningsgrupplist)
            {
                lbxTraningsgrupp.Items.Add(T);
            }
            lbxTraningsgrupp.DisplayMember = "Showtraningsgrupp";

        }

        private void btnIngar_Click(object sender, EventArgs e)
        {
            Ingar I = new Ingar(medlems_id, traningsgrupp);
            I.Addingar(medlems_id, traningsgrupp);
            UpdateAll();
        }

        private void lbxTraningsgrupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox T = sender as ListBox;
            if (T.SelectedIndex != -1)
            {
                lbxTraningsgrupp.SelectedIndex = T.SelectedIndex;
                Traningsgrupp IN = (Traningsgrupp)lbxTraningsgrupp.SelectedItem;
                traningsgrupp = IN.Traningsgrupp_id;
               




            }
        }

        private void lbxMedlem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox M = sender as ListBox;
            if (M.SelectedIndex != -1)
            {
                lbxMedlem.SelectedIndex = M.SelectedIndex;
                Medlem N = (Medlem)lbxMedlem.SelectedItem;
                medlems_id = N.Medlems_id;





            }
        }
    }
}
