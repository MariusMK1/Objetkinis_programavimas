namespace GUI_Museums
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
            this.components = new System.ComponentModel.Container();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openFileDialog2 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.baigtiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.duomenys = new System.Windows.Forms.DataGridView();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.city = new System.Windows.Forms.TextBox();
            this.city2 = new System.Windows.Forms.TextBox();
            this.day = new System.Windows.Forms.TextBox();
            this.dayWord = new System.Windows.Forms.TextBox();
            this.notLessThan = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duomenys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            this.openFileDialog2.FileName = "openFileDialog2";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1053, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem,
            this.spausdintiToolStripMenuItem,
            this.baigtiToolStripMenuItem});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
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
            // duomenys
            // 
            this.duomenys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.duomenys.Location = new System.Drawing.Point(0, 32);
            this.duomenys.Name = "duomenys";
            this.duomenys.Size = new System.Drawing.Size(952, 219);
            this.duomenys.TabIndex = 1;
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            // 
            // city
            // 
            this.city.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city.Location = new System.Drawing.Point(12, 271);
            this.city.Name = "city";
            this.city.Size = new System.Drawing.Size(377, 26);
            this.city.TabIndex = 2;
            this.city.Text = "Įveskite miestą kuriamę norite rasit muziejus su gidais:";
            // 
            // city2
            // 
            this.city2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city2.Location = new System.Drawing.Point(12, 313);
            this.city2.Name = "city2";
            this.city2.Size = new System.Drawing.Size(323, 26);
            this.city2.TabIndex = 3;
            this.city2.Text = "Įveskite miestą kurio muziejų tipus norite rasti:";
            // 
            // day
            // 
            this.day.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.day.Location = new System.Drawing.Point(673, 313);
            this.day.Name = "day";
            this.day.Size = new System.Drawing.Size(326, 26);
            this.day.TabIndex = 4;
            this.day.Text = "Įveskite dieną skaičiumi kurią norite rasti tipus:";
            // 
            // dayWord
            // 
            this.dayWord.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dayWord.Location = new System.Drawing.Point(341, 313);
            this.dayWord.Name = "dayWord";
            this.dayWord.Size = new System.Drawing.Size(326, 26);
            this.dayWord.TabIndex = 5;
            this.dayWord.Text = "Įveskite dieną žodžiu kurią norite rasti tipus:";
            // 
            // notLessThan
            // 
            this.notLessThan.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notLessThan.Location = new System.Drawing.Point(12, 365);
            this.notLessThan.Name = "notLessThan";
            this.notLessThan.Size = new System.Drawing.Size(612, 26);
            this.notLessThan.TabIndex = 6;
            this.notLessThan.Text = "Įveskite tą miestą kuriame norite pažiūrėti musziejus kurie dirba ne mažiau kaip " +
    "3 dienas";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.ClientSize = new System.Drawing.Size(1053, 450);
            this.Controls.Add(this.notLessThan);
            this.Controls.Add(this.dayWord);
            this.Controls.Add(this.day);
            this.Controls.Add(this.city2);
            this.Controls.Add(this.city);
            this.Controls.Add(this.duomenys);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Muziejai";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.duomenys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog2;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem baigtiToolStripMenuItem;
        private System.Windows.Forms.DataGridView duomenys;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private System.Windows.Forms.TextBox city;
        private System.Windows.Forms.TextBox day;
        private System.Windows.Forms.TextBox city2;
        private System.Windows.Forms.TextBox dayWord;
        private System.Windows.Forms.TextBox notLessThan;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    }
}

