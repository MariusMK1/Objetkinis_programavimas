using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family
{
    internal class Asmuo : object
    {
        public string Vardas { get; private set; }
        public string Pavardė { get; private set; }
        public Asmuo() : base()
        {
        }
        public Asmuo(string vardas, string pavardė) : base()
        {
            this.Vardas = vardas;
            this.Pavardė = pavardė;
        }
        public override string ToString()
        {
            return string.Format(" vardas = {0}; pavardė = {1};", Vardas, Pavardė);
        }
    }
}
