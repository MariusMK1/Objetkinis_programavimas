using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI_IMDB
{
    internal class Movie
    {
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string Genre { get; set; }
        public string Studio { get; set; }
        public string Director { get; set; }
        public string Actor1 { get; set; }
        public string Actor2 { get; set; }
        public int Gross { get; set; }
        public Movie(string title, DateTime releaseDate, string genre, string studio, string director, string actor1, string actor2, int gross)
        {
            this.Title = title;
            this.ReleaseDate = releaseDate;
            this.Genre = genre;
            this.Studio = studio;
            this.Director = director;
            this.Actor1 = actor1;
            this.Actor2 = actor2;
            this.Gross = gross;
        }
    }
}
