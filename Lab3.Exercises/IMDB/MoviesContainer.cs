using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMDB
{
    internal class MoviesContainer
    {
        private Movie[] movies;
        public int Count { get; private set; }
        public MoviesContainer()
        {
            this.movies = new Movie[16]; //default capacity
        }
        public string Name { get; set; }
        public void Add(Movie movie)
        {
            if (this.Count == this.Capacity) // Container is full
            {
                EnsureCapacity(this.Capacity * 2);
            }
            this.movies[this.Count++] = movie;
        }
        public void Put(int i, Movie movie)
        {
            this.Put(i, movie);       //Overides an element in the collection at the specified index.
        }
        public void Insert(int index, Movie movie)
        {
            if (this.Count == this.Capacity)
            {
                EnsureCapacity(this.Capacity * 2);
            }
            for (int i = this.Count; i > index; i--)
            {
                this.movies[i] = this.movies[i - 1];
            }
            this.movies[index] = movie;    //Inserts an element into the collection at the specified index.
            this.Count++;
        }
        public void Remove(Movie movie)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this.movies[i].Equals(movie))
                {
                    for (int j = i; j < Count; j++)
                    {
                        this.movies[j] = this.movies[j + 1];
                    }
                    Count--;
                }
            }
        }
        public void RemoveAt(int index)
        {
            for (int i = index; i < Count; i++)
            {
                this.movies[i] = this.movies[i + 1];
            }
            Count--;
        }
        public Movie Get(int index)
        {
            return this.movies[index];
        }
        public void Sort()
        {
            bool flag = true;
            while (flag)
            {
                flag = false;
                for (int i = 0; i < this.Count - 1; i++)
                {
                    Movie a = this.movies[i];
                    Movie b = this.movies[i + 1];
                    if (a.CompareTo(b) > 0)
                    {
                        this.movies[i] = b;
                        this.movies[i + 1] = a;
                        flag = true;
                    }
                }
            }
        }
        public bool Contains(Movie movie)
        {
            for (int i = 0; i < this.Count; i++)
            {
                if (this.movies[i].Equals(movie))
                {
                    return true;
                }
            }
            return false;
        }
        private int Capacity;
        public MoviesContainer(int capacity = 16)
        {
            this.Capacity = capacity;
            this.movies = new Movie[capacity];
        }
        private void EnsureCapacity(int minimumCapacity)
        {
            if (minimumCapacity > this.Capacity)
            {
                Movie[] temp = new Movie[minimumCapacity];
                for (int i = 0; i < this.Count; i++)
                {
                    temp[i] = this.movies[i];
                }
                this.Capacity = minimumCapacity;
                this.movies = temp;
            }
        }
        public MoviesContainer(MoviesContainer container) : this() //Calls another constructor
        {
            for (int i = 0; i < container.Count; i++)
            {
                this.Add(container.Get(i));
            }
        }
        public MoviesContainer Intersect(MoviesContainer other)
        {
            MoviesContainer result = new MoviesContainer();
            for (int i = 0; i < this.Count; i++)
            {
                Movie current = this.movies[i];
                if (other.Contains(current))
                {
                    result.Add(current);
                }
            }
            return result;
        }
        public int MostOccurancesOfDirector(List<Director> Directors)
        {
            int count = 0;
            for (int i = 0; i < this.Count; i++)
            {
                foreach (Director director in Directors)
                {
                    if (this.Get(i).Director == director.Name)
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
        public List<string> TheMostOccurringDirector(List<Director> Directors, int count)
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
        public double FindsMaxGross()
        {
            double maxGross = double.MinValue;
            for (int i = 0; i < this.Count; i++)
            {
                if (this.Get(i).Gross > maxGross)
                    maxGross = this.Get(i).Gross;
            }
            return maxGross;
        }
        public List<string> FindGenres(List<string> Genres)
        {
            for (int i = 0; i < this.Count; i++)
            {
                string Genre = this.Get(i).Genre;
                if (!Genres.Contains(Genre))        //uses List method Contains()
                {
                    Genres.Add(Genre);
                }
            }
            return Genres;
        }
    }
}
