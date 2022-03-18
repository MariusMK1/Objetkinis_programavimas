using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class TaskUtils
    {
        public static MoviesRegister BothSaw(MoviesRegister register1, MoviesRegister register2)
        {
            MoviesRegister Movies = new MoviesRegister();
            for (int i = 0; i < register1.MoviesCount(); i++)
            {
                for (int j = 0; j < register2.MoviesCount(); j++)
                {
                    if (register1.GetMovie(i).Title == register2.GetMovie(j).Title)
                    {
                        Movies.Add(register1.GetMovie(i));
                    }
                }
            }
            return Movies;
        }
        public static double MaxGrossInTwoRegisters(MoviesRegister register1, MoviesRegister register2)
        {
            double maxGross = 0;
            if (register1.FindsMaxGross() <= register2.FindsMaxGross())
                maxGross = register2.FindsMaxGross();
            else
                maxGross = register1.FindsMaxGross();
            return maxGross;
        }
        public static MoviesRegister MaxGross(MoviesRegister Movies, MoviesRegister register1, double maxGross)
        {
            for (int i = 0; i < register1.MoviesCount(); i++)
            {
                if (maxGross == register1.GetMovie(i).Gross)
                    Movies.Add(register1.GetMovie(i));
            }
            return Movies;
        }
    }
}
