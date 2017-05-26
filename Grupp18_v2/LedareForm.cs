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
        Narvaro N = new Narvaro();
        int medlems_id;
        int träning;


        public LedareForm()
        {
            InitializeComponent();
            UpdateAll();

        }

        private List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
        {
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM medlem ORDER BY efternamn ASC", conn);
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
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM traning ORDER BY beskrivning ASC", conn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    träningslist.Add(new Träning(dr.GetInt32(dr.GetOrdinal("traning_id")), dr.GetDateTime(dr.GetOrdinal("datum")), dr["beskrivning"].ToString(), dr.GetInt32(dr.GetOrdinal("traningsgrupp_fk")), dr.GetInt32(dr.GetOrdinal("plats_fk"))));
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
        private void UpdateAll()
        {

            medlemslist.Clear();
            GetMedlemmar(medlemslist);
            GetTräningar(träningslist);
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

        }

        //public Narvaro Addnarvaro(int traning, int medlem)
        //{
        //    conn.Open();
        //    try
        //    {
                
        //        cmd = new NpgsqlCommand("INSERT INTO narvaro (tranings_id, medlems_id) VALUES (@tid, @mid)", conn);


        //        cmd.Parameters.AddWithValue("@tid", traning);
        //        cmd.Parameters.AddWithValue("@mid", medlem);
        //        cmd.ExecuteNonQuery();
        //        return new Narvaro(traning, medlem);

        //    }
        //    catch (NpgsqlException ex)
        //    {

                
        //        return null;
        //    }
        //    finally
        //    {
        //        conn.Close();
        //    }
        //}

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
                
                N.Addnarvaro(träning, medlems_id);
          
         
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox C = sender as ListBox;
            if (C.SelectedIndex != -1)
            {
                listBox1.SelectedIndex = C.SelectedIndex;
                Träning T = (Träning)listBox1.SelectedItem;
                träning = T.Tränings_id;
                

            }
        }
    }
}
