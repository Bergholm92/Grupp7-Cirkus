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
    public partial class AdminForm : Form
    {
        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlDataReader dr;
        List<Medlem> medlemslist = new List<Medlem>();

        public AdminForm()
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

                    medlemslist.Add(new Medlem(dr.GetInt32(dr.GetOrdinal("medlems_id")), dr["förnamn"].ToString(), dr["efternamn"].ToString(), dr["adress"].ToString(), dr["epost"].ToString(), dr["telefon"].ToString(), dr["mobiltelefon"].ToString(), dr.GetBoolean(dr.GetOrdinal("fotograferas")), dr["kön"].ToString(), dr.GetInt32(dr.GetOrdinal("medlemstyp_id")),  dr.GetDateTime(dr.GetOrdinal("personnummer"))));
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

        private void UpdateAll()
        {
            lbxMedlem.Items.Clear();
            medlemslist.Clear();
            GetMedlemmar(medlemslist);
            foreach (Medlem m in medlemslist)
            {
                lbxMedlem.Items.Add(m);
            }
            lbxMedlem.DisplayMember = "ShowMembers";

        }



        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        public void ChangeMedlem()
        {
            string fnamn = textBox1.Text;
            string enamn = textBox2.Text;
            string adress = textBox3.Text;
            string epost = textBox4.Text;
            bool fotograferas = true;
            string kön = textBox8.Text;
            string mobiltelefon = textBox6.Text;
            string telefon = textBox5.Text;
            DateTime personnummer = Convert.ToDateTime(textBox9.Text);
            int medlems_id = Convert.ToInt32(textBox10.Text);
            int medlemstyp_id = Convert.ToInt32(textBox11.Text);

            try
            {

                conn.Open();
                string query = "UPDATE medlem SET (förnamn, efternamn,adress, epost,fotograferas, kön, mobiltelefon, telefon,personnummer, medlemstyp_id) = (@förnamn, @efternamn, @adress, @epost,@fotograferas, @kön, @mobiltelefon, @telefon, @personnummer,@medlemstyp) WHERE medlems_id=@id";
                cmd = new NpgsqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@förnamn", fnamn);
                cmd.Parameters.AddWithValue("@efternamn", enamn);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@epost", epost);

                if (checkBox1.Checked)
                {
                    cmd.Parameters.AddWithValue("@fotograferas", fotograferas);
                }
                else
                {
                    fotograferas = false;
                    cmd.Parameters.AddWithValue("@fotograferas", fotograferas);
                }
                cmd.Parameters.AddWithValue("@kön", kön);
                // cmd.Parameters.AddWithValue("@medlemstyp_id", medlemstyp_id);
                cmd.Parameters.AddWithValue("@mobiltelefon", mobiltelefon);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@personnummer", personnummer);
                cmd.Parameters.AddWithValue("@id", medlems_id);
                cmd.Parameters.AddWithValue("@medlemstyp", medlemstyp_id);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Användaren har uppdateras");
            }
            catch (NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);

            }
            finally
            {
                conn.Close();
            }

        }


        private void lbxMedlem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox L = sender as ListBox;
            if (L.SelectedIndex != -1)
            {
                lbxMedlem.SelectedIndex = L.SelectedIndex;
                Medlem M = (Medlem)lbxMedlem.SelectedItem;
                textBox1.Text = M.Förnamn;
                textBox2.Text = M.Efternamn;
                textBox3.Text = M.Adress;
                textBox4.Text = M.Epost;
                textBox5.Text = Convert.ToString(M.Telefon);
                textBox6.Text = Convert.ToString(M.Mobiltelefon);
                textBox7.Text = Convert.ToString(M.Fotograferas);
                textBox8.Text = M.Kön;
                textBox9.Text = Convert.ToString(M.Personnummer);
                textBox10.Text = Convert.ToString(M.Medlems_id);
                textBox11.Text = Convert.ToString(M.Medlemstyp_id);



            }
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            //if (txtbxMember.Text != "" & txtbxNamn.Text != "" & txtbxTele.Text != "")
            //{
            //    AddMedlem(Convert.ToInt32(txtbxMember.Text), txtbxNamn.Text, txtbxTele.Text);
            //}
            //else
            //{
            //    MessageBox.Show("Du måste mata in uppgifter i textboxarna.");
            //}


            try
            {
                AddMedlem_2(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToBoolean(textBox7.Text), textBox8.Text, textBox6.Text, textBox5.Text, Convert.ToInt32(textBox11.Text), Convert.ToDateTime(textBox9.Text), Convert.ToInt32(textBox10.Text) );

            }
            catch (NpgsqlException dx)
            {

                MessageBox.Show(dx.Message);
            }
            UpdateAll();
        }

        private Medlem AddMedlem_2(string fornamn, string efternamn, string adress, string epost, bool fotograferas, string kön, string mobiltelefon, string telefon, int medlemstyp, DateTime personnr, int id)
        {

            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("INSERT INTO medlem (medlems_id, förnamn, efternamn, adress, epost, fotograferas, kön, medlemstyp_id, mobiltelefon, telefon, personnummer ) VALUES(@medlems_id, @fornamn, @efternamn, @adress, @epost, @fotograferas, @kön, @typid, @mobiltelefon, @telefon, @personnr)", conn);

                cmd.Parameters.AddWithValue("@medlems_id", id);
                cmd.Parameters.AddWithValue("@fornamn", fornamn);
                cmd.Parameters.AddWithValue("@efternamn", efternamn);
                cmd.Parameters.AddWithValue("@adress", adress);
                cmd.Parameters.AddWithValue("@epost", epost);
                cmd.Parameters.AddWithValue("@fotograferas", fotograferas);
                cmd.Parameters.AddWithValue("@kön", kön);
                cmd.Parameters.AddWithValue("@typid", medlemstyp);
                cmd.Parameters.AddWithValue("mobiltelefon", mobiltelefon);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@personnr", personnr);

                cmd.ExecuteNonQuery();

                //OBS ID Läggs inte till i INSERT statement.
                //
                return new Medlem(id, fornamn, efternamn, adress, epost, telefon, mobiltelefon, fotograferas, kön, medlemstyp, personnr);

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

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeMedlem();
            UpdateAll();
        }
    }
}
