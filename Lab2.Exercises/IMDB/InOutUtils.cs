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
        public static MoviesRegister ReadMovies(string fileName)
        {
            MoviesRegister Movies = new MoviesRegister();
            StreamReader read = new StreamReader(fileName);
            string name = read.ReadLine();
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
        public static void PrintMovies(MoviesRegister register)
        {
            Console.WriteLine(new string('-', 139));
            Console.WriteLine("| {0,-20} | {1,-14} | {2,-10} | {3,-22} | {4,-19} | {5,-10} | {6,-10} | {7,-9} |", "Pavadinimas", "Išleidimo Data", "Žanras", "Kino Studija", "Režisierius", "Aktorius1", "Aktorius2", "Pajamos");
            Console.WriteLine(new string('-', 139));



            for (int i = 0; i < register.MoviesCount(); i++)
            {
                Console.WriteLine("| {0,-20} | {1,-14:yyyy-MM-dd} | {2,-10} | {3,-22} | {4,-19} | {5,-10} | {6,-10} | {7,-9} |", register.GetMovie(i).Title, register.GetMovie(i).ReleaseDate, register.GetMovie(i).Genre, register.GetMovie(i).Studio, register.GetMovie(i).Director, register.GetMovie(i).Actor1, register.GetMovie(i).Actor2, register.GetMovie(i).Gross);
            }
            Console.WriteLine(new string('-', 139));
            Console.WriteLine();
        }
        public static void PrintMoviesToCSVFile(string fileName, MoviesRegister register)
        {
            if(register.MoviesCount() != 0)
            {
                string[] lines = new string[register.MoviesCount() + 1];
                lines[0] = string.Format("{0};{1};{2};{3};{4};{5};{6};{7}", "Pavadinimas", "Išleidimo Data", "Žanras", "Kino Studija", "Režisierius", "Aktorius1", "Aktorius2", "Pajamos");
                for (int i = 0; i < register.MoviesCount(); i++)
                {
                    lines[i + 1] = String.Format("{0};{1};{2};{3};{4};{5};{6};{7}", register.GetMovie(i).Title, register.GetMovie(i).ReleaseDate, register.GetMovie(i).Genre, register.GetMovie(i).Studio, register.GetMovie(i).Director, register.GetMovie(i).Actor1, register.GetMovie(i).Actor2, register.GetMovie(i).Gross);
                }
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
            else
            {
                string[] lines = new string[register.MoviesCount() + 1];
                lines[0] = string.Format("{0}", "Filmų kuriuos matė abu nėra");
                File.WriteAllLines(fileName, lines, Encoding.UTF8);
            }
        }
        public static void PrintGenresToCSVFile(string fileName, List <string> Genres)
        {
            string[] lines = new string[Genres.Count() + 1];
            lines[0] = string.Format("{0}", "Žanrai");
            int i = 0;
            foreach(string genre in Genres)
            {
                lines[i + 1] = String.Format("{0}", genre);
                i++;
            }
            File.WriteAllLines(fileName, lines, Encoding.UTF8);
        }
    }
}
