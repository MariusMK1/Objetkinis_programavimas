using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class TaskUtils
    {
        public static MoviesContainer RecomendedMovies(MoviesContainer container1, MoviesContainer container2)
        {
            MoviesContainer Movies = new MoviesContainer();
            Movies.Name = container1.Name;
            for (int i = 0; i < container2.Count; i++)
            {
                if (!container1.Contains(container2.Get(i)))
                {
                    Movies.Add(container2.Get(i));
                }
            }
            return Movies;
        }
        public static double MaxGrossInTwoContainers(MoviesContainer container1, MoviesContainer container2)
        {
            double maxGross = double.MinValue;
            if (container1.FindsMaxGross() <= container2.FindsMaxGross())
                maxGross = container2.FindsMaxGross();
            else
                maxGross = container1.FindsMaxGross();
            return maxGross;
        }
        public static MoviesContainer MaxGross(MoviesContainer Movies, MoviesContainer container1, double maxGross)
        {
            for (int i = 0; i < container1.Count; i++)
            {
                if (maxGross == container1.Get(i).Gross)
                    if (!Movies.Contains(container1.Get(i)))
                    Movies.Add(container1.Get(i));
            }
            return Movies;
        }
    }
}
