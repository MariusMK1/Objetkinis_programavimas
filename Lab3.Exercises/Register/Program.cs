using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab3.Exercises.Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            DogsContainer container = InOutUtils.ReadDogs(@"Dogs.csv");
            InOutUtils.PrintDogs("Šunys", container);
            Console.WriteLine("Iš viso šunų: {0}", container.Count);
            Console.WriteLine("Patinų: {0}", container.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", container.CountByGender(Gender.Female));
            Dog oldest = container.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = container.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            DogsContainer FilteredByBreed = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs("Išfiltruotų pagal veislę sąrašas", FilteredByBreed);

            Dog oldestByBreed = container.FindOldestDog(selectedBreed);
            Console.WriteLine("Seniausias šuo pagal veislę");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldestByBreed.Name, oldestByBreed.Breed, oldestByBreed.Age);
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccination(@"Vaccinations.csv");
            container.UpdateVaccinationsInfo(VaccinationsData);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            DogsContainer FilterByVAccinationExpired = container.FilterByVaccinationExpired();
            InOutUtils.PrintDogsFiltered(FilterByVAccinationExpired);
            InOutUtils.PrintDogs("Reikia skiepyti (" + selectedBreed + ")", FilterByVAccinationExpired.Intersect(FilteredByBreed));

            DogsContainer allDogs = InOutUtils.ReadDogs(@"Dogs.csv");
            allDogs.Sort();
            InOutUtils.PrintDogs("Surikiuoti šunys", allDogs);
        }
    }
}
