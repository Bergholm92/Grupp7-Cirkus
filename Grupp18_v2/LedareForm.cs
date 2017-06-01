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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;

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
        List<Traningsgrupp> Traningsgrupplist = new List<Traningsgrupp>();
        List<Medlem> Ledarlist = new List<Medlem>();
        Traningsgrupp[] tarray;

        string filepath;
        int medlems_id;
        int träning;
        

        DateTime d1;
        DateTime d2;


        public LedareForm()
        {
            InitializeComponent();
            UpdateAll();

        }
        public string pdfutskriftdatum(string path)
        {

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            conn.Open();
            cmd = new NpgsqlCommand("SELECT beskrivning AS bes, datum AS dat, medlem.förnamn AS fn, medlem.efternamn AS en, medlem.personnummer AS pers from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id where datum BETWEEN @d1 AND @d2 ", conn);

            d1 = Convert.ToDateTime(textBox1.Text);
            d2 = Convert.ToDateTime(textBox2.Text);
            cmd.Parameters.AddWithValue("@d1", d1);
            cmd.Parameters.AddWithValue("@d2", d2);
            using (dr = cmd.ExecuteReader())
            {
                Paragraph p2 = new Paragraph("NÄRVAROKORT: \n \n");
                doc.Add(p2);
                while (dr.Read())
                {
                    Paragraph p1 = new Paragraph(dr["fn"].ToString() + " " + dr["en"].ToString() + " | " + dr["pers"].ToString() + " | " + dr["bes"].ToString() + " | " + dr["dat"].ToString());
                    doc.Add(p1);
                }

                dr.Close();
            }
            cmd = new NpgsqlCommand("SELECT medlem.förnamn as fn, medlem.efternamn as en from medlem INNER JOIN leder ON medlem.medlems_id = leder.medlems_id INNER JOIN traning ON leder.traning_id = traning.traning_id where traning.datum BETWEEN @d1 AND @d2", conn);
            cmd.Parameters.AddWithValue("@d1", d1);
            cmd.Parameters.AddWithValue("@d2", d2);

            using (dr = cmd.ExecuteReader())
            {
                Paragraph p1 = new Paragraph(" \n" + "LEDARE:");
                doc.Add(p1);
                while (dr.Read())

                {
                    Paragraph p2 = new Paragraph(" \n" + dr["fn"].ToString() + " " + dr["en"].ToString() + " | ");

                    doc.Add(p2);
                }
                dr.Close();
            }
            cmd = new NpgsqlCommand("SELECT COUNT(narvaro.medlems_id) as antal, traning.beskrivning as beskriv from narvaro INNER JOIN traning ON traning.traning_id = narvaro.tranings_id where traning.datum BETWEEN @d1 AND @d2 GROUP BY traning.beskrivning ", conn);
            cmd.Parameters.AddWithValue("@d1", d1);
            cmd.Parameters.AddWithValue("@d2", d2);
            using (dr = cmd.ExecuteReader())
            {
                Paragraph p1 = new Paragraph(" \n" + "");
                doc.Add(p1);
                while (dr.Read())

                {
                    Paragraph p2 = new Paragraph(" \n" + dr["antal"].ToString() + " st.  Tränade:" + dr["beskriv"].ToString() + " | ");

                    doc.Add(p2);
                }
                dr.Close();

            }
            cmd = new NpgsqlCommand("SELECT COUNT(traning.traningsgrupp_fk) as antalet, traningsgrupp.namn as namn from traning INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk WHERE traning.datum BETWEEN @d1 AND @d2 GROUP BY traningsgrupp.namn", conn);
            cmd.Parameters.AddWithValue("@d1", d1);
            cmd.Parameters.AddWithValue("@d2", d2);
            using (dr = cmd.ExecuteReader())
            {
                Paragraph p1 = new Paragraph(" \n" + "");
                doc.Add(p1);
                while (dr.Read())

                {
                    Paragraph p2 = new Paragraph(" \n" + dr["antalet"].ToString() + " tillfällen tränade grupp:" + dr["namn"].ToString() + " | ");

                    doc.Add(p2);
                }
                dr.Close();
                conn.Close();




                doc.Close();
                MessageBox.Show("PDF filen skapades");



            }
            return path;
        }
        public string pdfutskriftledare(string path)
        {

            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            conn.Open();
            cmd = new NpgsqlCommand("SELECT beskrivning AS bes, datum AS dat, medlem.förnamn AS fn, medlem.efternamn AS en, medlem.personnummer AS pers from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id INNER JOIN leder on leder.traning_id = traning.traning_id where leder.medlems_id = @mid ORDER BY bes ", conn);

            cmd.Parameters.AddWithValue("@mid", medlems_id);
            using (dr = cmd.ExecuteReader())
            {
                Paragraph p2 = new Paragraph("NÄRVAROKORT \n \n");
                doc.Add(p2);
                while (dr.Read())
                {
                    Paragraph p1 = new Paragraph(dr["fn"].ToString() + " " + dr["en"].ToString() + " | " + dr["pers"].ToString() + " | " + dr["bes"].ToString() + " | " + dr["dat"].ToString());
                    doc.Add(p1);
                }

                dr.Close();
            }
            cmd = new NpgsqlCommand("SELECT DISTINCT medlem.förnamn as fn, medlem.efternamn as en from medlem INNER JOIN leder ON medlem.medlems_id = leder.medlems_id INNER JOIN traning ON leder.traning_id = traning.traning_id where medlem.medlems_id=@mid", conn);
            cmd.Parameters.AddWithValue("@mid", medlems_id);

            using (dr = cmd.ExecuteReader())
            {
                Paragraph p1 = new Paragraph(" \n" + "LEDARE:");
                doc.Add(p1);
                while (dr.Read())

                {
                    Paragraph p2 = new Paragraph(" \n" + dr["fn"].ToString() + " " + dr["en"].ToString() + " | ");

                    doc.Add(p2);
                }
                dr.Close();
            }
            cmd = new NpgsqlCommand("SELECT COUNT(narvaro.medlems_id) as antal, beskrivning AS bes, datum AS dat from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id INNER JOIN leder on leder.traning_id = traning.traning_id where leder.medlems_id = @mid GROUP BY beskrivning, datum", conn);
            cmd.Parameters.AddWithValue("@mid", medlems_id);
            using (dr = cmd.ExecuteReader())
            {
                Paragraph p1 = new Paragraph(" \n" + "");
                doc.Add(p1);
                while (dr.Read())

                {
                    Paragraph p2 = new Paragraph(" \n" + dr["antal"].ToString() + " st.  Tränade: " + dr["bes"].ToString() + " | ");

                    doc.Add(p2);
                }
                dr.Close();

            }
            cmd = new NpgsqlCommand("SELECT COUNT(traning.traning_id) as antalet, medlem.förnamn as fnamn, medlem.efternamn as enamn from traning INNER JOIN leder ON leder.traning_id = traning.traning_id INNER JOIN medlem ON leder.medlems_id = medlem.medlems_id where leder.medlems_id = @mid GROUP BY medlem.förnamn, medlem.efternamn", conn);
            cmd.Parameters.AddWithValue("@mid", medlems_id);
            using (dr = cmd.ExecuteReader())
            {
                Paragraph p1 = new Paragraph(" \n" + "");
                doc.Add(p1);
                while (dr.Read())

                {
                    Paragraph p2 = new Paragraph(" \n" + dr["antalet"].ToString() + " gånger ledde :" + dr["fnamn"].ToString() + " " + dr["enamn"].ToString() + " olika träningar | ");

                    doc.Add(p2);
                }
                dr.Close();
                conn.Close();




                doc.Close();
                MessageBox.Show("PDF filen skapades");



            }
            return path;
        }
        public string pdfutskriftTgrupp(string path)
        {
            int count = 0;
            int antal = Convert.ToInt32(lbxTgrupp.SelectedItems.Count);
            tarray = new Traningsgrupp[antal];

            foreach (Traningsgrupp TG in lbxTgrupp.SelectedItems)
            {
                for (int i = 0; i < 1; i++)
                {
                    tarray[count] = TG;
                }
                count++;
            }
            Document doc = new Document();
            PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
            doc.Open();
            conn.Open();
            Paragraph p2 = new Paragraph("NÄRVAROKORT \n \n");
            doc.Add(p2);
            
            for (int i = 0; i < tarray.Length; i++)
            {
                doc.Open();

                cmd = new NpgsqlCommand("SELECT beskrivning AS bes, datum AS dat, medlem.förnamn AS fn, medlem.efternamn AS en, medlem.personnummer AS pers from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk where traningsgrupp.traningsgrupp_id = @tgid ORDER BY bes ", conn);
                cmd.Parameters.AddWithValue("@tgid", tarray[i].Traningsgrupp_id );
                using (dr = cmd.ExecuteReader())
                {
                    
                    
                    while (dr.Read())
                    {
                        Paragraph p1 = new Paragraph(dr["fn"].ToString() + " " + dr["en"].ToString() + " | " + dr["pers"].ToString() + " | " + dr["bes"].ToString() + " | " + dr["dat"].ToString());
                        doc.Add(p1);
                    }
                }
               
            }
            doc.Open();
            Paragraph p3 = new Paragraph("\n  LEDARE: \n");
            doc.Add(p3);
            for (int i = 0; i < tarray.Length; i++)
            {
                doc.Open();

                cmd = new NpgsqlCommand("SELECT DISTINCT medlem.förnamn as fn, medlem.efternamn as en, traning.beskrivning as bes from medlem INNER JOIN leder ON medlem.medlems_id = leder.medlems_id INNER JOIN traning ON leder.traning_id = traning.traning_id INNER JOIN traningsgrupp ON traning.traningsgrupp_fk = traningsgrupp.traningsgrupp_id where traningsgrupp_id = @tgid; ", conn);
                cmd.Parameters.AddWithValue("@tgid", tarray[i].Traningsgrupp_id);
                using (dr = cmd.ExecuteReader())
                {


                    while (dr.Read())
                    {
                        Paragraph p1 = new Paragraph(" \n" + dr["fn"].ToString() + " " + dr["en"].ToString() + " |  Träning: " + dr["bes"].ToString());
                        doc.Add(p1);
                    }
                }

            }
            doc.Open();
            Paragraph p4 = new Paragraph("\n Antal medlemmar på olika träningar: \n");
            doc.Add(p4);
            for (int i = 0; i < tarray.Length; i++)
            {
                
                cmd = new NpgsqlCommand("SELECT COUNT(narvaro.medlems_id) as antal, beskrivning AS bes, datum AS dat from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id INNER JOIN traningsgrupp ON traningsgrupp_id = traning.traningsgrupp_fk where traningsgrupp_id = @tgid GROUP BY beskrivning, datum", conn);
                cmd.Parameters.AddWithValue("@tgid", tarray[i].Traningsgrupp_id);
                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Paragraph p1 = new Paragraph(" \n" + dr["antal"].ToString() + " st    tränade" + " | " + dr["bes"].ToString());
                        doc.Add(p1);
                    }
                }
            }
            doc.Open();
            Paragraph p5 = new Paragraph("\n ANTAL TRÄNINGAR PER TRÄNINGSGRUPP \n");
            doc.Add(p5);
            for (int i = 0; i < tarray.Length; i++)
            {

                cmd = new NpgsqlCommand("SELECT COUNT(traning.traning_id) as antal, traningsgrupp.namn as namn  from traning INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk where traningsgrupp.traningsgrupp_id = @tgid GROUP BY traningsgrupp.namn", conn);
                cmd.Parameters.AddWithValue("@tgid", tarray[i].Traningsgrupp_id);
                using (dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        Paragraph p1 = new Paragraph(" \n" + dr["antal"].ToString() + " st träningar   har genomförst av " + "  " + dr["namn"].ToString() + " gruppen" );
                        doc.Add(p1);
                    }
                }
            }
            doc.Close();
            conn.Close();
            return path;
        

        }

     
        

        

        private List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
        {
           
            
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM medlem INNER JOIN ingar ON ingar.medlems_id=medlem.medlems_id WHERE ingar.traningsgrupp_id = @id; ", conn);

                if (cmbtgrupp.SelectedIndex > -1)
                {
                    Traningsgrupp TG;
                    TG =  (Traningsgrupp)cmbtgrupp.SelectedItem;
                    
                    cmd.Parameters.AddWithValue("@id", TG.Traningsgrupp_id);
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
          
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("Select traning_id, datum, beskrivning,plats_fk,traningsgrupp_fk, traningsgrupp.namn, plats.namn AS Plats from traning INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk INNER JOIN plats ON plats.plats_id=traning.plats_fk WHERE traning.traningsgrupp_fk = @tFK", conn);



                if (cmbtgrupp.SelectedIndex > -1)
                {
                    Traningsgrupp TG;
                    TG = (Traningsgrupp)cmbtgrupp.SelectedItem;
                    cmd.Parameters.AddWithValue("@tFK", TG.Traningsgrupp_id);
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {

                        träningslist.Add(new Träning(dr.GetInt32(dr.GetOrdinal("traning_id")), dr.GetDateTime(dr.GetOrdinal("datum")), dr["beskrivning"].ToString(), dr.GetInt32(dr.GetOrdinal("traningsgrupp_fk")), dr.GetInt32(dr.GetOrdinal("plats_fk")), dr["namn"].ToString(), dr["Plats"].ToString()));
                    }
                    return Träningar;
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

        private List<Traningsgrupp> GetTraningsgrupp(List<Traningsgrupp> traningsgrupper)
        {
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM traningsgrupp", conn);
                dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    Traningsgrupplist.Add(new Traningsgrupp(dr.GetInt32(dr.GetOrdinal("traningsgrupp_id")), dr["namn"].ToString(), dr.GetInt32(dr.GetOrdinal("antal")), dr["typ"].ToString()));
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

        private List<Medlem> GetLedare(List<Medlem> ledarna)
        {
            

            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT  DISTINCT medlem.medlems_id, förnamn, efternamn, adress, epost,telefon, mobiltelefon, fotograferas, kön, medlemstyp_id, personnummer from medlem INNER JOIN leder ON leder.medlems_id=medlem.medlems_id ", conn);

                dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    Ledarlist.Add(new Medlem(dr.GetInt32(dr.GetOrdinal("medlems_id")), dr["förnamn"].ToString(), dr["efternamn"].ToString(), dr["adress"].ToString(), dr["epost"].ToString(), dr["telefon"].ToString(), dr["mobiltelefon"].ToString(), dr.GetBoolean(dr.GetOrdinal("fotograferas")), dr["kön"].ToString(), dr.GetInt32(dr.GetOrdinal("medlemstyp_id")), dr.GetDateTime(dr.GetOrdinal("personnummer"))));
                }
                return ledarna;
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
            listBox4.Items.Clear();
            lbxLedare.Items.Clear();
            lbxTgrupp.Items.Clear();
            cmbtgrupp.Items.Clear();
            medlemslist.Clear();
            träningslist.Clear();
            Närvarolist.Clear();
            Traningsgrupplist.Clear();
            Ledarlist.Clear();
            GetMedlemmar(medlemslist);
            GetTräningar(träningslist);
            Getnarvaro(Närvarolist);
            GetTraningsgrupp(Traningsgrupplist);
            GetLedare(Ledarlist);

            
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
            foreach (Traningsgrupp Tr in Traningsgrupplist)
            {
                lbxTgrupp.Items.Add(Tr);
            }
            lbxTgrupp.DisplayMember = "Showtraningsgrupp";
            foreach (Medlem L in Ledarlist)
            {
                lbxLedare.Items.Add(L);
            }
            lbxLedare.DisplayMember = "ShowMembers";

          

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


        private void btnUtskrift_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF dokument|*.pdf";
            saveFileDialog1.Title = "Spara ett dokument";
            saveFileDialog1.ShowDialog();

            filepath = saveFileDialog1.FileName;
            pdfutskriftdatum(filepath);
            System.Diagnostics.Process.Start(filepath);
            UpdateAll();






        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnTgrupp_Click(object sender, EventArgs e)
        {

            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF dokument|*.pdf";
            saveFileDialog1.Title = "Spara ett dokument";
            saveFileDialog1.ShowDialog();

            filepath = saveFileDialog1.FileName;
            

            pdfutskriftTgrupp(filepath);
         
            System.Diagnostics.Process.Start(filepath);
            UpdateAll();
        }

        private void btnLedare_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF dokument|*.pdf";
            saveFileDialog1.Title = "Spara ett dokument";
            saveFileDialog1.ShowDialog();

            filepath = saveFileDialog1.FileName;
            pdfutskriftledare(filepath);
            System.Diagnostics.Process.Start(filepath);
            UpdateAll();

           
            
        }

        private void lbxLedare_SelectedIndexChanged(object sender, EventArgs e)
        {
            ListBox Ledare = sender as ListBox;
            if (Ledare.SelectedIndex != -1)
            {
                lbxLedare.SelectedIndex = Ledare.SelectedIndex;
                Medlem L = (Medlem)lbxLedare.SelectedItem;
                medlems_id = L.Medlems_id;



            }
        }

        private void lbxTgrupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
    }
}
