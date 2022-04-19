using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Override
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Auto AutoMob = new Auto();
            Console.WriteLine("AutoMob duomenys:\n{0}", AutoMob.ToString());
            KrovAuto Volvo = new KrovAuto(2012, 125000, "Volvo FH12", 24.5);
            Console.WriteLine("Volvo duomenys:\n{0}", Volvo.ToString());
            KrovAuto Scania = new KrovAuto(2002, 450000, "Scaniao FH12", 19.5);
            Console.WriteLine("Scania duomenys:\n{0}", Scania.ToString());
            Console.WriteLine();
            if (Volvo > Scania)
                Console.WriteLine("Volvo > už Scania.");
            else
                Console.WriteLine("Volvo < už Scania.");
        }
    }
}
