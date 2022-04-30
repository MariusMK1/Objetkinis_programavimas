using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI_Museums
{
    public partial class Form1 : Form
    {
        private List<Museum> Museums;
        public Form1()
        {
            InitializeComponent();
            spausdintiToolStripMenuItem.Enabled = false;
            city.Enabled = false;
            city2.Enabled = false;
            day.Enabled = false;
            dayWord.Enabled = false;
            notLessThan.Enabled = false;
        }
        public static string SetValueForCity1 = "";
        public static string SetValueForCity2 = "";
        public static string SetValueForCity3 = "";
        public static string SetValueForDayWord = "";
        public static int SetValueForDay = 0;
        public static int howManyHaveGuides = 0;
        public static List<string> typesInCityOnDay = new List<string>();
        public static List<Museum> notLessThan3 = new List<Museum>();
        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // OpenFileDialog komponenot savybių nustatymas
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "txt files (*.txt) |*.txt|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string fv = openFileDialog1.FileName;
                Museums = ReadMuseums(fv);
                // Komponento dataGridView1 užpildymas duomenimis
                duomenys.ColumnCount = 13;
                duomenys.Columns[0].Name = "Nr.";
                duomenys.Columns[0].Width = 40;
                duomenys.Columns[1].Name = "Pavadininmas";
                duomenys.Columns[1].Width = 100;
                duomenys.Columns[2].Name = "Miestas";
                duomenys.Columns[2].Width = 100;
                duomenys.Columns[3].Name = "Tipas";
                duomenys.Columns[3].Width = 100;
                duomenys.Columns[4].Name = "I";
                duomenys.Columns[4].Width = 40;
                duomenys.Columns[5].Name = "II";
                duomenys.Columns[5].Width = 40;
                duomenys.Columns[6].Name = "III";
                duomenys.Columns[6].Width = 40;
                duomenys.Columns[7].Name = "IV";
                duomenys.Columns[7].Width = 40;
                duomenys.Columns[8].Name = "V";
                duomenys.Columns[8].Width = 40;
                duomenys.Columns[9].Name = "VI";
                duomenys.Columns[9].Width = 40;
                duomenys.Columns[10].Name = "VII";
                duomenys.Columns[10].Width = 40;
                duomenys.Columns[11].Name = "Kaina";
                duomenys.Columns[11].Width = 100;
                duomenys.Columns[12].Name = "Gidas";
                duomenys.Columns[12].Width = 100;
                for (int i = 0; i < Museums.Count; i++)
                {
                    Museum museum = Museums[i];
                    duomenys.Rows.Add(i + 1, museum.Name, museum.City, museum.Type, museum.Week[0], museum.Week[1],
                        museum.Week[2], museum.Week[3], museum.Week[4], museum.Week[5], museum.Week[6], museum.Price, museum.Guide);
                }
                spausdintiToolStripMenuItem.Enabled = true;
                city.Enabled = true;
                city2.Enabled = true;
                notLessThan.Enabled = true;
                day.Enabled = true;
                dayWord.Enabled = true;
            }
        }

        private void spausdintiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetValueForCity1 = city.Text;
            howManyHaveGuides = HowManyHaveGuide(Museums, SetValueForCity1);
            SetValueForCity2 = city2.Text;
            SetValueForDay = int.Parse(day.Text) - 1;
            SetValueForDayWord = dayWord.Text;
            typesInCityOnDay = FindTypesInCityOnDay(Museums, SetValueForCity2, SetValueForDay);
            SetValueForCity3 = notLessThan.Text;
            notLessThan3 = NotLessThanThreeDays(Museums, SetValueForCity3);
            PrintMuseumsToCSVFile("Rezultatai.csv", notLessThan3);

            Form2 form2 = new Form2();
            form2.ShowDialog();
        }
        private void baigtiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
        static List<Museum> ReadMuseums(string fileName)
        {
            List<Museum> Museums = new List<Museum>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string name = Values[0];
                string city = Values[1];
                string type = Values[2];
                List<int> week = new List<int>();
                for (int i = 3; i < 10; i++)
                {
                    int day = int.Parse(Values[i]);
                    week.Add(day);
                }
                double price = double.Parse(Values[10]);
                string guide = Values[11];
                Museum museum = new Museum(name, city, type, week, price, guide);
                Museums.Add(museum);
            }
            return Museums;
        }
        static void PrintMuseums(string fv, List<Museum> Museums)
        {
            using (var fr = new StreamWriter(File.Open(fv, FileMode.Append), Encoding.UTF8))
            {
                fr.WriteLine(new String('-', 125));
                fr.WriteLine("| {0,-15} | {1,-10} | {2,-8} |   {3,2}   |   {4,2}   |   {5,3}  |   {6,2}   |   {7,2}   |   {8,2}   |  {9,2}   | {10,7} | {11,-6} |",
                    "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
                fr.WriteLine(new String('-', 125));
                foreach (Museum museum in Museums)
                {
                    fr.Write("| {0,-15} | {1,-10} | {2,-8} |", museum.Name, museum.City, museum.Type);
                    for (int i = 0; i < 7; i++)
                    {
                        fr.Write(" {0,6} |", museum.WorkingOrNot(i));
                    }
                    fr.WriteLine(" {0,7:f2} | {1, -6} |", museum.Price, museum.Guide);
                }
                fr.WriteLine(new String('-', 125));
            }
        }
        static int HowManyHaveGuide(List<Museum> Museums, string City)
        {
            int count = 0;
            foreach (Museum museum in Museums)
            {
                if (museum.City.Contains(City))
                    if (museum.Guide == "turi")
                    {
                        count++;
                    }
            }
            return count;
        }
        static List<string> FindTypesInCityOnDay(List<Museum> Museums, string City, int day)
        {
            List<string> Types = new List<string>();
            foreach (Museum museum in Museums)
            {
                if (museum.City.Contains(City))
                {
                    if (museum.Week[day] == 1)
                    {
                        string type = museum.Type;
                        if (!Types.Contains(type))        //uses List method Contains()
                        {
                            Types.Add(type);
                        }
                    }
                }
            }
            return Types;
        }
        static List<Museum> NotLessThanThreeDays(List<Museum> Museums, string City)
        {
            List<Museum> NotLessThanTwoDays = new List<Museum>();
            foreach (Museum museum in Museums)
            {
                if (museum.City.Contains(City))
                {
                    int sum = 0;
                    for (int i = 0; i < 7; i++)
                    {
                        if (museum.Week[i] == 1)
                        {
                            sum++;
                        }
                    }
                    if (sum > 2)
                    {
                        NotLessThanTwoDays.Add(museum);
                    }

                }
            }
            return NotLessThanTwoDays;
        }
        public static void PrintMuseumsToCSVFile(string fileName, List<Museum> Museums)
        {
            string[] lines = new string[Museums.Count + 1];
            lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7};{8};{9};{10};{11}", "Pavadinimas", "Miestas", "Tipas", "I", "II", "III", "IV", "V", "VI", "VII", "Kaina", "Gidas");
            if (Museums.Count > 0)
            {
                for (int i = 0; i < Museums.Count; i++)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};", Museums[i].Name, Museums[i].City, Museums[i].Type);
                    for (int j = 0; j < 7; j++)
                    {
                        lines[i + 1] += String.Format("{0};", Museums[i].WorkingOrNot(j));
                    }
                    lines[i + 1] += String.Format("{0};{1}", Museums[i].Price, Museums[i].Guide);
                }
            }
            else
            {
                String.Format("Tokių muziejų nėra");
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
