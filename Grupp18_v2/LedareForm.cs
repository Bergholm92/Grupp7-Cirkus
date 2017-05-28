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
    public partial class LedareForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlDataReader dr;
        List<Medlem> medlemslist = new List<Medlem>();
        List<Träning> träningslist = new List<Träning>();
        List<Narvaro> Närvarolist = new List<Narvaro>();
        int medlems_id;
        int träning;
        

        public LedareForm()
        {
            InitializeComponent();
            UpdateAll();
            


        }

        private List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
        {
            int id;
            
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM medlem INNER JOIN ingar ON ingar.medlems_id=medlem.medlems_id WHERE ingar.traningsgrupp_id = @id; ", conn);

                if (comboBox1.SelectedItem == "Akrobatik")
                {
                    id = 1;
                    cmd.Parameters.AddWithValue("@id", id);
                }
                else if (comboBox1.SelectedItem == "Jonglering")
                {
                    id = 2;
                    cmd.Parameters.AddWithValue("@id", id);
                }
                else if (comboBox1.SelectedItem == "Klot")
                {
                    id = 3;
                    cmd.Parameters.AddWithValue("@id", id);
                }
                else if (comboBox1.SelectedItem == null)
                {
                    id = 1;
                    cmd.Parameters.AddWithValue("@id", id);
                }

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

        public List<Träning> GetTräningar(List<Träning> Träningar)
        {
            int id;
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("Select traning_id, datum, beskrivning,plats_fk,traningsgrupp_fk, traningsgrupp.namn, plats.namn AS Plats from traning INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk INNER JOIN plats ON plats.plats_id=traning.plats_fk WHERE traning.traningsgrupp_fk = @tFK", conn);
                


                if (comboBox1.SelectedItem == "Akrobatik")
                {
                    id = 1;
                    cmd.Parameters.AddWithValue("@tFK", id);
                }
                else if (comboBox1.SelectedItem == "Jonglering")
                {
                    id = 2;
                    cmd.Parameters.AddWithValue("@tFK", id);
                }
                else if (comboBox1.SelectedItem == "Klot")
                {
                    id = 3;
                    cmd.Parameters.AddWithValue("@tFK", id);
                }
                else if (comboBox1.SelectedItem == null)
                {
                    id = 1;
                    cmd.Parameters.AddWithValue("@tFK", id);
                }
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {

                    träningslist.Add(new Träning(dr.GetInt32(dr.GetOrdinal("traning_id")), dr.GetDateTime(dr.GetOrdinal("datum")), dr["beskrivning"].ToString(), dr.GetInt32(dr.GetOrdinal("traningsgrupp_fk")), dr.GetInt32(dr.GetOrdinal("plats_fk")), dr["namn"].ToString(), dr["Plats"].ToString()));
                }
                return Träningar;
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
        public List<Narvaro> Getnarvaro(List<Narvaro> narvaror)
        {

            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT narvaro.tranings_id,narvaro.medlems_id, medlem.förnamn AS förnamn from narvaro INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id WHERE tranings_id=@id ", conn);
                cmd.Parameters.AddWithValue("@id", träning);
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {

                    Närvarolist.Add(new Narvaro(dr.GetInt32(dr.GetOrdinal("tranings_id")), dr.GetInt32(dr.GetOrdinal("medlems_id")), dr["förnamn"].ToString()));
                }
                return narvaror;
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
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            medlemslist.Clear();
            träningslist.Clear();
            Närvarolist.Clear();
            
            GetMedlemmar(medlemslist);
            GetTräningar(träningslist);
            Getnarvaro(Närvarolist);
            foreach (Medlem m in medlemslist)
            {
                listBox2.Items.Add(m);
            }
            listBox2.DisplayMember = "ShowMembers";

            foreach (Träning T in träningslist)
            {
                listBox1.Items.Add(T);
            }
            listBox1.DisplayMember = "Showtraning";
            foreach (Narvaro N in Närvarolist)
            {
                listBox3.Items.Add(N);
            }
            listBox3.DisplayMember = "Shownarvaro";
           

        }
        private void UpdateAll2()
        {
            
            listBox2.Items.Clear();
            listBox3.Items.Clear();
            medlemslist.Clear();
            
            Närvarolist.Clear();

            GetMedlemmar(medlemslist);
            GetTräningar(träningslist);
            Getnarvaro(Närvarolist);
            foreach (Medlem m in medlemslist)
            {
                listBox2.Items.Add(m);
            }
            listBox2.DisplayMember = "ShowMembers";

   
            foreach (Narvaro N in Närvarolist)
            {
                listBox3.Items.Add(N);
            }
            listBox3.DisplayMember = "Shownarvaro";


        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Narvaro N = new Narvaro(träning, medlems_id);
            N.Addnarvaro(träning, medlems_id);
            Getnarvaro(Närvarolist);
            UpdateAll2();
            

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            ListBox L = sender as ListBox;
            if (L.SelectedIndex != -1)
            {
                listBox2.SelectedIndex = L.SelectedIndex;
                Medlem M = (Medlem)listBox2.SelectedItem;
                medlems_id = M.Medlems_id;
               
                

            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            ListBox C = sender as ListBox;
            if (C.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = C.SelectedIndex;
                Träning T = (Träning)listBox1.SelectedItem;
                träning = T.Tränings_id;
                Närvarolist.Clear();
                listBox3.Items.Clear();


            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            GetMedlemmar(medlemslist);
            UpdateAll();
            Närvarolist.Clear();
            listBox3.Items.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Narvaro N = new Narvaro(träning, medlems_id);
            N.Removenarvaro(träning, medlems_id);
            UpdateAll2();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox M = sender as ListBox;
            if (M.SelectedIndex != -1)
            {
                listBox3.SelectedIndex = M.SelectedIndex;
                Narvaro N = (Narvaro)listBox3.SelectedItem;
                träning = N.Traning;
                medlems_id = N.Medlem;
                 
               


            }
        }
    }
}
