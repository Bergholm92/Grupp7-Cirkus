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
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.button1 = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox3 = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.gbUtskrift = new System.Windows.Forms.GroupBox();
            this.btnTgrupp = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.lbxLedare = new System.Windows.Forms.ListBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lbxTgrupp = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.btnUtskrift = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.listBox4 = new System.Windows.Forms.ListBox();
            this.btnLedare = new System.Windows.Forms.Button();
            this.gbUtskrift.SuspendLayout();
            this.SuspendLayout();
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.Location = new System.Drawing.Point(643, 38);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(194, 238);
            this.listBox2.TabIndex = 1;
            this.listBox2.SelectedIndexChanged += new System.EventHandler(this.listBox2_SelectedIndexChanged_1);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(505, 130);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Närvaro";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(446, 238);
            this.listBox1.TabIndex = 3;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Träningar";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(640, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Medlemmar";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Akrobatik",
            "Jonglering",
            "Klot"});
            this.comboBox1.Location = new System.Drawing.Point(495, 38);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 6;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox3
            // 
            this.listBox3.FormattingEnabled = true;
            this.listBox3.Location = new System.Drawing.Point(12, 321);
            this.listBox3.Name = "listBox3";
            this.listBox3.Size = new System.Drawing.Size(135, 147);
            this.listBox3.TabIndex = 7;
            this.listBox3.SelectedIndexChanged += new System.EventHandler(this.listBox3_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 305);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Närvarolista";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(15, 475);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(121, 23);
            this.button2.TabIndex = 9;
            this.button2.Text = "Ta bort från aktivitet";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gbUtskrift
            // 
            this.gbUtskrift.Controls.Add(this.btnTgrupp);
            this.gbUtskrift.Controls.Add(this.label7);
            this.gbUtskrift.Controls.Add(this.lbxLedare);
            this.gbUtskrift.Controls.Add(this.label6);
            this.gbUtskrift.Controls.Add(this.label5);
            this.gbUtskrift.Controls.Add(this.lbxTgrupp);
            this.gbUtskrift.Controls.Add(this.label4);
            this.gbUtskrift.Controls.Add(this.textBox2);
            this.gbUtskrift.Controls.Add(this.btnUtskrift);
            this.gbUtskrift.Controls.Add(this.textBox1);
            this.gbUtskrift.Location = new System.Drawing.Point(415, 334);
            this.gbUtskrift.Name = "gbUtskrift";
            this.gbUtskrift.Size = new System.Drawing.Size(580, 345);
            this.gbUtskrift.TabIndex = 10;
            this.gbUtskrift.TabStop = false;
            this.gbUtskrift.Text = "Utskrift";
            // 
            // btnTgrupp
            // 
            this.btnTgrupp.Location = new System.Drawing.Point(405, 304);
            this.btnTgrupp.Name = "btnTgrupp";
            this.btnTgrupp.Size = new System.Drawing.Size(79, 35);
            this.btnTgrupp.TabIndex = 9;
            this.btnTgrupp.Text = "Skriv ut träningsgrupper";
            this.btnTgrupp.UseVisualStyleBackColor = true;
            this.btnTgrupp.Click += new System.EventHandler(this.btnTgrupp_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
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
            this.label6.Location = new System.Drawing.Point(7, 114);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Träningsgrupper:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
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
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(176, 70);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(142, 20);
            this.textBox2.TabIndex = 2;
            // 
            // btnUtskrift
            // 
            this.btnUtskrift.Location = new System.Drawing.Point(320, 304);
            this.btnUtskrift.Name = "btnUtskrift";
            this.btnUtskrift.Size = new System.Drawing.Size(79, 35);
            this.btnUtskrift.TabIndex = 1;
            this.btnUtskrift.Text = "Skriv ut datumintervall";
            this.btnUtskrift.UseVisualStyleBackColor = true;
            this.btnUtskrift.Click += new System.EventHandler(this.btnUtskrift_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(6, 70);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 0;
            // 
            // listBox4
            // 
            this.listBox4.FormattingEnabled = true;
            this.listBox4.Location = new System.Drawing.Point(289, 373);
            this.listBox4.Name = "listBox4";
            this.listBox4.Size = new System.Drawing.Size(120, 147);
            this.listBox4.TabIndex = 11;
            // 
            // btnLedare
            // 
            this.btnLedare.Location = new System.Drawing.Point(905, 638);
            this.btnLedare.Name = "btnLedare";
            this.btnLedare.Size = new System.Drawing.Size(79, 35);
            this.btnLedare.TabIndex = 10;
            this.btnLedare.Text = "Skriv ut ledare";
            this.btnLedare.UseVisualStyleBackColor = true;
            this.btnLedare.Click += new System.EventHandler(this.btnLedare_Click);
            // 
            // LedareForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1030, 716);
            this.Controls.Add(this.btnLedare);
            this.Controls.Add(this.listBox4);
            this.Controls.Add(this.gbUtskrift);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.listBox3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.listBox2);
            this.Name = "LedareForm";
            this.Text = "LedareForm";
            this.gbUtskrift.ResumeLayout(false);
            this.gbUtskrift.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ListBox listBox3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.GroupBox gbUtskrift;
        private System.Windows.Forms.Button btnUtskrift;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ListBox listBox4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.ListBox lbxTgrupp;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ListBox lbxLedare;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTgrupp;
        private System.Windows.Forms.Button btnLedare;
    }
}