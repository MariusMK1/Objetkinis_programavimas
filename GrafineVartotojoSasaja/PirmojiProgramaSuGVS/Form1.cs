using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PirmojiProgramaSuGVS
{
    public partial class Form1 : Form
    {
        int ilgis,
            plotis,
            plotas;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ilgis = Convert.ToInt32(textBox1.Text);
            plotis = Convert.ToInt32(textBox2.Text);
            button2.Enabled = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            plotas = Plotas(ilgis, plotis);
            label3.Text = "Stačiakampio plotas: " + Convert.ToString(plotas);
        }
        /// <summary>
        /// Apskaičiuoja stačiakampio plotą
        /// </summary>
        /// <param name="ilg"> stačiakampio ilgis</param>
        /// <param name="plot">stačiakampio plotis</param>
        /// <returns>grąžina stačiakampio plotą</returns>
        static int Plotas(int ilg, int plot)
        {
            return ilg * plot;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
