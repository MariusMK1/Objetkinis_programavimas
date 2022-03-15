using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Apartments
{
    internal class InOutUtils
    {
        public static ApartmentRegister ReadApartments(string fileName)
        {
            ApartmentRegister Apartments = new ApartmentRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int apartmentNumber = int.Parse(Values[0]);
                double area = double.Parse(Values[1]);
                int roomNumber = int.Parse(Values[2]);
                double price = double.Parse(Values[3]);
                int phoneNumber = int.Parse(Values[4]);

                Apartment apartment = new Apartment(apartmentNumber, area, roomNumber, price, phoneNumber);
                if (!Apartments.Contains(apartment))
                {
                    Apartments.Add(apartment);
                }
            }
            return Apartments;
        }
        public static void PrintApartments(ApartmentRegister register)
        {
            Console.WriteLine(new string('-', 63));
            Console.WriteLine("| {0,8} | {1,6} | {2,12} | {3,9} | {4,12} |", "Buto.Nr.", "Plotas", "Kambarių sk.", "Kaina", "Telefono nr.");
            Console.WriteLine(new string('-', 63));
            for (int i = 0; i < register.ApartmentCount(); i++)
            {
                Console.WriteLine("| {0,8} | {1,6:f2} | {2,12} | {3,9} | {4,12} |", register.GetApartment(i).ApartmentNumber, register.GetApartment(i).Area, register.GetApartment(i).RoomNumber, register.GetApartment(i).Price, register.GetApartment(i).PhoneNumber);
            }
            Console.WriteLine(new string('-', 63));
        }
        public static void PrintFiltered(List<Apartment> Apartments)
        {
            if (Apartments.Count != 0)
            {
                Console.WriteLine("Butai kurie atitinka reikalavimus:");
                Console.WriteLine(new String('-', 63));
                Console.WriteLine("| {0,8} | {1,6} | {2,12} | {3,9} | {4,12} |", "Buto.Nr.", "Plotas", "Kambarių sk.", "Kaina", "Telefono nr.");
                Console.WriteLine(new String('-', 63));
                foreach (Apartment apartment in Apartments)
                {
                    Console.WriteLine("| {0,8} | {1,6} | {2,12} | {3,9} | {4,12} |", apartment.ApartmentNumber, apartment.Area, apartment.RoomNumber, apartment.Price, apartment.PhoneNumber);
                }
                Console.WriteLine(new String('-', 63));
            }
            else
            {
                Console.WriteLine("Butų kurie atitiktų reikalavimus nėra");
            }
        }
    }
}
