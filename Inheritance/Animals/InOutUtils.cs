using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Globalization;

namespace Animals
{
    static class InOutUtils
    {
        public static AnimalsContainer ReadAnimals(string fileName)
        {
            AnimalsContainer animals = new AnimalsContainer();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string type = Values[0];
                int id = int.Parse(Values[1]);
                string name = Values[2];
                string breed = Values[3];
                DateTime birthDate = DateTime.Parse(Values[4]);

                Gender gender;
                Enum.TryParse(Values[5], out gender);       //tries to convert value to enum

                switch (type)
                {
                    case "Dog":
                        bool aggresive = bool.Parse(Values[6]);
                        Dog dog = new Dog(id, name, breed, birthDate, gender, aggresive);
                        if (!animals.Contains(dog))
                        {
                            animals.Add(dog);
                        }
                        break;
                    case "Cat":
                        Cat cat = new Cat(id, name, breed, birthDate, gender);
                        if (!animals.Contains(cat))
                        {
                            animals.Add(cat);
                        }
                        break;
                    case "GuineaPig":
                        GuineaPig guineaPig = new GuineaPig(id, name, breed, birthDate, gender);
                        if (!animals.Contains(guineaPig))
                        {
                            animals.Add(guineaPig);
                        }
                        break;
                    default:
                        break; //unknown type
                }
            }
            return animals;
        }
        public static void PrintAnimals(string label, AnimalsContainer Animals)
        {
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,-70} |", label);
            Console.WriteLine(new string('-', 74));
            Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
            Console.WriteLine(new string('-', 74));
            for (int i = 0; i < Animals.Count; i++)
            {
                Animal animal = Animals.Get(i);
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);
            }
            Console.WriteLine(new string('-', 74));
        }

        public static void PrintBreeds(List<string> breeds)
        {
            foreach (string breed in breeds)
            {
                Console.WriteLine(breed);
            }
        }
        public static void PrintAnimalsToCSVFile(string fileName, AnimalsContainer Animals)
        {
            string[] lines = new string[Animals.Count + 1];
            lines[0] = string.Format("{0};{1};{2};{3};{4}", "Reg.Nr", "Vardas", "Veislė", "Gimimo data", "Lytis");
            for (int i = 0; i < Animals.Count; i++)
            {
                Animal animal = Animals.Get(i);
                lines[i + 1] = String.Format("{0};{1};{2};{3};{4}", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);
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
        public static void PrintAnimalsFiltered(AnimalsContainer Animals)
        {
            if (Animals.Count != 0)
            {
                Console.WriteLine("Šunų kuriems reikia skiepų sąrašas:");
                Console.WriteLine(new String('-', 74));
                Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12} | {4,-8} |", "Reg.Nr.", "Vardas", "Veislė", "Gimimo data", "Lytis");
                Console.WriteLine(new String('-', 74));
                for (int i = 0; i < Animals.Count; i++)
                {
                    Animal animal = Animals.Get(i);
                    Console.WriteLine("| {0,8} | {1,-15} | {2,-15} | {3,-12:yyyy-MM-dd} | {4,-8} |", animal.ID, animal.Name, animal.Breed, animal.BirthDate, animal.Gender);
                }
                Console.WriteLine(new String('-', 74));
            }
            else
            {
                Console.WriteLine("Visų šunų skiepai galiojantys");
            }
        }

    }
}
