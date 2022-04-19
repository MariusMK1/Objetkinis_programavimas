using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Family2
{
    class Asmuo : object, IComparable<Asmuo>, IEquatable<Asmuo> 
    {
        public string Vardas { get; private set; }
        public string Pavardė { get; private set; }
        public int Amžius { get; private set; }
        public Asmuo() : base()
        {
        }
        public Asmuo(string vardas, string pavardė, int amžius) : base()
        {
            this.Vardas = vardas;
            this.Pavardė = pavardė;
            this.Amžius = amžius;
        }
        public int CompareTo(Asmuo kitas)
        {
            int poz = string.Compare(this.Vardas, kitas.Vardas, StringComparison.CurrentCulture);
            if (poz > 0)
                return 1;
            if (poz < 0)
                return -1;
            else if (this.Amžius > kitas.Amžius) return 1;
            else if (this.Amžius < kitas.Amžius) return -1;
            else return 0;
        }
        public override bool Equals(object obj)
        {
            return Equals(obj as Asmuo);
        }
        public bool Equals(Asmuo kitas)
        {
            return kitas.Vardas == this.Vardas && kitas.Pavardė == this.Pavardė && kitas.Amžius == this.Amžius;
        }
        public static bool operator ==(Asmuo pirmas, Asmuo antras)
        {
            if (((object)pirmas) == null || ((object)antras) == null)
                return Object.Equals(pirmas, antras);
            return pirmas.Equals(antras);
        }
        public static bool operator !=(Asmuo pirmas, Asmuo antras)
        {
            if (((object)pirmas) == null || ((object)antras) == null)
                return !Object.Equals(pirmas, antras);
            return !(pirmas.Equals(antras));
        }
        public override int GetHashCode()
        {
            return Vardas.GetHashCode() ^ Pavardė.GetHashCode() ^ Amžius.GetHashCode();
        }
        public override string ToString()
        {
            return string.Format(" vardas = {0}; pavardė = {1}; amžius = {2}", Vardas, Pavardė, Amžius);
        }
    }
}
