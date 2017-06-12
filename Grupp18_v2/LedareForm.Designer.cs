namespace Grupp18_v2
{
    partial class LedareForm
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
            this.lbxmedlemmar = new System.Windows.Forms.ListBox();
            this.btnnarvaro = new System.Windows.Forms.Button();
            this.lbxtraningar = new System.Windows.Forms.ListBox();
            this.lbltraningar = new System.Windows.Forms.Label();
            this.lblmedlemmar = new System.Windows.Forms.Label();
            this.lbxnarvaro = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btntabort = new System.Windows.Forms.Button();
            this.gbUtskrift = new System.Windows.Forms.GroupBox();
            this.btnTgrupp = new System.Windows.Forms.Button();
            this.btnLedare = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbxLedare = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxTgrupp = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbxdatum2 = new System.Windows.Forms.TextBox();
            this.btnUtskrift = new System.Windows.Forms.Button();
            this.tbxdatum1 = new System.Windows.Forms.TextBox();
            this.cmbtgrupp = new System.Windows.Forms.ComboBox();
            this.lbxutskrift = new System.Windows.Forms.ListBox();
            this.gbUtskrift.SuspendLayout();
            this.SuspendLayout();
            // 
            // lbxmedlemmar
            // 
            this.lbxmedlemmar.FormattingEnabled = true;
            this.lbxmedlemmar.Location = new System.Drawing.Point(643, 38);
            this.lbxmedlemmar.Name = "lbxmedlemmar";
            this.lbxmedlemmar.Size = new System.Drawing.Size(194, 238);
            this.lbxmedlemmar.TabIndex = 1;
            this.lbxmedlemmar.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged_1);
            // 
            // btnnarvaro
            // 
            this.btnnarvaro.Location = new System.Drawing.Point(505, 130);
            this.btnnarvaro.Name = "btnnarvaro";
            this.btnnarvaro.Size = new System.Drawing.Size(75, 23);
            this.btnnarvaro.TabIndex = 2;
            this.btnnarvaro.Text = "Närvaro";
            this.btnnarvaro.UseVisualStyleBackColor = true;
            this.btnnarvaro.Click += new System.EventHandler(this.button1_Click);
            // 
            // lbxtraningar
            // 
            this.lbxtraningar.FormattingEnabled = true;
            this.lbxtraningar.Location = new System.Drawing.Point(12, 38);
            this.lbxtraningar.Name = "lbxtraningar";
            this.lbxtraningar.Size = new System.Drawing.Size(446, 238);
            this.lbxtraningar.TabIndex = 3;
            this.lbxtraningar.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // lbltraningar
            // 
            this.lbltraningar.AutoSize = true;
            this.lbltraningar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbltraningar.Location = new System.Drawing.Point(12, 17);
            this.lbltraningar.Name = "lbltraningar";
            this.lbltraningar.Size = new System.Drawing.Size(69, 15);
            this.lbltraningar.TabIndex = 4;
            this.lbltraningar.Text = "Träningar";
            // 
            // lblmedlemmar
            // 
            this.lblmedlemmar.AutoSize = true;
            this.lblmedlemmar.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmedlemmar.Location = new System.Drawing.Point(640, 17);
            this.lblmedlemmar.Name = "lblmedlemmar";
            this.lblmedlemmar.Size = new System.Drawing.Size(84, 15);
            this.lblmedlemmar.TabIndex = 5;
            this.lblmedlemmar.Text = "Medlemmar";
            // 
            // lbxnarvaro
            // 
            this.lbxnarvaro.FormattingEnabled = true;
            this.lbxnarvaro.Location = new System.Drawing.Point(12, 321);
            this.lbxnarvaro.Name = "lbxnarvaro";
            this.lbxnarvaro.Size = new System.Drawing.Size(135, 147);
            this.lbxnarvaro.TabIndex = 7;
            this.lbxnarvaro.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Närvarolista";
            // 
            // btntabort
            // 
            this.btntabort.Location = new System.Drawing.Point(15, 475);
            this.btntabort.Name = "btntabort";
            this.btntabort.Size = new System.Drawing.Size(121, 23);
            this.btntabort.TabIndex = 9;
            this.btntabort.Text = "Ta bort från aktivitet";
            this.btntabort.UseVisualStyleBackColor = true;
            this.btntabort.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbUtskrift
            // 
            this.gbUtskrift.Controls.Add(this.btnTgrupp);
            this.gbUtskrift.Controls.Add(this.btnLedare);
            this.gbUtskrift.Controls.Add(this.label7);
            this.gbUtskrift.Controls.Add(this.lbxLedare);
            this.gbUtskrift.Controls.Add(this.label6);
            this.gbUtskrift.Controls.Add(this.label5);
            this.gbUtskrift.Controls.Add(this.lbxTgrupp);
            this.gbUtskrift.Controls.Add(this.label4);
            this.gbUtskrift.Controls.Add(this.tbxdatum2);
            this.gbUtskrift.Controls.Add(this.btnUtskrift);
            this.gbUtskrift.Controls.Add(this.tbxdatum1);
            this.gbUtskrift.Location = new System.Drawing.Point(415, 334);
            this.gbUtskrift.Name = "gbUtskrift";
            this.gbUtskrift.Size = new System.Drawing.Size(580, 345);
            this.gbUtskrift.TabIndex = 10;
            this.gbUtskrift.TabStop = false;
            this.gbUtskrift.Text = "Utskrift";
            // 
            // btnTgrupp
            // 
            this.btnTgrupp.Location = new System.Drawing.Point(15, 304);
            this.btnTgrupp.Name = "btnTgrupp";
            this.btnTgrupp.Size = new System.Drawing.Size(79, 35);
            this.btnTgrupp.TabIndex = 9;
            this.btnTgrupp.Text = "Skriv ut träningsgrupper";
            this.btnTgrupp.UseVisualStyleBackColor = true;
            this.btnTgrupp.Click += new System.EventHandler(this.btnTgrupp_Click);
            // 
            // btnLedare
            // 
            this.btnLedare.Location = new System.Drawing.Point(205, 299);
            this.btnLedare.Name = "btnLedare";
            this.btnLedare.Size = new System.Drawing.Size(79, 35);
            this.btnLedare.TabIndex = 10;
            this.btnLedare.Text = "Skriv ut ledare";
            this.btnLedare.UseVisualStyleBackColor = true;
            this.btnLedare.Click += new System.EventHandler(this.btnLedare_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(173, 114);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 13);
            this.label7.TabIndex = 8;
            this.label7.Text = "Ledare";
            // 
            // lbxLedare
            // 
            this.lbxLedare.FormattingEnabled = true;
            this.lbxLedare.Location = new System.Drawing.Point(176, 133);
            this.lbxLedare.Name = "lbxLedare";
            this.lbxLedare.Size = new System.Drawing.Size(142, 160);
            this.lbxLedare.TabIndex = 7;
            this.lbxLedare.SelectedIndexChanged += new System.EventHandler(this.lbxLedare_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(7, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Träningsgrupper:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 51);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Datumintervall:";
            // 
            // lbxTgrupp
            // 
            this.lbxTgrupp.FormattingEnabled = true;
            this.lbxTgrupp.Location = new System.Drawing.Point(6, 133);
            this.lbxTgrupp.Name = "lbxTgrupp";
            this.lbxTgrupp.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbxTgrupp.Size = new System.Drawing.Size(121, 160);
            this.lbxTgrupp.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 73);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "mellan";
            // 
            // tbxdatum2
            // 
            this.tbxdatum2.Location = new System.Drawing.Point(176, 70);
            this.tbxdatum2.Name = "tbxdatum2";
            this.tbxdatum2.Size = new System.Drawing.Size(142, 20);
            this.tbxdatum2.TabIndex = 2;
            this.tbxdatum2.Text = "2018-01-01";
            // 
            // btnUtskrift
            // 
            this.btnUtskrift.Location = new System.Drawing.Point(336, 62);
            this.btnUtskrift.Name = "btnUtskrift";
            this.btnUtskrift.Size = new System.Drawing.Size(86, 35);
            this.btnUtskrift.TabIndex = 1;
            this.btnUtskrift.Text = "Skriv ut datumintervall";
            this.btnUtskrift.UseVisualStyleBackColor = true;
            this.btnUtskrift.Click += new System.EventHandler(this.btnUtskrift_Click);
            // 
            // tbxdatum1
            // 
            this.tbxdatum1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tbxdatum1.Location = new System.Drawing.Point(6, 70);
            this.tbxdatum1.Name = "tbxdatum1";
            this.tbxdatum1.Size = new System.Drawing.Size(121, 20);
            this.tbxdatum1.TabIndex = 0;
            this.tbxdatum1.Text = "2015-01-01";
            // 
            // cmbtgrupp
            // 
            this.cmbtgrupp.FormattingEnabled = true;
            this.cmbtgrupp.Location = new System.Drawing.Point(490, 38);
            this.cmbtgrupp.Name = "cmbtgrupp";
            this.cmbtgrupp.Size = new System.Drawing.Size(121, 21);
            this.cmbtgrupp.TabIndex = 12;
            this.cmbtgrupp.SelectedIndexChanged += new System.EventHandler(this.cmbtgrupp_SelectedIndexChanged);
            // 
            // lbxutskrift
            // 
            this.lbxutskrift.FormattingEnabled = true;
            this.lbxutskrift.HorizontalScrollbar = true;
            this.lbxutskrift.Location = new System.Drawing.Point(886, 38);
            this.lbxutskrift.Name = "lbxutskrift";
            this.lbxutskrift.ScrollAlwaysVisible = true;
            this.lbxutskrift.SelectionMode = System.Windows.Forms.SelectionMode.None;
            this.lbxutskrift.Size = new System.Drawing.Size(441, 511);
            this.lbxutskrift.TabIndex = 13;
            // 
            // LedareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1323, 684);
            this.Controls.Add(this.lbxutskrift);
            this.Controls.Add(this.cmbtgrupp);
            this.Controls.Add(this.gbUtskrift);
            this.Controls.Add(this.btntabort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbxnarvaro);
            this.Controls.Add(this.lblmedlemmar);
            this.Controls.Add(this.lbltraningar);
            this.Controls.Add(this.lbxtraningar);
            this.Controls.Add(this.btnnarvaro);
            this.Controls.Add(this.lbxmedlemmar);
            this.Name = "LedareForm";
            this.Text = "LedareForm";
            this.Load += new System.EventHandler(this.LedareForm_Load);
            this.gbUtskrift.ResumeLayout(false);
            this.gbUtskrift.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox lbxmedlemmar;
        private System.Windows.Forms.Button btnnarvaro;
        private System.Windows.Forms.ListBox lbxtraningar;
        private System.Windows.Forms.Label lbltraningar;
        private System.Windows.Forms.Label lblmedlemmar;
        private System.Windows.Forms.ListBox lbxnarvaro;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btntabort;
        private System.Windows.Forms.GroupBox gbUtskrift;
        private System.Windows.Forms.Button btnUtskrift;
        private System.Windows.Forms.TextBox tbxdatum1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbxdatum2;
        private System.Windows.Forms.ListBox lbxTgrupp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbxLedare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTgrupp;
        private System.Windows.Forms.Button btnLedare;
        private System.Windows.Forms.ComboBox cmbtgrupp;
        private System.Windows.Forms.ListBox lbxutskrift;
    }
}