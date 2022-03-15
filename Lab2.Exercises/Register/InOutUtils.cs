using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Lab2.Exercises.Register
{
    static class InOutUtils
    {
        public static DogsRegister ReadDogs(string fileName)
        {
            DogsRegister Dogs = new DogsRegister();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                string name = Values[1];
                string breed = Values[2];
                DateTime birthDate = DateTime.Parse(Values[3]);

                Gender gender;
                Enum.TryParse(Values[4], out gender);       //tries to convert value to enum

                Dog dog = new Dog(id, name, breed, birthDate, gender);
                if (!Dogs.Contains(dog))
                {
                    Dogs.Add(dog);
                }
            }
            return Dogs;
        }
        public static void PrintDogs(List<Dog> Dogs)
        {
            Console.WriteLine(new String('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new String('-', 74));
            foreach(Dog dog in Dogs)
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
            }
            Console.WriteLine(new String('-', 74));
        }
        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }
        public static void PrintDogsToCSVFile(string fileName, List<Dog> Dogs)
        {
            string[] lines = new string[Dogs.Count + 1];
            lines[0] = string.Format("{0};{1};{2};{3};{4}", "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Dogs.Count; i++)
            {
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", Dogs[i].ID, Dogs[i].Name, Dogs[i].Breed, Dogs[i].BirthDate, Dogs[i].Gender);
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
        public static List<Vaccination> ReadVaccination(string fileName)
        {
            List<Vaccination> Vaccinations = new List<Vaccination>();
            string[] Lines = File.ReadAllLines(fileName);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                int id = int.Parse(Values[0]);
                DateTime vaccinationDate = DateTime.Parse(Values[1]);
                Vaccination v = new Vaccination(id, vaccinationDate);
                Vaccinations.Add(v);
            }
            return Vaccinations;
        }
        public static void PrintDogsFiltered(List<Dog> Dogs)
        {
            if(Dogs.Count != 0)
            {
                Console.WriteLine("Šunų kuriems reikia skiepų sąrašas:");
                Console.WriteLine(new String('-', 74));
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
                Console.WriteLine(new String('-', 74));
                foreach (Dog dog in Dogs)
                {
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", dog.ID, dog.Name, dog.Breed, dog.BirthDate, dog.Gender);
                }
                Console.WriteLine(new String('-', 74));
            }
            else
            {
                Console.WriteLine("Visų šunų skiepai galiojantys");
            }
        }
        public static void PrintDogs2(DogsRegister register)
        {
            Console.WriteLine(new string('-', 96));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} | {5,19} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis", "Reikia vakcinacijos");
            Console.WriteLine(new string('-', 96));



            for (int i = 0; i < register.DogsCount(); i++)
            {
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} | {5,-19} |", register.GetDog(i).ID, register.GetDog(i).Name, register.GetDog(i).Breed, register.GetDog(i).BirthDate, register.GetDog(i).Gender, register.GetDog(i).requiresVaccination);
            }
            Console.WriteLine(new string('-', 96));
        }
    }
}
