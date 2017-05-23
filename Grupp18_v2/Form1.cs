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
    public partial class Form1 : Form
    {

        NpgsqlConnection conn = new NpgsqlConnection("Server=webblabb.miun.se;Port=5432;User Id=db_g7;Password=cirkus88;Database=db_g7;SSL Mode = Require;");
        NpgsqlCommand cmd = new NpgsqlCommand();
        NpgsqlDataReader dr;
        List<Medlem> medlemslist = new List<Medlem>();
        public Form1()
        {
            InitializeComponent();
            
        }
        private List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
        {
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT förnamn, efternamn FROM medlem", conn);
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                  medlemslist.Add(new Medlem(dr.GetInt32(dr.GetOrdinal("")), dr["förnamn"].ToString(), dr["efternamn"].ToString(), dr["adress"].ToString(), dr["epost"].ToString(), dr.GetInt32(dr.GetOrdinal("telefon")), dr.GetInt32(dr.GetOrdinal("mobiltelefon")), dr.GetBoolean(dr.GetOrdinal("fotograferas")), dr["kön"].ToString(), dr.GetInt32(dr.GetOrdinal("medlemstyp_id")), dr.GetInt32(dr.GetOrdinal("malsman_id")), dr.GetInt32(dr.GetOrdinal("personnummer"))));
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
            listBox1.Items.Clear();
            medlemslist.Clear();
            GetMedlemmar(medlemslist);
            foreach (Medlem m in medlemslist)
            {
                listBox1.Items.Add(m);
            }

        }
        private void OpenAndGetData()
        {
        //    try
        //    {
        //        conn.Open();
        //        cmd = new NpgsqlCommand("SELECT medlems_id, förnamn FROM medlem WHERE medlems_id = 1", conn);

        //        dr = cmd.ExecuteReader();

        //        while (dr.Read())
        //        {
        //            MessageBox.Show(dr["förnamn"].ToString() + " " + dr["medlems_id"].ToString());
        //        }

        //    }
        //    catch (NpgsqlException exc)
        //    {
        //        MessageBox.Show(exc.Message);

        //    }

        //    finally
        //    {
        //        conn.Close();

        //    }

        }

        
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            UpdateAll();
        }
    }
}
