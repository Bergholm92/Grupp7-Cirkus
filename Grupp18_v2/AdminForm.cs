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
        public List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
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

        private void UpdateAll()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
            textBox6.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
            textBox11.Clear();
            lbxMedlem.Items.Clear();
            medlemslist.Clear();
            comboBox1.SelectedIndex = -1;
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

                if (comboBox1.SelectedItem == "Medlem")
                {
                    medlemstyp_id = 1;
                    cmd.Parameters.AddWithValue("@medlemstyp", medlemstyp_id);
                }
                else if (comboBox1.SelectedItem == "Prova-På")
                {
                    medlemstyp_id = 2;
                    cmd.Parameters.AddWithValue("@medlemstyp", medlemstyp_id);
                }
                else if (comboBox1.SelectedItem == "Cirkusvän")
                {
                    medlemstyp_id = 3;
                    cmd.Parameters.AddWithValue("@medlemstyp", medlemstyp_id);
                }
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
                checkBox1.Checked = M.Fotograferas;
                textBox8.Text = M.Kön;
                textBox9.Text = Convert.ToString(M.Personnummer);
                textBox10.Text = Convert.ToString(M.Medlems_id);

                textBox11.Text = Convert.ToString(M.Medlemstyp_id);
                if (textBox11.Text == "1")
                {
                    comboBox1.SelectedItem = "Medlem";

                }
                else if (textBox11.Text == "2")
                {
                    comboBox1.SelectedItem = "Prova-På";

                }
                else if (textBox11.Text == "3")
                {
                    comboBox1.SelectedItem = "Cirkusvän";

                }



            }
        }

        private Medlem TaBortMedlem(Medlem valdMedlem)
        {
            try
            {
                foreach (Medlem M in medlemslist)
                {
                    Medlem N = (Medlem)lbxMedlem.SelectedItem;
                    if (M == N)
                    {
                        medlemslist.Remove(N);
                        TaBortMedlem(N);
                        conn.Open();
                        cmd = new NpgsqlCommand("DELETE from ingar where medlems_id= @id; DELETE from medlemsansvar where medlems_id = @id; DELETE from leder where medlems_id = @id; DELETE from narvaro where medlems_id = @id; DELETE from medlem where medlems_id = @id;", conn);
                        cmd.Parameters.AddWithValue("@id", N.Medlems_id);
                        dr = cmd.ExecuteReader();

                        lbxMedlem.Items.Remove(N);
                        lbxMedlem.Refresh();
                        break;
                    }
                    else
                    {

                    }
                }

                while (dr.Read())
                {

                }
                return valdMedlem;
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
                AddMedlem_2(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, Convert.ToBoolean(checkBox1.Checked), textBox8.Text, textBox6.Text, textBox5.Text, Convert.ToInt32(textBox11.Text), Convert.ToDateTime(textBox9.Text));

            }
            catch (NpgsqlException dx)
            {

                MessageBox.Show(dx.Message);
            }
            UpdateAll();
        }

        private Medlem AddMedlem_2(string fornamn, string efternamn, string adress, string epost, bool fotograferas, string kön, string mobiltelefon, string telefon, int medlemstyp, DateTime personnr)
        {
            fotograferas = true;

            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("INSERT INTO medlem ( förnamn, efternamn, adress, epost, fotograferas, kön, medlemstyp_id, mobiltelefon, telefon, personnummer ) VALUES( @fornamn, @efternamn, @adress, @epost, @fotograferas, @kön, @typid, @mobiltelefon, @telefon, @personnr)", conn);


                cmd.Parameters.AddWithValue("@fornamn", fornamn);
                cmd.Parameters.AddWithValue("@efternamn", efternamn);
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
                if (comboBox1.SelectedItem == "Medlem")
                {
                    medlemstyp = 1;
                    cmd.Parameters.AddWithValue("@typid", medlemstyp);
                }
                else if (comboBox1.SelectedItem == "Prova-På")
                {
                    medlemstyp = 2;
                    cmd.Parameters.AddWithValue("@typid", medlemstyp);
                }
                else if (comboBox1.SelectedItem == "Cirkusvän")
                {
                    medlemstyp = 3;
                    cmd.Parameters.AddWithValue("@typid", medlemstyp);
                }


                cmd.Parameters.AddWithValue("mobiltelefon", mobiltelefon);
                cmd.Parameters.AddWithValue("@telefon", telefon);
                cmd.Parameters.AddWithValue("@personnr", personnr);

                cmd.ExecuteNonQuery();

                //OBS ID Läggs inte till i INSERT statement.
                //
                return new Medlem(fornamn, efternamn, adress, epost, telefon, mobiltelefon, fotograferas, kön, medlemstyp, personnr);

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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                checkBox1.Text = "Ja";
            }
            else
            {
                checkBox1.Text = "Nej";
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            Medlem N = (Medlem)lbxMedlem.SelectedItem;
            TaBortMedlem(N);
            UpdateAll();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == "Medlem")
            {
                textBox11.Text = "1";

            }

            else if (comboBox1.SelectedItem == "Prova-På")
            {

                textBox11.Text = "2";

            }
            else if (comboBox1.SelectedItem == "Cirkusvän")
            {

                textBox11.Text = "3";
            }
     

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }
    }
}
