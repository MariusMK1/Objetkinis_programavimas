using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_Museums
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (Form1.howManyHaveGuides > 0)
                label1.Text = Form1.SetValueForCity1 + " turi " + Form1.howManyHaveGuides + " muziejus su gidais";
            else
                label1.Text = Form1.SetValueForCity1 + " neturi muziejų su gidais";

            if (Form1.typesInCityOnDay.Count > 0)
            {
                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].Name = Form1.SetValueForCity2 + Form1.SetValueForDayWord + " galima aplankyti tokio tipo muziejus:";
                dataGridView1.Columns[0].Width = 350;
                for (int i = 0; i < Form1.typesInCityOnDay.Count; i++)
                {
                   dataGridView1.Rows.Add(Form1.typesInCityOnDay[i]);
                }
            }
            else
            {
                dataGridView1.ColumnCount = 1;
                dataGridView1.Columns[0].Name = (Form1.SetValueForCity2 + " "+ Form1.SetValueForDayWord + " nėra dirbančių muziejų)");
            }

            if(Form1.notLessThan3.Count > 0)
            {
                dataGridView2.ColumnCount = 13;
                dataGridView2.Columns[0].Name = "Nr.";
                dataGridView2.Columns[0].Width = 40;
                dataGridView2.Columns[1].Name = "Pavadininmas";
                dataGridView2.Columns[1].Width = 100;
                dataGridView2.Columns[2].Name = "Miestas";
                dataGridView2.Columns[2].Width = 100;
                dataGridView2.Columns[3].Name = "Tipas";
                dataGridView2.Columns[3].Width = 100;
                dataGridView2.Columns[4].Name = "I";
                dataGridView2.Columns[4].Width = 40;
                dataGridView2.Columns[5].Name = "II";
                dataGridView2.Columns[5].Width = 40;
                dataGridView2.Columns[6].Name = "III";
                dataGridView2.Columns[6].Width = 40;
                dataGridView2.Columns[7].Name = "IV";
                dataGridView2.Columns[7].Width = 40;
                dataGridView2.Columns[8].Name = "V";
                dataGridView2.Columns[8].Width = 40;
                dataGridView2.Columns[9].Name = "VI";
                dataGridView2.Columns[9].Width = 40;
                dataGridView2.Columns[10].Name = "VII";
                dataGridView2.Columns[10].Width = 40;
                dataGridView2.Columns[11].Name = "Kaina";
                dataGridView2.Columns[11].Width = 100;
                dataGridView2.Columns[12].Name = "Gidas";
                dataGridView2.Columns[12].Width = 100;
                for (int i = 0; i < Form1.notLessThan3.Count; i++)
                {
                    Museum museum = Form1.notLessThan3[i];
                    dataGridView2.Rows.Add(i + 1, museum.Name, museum.City, museum.Type, museum.Week[0], museum.Week[1],
                        museum.Week[2], museum.Week[3], museum.Week[4], museum.Week[5], museum.Week[6], museum.Price, museum.Guide);
                }
            }
            else
            {
                dataGridView2.Text = Form1.SetValueForCity3 + "neturi muziejų kurie dirbtų nemažiau negu 3 dienas";
            }
        }
    }
}
