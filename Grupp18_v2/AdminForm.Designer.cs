namespace Grupp18_v2
{
    partial class AdminForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbxMedlem = new System.Windows.Forms.ListBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tbxfnamn = new System.Windows.Forms.TextBox();
            this.tbxenamn = new System.Windows.Forms.TextBox();
            this.tbxadress = new System.Windows.Forms.TextBox();
            this.tbxepost = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbxtele = new System.Windows.Forms.TextBox();
            this.tbxmobil = new System.Windows.Forms.TextBox();
            this.tbxprsnummer = new System.Windows.Forms.TextBox();
            this.tbxmedlemsid = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lblMId = new System.Windows.Forms.Label();
            this.btnChange = new System.Windows.Forms.Button();
            this.cbxfoto = new System.Windows.Forms.CheckBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.cbxtyp = new System.Windows.Forms.ComboBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnTraning = new System.Windows.Forms.Button();
            this.cmbkön = new System.Windows.Forms.ComboBox();
            this.lblPersonEx = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lbxMedlem
            // 
            this.lbxMedlem.FormattingEnabled = true;
            this.lbxMedlem.ItemHeight = 16;
            this.lbxMedlem.Location = new System.Drawing.Point(560, 57);
            this.lbxMedlem.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lbxMedlem.Name = "lbxMedlem";
            this.lbxMedlem.Size = new System.Drawing.Size(273, 292);
            this.lbxMedlem.TabIndex = 0;
            this.lbxMedlem.SelectedIndexChanged += new System.EventHandler(this.lbxMedlem_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(17, 321);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(100, 28);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Lägg till";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 37);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Medlemmar";
            // 
            // tbxfnamn
            // 
            this.tbxfnamn.Location = new System.Drawing.Point(17, 71);
            this.tbxfnamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxfnamn.Name = "tbxfnamn";
            this.tbxfnamn.Size = new System.Drawing.Size(132, 22);
            this.tbxfnamn.TabIndex = 3;
            // 
            // tbxenamn
            // 
            this.tbxenamn.Location = new System.Drawing.Point(17, 130);
            this.tbxenamn.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxenamn.Name = "tbxenamn";
            this.tbxenamn.Size = new System.Drawing.Size(132, 22);
            this.tbxenamn.TabIndex = 4;
            // 
            // tbxadress
            // 
            this.tbxadress.Location = new System.Drawing.Point(17, 181);
            this.tbxadress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxadress.Name = "tbxadress";
            this.tbxadress.Size = new System.Drawing.Size(132, 22);
            this.tbxadress.TabIndex = 5;
            // 
            // tbxepost
            // 
            this.tbxepost.Location = new System.Drawing.Point(17, 235);
            this.tbxepost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxepost.Name = "tbxepost";
            this.tbxepost.Size = new System.Drawing.Size(132, 22);
            this.tbxepost.TabIndex = 6;
            this.tbxepost.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 17);
            this.label2.TabIndex = 7;
            this.label2.Text = "Förnamn";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 111);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Efternamn";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 161);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Adress";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 215);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 17);
            this.label5.TabIndex = 10;
            this.label5.Text = "Epost";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(229, 52);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(56, 17);
            this.label7.TabIndex = 12;
            this.label7.Text = "Telefon";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(229, 111);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mobiltelefon";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(229, 161);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(89, 17);
            this.label9.TabIndex = 14;
            this.label9.Text = "Fotograferas";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(229, 215);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(33, 17);
            this.label10.TabIndex = 15;
            this.label10.Text = "Kön";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(394, 23);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 17);
            this.label11.TabIndex = 16;
            this.label11.Text = "Personnummer";
            // 
            // tbxtele
            // 
            this.tbxtele.Location = new System.Drawing.Point(233, 71);
            this.tbxtele.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxtele.Name = "tbxtele";
            this.tbxtele.Size = new System.Drawing.Size(132, 22);
            this.tbxtele.TabIndex = 17;
            // 
            // tbxmobil
            // 
            this.tbxmobil.Location = new System.Drawing.Point(233, 130);
            this.tbxmobil.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxmobil.Name = "tbxmobil";
            this.tbxmobil.Size = new System.Drawing.Size(132, 22);
            this.tbxmobil.TabIndex = 18;
            // 
            // tbxprsnummer
            // 
            this.tbxprsnummer.Location = new System.Drawing.Point(397, 71);
            this.tbxprsnummer.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxprsnummer.Name = "tbxprsnummer";
            this.tbxprsnummer.Size = new System.Drawing.Size(83, 22);
            this.tbxprsnummer.TabIndex = 21;
            // 
            // tbxmedlemsid
            // 
            this.tbxmedlemsid.Location = new System.Drawing.Point(397, 129);
            this.tbxmedlemsid.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.tbxmedlemsid.Name = "tbxmedlemsid";
            this.tbxmedlemsid.ReadOnly = true;
            this.tbxmedlemsid.Size = new System.Drawing.Size(100, 22);
            this.tbxmedlemsid.TabIndex = 22;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(397, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 17);
            this.label6.TabIndex = 23;
            this.label6.Text = "Medlemsid";
            // 
            // lblMId
            // 
            this.lblMId.AutoSize = true;
            this.lblMId.Location = new System.Drawing.Point(400, 158);
            this.lblMId.Name = "lblMId";
            this.lblMId.Size = new System.Drawing.Size(103, 17);
            this.lblMId.TabIndex = 25;
            this.lblMId.Text = "MedlemstypsID";
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(125, 321);
            this.btnChange.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(100, 28);
            this.btnChange.TabIndex = 28;
            this.btnChange.Text = "Ändra";
            this.btnChange.UseVisualStyleBackColor = true;
            this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
            // 
            // cbxfoto
            // 
            this.cbxfoto.AutoSize = true;
            this.cbxfoto.Location = new System.Drawing.Point(233, 181);
            this.cbxfoto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxfoto.Name = "cbxfoto";
            this.cbxfoto.Size = new System.Drawing.Size(157, 21);
            this.cbxfoto.TabIndex = 29;
            this.cbxfoto.Text = "Vill du fotograferas?";
            this.cbxfoto.UseVisualStyleBackColor = true;
            this.cbxfoto.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(233, 321);
            this.btnRemove.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(100, 28);
            this.btnRemove.TabIndex = 31;
            this.btnRemove.Text = "Ta bort";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.button2_Click);
            // 
            // cbxtyp
            // 
            this.cbxtyp.FormattingEnabled = true;
            this.cbxtyp.Items.AddRange(new object[] {
            "Medlem",
            "Prova-På",
            "Cirkusvän"});
            this.cbxtyp.Location = new System.Drawing.Point(397, 215);
            this.cbxtyp.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxtyp.Name = "cbxtyp";
            this.cbxtyp.Size = new System.Drawing.Size(93, 24);
            this.cbxtyp.TabIndex = 32;
            this.cbxtyp.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // textBox11
            // 
            this.textBox11.Location = new System.Drawing.Point(397, 178);
            this.textBox11.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(92, 22);
            this.textBox11.TabIndex = 24;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(341, 321);
            this.btnClear.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(100, 28);
            this.btnClear.TabIndex = 33;
            this.btnClear.Text = "Rensa";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnTraning
            // 
            this.btnTraning.Location = new System.Drawing.Point(620, 357);
            this.btnTraning.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnTraning.Name = "btnTraning";
            this.btnTraning.Size = new System.Drawing.Size(155, 63);
            this.btnTraning.TabIndex = 34;
            this.btnTraning.Text = "Lägg till medlemmar i träningsgrupp";
            this.btnTraning.UseVisualStyleBackColor = true;
            this.btnTraning.Click += new System.EventHandler(this.btnTraning_Click);
            // 
            // cmbkön
            // 
            this.cmbkön.FormattingEnabled = true;
            this.cmbkön.Items.AddRange(new object[] {
            "Man",
            "Kvinna"});
            this.cmbkön.Location = new System.Drawing.Point(233, 235);
            this.cmbkön.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbkön.Name = "cmbkön";
            this.cmbkön.Size = new System.Drawing.Size(132, 24);
            this.cmbkön.TabIndex = 35;
            // 
            // lblPersonEx
            // 
            this.lblPersonEx.AutoSize = true;
            this.lblPersonEx.Location = new System.Drawing.Point(393, 50);
            this.lblPersonEx.Name = "lblPersonEx";
            this.lblPersonEx.Size = new System.Drawing.Size(106, 17);
            this.lblPersonEx.TabIndex = 36;
            this.lblPersonEx.Text = "(ÅÅÅÅ-MM-DD)";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(851, 519);
            this.Controls.Add(this.lblPersonEx);
            this.Controls.Add(this.cmbkön);
            this.Controls.Add(this.btnTraning);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.cbxtyp);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.cbxfoto);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.lblMId);
            this.Controls.Add(this.textBox11);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.tbxmedlemsid);
            this.Controls.Add(this.tbxprsnummer);
            this.Controls.Add(this.tbxmobil);
            this.Controls.Add(this.tbxtele);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tbxepost);
            this.Controls.Add(this.tbxadress);
            this.Controls.Add(this.tbxenamn);
            this.Controls.Add(this.tbxfnamn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.lbxMedlem);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMedlem;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbxfnamn;
        private System.Windows.Forms.TextBox tbxenamn;
        private System.Windows.Forms.TextBox tbxadress;
        private System.Windows.Forms.TextBox tbxepost;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbxtele;
        private System.Windows.Forms.TextBox tbxmobil;
        private System.Windows.Forms.TextBox tbxprsnummer;
        private System.Windows.Forms.TextBox tbxmedlemsid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblMId;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.CheckBox cbxfoto;
        private System.Windows.Forms.Button btnRemove;
        private System.Windows.Forms.ComboBox cbxtyp;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnTraning;
        private System.Windows.Forms.ComboBox cmbkön;
        private System.Windows.Forms.Label lblPersonEx;
    }
}