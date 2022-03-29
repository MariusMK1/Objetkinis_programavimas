using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            MoviesContainer container1 = InOutUtils.ReadMovies(@"Duom.csv");
            MoviesContainer container2 = InOutUtils.ReadMovies(@"Duom2.csv");
            InOutUtils.PrintMovies(container1);
            InOutUtils.PrintMovies(container2);

            // Finds most occuring directors
            List<Director> Directors = InOutUtils.InsertDirectors(container1);
            int Count1 = container1.MostOccurancesOfDirector(Directors);
            List<string> mostOccDirectors1 = container1.TheMostOccurringDirector(Directors, Count1);
            InOutUtils.PrintMostOccDirector(mostOccDirectors1, container1);

            List<Director> Directors2 = InOutUtils.InsertDirectors(container2);
            int Count2 = container2.MostOccurancesOfDirector(Directors2);
            List<string> mostOccDirectors2 = container2.TheMostOccurringDirector(Directors2, Count2);
            InOutUtils.PrintMostOccDirector(mostOccDirectors2, container2);

            // Finds movies that made the most money
            double maxGross = TaskUtils.MaxGrossInTwoContainers(container1, container2);
            MoviesContainer container3 = new MoviesContainer();
            TaskUtils.MaxGross(container3, container1, maxGross);
            TaskUtils.MaxGross(container3, container2, maxGross);
            Console.WriteLine("Daugiausiai uždirbę filmai:");
            InOutUtils.PrintMovies(container3);

            // Finds movies that other person haven't seen and sorts them and prints to csv file
            MoviesContainer container4 = TaskUtils.RecomendedMovies(container1, container2);
            MoviesContainer container5 = TaskUtils.RecomendedMovies(container2, container1);
            container4.Sort();
            container5.Sort();
            string fileName1 = "Rekomendacija_" + container4.Name + ".csv";
            string fileName2 = "Rekomendacija_" + container5.Name + ".csv";
            Console.WriteLine(container4.Name);
            InOutUtils.PrintMoviesToCSVFile(fileName1, container4);
            InOutUtils.PrintMoviesToCSVFile(fileName2, container4);
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
