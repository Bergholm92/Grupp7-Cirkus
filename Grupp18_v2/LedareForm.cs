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
using System.Text.RegularExpressions;

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
        string tgrupp;

        DateTime d1;
        DateTime d2;


        public LedareForm()
        {
            InitializeComponent();
            UpdateAll();
           


        }
        public string pdfutskriftdatum(string path)
        {
            try
            {
                //Skapar ett dokument som sedan utgör pdf-dokumentet.
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();
                //Öppnar connection och skriver ut SQL-frågan nedan. Denna process görs flertalet gånger till varje fråga.
                conn.Open();
                cmd = new NpgsqlCommand("SELECT beskrivning AS bes, datum AS dat, medlem.förnamn AS fn, medlem.efternamn AS en, medlem.personnummer AS pers from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id where datum BETWEEN @d1 AND @d2 ", conn);
                //Använder oss av olika parametrar för att kunna mata in värden på ett säkert sätt.
                d1 = Convert.ToDateTime(tbxdatum1.Text);
                d2 = Convert.ToDateTime(tbxdatum2.Text);
                cmd.Parameters.AddWithValue("@d1", d1);
                cmd.Parameters.AddWithValue("@d2", d2);
                using (dr = cmd.ExecuteReader())
                {
                    Paragraph p2 = new Paragraph("NÄRVAROKORT: "+ tbxdatum1.Text + " - " + tbxdatum2.Text +  " \n \n");
                    doc.Add(p2);
                    lbxutskrift.Items.Add("NÄRVAROKORT: " + tbxdatum1.Text + " - " + tbxdatum2.Text);
                    lbxutskrift.Items.Add(" ");
                    lbxutskrift.Items.Add("------------------------------------------------------");
                    while (dr.Read())
                    {
                        //Lägger till en paragraph till dokumentet som innehåller det vi hämtar från databasen.
                        Paragraph p1 = new Paragraph(dr["fn"].ToString() + " " + dr["en"].ToString() + " | " + dr["pers"].ToString() + " | " + dr["bes"].ToString() + " | " + dr["dat"].ToString());
                        doc.Add(p1);
                        lbxutskrift.Items.Add( dr["fn"].ToString() + " " + dr["en"].ToString() + " | " + dr["pers"].ToString() + " | " + dr["bes"].ToString() + " | " + dr["dat"].ToString());
                        lbxutskrift.Items.Add(" ");
                    }

                    dr.Close();
                }
                // Samma som ovan
                cmd = new NpgsqlCommand("SELECT medlem.förnamn as fn, medlem.efternamn as en from medlem INNER JOIN leder ON medlem.medlems_id = leder.medlems_id INNER JOIN traning ON leder.traning_id = traning.traning_id where traning.datum BETWEEN @d1 AND @d2", conn);
                cmd.Parameters.AddWithValue("@d1", d1);
                cmd.Parameters.AddWithValue("@d2", d2);

                using (dr = cmd.ExecuteReader())
                {
                    Paragraph p1 = new Paragraph(" \n" + "LEDARE:");
                    doc.Add(p1);
                    lbxutskrift.Items.Add(" \n" + "LEDARE:");
                    lbxutskrift.Items.Add(" ");
                    lbxutskrift.Items.Add("------------------------------------------------------");
                    while (dr.Read())

                    {
                        Paragraph p2 = new Paragraph(" \n" + dr["fn"].ToString() + " " + dr["en"].ToString() + " | ");
                        doc.Add(p2);
                        lbxutskrift.Items.Add(" \n" + dr["fn"].ToString() + " " + dr["en"].ToString() + " | ");
                        lbxutskrift.Items.Add(" ");

                    }
                    dr.Close();
                }
                // Samma som ovan
                cmd = new NpgsqlCommand("SELECT COUNT(narvaro.medlems_id) as antal, traning.beskrivning as beskriv from narvaro INNER JOIN traning ON traning.traning_id = narvaro.tranings_id where traning.datum BETWEEN @d1 AND @d2 GROUP BY traning.beskrivning ", conn);
                cmd.Parameters.AddWithValue("@d1", d1);
                cmd.Parameters.AddWithValue("@d2", d2);
                using (dr = cmd.ExecuteReader())
                {
                    Paragraph p1 = new Paragraph(" \n" + "");
                    doc.Add(p1);
                    
                    lbxutskrift.Items.Add(" ");
                    lbxutskrift.Items.Add("------------------------------------------------------");

                    while (dr.Read())

                    {
                        Paragraph p2 = new Paragraph(" \n" + dr["antal"].ToString() + " st.  Tränade:" + dr["beskriv"].ToString() + " | ");
                        doc.Add(p2);
                        lbxutskrift.Items.Add(" \n" + dr["antal"].ToString() + " st.  Tränade:" + dr["beskriv"].ToString() + " | ");
                        lbxutskrift.Items.Add(" ");
                    }
                    dr.Close();

                }
                // Samma som ovan
                cmd = new NpgsqlCommand("SELECT COUNT(traning.traningsgrupp_fk) as antalet, traningsgrupp.namn as namn from traning INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk WHERE traning.datum BETWEEN @d1 AND @d2 GROUP BY traningsgrupp.namn", conn);
                cmd.Parameters.AddWithValue("@d1", d1);
                cmd.Parameters.AddWithValue("@d2", d2);
                using (dr = cmd.ExecuteReader())
                {
                    Paragraph p1 = new Paragraph(" \n" + "");
                    doc.Add(p1);
                    lbxutskrift.Items.Add(" ");
                    lbxutskrift.Items.Add("------------------------------------------------------");
                    while (dr.Read())

                    {
                        Paragraph p2 = new Paragraph(" \n" + dr["antalet"].ToString() + " tillfällen tränade grupp:" + dr["namn"].ToString() + " | ");
                        lbxutskrift.Items.Add(" \n" + dr["antalet"].ToString() + " tillfällen tränade grupp:" + dr["namn"].ToString() + " | ");
                        lbxutskrift.Items.Add(" ");
                        doc.Add(p2);
                    }
                    //Stänger alla saker som dr:en, connectionen och dokumentet. Och skriver sedan ut en messagebox där det rapporteras att PDF-filen skapas. 
                    dr.Close();
                    conn.Close();
                    doc.Close();
                    MessageBox.Show("PDF filen skapades");



                }

                return path;
            }
            //catch
            //{
            //    MessageBox.Show("Fel inmatning");
                
            //     return null;
            //}
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }
            finally
            {
                conn.Close();
            }
        } //metod för att skriva ut baserat på datumintervall.
        public string pdfutskriftledare(string path)
        {
            Medlem L = (Medlem)lbxLedare.SelectedItem;
            try
            {
                //Exakt samma sätt som datum metoden. Bara att dessa parametrar nu matar in vilken ledare.
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();
                conn.Open();
                cmd = new NpgsqlCommand("SELECT beskrivning AS bes, datum AS dat, medlem.förnamn AS fn, medlem.efternamn AS en, medlem.personnummer AS pers from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id INNER JOIN leder on leder.traning_id = traning.traning_id where leder.medlems_id = @mid ORDER BY bes ", conn);

                cmd.Parameters.AddWithValue("@mid", medlems_id);
                using (dr = cmd.ExecuteReader())
                   
                {
                    
                    Paragraph p2 = new Paragraph("NÄRVAROKORT för: " + L.ShowMembers + " \n \n");
                    doc.Add(p2);
                    lbxutskrift.Items.Add("NÄRVAROKORT för: " + L.ShowMembers + " \n \n");
                    lbxutskrift.Items.Add("------------------------------------------------------");
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

                    return path;

                }
              
            }
            catch
            {
                MessageBox.Show("Ingen ledare är vald");
                return null;
            }
            finally
            {
                conn.Close();
            }
        } //metod för att skriva ut baserat på ledare.
        public string pdfutskriftTgrupp(string path)
        {
            try
            {
                //Denna metod blir lite annorlunda jämförelse med de andra. Eftersom man under just Träningsgrupp ville kunna använda en-eller flera så har vi skapat en for-loop
                int count = 0;
                int antal = Convert.ToInt32(lbxTgrupp.SelectedItems.Count);
                tarray = new Traningsgrupp[antal];
                //Vi kör först en foreach-loop där vi loopar igenom alla träningsgrupper som är selectade i listboxen.
                foreach (Traningsgrupp TG in lbxTgrupp.SelectedItems)
                {
                    for (int i = 0; i < 1; i++)
                    {
                        //Här har vi gjort en for-loop som helt enkelt lägger till varje träningsgrupp i en array som består av träningsgrupper.
                        tarray[count] = TG;
                        tgrupp =  tgrupp + " | " +  tarray[count].Showtraningsgrupp;
                    }
                    count++;
                }
                Document doc = new Document();
                PdfWriter.GetInstance(doc, new FileStream(path, FileMode.Create));
                doc.Open();
                conn.Open();
                
                Paragraph p2 = new Paragraph("NÄRVAROKORT för grupperna:"  + tgrupp + " \n \n");
                doc.Add(p2);
                //Här gör vi även en for-loop som för varje tarray-item kör den igenom och lägger då till tarray[i].Traningsgrupp_id till SQL frågan vilket då gör att vi får med varje träningsgrupp som är selectad.
                for (int i = 0; i < tarray.Length; i++)
                {
                    doc.Open();

                    cmd = new NpgsqlCommand("SELECT beskrivning AS bes, datum AS dat, medlem.förnamn AS fn, medlem.efternamn AS en, medlem.personnummer AS pers from traning INNER JOIN narvaro ON narvaro.tranings_id = traning.traning_id INNER JOIN medlem ON medlem.medlems_id = narvaro.medlems_id INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk where traningsgrupp.traningsgrupp_id = @tgid ORDER BY bes ", conn);
                    cmd.Parameters.AddWithValue("@tgid", tarray[i].Traningsgrupp_id);
                    using (dr = cmd.ExecuteReader())
                    {


                        while (dr.Read())
                        {
                            //Samma här lägger vi till alla valda stringar till paragraphen. 
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
                //Vi gör en for-loop för varje fråga som ovan för att kunna köra alla valda items.
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
                            Paragraph p1 = new Paragraph(" \n" + dr["antal"].ToString() + " st träningar   har genomförst av " + "  " + dr["namn"].ToString() + " gruppen");
                            doc.Add(p1);
                        }
                    }
                }
          
                doc.Close();
                conn.Close();
                return path;

            }
            catch
            {
                MessageBox.Show("Ingen träningsgrupp vald");
                return null;
            }
            finally
            {
                conn.Close();
            }
        } //metod för att skriva ut baserat på Träningsgrupper.






        private List<Medlem> GetMedlemmar(List<Medlem> medlemmar)
        {
           
            
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("SELECT * FROM medlem INNER JOIN ingar ON ingar.medlems_id=medlem.medlems_id WHERE ingar.traningsgrupp_id = @id; ", conn);

                if (cmbtgrupp.SelectedIndex > -1)
                {
                    Traningsgrupp TG;
                    TG = (Traningsgrupp)cmbtgrupp.SelectedItem;
                    cmd.Parameters.AddWithValue("@id", TG.Traningsgrupp_id);
                }
                else if (cmbtgrupp.SelectedIndex == -1)
                {
                    cmd.Parameters.AddWithValue("@id", 0);
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
        }//En metod för att hämta alla medlemmar.

        public List<Träning> GetTräningar(List<Träning> Träningar)
        {
            
            try
            {
                conn.Open();
                cmd = new NpgsqlCommand("Select traning_id, datum, beskrivning,plats_fk,traningsgrupp_fk, traningsgrupp.namn, plats.namn AS Plats from traning INNER JOIN traningsgrupp ON traningsgrupp.traningsgrupp_id = traning.traningsgrupp_fk INNER JOIN plats ON plats.plats_id=traning.plats_fk WHERE traning.traningsgrupp_fk = @tFK", conn);



                if (cmbtgrupp.SelectedIndex > -1)
                {
                    {
                        Traningsgrupp TG;
                        TG = (Traningsgrupp)cmbtgrupp.SelectedItem;

                        cmd.Parameters.AddWithValue("@tFK", TG.Traningsgrupp_id);
                    }

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
        }//En metod för att hämta alla träningar
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
        }//En metod för att hämta all närvaro

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
        }//En metod för att hämta alla träningsgrupper

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
        }//En metod för att hämta alla ledare.

        private void UpdateAll()
        {
            lbxtraningar.Items.Clear();
            lbxmedlemmar.Items.Clear();
            lbxnarvaro.Items.Clear();
            lbxutskrift.Items.Clear();
            lbxLedare.Items.Clear();
            lbxTgrupp.Items.Clear();
     
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
                lbxmedlemmar.Items.Add(m);
            }
            lbxmedlemmar.DisplayMember = "ShowMembers";

            foreach (Träning T in träningslist)
            {
                lbxtraningar.Items.Add(T);
            }
            lbxtraningar.DisplayMember = "Showtraning";
            foreach (Narvaro N in Närvarolist)
            {
                lbxnarvaro.Items.Add(N);
            }
            lbxnarvaro.DisplayMember = "Shownarvaro";
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
            cmbtgrupp.Items.Clear();
            foreach (Traningsgrupp TG in Traningsgrupplist)
            {
                cmbtgrupp.Items.Add(TG);
            }
            cmbtgrupp.DisplayMember = "Showtraningsgrupp";

            


        }//En update-metod som helt enkelt uppdaterar allt som behövs uppdatera i gränssnittet men även listor.
        private void UpdateAll2()//En annan update-metod som har i fokus att endast beröra närvarolistan vilket vi gjorde i en separat metod.
        {
            lbxnarvaro.Items.Clear();
            Närvarolist.Clear();
            Getnarvaro(Närvarolist);
            lbxutskrift.Items.Clear();
            foreach (Narvaro N in Närvarolist)
            {
                lbxnarvaro.Items.Add(N);
            }
            lbxnarvaro.DisplayMember = "Shownarvaro";
        }

   

        private void button1_Click(object sender, EventArgs e)
        {
            Narvaro N = new Narvaro(träning, medlems_id);
            N.Addnarvaro(träning, medlems_id);//Här finns en metod som lägger till närvaro till närvaro-listan i databasen.
            UpdateAll2();
           
            

        }

        private void listBox2_SelectedIndexChanged_1(object sender, EventArgs e)//När listboxen ändras så kommer medlems_id få det värde som det selectade itemet har.
        {
            ListBox L = sender as ListBox;
            if (L.SelectedIndex != -1)
            {
                lbxmedlemmar.SelectedIndex = L.SelectedIndex;
                Medlem M = (Medlem)lbxmedlemmar.SelectedItem;
                medlems_id = M.Medlems_id;

               
                

            }
        }

        public void listBox1_SelectedIndexChanged(object sender, EventArgs e)//När listboxen ändras så kommer int traning få det värde som det selectade itemet har.
        {
           
            ListBox C = sender as ListBox;
            if (C.SelectedIndex != -1)
            {
                lbxtraningar.SelectedIndex = C.SelectedIndex;
                Träning T = (Träning)lbxtraningar.SelectedItem;
                träning = T.Tränings_id;
                Närvarolist.Clear();
                lbxnarvaro.Items.Clear();
                UpdateAll2();

            }
            

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateAll();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Narvaro N = new Narvaro(träning, medlems_id);
            N.Removenarvaro(träning, medlems_id);//Även här finns en metod för att tabort närvaro 
            UpdateAll2();
        }

        private void listBox3_SelectedIndexChanged(object sender, EventArgs e)//Även här blir medlems_id inten det värdet som selectade itemet har.
        {
            ListBox M = sender as ListBox;
            if (M.SelectedIndex != -1)
            {
                lbxnarvaro.SelectedIndex = M.SelectedIndex;
                Narvaro N = (Narvaro)lbxnarvaro.SelectedItem;
                träning = N.Traning;
                medlems_id = N.Medlem;
                 
               


            }
        }


        private void btnUtskrift_Click(object sender, EventArgs e)//Knappen för att skriva ut en utskrift baserat på datumintervall.
        {
            Regex datum = new Regex("[0-9]");
            Regex datumbokstav = new Regex("[a-ö]");
            Match datumsif1 =  datum.Match(tbxdatum1.Text);
            Match datumbok1 = datumbokstav.Match(tbxdatum1.Text);
            Match datumsif2 = datum.Match(tbxdatum2.Text);
            Match datumsbok2 = datumbokstav.Match(tbxdatum2.Text);


            
                if (datumsif1.Success && !datumbok1.Success && !datumsbok2.Success && datumsif2.Success)
                {
                    UpdateAll();
                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();//Här kommer dialogrutan upp så man kan spara sitt dokument på vald plats.
                    saveFileDialog1.Filter = "PDF dokument|*.pdf";
                    saveFileDialog1.Title = "Spara ett dokument";
                    saveFileDialog1.ShowDialog();

                    filepath = saveFileDialog1.FileName; //En string som helt enkelt sparar saveFileDialog1.FileName så vi kan använda den till de metoden som vill ha en filepath.
                    pdfutskriftdatum(filepath);
                    System.Diagnostics.Process.Start(filepath);


                }
                else
                {
                    MessageBox.Show("Fel inmatning");
                }
            

           





        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            
        }

        private void btnTgrupp_Click(object sender, EventArgs e)//Knappen för att skriva ut en utskrift baserat på träningsgrupper. Samma saker sker här som i knappen ovan. 
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
            UpdateAll2();
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "PDF dokument|*.pdf";
            saveFileDialog1.Title = "Spara ett dokument";
            saveFileDialog1.ShowDialog();

            filepath = saveFileDialog1.FileName;
            pdfutskriftledare(filepath);
            System.Diagnostics.Process.Start(filepath);
            

           
            
        }//Knappen för att skriva ut en utskrift baserat på Ledare. Samma saker sker här som i datumknappen.

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


        private void cmbtgrupp_SelectedIndexChanged(object sender, EventArgs e)
        {
            Traningsgrupp TG;
            TG = (Traningsgrupp)cmbtgrupp.SelectedItem;
            lbltraningar.Text = "Träningsgrupp: " + TG.Showtraningsgrupp;
            UpdateAll();
            UpdateAll2();
        
        }// Comboboxen som visar träningsgrupper. En label ändras beroende på den träningsgruppen man valde. 

        private void LedareForm_Load(object sender, EventArgs e)
        {

        }
    }
}
