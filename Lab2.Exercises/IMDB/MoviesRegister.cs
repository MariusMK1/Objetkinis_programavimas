using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class MoviesRegister
    {
        private List<Movie> AllMovies;
        public MoviesRegister()
        {
            AllMovies = new List<Movie>();
        }
        public MoviesRegister(List<Movie> Movies)
        {
            AllMovies = new List<Movie>();
            foreach (Movie movie in Movies)
            {
                this.AllMovies.Add(movie);
            }
        }
        public void Add(Movie movie)
        {
            AllMovies.Add(movie);
        }
        public int MoviesCount()
        {
            return this.AllMovies.Count;
        }
        public Movie GetMovie(int index)
        {
            return this.AllMovies[index];
        }
        public bool Contains(Movie movie)
        {
            return AllMovies.Contains(movie);
        }
        public double FindsMaxGross()
        {
            double maxGross = double.MinValue;
            foreach (Movie movie in AllMovies)
            {
                if(movie.Gross > maxGross)
                    maxGross = movie.Gross;
            }
            return maxGross;
        }
        public List<string> FindGenres(List<string> Genres)
        {
            foreach (Movie movie in this.AllMovies)
            {
                string Genre = movie.Genre;
                if (!Genres.Contains(Genre))        //uses List method Contains()
                {
                    Genres.Add(Genre);
                }
            }
            return Genres;
        }
    }
}
