using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            AnimalsContainer container = InOutUtils.ReadAnimals(@"Dogs.csv");
            InOutUtils.PrintAnimals("Gyvūnai", container);
            Console.WriteLine("Agresyvių šunų yra: {0}", container.CountAggresiveDogs());
            Console.WriteLine("Iš viso šunų: {0}", container.Count);
            Console.WriteLine("Patinų: {0}", container.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", container.CountByGender(Gender.Female));
            Animal oldest = container.FindOldestAnimal();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = container.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            AnimalsContainer FilteredByBreed = container.FilterByBreed(selectedBreed);
            InOutUtils.PrintAnimals("Išfiltruotų pagal veislę sąrašas", FilteredByBreed);

            Animal oldestByBreed = container.FindOldestAnimal(selectedBreed);
            Console.WriteLine("Seniausias šuo pagal veislę");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldestByBreed.Name, oldestByBreed.Breed, oldestByBreed.Age);
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccination(@"Vaccinations.csv");
            container.UpdateVaccinationsInfo(VaccinationsData);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintAnimalsToCSVFile(fileName, FilteredByBreed);

            AnimalsContainer FilterByVAccinationExpired = container.FilterByVaccinationExpired();
            InOutUtils.PrintAnimalsFiltered(FilterByVAccinationExpired);
            InOutUtils.PrintAnimals("Reikia skiepyti (" + selectedBreed + ")", FilterByVAccinationExpired.Intersect(FilteredByBreed));

            AnimalsContainer allAnimals = InOutUtils.ReadAnimals(@"Dogs.csv");
            allAnimals.Sort(new AnimalsComparatorByName());
            InOutUtils.PrintAnimals("Surikiuoti gyvūnai pagal vardą ir ID", allAnimals);
            allAnimals.Sort(new AnimalsComparatorByBirthDate());
            InOutUtils.PrintAnimals("Surikiuoti gyvūnai pagal gimimo datą", allAnimals);
        }
    }
}
