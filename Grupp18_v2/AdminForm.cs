﻿using System;
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
            catch(NpgsqlException ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
            
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

                    medlemslist.Add(new Medlem(dr.GetInt32(dr.GetOrdinal("medlems_id")), dr["förnamn"].ToString(), dr["efternamn"].ToString(), dr["adress"].ToString(), dr["epost"].ToString(), dr["telefon"].ToString(), dr["mobiltelefon"].ToString(), dr.GetBoolean(dr.GetOrdinal("fotograferas")), dr["kön"].ToString(), dr.GetInt32(dr.GetOrdinal("medlemstyp_id")), dr["personnummer"].ToString()));
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

        private void button1_Click(object sender, EventArgs e)
        {
        
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
                


            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Medlem N = (Medlem)lbxMedlem.SelectedItem;
            TaBortMedlem(N);
            UpdateAll();
        }
    }
}
