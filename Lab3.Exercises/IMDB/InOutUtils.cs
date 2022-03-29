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
        public static MoviesContainer ReadMovies(string fileName)
        {
            MoviesContainer Movies = new MoviesContainer();
            StreamReader read = new StreamReader(fileName, Encoding.UTF8);
            string name = read.ReadLine();
            Movies.Name = name;
            int birthYear = int.Parse(read.ReadLine());
            string city = read.ReadLine();
            string lines;

            while ((lines = read.ReadLine()) != null)
            {
               string[] Values = lines.Split(';');
               string title = Values[0];
               DateTime releaseDate = DateTime.Parse(Values[1]);
               string genre = Values[2];
               string studio = Values[3];
               string director = Values[4];
               string actor1 = Values[5];
               string actor2 = Values[6];
               int gross = int.Parse(Values[7]);
               Movie movie = new Movie(title, releaseDate, genre, studio, director, actor1, actor2, gross);
                if (!Movies.Contains(movie))
                {
                    Movies.Add(movie);
                }
            }
            return Movies;
        }
        public static void PrintMovies(MoviesContainer container)
        {
            Console.WriteLine("{0}", container.Name);
            Console.WriteLine(new string('-', 139));
            Console.WriteLine("| {0,-20} | {1,-14} | {2,-10} | {3,-22} | {4,-19} | {5,-10} | {6,-10} | {7,-9} |", "Pavadinimas", "Išleidimo Data", "Žanras", "Kino Studija", "Režisierius", "Aktorius1", "Aktorius2", "Pajamos");
            Console.WriteLine(new string('-', 139));

            for (int i = 0; i < container.Count; i++)
            {
                Movie movie = container.Get(i);
                Console.WriteLine("| {0,-20} | {1,-14:yyyy-MM-dd} | {2,-10} | {3,-22} | {4,-19} | {5,-10} | {6,-10} | {7,-9} |", movie.Title, movie.ReleaseDate, movie.Genre, movie.Studio, movie.Director, movie.Actor1, movie.Actor2, movie.Gross);
            }
            Console.WriteLine(new string('-', 139));
            Console.WriteLine();
        }
        public static List<Director> InsertDirectors(MoviesContainer Movies)
        {
            List<Director> Directors = new List<Director>();
            for (int i = 0; i < Movies.Count; i++)
            {
                string Name = Movies.Get(i).Director;
                int Count = 1;
                Director director = new Director(Name, Count);
                Directors.Add(director);
            }
            return Directors;
        }
        public static void PrintMostOccDirector(List<string> mostOccDirector, MoviesContainer movies)
        {
            if(mostOccDirector.Count == 1)
            {
                Console.WriteLine("Kino mano {0} mėgstamiausi riežisieriai: ", movies.Name);
                foreach (string s in mostOccDirector)
                {
                    Console.WriteLine("{0}", s);
                }
            }
            else
            {
                Console.WriteLine("Kino manas {0} neturi mėgstamiausio riežisieriaus: ", movies.Name);
            }
            Console.WriteLine();
        }
        public static void PrintMoviesToCSVFile(string fileName, MoviesContainer container)
        {
            if (container.Count != 0)
            {
                string[] lines = new string[container.Count + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "Pavadinimas", "Išleidimo Data", "Žanras", "Kino Studija", "Režisierius", "Aktorius1", "Aktorius2", "Pajamos");
                for (int i = 0; i < container.Count; i++)
                {
                    Movie movie = container.Get(i);
                    lines[i + 1] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", movie.Title, movie.ReleaseDate, movie.Genre, movie.Studio, movie.Director, movie.Actor1, movie.Actor2, movie.Gross);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[container.Count + 1];
                lines[0] = string.Format("{0}", "Rekomenduojamų filmų nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
    }
}
