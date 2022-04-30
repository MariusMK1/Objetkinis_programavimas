namespace GUI_Studentai2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentųSkaičiusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentoĮvertinimasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vidurkiaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vaikinųToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.merginųToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pagalbaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.užduotisToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.nurodymaiVartotojuiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duomenys = new System.Windows.Forms.RichTextBox();
            this.rezultatai = new System.Windows.Forms.DataGridView();
            this.pavardeVrd = new System.Windows.Forms.TextBox();
            this.vertinimai = new System.Windows.Forms.ComboBox();
            this.rezultatas = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.vaikinuVid = new System.Windows.Forms.Label();
            this.merginuVid = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rezultatai)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem,
            this.pagalbaToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestisToolStripMenuItem,
            this.spausdintiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestisToolStripMenuItem
            // 
            this.įvestisToolStripMenuItem.Name = "įvestisToolStripMenuItem";
            this.įvestisToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.įvestisToolStripMenuItem.Text = "Įvestis";
            this.įvestisToolStripMenuItem.Click += new System.EventHandler(this.įvestisToolStripMenuItem_Click);
            // 
            // spausdintiToolStripMenuItem
            // 
            this.spausdintiToolStripMenuItem.Name = "spausdintiToolStripMenuItem";
            this.spausdintiToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.spausdintiToolStripMenuItem.Text = "Spausdinti";
            this.spausdintiToolStripMenuItem.Click += new System.EventHandler(this.spausdintiToolStripMenuItem_Click);
            // 
            // baigtiToolStripMenuItem
            // 
            this.baigtiToolStripMenuItem.Name = "baigtiToolStripMenuItem";
            this.baigtiToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.baigtiToolStripMenuItem.Text = "Baigti";
            this.baigtiToolStripMenuItem.Click += new System.EventHandler(this.baigtiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.studentųSkaičiusToolStripMenuItem,
            this.studentoĮvertinimasToolStripMenuItem,
            this.vidurkiaiToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // studentųSkaičiusToolStripMenuItem
            // 
            this.studentųSkaičiusToolStripMenuItem.Name = "studentųSkaičiusToolStripMenuItem";
            this.studentųSkaičiusToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.studentųSkaičiusToolStripMenuItem.Text = "Studentų skaičius";
            this.studentųSkaičiusToolStripMenuItem.Click += new System.EventHandler(this.studentųSkaičiusToolStripMenuItem_Click);
            // 
            // studentoĮvertinimasToolStripMenuItem
            // 
            this.studentoĮvertinimasToolStripMenuItem.Name = "studentoĮvertinimasToolStripMenuItem";
            this.studentoĮvertinimasToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.studentoĮvertinimasToolStripMenuItem.Text = "Studento įvertinimas";
            this.studentoĮvertinimasToolStripMenuItem.Click += new System.EventHandler(this.studentoĮvertinimasToolStripMenuItem_Click);
            // 
            // vidurkiaiToolStripMenuItem
            // 
            this.vidurkiaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vaikinųToolStripMenuItem,
            this.merginųToolStripMenuItem});
            this.vidurkiaiToolStripMenuItem.Name = "vidurkiaiToolStripMenuItem";
            this.vidurkiaiToolStripMenuItem.Size = new System.Drawing.Size(223, 26);
            this.vidurkiaiToolStripMenuItem.Text = "Vidurkiai";
            // 
            // vaikinųToolStripMenuItem
            // 
            this.vaikinųToolStripMenuItem.Name = "vaikinųToolStripMenuItem";
            this.vaikinųToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.vaikinųToolStripMenuItem.Text = "Vaikinų";
            this.vaikinųToolStripMenuItem.Click += new System.EventHandler(this.vaikinųToolStripMenuItem_Click);
            // 
            // merginųToolStripMenuItem
            // 
            this.merginųToolStripMenuItem.Name = "merginųToolStripMenuItem";
            this.merginųToolStripMenuItem.Size = new System.Drawing.Size(139, 26);
            this.merginųToolStripMenuItem.Text = "Merginų";
            this.merginųToolStripMenuItem.Click += new System.EventHandler(this.merginųToolStripMenuItem_Click);
            // 
            // pagalbaToolStripMenuItem
            // 
            this.pagalbaToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.užduotisToolStripMenuItem,
            this.nurodymaiVartotojuiToolStripMenuItem});
            this.pagalbaToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pagalbaToolStripMenuItem.Name = "pagalbaToolStripMenuItem";
            this.pagalbaToolStripMenuItem.Size = new System.Drawing.Size(76, 25);
            this.pagalbaToolStripMenuItem.Text = "Pagalba";
            // 
            // užduotisToolStripMenuItem
            // 
            this.užduotisToolStripMenuItem.Name = "užduotisToolStripMenuItem";
            this.užduotisToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.užduotisToolStripMenuItem.Text = "Užduotis";
            this.užduotisToolStripMenuItem.Click += new System.EventHandler(this.užduotisToolStripMenuItem_Click);
            // 
            // nurodymaiVartotojuiToolStripMenuItem
            // 
            this.nurodymaiVartotojuiToolStripMenuItem.Name = "nurodymaiVartotojuiToolStripMenuItem";
            this.nurodymaiVartotojuiToolStripMenuItem.Size = new System.Drawing.Size(230, 26);
            this.nurodymaiVartotojuiToolStripMenuItem.Text = "Nurodymai vartotojui";
            this.nurodymaiVartotojuiToolStripMenuItem.Click += new System.EventHandler(this.nurodymaiVartotojuiToolStripMenuItem_Click);
            // 
            // duomenys
            // 
            this.duomenys.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.duomenys.Location = new System.Drawing.Point(0, 27);
            this.duomenys.Name = "duomenys";
            this.duomenys.Size = new System.Drawing.Size(463, 218);
            this.duomenys.TabIndex = 2;
            this.duomenys.Text = "Čia bus parodyti programos pradiniai duomenys";
            // 
            // rezultatai
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Blue;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.rezultatai.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.rezultatai.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.rezultatai.DefaultCellStyle = dataGridViewCellStyle2;
            this.rezultatai.Location = new System.Drawing.Point(0, 283);
            this.rezultatai.Name = "rezultatai";
            this.rezultatai.Size = new System.Drawing.Size(463, 218);
            this.rezultatai.TabIndex = 3;
            // 
            // pavardeVrd
            // 
            this.pavardeVrd.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.pavardeVrd.Location = new System.Drawing.Point(0, 251);
            this.pavardeVrd.Name = "pavardeVrd";
            this.pavardeVrd.Size = new System.Drawing.Size(347, 26);
            this.pavardeVrd.TabIndex = 4;
            this.pavardeVrd.Text = "Čia užrašykite pavardę ir vardą";
            // 
            // vertinimai
            // 
            this.vertinimai.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vertinimai.FormattingEnabled = true;
            this.vertinimai.Location = new System.Drawing.Point(507, 27);
            this.vertinimai.Name = "vertinimai";
            this.vertinimai.Size = new System.Drawing.Size(179, 30);
            this.vertinimai.TabIndex = 5;
            this.vertinimai.Text = "Pasirinkite pažymį";
            // 
            // rezultatas
            // 
            this.rezultatas.AutoSize = true;
            this.rezultatas.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.rezultatas.Location = new System.Drawing.Point(503, 72);
            this.rezultatas.Name = "rezultatas";
            this.rezultatas.Size = new System.Drawing.Size(227, 22);
            this.rezultatas.TabIndex = 6;
            this.rezultatas.Text = "Čia bus parodyti rezultatai";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // vaikinuVid
            // 
            this.vaikinuVid.AutoSize = true;
            this.vaikinuVid.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.vaikinuVid.Location = new System.Drawing.Point(503, 165);
            this.vaikinuVid.Name = "vaikinuVid";
            this.vaikinuVid.Size = new System.Drawing.Size(294, 22);
            this.vaikinuVid.TabIndex = 7;
            this.vaikinuVid.Text = "Čia bus parodytas vaikinų vidurkis";
            // 
            // merginuVid
            // 
            this.merginuVid.AutoSize = true;
            this.merginuVid.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(186)));
            this.merginuVid.Location = new System.Drawing.Point(503, 210);
            this.merginuVid.Name = "merginuVid";
            this.merginuVid.Size = new System.Drawing.Size(301, 22);
            this.merginuVid.TabIndex = 8;
            this.merginuVid.Text = "Čia bus parodytas merginų vidurkis";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 502);
            this.Controls.Add(this.merginuVid);
            this.Controls.Add(this.vaikinuVid);
            this.Controls.Add(this.rezultatas);
            this.Controls.Add(this.vertinimai);
            this.Controls.Add(this.pavardeVrd);
            this.Controls.Add(this.rezultatai);
            this.Controls.Add(this.duomenys);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Studentai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rezultatai)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentųSkaičiusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem studentoĮvertinimasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pagalbaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem užduotisToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem nurodymaiVartotojuiToolStripMenuItem;
        private System.Windows.Forms.RichTextBox duomenys;
        private System.Windows.Forms.DataGridView rezultatai;
        private System.Windows.Forms.TextBox pavardeVrd;
        private System.Windows.Forms.ComboBox vertinimai;
        private System.Windows.Forms.Label rezultatas;
        private System.Windows.Forms.ToolStripMenuItem įvestisToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem vidurkiaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vaikinųToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem merginųToolStripMenuItem;
        private System.Windows.Forms.Label vaikinuVid;
        private System.Windows.Forms.Label merginuVid;
    }
}

