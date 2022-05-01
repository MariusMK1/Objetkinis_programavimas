using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace GUI_IMDB
{
    public partial class Form1 : Form
    {
        private List<Director> directors = new List<Director>();
        private List<Movie> movies = new List<Movie>();
        public Form1()
        {
            InitializeComponent();
            daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem.Enabled = false;
            pelningiausias2019ToolStripMenuItem.Enabled = false;
            spausdintiĮCSVFailąToolStripMenuItem.Enabled = false;
            pradiniaiDuom.Hide();
        }
        private void įvestiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "csv files (*.csv) |*.csv|All files (*.*)|*.*";
            openFileDialog1.Title = "Pasirinkite duomenų failą";
            DialogResult result = openFileDialog1.ShowDialog();
            try
            {
                string fv = openFileDialog1.FileName;
                movies = ReadMovies(fv);
                // Komponento dataGridView1 užpildymas duomenimis
                info.ColumnCount = 9;
                info.Columns[0].Name = "Nr.";
                info.Columns[0].Width = 40;
                info.Columns[1].Name = "Pavadininmas";
                info.Columns[1].Width = 100;
                info.Columns[2].Name = "Išleidimo data";
                info.Columns[2].Width = 100;
                info.Columns[3].Name = "Žanras";
                info.Columns[3].Width = 100;
                info.Columns[4].Name = "Kino Studija";
                info.Columns[4].Width = 100;
                info.Columns[5].Name = "Režisierius";
                info.Columns[5].Width = 100;
                info.Columns[6].Name = "Aktorius1";
                info.Columns[6].Width = 100;
                info.Columns[7].Name = "Aktroius2";
                info.Columns[7].Width = 100;
                info.Columns[8].Name = "Pajamos";
                info.Columns[8].Width = 100;
                for (int i = 0; i < movies.Count; i++)
                {
                    Movie movie = movies[i];
                    info.Rows.Add(i + 1, movie.Title, movie.ReleaseDate, movie.Genre, movie.Studio, movie.Director, movie.Actor1, movie.Actor2, movie.Gross);
                }
                daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem.Enabled = true;
                pelningiausias2019ToolStripMenuItem.Enabled = true;
                spausdintiĮCSVFailąToolStripMenuItem.Enabled = true;
            }
            catch
            {
                MessageBox.Show("Failo formatas neteisingas!.", "Įspėjimas!");
            }
        }
        private void pelningiausias2019ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            info.Rows.Clear();

            int max = MaxGrossForYear(movies, 2019);
            if (!(max == 0))
            {
                info.ColumnCount = 3;
                info.Columns[0].Name = "Pavadininmas";
                info.Columns[0].Width = 200;
                info.Columns[1].Name = "Režisierius";
                info.Columns[1].Width = 200;
                info.Columns[2].Name = "Pajamos";
                info.Columns[2].Width = 200;
                foreach (Movie movie in movies)
                {
                    if (movie.Gross == max)
                        info.Rows.Add(movie.Title, movie.Director, movie.Gross);
                }
            }
            pradiniaiDuom.Show();
        }
        private void daugiausiaiFilmųPastatęsRežisieriusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            directors = InsertDirectors(movies);
            int Count = MostOccurancesOfDirector(movies, directors);
            List<string> mostOccDirectors = TheMostOccurringDirector(directors, Count);
            info.Rows.Clear();
            info.ColumnCount = 1;
            info.Columns[0].Name = "Daugiausiai filmų pastatę režisieriai: ";
            info.Columns[0].Width = 300;
            foreach (string s in mostOccDirectors)
            {
                info.Rows.Add(s);
            }
            pradiniaiDuom.Show();
        }

        private void spausdintiĮCSVFailąToolStripMenuItem_Click(object sender, EventArgs e)
        {
            List<Movie> Filtered = NumberMoviesActor(movies, "N.Cage");
            PrintFilterdByActorToCSVFile("Filtered.csv", Filtered, "N.Cage");
        }
        private void pradiniaiDuom_Click(object sender, EventArgs e)
        {
            info.Rows.Clear();
            info.ColumnCount = 9;
            info.Columns[0].Name = "Nr.";
            info.Columns[0].Width = 40;
            info.Columns[1].Name = "Pavadininmas";
            info.Columns[1].Width = 100;
            info.Columns[2].Name = "Išleidimo data";
            info.Columns[2].Width = 100;
            info.Columns[3].Name = "Žanras";
            info.Columns[3].Width = 100;
            info.Columns[4].Name = "Kino Studija";
            info.Columns[4].Width = 100;
            info.Columns[5].Name = "Režisierius";
            info.Columns[5].Width = 100;
            info.Columns[6].Name = "Aktorius1";
            info.Columns[6].Width = 100;
            info.Columns[7].Name = "Aktroius2";
            info.Columns[7].Width = 100;
            info.Columns[8].Name = "Pajamos";
            info.Columns[8].Width = 100;
            for (int i = 0; i < movies.Count; i++)
            {
                Movie movie = movies[i];
                info.Rows.Add(i + 1, movie.Title, movie.ReleaseDate, movie.Genre, movie.Studio, movie.Director, movie.Actor1, movie.Actor2, movie.Gross);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Close();
        }
        static List<Movie> ReadMovies(string fileName)
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
        static int MaxGrossForYear(List<Movie> Movies, int year)
        {
            int Max = 0;
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
        static int MostOccurancesOfDirector(List<Movie> Movies, List<Director> Directors)
        {
            int count = int.MinValue;
            foreach (Movie movie in Movies)
            {
                foreach (Director director in Directors)
                {
                    if (movie.Director == director.Name)
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
        static List<string> TheMostOccurringDirector(List<Director> Directors, int count)
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
        static List<Director> InsertDirectors(List<Movie> Movies)
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
        static List<Movie> NumberMoviesActor(List<Movie> Movies, string Actor)
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
        static void PrintFilterdByActorToCSVFile(string fileName, List<Movie> Filtered, string actor)
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
    }
}
