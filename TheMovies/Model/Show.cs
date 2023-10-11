using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Show
    {
        public string MovieTitle { get; set; }
        public string MovieGenre { get; set; }
        public int Duration { get; set;}
        public int ShowId { get; set; }
        public string CinemaName { get; set; }

        public DateTime ShowDate { get; set; }

        public Show(string movieTitle, string movieGenre, int duration, int showId, string cinemaName, DateTime showDate)
        {
            MovieTitle = movieTitle;
            MovieGenre = movieGenre;
            Duration = duration + 30; // tilføjer 30 min til duration sådan at der er de 15 min til rengøring og 15 min til reklamer
            ShowId = showId;
            CinemaName = cinemaName;
            ShowDate = showDate;
        }

        //public Show(string movieTitle, string movieGenre, int Duration, int showId, string cinemaName, DateTime showDate)
        //{

        //}



    }
}
