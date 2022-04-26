﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI_Studentai
{
    public partial class Form1 : Form
    {
        const string CFd = "..\\..\\Studentai.txt";
        const string CFr = "..\\..\\Rezultatai.txt";
        Studentai TestasMas;        //student7 testo rezultatai (konteineris)
        Pazymys[] Pazymiai = new Pazymys[10]
        {
            new Pazymys(10, "Puikiai"),
            new Pazymys(9, "Labai gerai"),
            new Pazymys(8, "Gerai"),
            new Pazymys(7, "Vidutiniškai"),
            new Pazymys(6, "Patenkinamai"),
            new Pazymys(5, "Silpnai"),
            new Pazymys(4, "Nepatenkinamai"),
            new Pazymys(3, "Nepatenkinamai"),
            new Pazymys(2, "Nepatenkinamai"),
            new Pazymys(1, "Nepatenkinamai")
        };
        public Form1()
        {
            InitializeComponent();
            // Nurodomi mygtukai padaromi pasyviais
            spausdinti.Enabled = false;
            skaiciuoti.Enabled = false;
            rasti.Enabled = false;

            if (File.Exists(CFr))
                File.Delete(CFr);

            //Komponento verinimai užpildymas pažymiais
            foreach (Pazymys paz in Pazymiai)
                vertinimai.Items.Add(paz.Pazym + " " + paz.PazZodR);
        }
        /// <summary>
        /// Mygtuko "Įvesti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ivesti_Click(object sender, EventArgs e)
        {
            rezultatai.LoadFile(CFd, RichTextBoxStreamType.PlainText);
            TestasMas = SkaitytiStudKont(CFd);
            ivesti.Enabled = false;
            spausdinti.Enabled = true;
            skaiciuoti.Enabled = true;
            rasti.Enabled = true;
        }
        /// <summary>
        /// Mygtuko "spausdinti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Spausdinti_Click(object sender, EventArgs e)
        {
            SpausdintiStudKont(CFr, TestasMas, "Studentų sąrašas (testo rezultatai)");
            rezultatai.LoadFile(CFr, RichTextBoxStreamType.PlainText);
            vertinimai.SelectedIndex = 0; // parenkama 1-oji reikšmė
        }
        /// <summary>
        /// Mygtuko "skaiciuoti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void skaiciuoti_Click(object sender, EventArgs e)
        {
            string ivertis = vertinimai.SelectedItem.ToString();
            string[] eilDalis = ivertis.Split(' ');
            int pazymys = Int32.Parse(eilDalis[0]);
            int kiekis = Kiekis(TestasMas, pazymys);
            if (kiekis > 0)
                rezultatas.Text = "Studentų skaičius: " + kiekis.ToString();
            else
                rezultatas.Text = "Tokių studentų nėra.";
        }
        /// <summary>
        /// Mygtuko "rasti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rasti_Click(object sender, EventArgs e)
        {
            pavardeVardas.Text = "Pavardė ir vardas";  //pakartotiniam paspaudimui
            string pavVrd = pavardeVrd.Text;
            int index = StudentoIndeksas(TestasMas, pavVrd);
            if(index > -1)
            {
                Studentas stud = TestasMas.ImtiStudenta(index);
                int pazymys = stud.Pazym;
                pavardeVardas.Text = pavardeVardas.Text + " (pažymys: " + pazymys.ToString() + ")";
            }
            else
                pavardeVardas.Text = pavardeVardas.Text + " (Tokio studento (-ės) nėra.)";
        }
        /// <summary>
        /// Mygtuko "Bagiti" atliekami veiksmai
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Baigti_Click(object sender, EventArgs e)
        {
            Close();
        }
        static Studentai SkaitytiStudKont(string fv)
        {
            Studentai StudentaiKont = new Studentai();
            using (StreamReader srautas = new StreamReader(fv, Encoding.GetEncoding(1257)))
            {
                string eilute;
                while ((eilute = srautas.ReadLine()) != null)
                {
                    string [] eilDalis = eilute.Split(';');
                    string pavVrd = eilDalis[0];
                    int pazym = int.Parse(eilDalis[1]);
                    Studentas studentas = new Studentas(pavVrd, pazym);
                    StudentaiKont.DetiStudenta(studentas);
                }
            }
            return StudentaiKont;
        }
        static void SpausdintiStudKont(string fv, Studentai StudentaiKont, string antraste)
        {
            const string virsus = "-----------------------------------\r\n"
                                + " Nr.   Pavardė ir vardas    Pažymys \r\n"
                                + "-----------------------------------";
            using (var fr = new StreamWriter(File.Open(fv,FileMode.Append), Encoding.GetEncoding(1257)))
            {
                fr.WriteLine("\n" + antraste);
                fr.WriteLine(virsus);
                for (int i = 0; i < StudentaiKont.Kiek; i++)
                {
                    Studentas stud = StudentaiKont.ImtiStudenta(i);
                    fr.WriteLine("{0, 3}    {1}", i + 1, stud);
                }
                fr.WriteLine("-----------------------------------\n");
            }
        }
        /// <summary>
        /// Suskaičiuoja studentų kurių pažymiai lygūs nurodytam pažymiui, skaičių.
        /// </summary>
        /// <param name="StudentaiKont"></param>
        /// <param name="pazymys"></param>
        /// <returns></returns>
        static int Kiekis (Studentai StudentaiKont, int pazymys)
        {
            int kiek = 0;
            for (int i = 0; i < StudentaiKont.Kiek; i++)
            {
                Studentas stud = StudentaiKont.ImtiStudenta(i);
                if (stud.Pazym == pazymys)
                    kiek++;
            }
            return kiek;
        }
        /// <summary>
        /// Ieško nurodytos pavardės ir vardo studento
        /// </summary>
        /// <param name="StudentaiKont"></param>
        /// <param name="pavVrd"></param>
        /// <returns></returns>
        static int StudentoIndeksas(Studentai StudentaiKont, string pavVrd)
        {
            for (int i = 0; i < StudentaiKont.Kiek; i++)
            {
                Studentas stud = StudentaiKont.ImtiStudenta(i);
                if (stud.PavVrd == pavVrd)
                    return i;
            }
            return -1;
        }
    }
}
