using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
using System.IO;

namespace IMDB
{
    internal class InOutUtils
    {
        public static List<Movie> ReadMovies(string fileName)
        {
            List<Movie> Movies = new List<Movie>();
            string[] Lines = File.ReadAllLines(fileName, Encoding.UTF8);
            foreach (string line in Lines)
            {
                string[] Values = line.Split(';');
                string title = Values[0];
                DateTime releaseDate = DateTime.Parse(Values[1]);
                string genre = Values[2];
                string studio = Values[3];
                string director = Values[4];
                string actor1 = Values[5];
                string actor2 = Values[6];
                int gross = int.Parse(Values[7]);
                Movie movie = new Movie(title, releaseDate, genre, studio, director, actor1, actor2, gross);
                Movies.Add(movie);
            }
            return Movies;
        }
        public static void PrintMovies(List<Movie> Movies)
        {
            Console.WriteLine(new String('-', 139));
            Console.WriteLine("| {0,-20} | {1,-14} | {2,-10} | {3,-22} | {4,-19} | {5,-10} | {6,-10} | {7,-9} |", "Pavadinimas", "Išleidimo Data", "Žanras", "Kino Studija", "Režisierius", "Aktorius1", "Aktorius2", "Pajamos");
            Console.WriteLine(new String('-', 139));
            foreach (Movie movie in Movies)
            {
                Console.WriteLine("| {0,-20} | {1,-14:yyyy-MM-dd} | {2,-10} | {3,-22} | {4,-19} | {5,-10} | {6,-10} | {7,-9} |", movie.Title, movie.ReleaseDate, movie.Genre, movie.Studio, movie.Director, movie.Actor1, movie.Actor2, movie.Gross);
            }
            Console.WriteLine(new String('-', 139));
        }
        public static void PrintMaxGrossForYear(List<Movie> Movies, int year)
        {
            int max = TaskUtils.MaxGrossForYear(Movies, year);
            if(!(max == 0))
            {
                Console.WriteLine("{0} metais daugiausia uždirbę filmai:", year);
                foreach (Movie movie in Movies)
                {
                    if (movie.Gross == max)
                        Console.WriteLine("{0} {1} {2}", movie.Title, movie.Director, movie.Gross);
                }
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("Filmų išleistų {0} metais nėra", year);
                Console.WriteLine();
            }
        }
        public static void PrintFilterdByActorToCSVFile(string fileName, List<Movie> Filtered, string actor)
        {
            if (!Filtered.Count.Equals(0))
            {
                string[] lines = new string[Filtered.Count + 2];
                lines[0] = string.Format("Filmai kuriuose vaidina {0}:", actor);
                lines[1] = string.Format("{0};{1};{2}", "Pavadinimas", "Išleidimo Data", "Kino Studija");
                for (int i = 0; i < Filtered.Count; i++)
                {
                    lines[i + 2] = String.Format("{0};{1,-10:yyyy-MM-dd};{2}", Filtered[i].Title, Filtered[i].ReleaseDate, Filtered[i].Studio);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[Filtered.Count + 1];
                lines[0] = string.Format("Filmų kuriuose vaidina {0} nėra:", actor);
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
        public static List<Director> InsertDirectors(List<Movie> Movies)
        {
            List<Director> Directors = new List<Director>();
            foreach (Movie movie in Movies)
            {
                string Name = movie.Director;
                int Count = 1;
                Director director = new Director(Name, Count);
                Directors.Add(director);
            }
            return Directors;
        }
        public static void PrintMostOccDirector(List<string> mostOccDirector)
        {
            Console.WriteLine("Daugiausiai filmų pastatę režisieriai: ");
            foreach (string s in mostOccDirector)
            {
                Console.WriteLine("{0}", s);
            }
        }
    }
}
