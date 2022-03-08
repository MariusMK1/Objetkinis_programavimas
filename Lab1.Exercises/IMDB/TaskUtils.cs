using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class TaskUtils
    {
        public static int MaxGrossForYear(List<Movie> Movies, int year)
        {
            int Max = 0;
            List<string> Types = new List<string>();
            foreach (Movie movie in Movies)
            {
                if (movie.ReleaseDate.Year == year)
                {
                    if (Max < movie.Gross)
                        Max = movie.Gross;
                }
            }
            return Max;
        }
        public static int MostOccurancesOfDirector(List<Movie> Movies, List<Director> Directors)
        {
            int count = int.MinValue;
            foreach (Movie movie in Movies)
            {
                foreach (Director director in Directors)
                {
                    if(movie.Director == director.Name)
                    {
                        director.Count++;
                    }
                    if (director.Count > count)
                    {
                        count = director.Count;
                    }
                }
            }
            return count;
        }
        public static List<string> TheMostOccurringDirector(List<Director> Directors, int count)
        {
            List<string> MostOccDirector = new List<string>();
            foreach (Director item in Directors)
            {
                if (item.Count == count && !MostOccDirector.Contains(item.Name))
                {
                    MostOccDirector.Add(item.Name);
                }
            }
            return MostOccDirector;
        }
        public static List<Movie> NumberMoviesActor(List<Movie> Movies, string Actor)
        {
            List<Movie> Filtered = new List<Movie>();
            foreach (Movie movie in Movies)
            {
                if (Actor == movie.Actor1 || Actor == movie.Actor2)
                {
                    Filtered.Add(movie);
                }
            }
            return Filtered;
        }
    }
}
