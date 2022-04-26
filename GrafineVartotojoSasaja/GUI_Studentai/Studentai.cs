using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Studentai
{
    /// <summary>
    /// Klasė (Konteinerinė) studentų duomenims saugoti
    /// </summary>
    internal class Studentai
    {
        const int Cn = 500;             // studentų masyvo dydis
        private Studentas[] Stud;       //studentų objektų masyvas
        public int Kiek { get; set; }   //savybė: studentų skaičius
        /// <summary>
        /// Klasės konstruktorius: suteikia kintamiesiems reikšmes
        /// </summary>
        public Studentai()
        {
            Kiek = 0;
            Stud = new Studentas[Cn];
        }
        /// <summary>
        /// Grąžina nurodyto indekso studento objektą
        /// </summary>
        /// <param name="i"></param>
        /// <returns></returns>
        public Studentas ImtiStudenta (int i) { return Stud[i]; }
        /// <summary>
        /// Įrašo į studentų objektų masyvą naują studentą
        /// </summary>
        /// <param name="stud"></param>
        public void DetiStudenta(Studentas stud) { Stud[Kiek++] = stud; }
    }
}
