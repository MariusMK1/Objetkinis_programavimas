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
            MoviesRegister register1 = InOutUtils.ReadMovies(@"Duom.csv");
            MoviesRegister register2 = InOutUtils.ReadMovies(@"Duom2.csv");
            InOutUtils.PrintMovies(register1);
            InOutUtils.PrintMovies(register2);
            MoviesRegister register3 = TaskUtils.BothSaw(register1, register2);
            InOutUtils.PrintMoviesToCSVFile("MatėAbu.csv", register3);
            double maxGross = TaskUtils.MaxGrossInTwoRegisters(register1, register2);
            MoviesRegister register4 = new MoviesRegister();
            TaskUtils.MaxGross(register4, register1, maxGross);
            TaskUtils.MaxGross(register4, register2, maxGross);
            Console.WriteLine("Daugiausiai uždirbę filmai:");
            InOutUtils.PrintMovies(register4);
            List<string> Genres = new List<string>();
            register1.FindGenres(Genres);
            register2.FindGenres(Genres);
            InOutUtils.PrintGenresToCSVFile("Žanrai.csv", Genres);
            Console.WriteLine();
            Console.WriteLine("Programa baigė darbą!");
        }
    }
}
