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
        }//Liknande Get-metod som finns hos ledare-formet.

        private void UpdateAll()
        {
            tbxfnamn.Clear();
            tbxenamn.Clear();
            tbxadress.Clear();
            tbxepost.Clear();
            tbxtele.Clear();
            tbxmobil.Clear();
            
            tbxprsnummer.Clear();
            tbxmedlemsid.Clear();
            textBox11.Clear();
            lbxMedlem.Items.Clear();
            medlemslist.Clear();
            cbxtyp.SelectedIndex = -1;
            GetMedlemmar(medlemslist);
            foreach (Medlem m in medlemslist)
            {
                lbxMedlem.Items.Add(m);
            }
            lbxMedlem.DisplayMember = "ShowMembers";


        }// En update-metod som uppdaterar allt. 



        private void AdminForm_Load(object sender, EventArgs e)
        {

        }

        public void ChangeMedlem()
        {
            string fnamn = tbxfnamn.Text;
            string enamn = tbxenamn.Text;
            string adress = tbxadress.Text;
            string epost = tbxepost.Text;
            bool fotograferas = true;
            string kön = cmbkön.Text;
            string mobiltelefon = tbxmobil.Text;
            string telefon = tbxtele.Text;
            DateTime personnummer = Convert.ToDateTime(tbxprsnummer.Text);
            int medlems_id = Convert.ToInt32(tbxmedlemsid.Text);
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

                if (cbxfoto.Checked)
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

                if (cbxtyp.SelectedItem == "Medlem")
                {
                    medlemstyp_id = 1;
                    cmd.Parameters.AddWithValue("@medlemstyp", medlemstyp_id);
                }
                else if (cbxtyp.SelectedItem == "Prova-På")
                {
                    medlemstyp_id = 2;
                    cmd.Parameters.AddWithValue("@medlemstyp", medlemstyp_id);
                }
                else if (cbxtyp.SelectedItem == "Cirkusvän")
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

        }//Metod som gör det möjligt att ändra en medlem. 


        private void lbxMedlem_SelectedIndexChanged(object sender, EventArgs e)
        {

            ListBox L = sender as ListBox;
            if (L.SelectedIndex != -1)
            {
                lbxMedlem.SelectedIndex = L.SelectedIndex;
                Medlem M = (Medlem)lbxMedlem.SelectedItem;
                tbxfnamn.Text = M.Förnamn;
                tbxenamn.Text = M.Efternamn;
                tbxadress.Text = M.Adress;
                tbxepost.Text = M.Epost;
                tbxtele.Text = Convert.ToString(M.Telefon);
                tbxmobil.Text = Convert.ToString(M.Mobiltelefon);
                cbxfoto.Checked = M.Fotograferas;
                cmbkön.Text = M.Kön;
                tbxprsnummer.Text = Convert.ToString(M.Personnummer);
                tbxmedlemsid.Text = Convert.ToString(M.Medlems_id);

                textBox11.Text = Convert.ToString(M.Medlemstyp_id);
                if (textBox11.Text == "1")
                {
                    cbxtyp.SelectedItem = "Medle";

                }
                else if (textBox11.Text == "2")
                {
                    cbxtyp.SelectedItem = "Prova-På";

                }
                else if (textBox11.Text == "3")
                {
                    cbxtyp.SelectedItem = "Cirkusvän";

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

        }//Metod som gör det möjligt att ta bort en medlem från registret. 

        private void btnCreate_Click(object sender, EventArgs e)
        {
     


            try
            {
                AddMedlem_2(tbxfnamn.Text, tbxenamn.Text, tbxadress.Text, tbxepost.Text, Convert.ToBoolean(cbxfoto.Checked), cmbkön.Text, tbxmobil.Text, tbxtele.Text, Convert.ToInt32(textBox11.Text), Convert.ToDateTime(tbxprsnummer.Text));

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
                if (cbxfoto.Checked)
                {
                    cmd.Parameters.AddWithValue("@fotograferas", fotograferas);
                }
                else
                {
                    fotograferas = false;
                    cmd.Parameters.AddWithValue("@fotograferas", fotograferas);
                }

                cmd.Parameters.AddWithValue("@kön", kön);
                if (cbxtyp.SelectedItem == "Medlem")
                {
                    medlemstyp = 1;
                    cmd.Parameters.AddWithValue("@typid", medlemstyp);
                }
                else if (cbxtyp.SelectedItem == "Prova-På")
                {
                    medlemstyp = 2;
                    cmd.Parameters.AddWithValue("@typid", medlemstyp);
                }
                else if (cbxtyp.SelectedItem == "Cirkusvän")
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



        }//Metod som gör det möjligt att lägga till en medlem. 

        private void button3_Click(object sender, EventArgs e)
        {
            ChangeMedlem();
            UpdateAll();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (cbxfoto.Checked)
            {
                cbxfoto.Text = "Ja";
            }
            else
            {
                cbxfoto.Text = "Nej";
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
            if (cbxtyp.SelectedItem == "Medlem")
            {
                textBox11.Text = "1";

            }

            else if (cbxtyp.SelectedItem == "Prova-På")
            {

                textBox11.Text = "2";

            }
            else if (cbxtyp.SelectedItem == "Cirkusvän")
            {

                textBox11.Text = "3";
            }
     

        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }

        private void btnTraning_Click(object sender, EventArgs e)//Knapp som tar oss till formen där man kan lägga till medlemmar till olika träningsgrupper. 
        {
            var Traningsgruppform = new TraningsgruppForm();
            Traningsgruppform.Show();
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
