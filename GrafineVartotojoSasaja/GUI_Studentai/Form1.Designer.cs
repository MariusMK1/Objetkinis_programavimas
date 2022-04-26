namespace GUI_Studentai
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
            this.rezultatai = new System.Windows.Forms.RichTextBox();
            this.ivesti = new System.Windows.Forms.Button();
            this.spausdinti = new System.Windows.Forms.Button();
            this.skaiciuoti = new System.Windows.Forms.Button();
            this.rasti = new System.Windows.Forms.Button();
            this.Baigti = new System.Windows.Forms.Button();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.rezultatas = new System.Windows.Forms.Label();
            this.pavardeVardas = new System.Windows.Forms.Label();
            this.pavardeVrd = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // rezultatai
            // 
            this.rezultatai.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatai.Location = new System.Drawing.Point(12, 12);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(598, 406);
            this.rezultatai.TabIndex = 0;
            this.rezultatai.Text = "";
            // 
            // ivesti
            // 
            this.ivesti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.ivesti.Location = new System.Drawing.Point(636, 12);
            this.ivesti.Name = "ivesti";
            this.ivesti.Size = new System.Drawing.Size(158, 43);
            this.ivesti.TabIndex = 1;
            this.ivesti.Text = "Įvesti";
            this.ivesti.UseVisualStyleBackColor = true;
            this.ivesti.Click += new System.EventHandler(this.ivesti_Click);
            // 
            // spausdinti
            // 
            this.spausdinti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.spausdinti.Location = new System.Drawing.Point(636, 74);
            this.spausdinti.Name = "spausdinti";
            this.spausdinti.Size = new System.Drawing.Size(158, 42);
            this.spausdinti.TabIndex = 2;
            this.spausdinti.Text = "Spausdinti";
            this.spausdinti.UseVisualStyleBackColor = true;
            this.spausdinti.Click += new System.EventHandler(this.Spausdinti_Click);
            // 
            // skaiciuoti
            // 
            this.skaiciuoti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaiciuoti.Location = new System.Drawing.Point(636, 207);
            this.skaiciuoti.Name = "skaiciuoti";
            this.skaiciuoti.Size = new System.Drawing.Size(158, 42);
            this.skaiciuoti.TabIndex = 3;
            this.skaiciuoti.Text = "Skaičiuoti";
            this.skaiciuoti.UseVisualStyleBackColor = true;
            this.skaiciuoti.Click += new System.EventHandler(this.skaiciuoti_Click);
            // 
            // rasti
            // 
            this.rasti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rasti.Location = new System.Drawing.Point(640, 375);
            this.rasti.Name = "rasti";
            this.rasti.Size = new System.Drawing.Size(154, 43);
            this.rasti.TabIndex = 4;
            this.rasti.Text = "Rasti";
            this.rasti.UseVisualStyleBackColor = true;
            this.rasti.Click += new System.EventHandler(this.rasti_Click);
            // 
            // Baigti
            // 
            this.Baigti.Font = new System.Drawing.Font("Times New Roman", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.Baigti.Location = new System.Drawing.Point(640, 463);
            this.Baigti.Name = "Baigti";
            this.Baigti.Size = new System.Drawing.Size(154, 43);
            this.Baigti.TabIndex = 5;
            this.Baigti.Text = "Baigti";
            this.Baigti.UseVisualStyleBackColor = true;
            this.Baigti.Click += new System.EventHandler(this.Baigti_Click);
            // 
            // vertinimai
            // 
            this.vertinimai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(636, 146);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(184, 30);
            this.vertinimai.TabIndex = 6;
            this.vertinimai.Text = "Pasirinkite pažymį";
            // 
            // rezultatas
            // 
            this.rezultatas.AutoSize = true;
            this.rezultatas.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatas.ForeColor = System.Drawing.Color.Blue;
            this.rezultatas.Location = new System.Drawing.Point(636, 303);
            this.rezultatas.Name = "rezultatas";
            this.rezultatas.Size = new System.Drawing.Size(184, 19);
            this.rezultatas.TabIndex = 7;
            this.rezultatas.Text = "Čia bus parodyti rezultatai";
            // 
            // pavardeVardas
            // 
            this.pavardeVardas.AutoSize = true;
            this.pavardeVardas.Font = new System.Drawing.Font("Times New Roman", 16F, System.Drawing.FontStyle.Bold);
            this.pavardeVardas.ForeColor = System.Drawing.SystemColors.ControlText;
            this.pavardeVardas.Location = new System.Drawing.Point(25, 449);
            this.pavardeVardas.Name = "pavardeVardas";
            this.pavardeVardas.Size = new System.Drawing.Size(182, 25);
            this.pavardeVardas.TabIndex = 8;
            this.pavardeVardas.Text = "Pavardė ir vardas";
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVrd.Location = new System.Drawing.Point(30, 493);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(320, 26);
            this.pavardeVrd.TabIndex = 9;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 543);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.pavardeVardas);
            this.Controls.Add(this.rezultatas);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.Baigti);
            this.Controls.Add(this.rasti);
            this.Controls.Add(this.skaiciuoti);
            this.Controls.Add(this.spausdinti);
            this.Controls.Add(this.ivesti);
            this.Controls.Add(this.rezultatai);
            this.Name = "Form1";
            this.Text = "Studentai";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rezultatai;
        private System.Windows.Forms.Button ivesti;
        private System.Windows.Forms.Button spausdinti;
        private System.Windows.Forms.Button skaiciuoti;
        private System.Windows.Forms.Button rasti;
        private System.Windows.Forms.Button Baigti;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label rezultatas;
        private System.Windows.Forms.Label pavardeVardas;
        private System.Windows.Forms.TextBox pavardeVrd;
    }
}

