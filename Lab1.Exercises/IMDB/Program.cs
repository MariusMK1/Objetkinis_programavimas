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
            List<Movie> allMovies = InOutUtils.ReadMovies(@"Duom2.csv");
            InOutUtils.PrintMovies(allMovies);
            InOutUtils.PrintMaxGrossForYear(allMovies, 2019);
            List<Director> Directors = InOutUtils.InsertDirectors(allMovies);
            int Count = TaskUtils.MostOccurancesOfDirector(allMovies, Directors);
            List<string> mostOccDirectors = TaskUtils.TheMostOccurringDirector(Directors, Count);
            InOutUtils.PrintMostOccDirector(mostOccDirectors);
            List<Movie> Filtered = TaskUtils.NumberMoviesActor(allMovies, "N.Cage");
            InOutUtils.PrintFilterdByActorToCSVFile("Filtered.csv", Filtered, "N.Cage");
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
