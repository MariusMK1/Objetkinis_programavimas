using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2.Exercises.Register
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            DogsRegister register = InOutUtils.ReadDogs(@"Dogs.csv");
            InOutUtils.PrintDogs2(register);
            Console.WriteLine("Iš viso šunų: {0}", register.DogsCount());
            Console.WriteLine("Patinų: {0}", register.CountByGender(Gender.Male));
            Console.WriteLine("Patelių: {0}", register.CountByGender(Gender.Female));
            Dog oldest = register.FindOldestDog();
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldest.Name, oldest.Breed, oldest.Age);
            Console.WriteLine();

            List<string> Breeds = register.FindBreeds();
            Console.WriteLine("Šunų veislės:");
            InOutUtils.PrintBreeds(Breeds);
            Console.WriteLine();
            Console.WriteLine("Kokios veislės šunis atrinkti?");
            string selectedBreed = Console.ReadLine();
            List<Dog> FilteredByBreed = register.FilterByBreed(selectedBreed);
            InOutUtils.PrintDogs(FilteredByBreed);

            Dog oldestByBreed = register.FindOldestDog(selectedBreed);
            Console.WriteLine("Seniausias šuo");
            Console.WriteLine("Vardas: {0}, Veislė: {1}, Amžius: {2}", oldestByBreed.Name, oldestByBreed.Breed, oldestByBreed.Age);
            Console.WriteLine();

            List<Vaccination> VaccinationsData = InOutUtils.ReadVaccination(@"Vaccinations.csv");
            register.UpdateVaccinationsInfo(VaccinationsData);

            string fileName = selectedBreed + ".csv";
            InOutUtils.PrintDogsToCSVFile(fileName, FilteredByBreed);

            List<Dog> FilterByVAccinationExpired = register.FilterByVaccinationExpired();
            InOutUtils.PrintDogsFiltered(FilterByVAccinationExpired);
        }
    }
}
