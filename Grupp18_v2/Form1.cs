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
      
        public Form1()
        {
            InitializeComponent();
            
        }
        //private void OpenAndGetData()
        //{
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

        //}


        private void btnAdmin_Click(object sender, EventArgs e)
        {
            var AdminForm = new AdminForm();
            AdminForm.Show();

        }

        private void btnLedare_Click(object sender, EventArgs e)
        {
            var LedareForm = new LedareForm();
            LedareForm.Show();
        }
    }
}
