namespace Grupp18_v2
{
    partial class Form1
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
            this.lblWelcome = new System.Windows.Forms.Label();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btnLedare = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblWelcome
            // 
            this.lblWelcome.AutoSize = true;
            this.lblWelcome.Location = new System.Drawing.Point(138, 46);
            this.lblWelcome.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblWelcome.Name = "lblWelcome";
            this.lblWelcome.Size = new System.Drawing.Size(169, 13);
            this.lblWelcome.TabIndex = 0;
            this.lblWelcome.Text = "Välkommen till Cirkus Kul och Bus!";
            // 
            // btnAdmin
            // 
            this.btnAdmin.Location = new System.Drawing.Point(140, 98);
            this.btnAdmin.Margin = new System.Windows.Forms.Padding(2);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(80, 32);
            this.btnAdmin.TabIndex = 1;
            this.btnAdmin.Text = "Administratör";
            this.btnAdmin.UseVisualStyleBackColor = true;
            // 
            // btnLedare
            // 
            this.btnLedare.Location = new System.Drawing.Point(239, 98);
            this.btnLedare.Margin = new System.Windows.Forms.Padding(2);
            this.btnLedare.Name = "btnLedare";
            this.btnLedare.Size = new System.Drawing.Size(80, 32);
            this.btnLedare.TabIndex = 2;
            this.btnLedare.Text = "Ledare";
            this.btnLedare.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 236);
            this.Controls.Add(this.btnLedare);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.lblWelcome);
            this.Name = "Form1";
            this.Text = "Cirkus Kul & Bus";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblWelcome;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btnLedare;
    }
}

