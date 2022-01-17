using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simboliai_dienos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 5 žingsnis
            //string diena;
            //Console.Write("Kokia šiandien savaitės dienas (Įveskite mažosiomis raidėmis)? ");
            //diena = Console.ReadLine();
            //if (diena == "pirmadienis")
            //    Console.WriteLine("Pirmadienis - Sudėtingiausia savaitės diena.");
            //else
            //    if (diena == "antradienis")
            //    Console.WriteLine("Antradienis - aktyvių veiksmų, Marso diena.");
            //else
            //    if (diena == "trečiadienis")
            //    Console.WriteLine("Trečiadienis - sandoriams sudaryti " +
            //                        "tinkamiausia diena.");
            //else
            //    if (diena == "ketvirtadienis")
            //    Console.WriteLine("Ketviradienį reiktų imtis visuomeninių darbų.");
            //else
            //    if (diena == "penktadienis")
            //    Console.WriteLine("Penktadienį lengvai gimsta šedevrai, susitinka mylimieji.");
            //else
            //    if (diena == "šeštadienis")
            //    Console.WriteLine("Šeštadienis - savo problemų sprendimo diena.");
            //else
            //    if (diena == "sekmadienis")
            //    Console.WriteLine("Sekmadienį reikėtų pradėti naujus darbus.");
            //else
            //    Console.WriteLine("Tokios savaitės dienos pas mus nebūna");

            // 6 žingsnis
            string diena;
            Console.Write("Kokia šiandien savaitės dienas? ");
            diena = Console.ReadLine().ToUpper();
            switch (diena)
            {
                case "pirmadienis":
                    Console.WriteLine("Pirmadienis - Sudėtingiausia savaitės diena.");
                    break;
                case "antradienis":
                    Console.WriteLine("Antradienis - aktyvių veiksmų, Marso diena.");
                    break;
                case "trečiadienis":
                    Console.WriteLine("Trečiadienis - sandoriams sudaryti " +
                                        "tinkamiausia diena.");
                    break;
                case "ketvirtadienis":
                    Console.WriteLine("Ketviradienį reiktų imtis visuomeninių darbų.");
                    break;
                case "penktadienis":
                    Console.WriteLine("Penktadienį lengvai gimsta šedevrai, susitinka mylimieji.");
                    break;
                case "šeštadienis":
                    Console.WriteLine("Šeštadienis - savo problemų sprendimo diena.");
                    break;
                case "sekmadienis":
                    Console.WriteLine("Sekmadienį reikėtų pradėti naujus darbus.");
                    break;

                default:
                    Console.WriteLine("Tokios savaitės dienos pas mus nebūna");
                    break;
            }

        }
        static void ToUpper1(string str1, out string str)
        {
            int y;
            str = str1;
            int n = str.Length;
            for(int pos = 0; pos < n; pos ++)
                if (str[pos] >= 'a' && str[pos] <= 'z')
                {
                    y = (int)str[pos] + (int)'A' - (int)'a';
                    char z = (char)y;
                    string z1 = z.ToString();
                    str = str.Remove(pos, 1);
                    str = str.Insert(pos, z1);
                }
        } 
    }
}
