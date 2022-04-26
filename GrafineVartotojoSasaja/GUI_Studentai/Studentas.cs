using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Studentai
{
    /// <summary>
    /// Klasė vieno studento duomenims saugoti
    /// </summary>
    class Studentas
    {
        public string PavVrd { get; set; }
        public int Pazym { get; set; }
        /// <summary>
        /// Klasės konstruktorius: savybėms suteikia reikšmes
        /// </summary>
        /// <param name="pavv"> pavardė ir vardsa </param>
        /// <param name="pazym"> pažymys </param>
        public Studentas(string pavv, int pazym)
        {
            PavVrd = pavv;
            Pazym = pazym;
        }
        /// <summary>
        /// Užklotas metodas ToString()
        /// </summary>
        /// <returns> Gražina suformuotą eilutę </returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, -20}   {1, 2}", PavVrd, Pazym);
            return eilute;
        }
    }
}
