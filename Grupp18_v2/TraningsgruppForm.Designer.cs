namespace Grupp18_v2
{
    partial class TraningsgruppForm
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
            this.btnIngar = new System.Windows.Forms.Button();
            this.lbxTraningsgrupp = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // lbxMedlem
            // 
            this.lbxMedlem.FormattingEnabled = true;
            this.lbxMedlem.Location = new System.Drawing.Point(12, 33);
            this.lbxMedlem.Name = "lbxMedlem";
            this.lbxMedlem.Size = new System.Drawing.Size(170, 251);
            this.lbxMedlem.TabIndex = 0;
            this.lbxMedlem.SelectedIndexChanged += new System.EventHandler(this.lbxMedlem_SelectedIndexChanged);
            // 
            // btnIngar
            // 
            this.btnIngar.Location = new System.Drawing.Point(208, 118);
            this.btnIngar.Name = "btnIngar";
            this.btnIngar.Size = new System.Drawing.Size(88, 53);
            this.btnIngar.TabIndex = 1;
            this.btnIngar.Text = "Lägg till i träningsgrupp";
            this.btnIngar.UseVisualStyleBackColor = true;
            this.btnIngar.Click += new System.EventHandler(this.btnIngar_Click);
            // 
            // lbxTraningsgrupp
            // 
            this.lbxTraningsgrupp.FormattingEnabled = true;
            this.lbxTraningsgrupp.Location = new System.Drawing.Point(315, 35);
            this.lbxTraningsgrupp.Name = "lbxTraningsgrupp";
            this.lbxTraningsgrupp.Size = new System.Drawing.Size(159, 251);
            this.lbxTraningsgrupp.TabIndex = 2;
            this.lbxTraningsgrupp.SelectedIndexChanged += new System.EventHandler(this.lbxTraningsgrupp_SelectedIndexChanged);
            // 
            // TraningsgruppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(486, 354);
            this.Controls.Add(this.lbxTraningsgrupp);
            this.Controls.Add(this.btnIngar);
            this.Controls.Add(this.lbxMedlem);
            this.Name = "TraningsgruppForm";
            this.Text = "TraningsgruppForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lbxMedlem;
        private System.Windows.Forms.Button btnIngar;
        private System.Windows.Forms.ListBox lbxTraningsgrupp;
    }
}