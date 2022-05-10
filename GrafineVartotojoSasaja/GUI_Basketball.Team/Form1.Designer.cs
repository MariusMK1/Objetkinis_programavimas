namespace GUI_Basketball.Team
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.failasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiPirmajįFailąToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.įvestiAntąToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.info = new System.Windows.Forms.RichTextBox();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.panelDesktopPanel = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.btnDuomenys = new System.Windows.Forms.Button();
            this.btnRezultatai = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.panelDesktopPanel.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.failasToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1038, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // failasToolStripMenuItem
            // 
            this.failasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.įvestiPirmajįFailąToolStripMenuItem,
            this.įvestiAntąToolStripMenuItem});
            this.failasToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.failasToolStripMenuItem.Name = "failasToolStripMenuItem";
            this.failasToolStripMenuItem.Size = new System.Drawing.Size(60, 25);
            this.failasToolStripMenuItem.Text = "Failas";
            // 
            // įvestiPirmajįFailąToolStripMenuItem
            // 
            this.įvestiPirmajįFailąToolStripMenuItem.Name = "įvestiPirmajįFailąToolStripMenuItem";
            this.įvestiPirmajįFailąToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.įvestiPirmajįFailąToolStripMenuItem.Text = "Įvesti pirmąjį failą";
            this.įvestiPirmajįFailąToolStripMenuItem.Click += new System.EventHandler(this.įvestiPirmajįFailąToolStripMenuItem_Click);
            // 
            // įvestiAntąToolStripMenuItem
            // 
            this.įvestiAntąToolStripMenuItem.Name = "įvestiAntąToolStripMenuItem";
            this.įvestiAntąToolStripMenuItem.Size = new System.Drawing.Size(202, 26);
            this.įvestiAntąToolStripMenuItem.Text = "Įvesti antąjį failą";
            this.įvestiAntąToolStripMenuItem.Click += new System.EventHandler(this.įvestiAntąToolStripMenuItem_Click);
            // 
            // info
            // 
            this.info.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.info.Location = new System.Drawing.Point(0, 43);
            this.info.Name = "info";
            this.info.Size = new System.Drawing.Size(1038, 472);
            this.info.TabIndex = 2;
            this.info.Text = "";
            // 
            // panelDesktopPanel
            // 
            this.panelDesktopPanel.BackColor = System.Drawing.Color.White;
            this.panelDesktopPanel.Controls.Add(this.info);
            this.panelDesktopPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelDesktopPanel.Location = new System.Drawing.Point(0, 29);
            this.panelDesktopPanel.Name = "panelDesktopPanel";
            this.panelDesktopPanel.Size = new System.Drawing.Size(1038, 515);
            this.panelDesktopPanel.TabIndex = 3;
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.White;
            this.panelMenu.Controls.Add(this.btnRezultatai);
            this.panelMenu.Controls.Add(this.btnDuomenys);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 29);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1038, 42);
            this.panelMenu.TabIndex = 4;
            // 
            // btnDuomenys
            // 
            this.btnDuomenys.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuomenys.Location = new System.Drawing.Point(0, 0);
            this.btnDuomenys.Name = "btnDuomenys";
            this.btnDuomenys.Size = new System.Drawing.Size(138, 33);
            this.btnDuomenys.TabIndex = 0;
            this.btnDuomenys.Text = "Duomenys";
            this.btnDuomenys.UseVisualStyleBackColor = true;
            this.btnDuomenys.Click += new System.EventHandler(this.btnDuomenys_Click);
            // 
            // btnRezultatai
            // 
            this.btnRezultatai.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRezultatai.Location = new System.Drawing.Point(135, 0);
            this.btnRezultatai.Name = "btnRezultatai";
            this.btnRezultatai.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.btnRezultatai.Size = new System.Drawing.Size(138, 33);
            this.btnRezultatai.TabIndex = 1;
            this.btnRezultatai.Text = "Rezultatai";
            this.btnRezultatai.UseVisualStyleBackColor = true;
            this.btnRezultatai.Click += new System.EventHandler(this.btnRezultatai_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1038, 544);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.panelDesktopPanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panelDesktopPanel.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem failasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiPirmajįFailąToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem įvestiAntąToolStripMenuItem;
        private System.Windows.Forms.RichTextBox info;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Panel panelDesktopPanel;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Button btnRezultatai;
        private System.Windows.Forms.Button btnDuomenys;
    }
}

