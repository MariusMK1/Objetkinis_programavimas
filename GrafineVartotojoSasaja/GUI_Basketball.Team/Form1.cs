using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Basketball.Team
{
    public partial class Form1 : Form
    {
        PlayerContainer container1 = new PlayerContainer();
        PlayerContainer container2 = new PlayerContainer();
        private Form activeForm;
        private Button currentButton;
        public Form1()
        {
            InitializeComponent();
        }

        private void įvestiPirmajįFailąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "csv files (*.csv) |*.csv|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            try
            {
                string fv = openFileDialog1.FileName;
                container1 = InOutUtils.ReadPlayers(fv);
                info.LoadFile(fv, RichTextBoxStreamType.PlainText);
            }
            catch
            {
                MessageBox.Show("Failo formatas neteisingas!.", "Įspėjimas!");
            }
        }

        private void įvestiAntąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "csv files (*.csv) |*.csv|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            try
            {
                string fv = openFileDialog1.FileName;
                container2 = InOutUtils.ReadPlayers(fv);
                info.LoadFile(fv, RichTextBoxStreamType.PlainText);
            }
            catch
            {
                MessageBox.Show("Failo formatas neteisingas!.", "Įspėjimas!");
            }
        }
        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    DisableButton();
                    currentButton = (Button)btnSender;
                    currentButton.BackColor = Color.Gray;
                }
            }
        }
        private void DisableButton()
        {
            foreach (Control previousBtn in panelMenu.Controls)
            {
                if (previousBtn.GetType() == typeof(Button))
                {
                    previousBtn.BackColor = Color.LightGray;
                }
            }
        }
        private void OpenChildForm(Form childForm, object btnSender)
        {
            if(activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelDesktopPanel.Controls.Add(childForm);
            this.panelDesktopPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnDuomenys_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            if(activeForm != null)
            {
                activeForm.Close();
            }
        }

        private void btnRezultatai_Click(object sender, EventArgs e)
        {
            ActivateButton(sender);
            OpenChildForm(new Forms.Form2(), sender);
        }
    }
}
