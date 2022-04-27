using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_Studentai2
{
    class Pazymys
    {
        public int Pazym { get; set; }
        public string PazZodR { get; set; }
        public Pazymys(int paz, string pazR)
        {
            Pazym = paz;
            PazZodR = pazR;
        }
        /// <summary>
        /// Užklotas metodas ToString()
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            string eilute;
            eilute = string.Format("{0, 2:d}   {1, -15}", Pazym, PazZodR);
            return eilute;
        }
    }
}
