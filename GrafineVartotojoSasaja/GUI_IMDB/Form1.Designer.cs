namespace GUI_IMDB
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skaičiavimaiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pelningiausias2019ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spausdintiĮCSVFailąToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.info = new System.Windows.Forms.DataGridView();
            this.pradiniaiDuom = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem,
            this.skaičiavimaiToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(1176, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiToolStripMenuItem});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiToolStripMenuItem
            // 
            this.įvestiToolStripMenuItem.Name = "įvestiToolStripMenuItem";
            this.įvestiToolStripMenuItem.Size = new System.Drawing.Size(116, 26);
            this.įvestiToolStripMenuItem.Text = "Įvesti";
            this.įvestiToolStripMenuItem.Click += new System.EventHandler(this.įvestiToolStripMenuItem_Click);
            // 
            // skaičiavimaiToolStripMenuItem
            // 
            this.skaičiavimaiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pelningiausias2019ToolStripMenuItem,
            this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem,
            this.spausdintiĮCSVFailąToolStripMenuItem});
            this.skaičiavimaiToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.skaičiavimaiToolStripMenuItem.Name = "skaičiavimaiToolStripMenuItem";
            this.skaičiavimaiToolStripMenuItem.Size = new System.Drawing.Size(108, 25);
            this.skaičiavimaiToolStripMenuItem.Text = "Skaičiavimai";
            // 
            // pelningiausias2019ToolStripMenuItem
            // 
            this.pelningiausias2019ToolStripMenuItem.Name = "pelningiausias2019ToolStripMenuItem";
            this.pelningiausias2019ToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.pelningiausias2019ToolStripMenuItem.Text = "Pelningiausias 2019";
            this.pelningiausias2019ToolStripMenuItem.Click += new System.EventHandler(this.pelningiausias2019ToolStripMenuItem_Click);
            // 
            // daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem
            // 
            this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem.Name = "daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem";
            this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem.Text = "Daugiausiai filmų pastatęs režisierius";
            this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem.Click += new System.EventHandler(this.daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem_Click);
            // 
            // spausdintiĮCSVFailąToolStripMenuItem
            // 
            this.spausdintiĮCSVFailąToolStripMenuItem.Name = "spausdintiĮCSVFailąToolStripMenuItem";
            this.spausdintiĮCSVFailąToolStripMenuItem.Size = new System.Drawing.Size(336, 26);
            this.spausdintiĮCSVFailąToolStripMenuItem.Text = "Spausdinti į CSV failą";
            this.spausdintiĮCSVFailąToolStripMenuItem.Click += new System.EventHandler(this.spausdintiĮCSVFailąToolStripMenuItem_Click);
            // 
            // info
            // 
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.RosyBrown;
            this.info.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.info.BackgroundColor = System.Drawing.Color.DarkSalmon;
            this.info.BorderStyle = System.Windows.Forms.BorderStyle.None;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.RosyBrown;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.info.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.info.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.info.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(0, 25);
            this.info.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(1176, 236);
            this.info.TabIndex = 1;
            // 
            // pradiniaiDuom
            // 
            this.pradiniaiDuom.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pradiniaiDuom.Location = new System.Drawing.Point(23, 341);
            this.pradiniaiDuom.Name = "pradiniaiDuom";
            this.pradiniaiDuom.Size = new System.Drawing.Size(178, 35);
            this.pradiniaiDuom.TabIndex = 2;
            this.pradiniaiDuom.Text = "Rodyti pradinius duomenis";
            this.pradiniaiDuom.UseVisualStyleBackColor = true;
            this.pradiniaiDuom.Click += new System.EventHandler(this.pradiniaiDuom_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 26);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem1.Text = "Baigti";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1176, 526);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.pradiniaiDuom);
            this.Controls.Add(this.info);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.Text = "IMDB";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.info)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiToolStripMenuItem;
        private System.Windows.Forms.DataGridView info;
        private System.Windows.Forms.ToolStripMenuItem skaičiavimaiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pelningiausias2019ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spausdintiĮCSVFailąToolStripMenuItem;
        private System.Windows.Forms.Button pradiniaiDuom;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}

