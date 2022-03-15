using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apartments
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            ApartmentRegister register = InOutUtils.ReadApartments(@"Duom.txt");
            InOutUtils.PrintApartments(register);
            Console.WriteLine();
            Console.Write("Nurodykite kambarių skaičių: ");
            int roomNo= int.Parse(Console.ReadLine());
            Console.WriteLine("Nurodykite tinkamus aukštus");
            Console.Write("Nuo:");
            int minFloor = int.Parse(Console.ReadLine());
            Console.Write("Iki:");
            int maxFloor = int.Parse(Console.ReadLine());
            Console.Write("Nurodykite kainą kurios nenorite viršyti: ");
            double maxPrice = double.Parse(Console.ReadLine());
            Console.WriteLine();
            List<Apartment> Filtered = register.Filter(roomNo, minFloor, maxFloor, maxPrice);
            InOutUtils.PrintFiltered(Filtered);
        }
    }
}
