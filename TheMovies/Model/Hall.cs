using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Hall
    {
        public int Id { get; set; }
        public int CinemaId { get; set; }
        public int Number { get; set; }

        public Hall(int id, int cinemaId, int number)
        {
            Id = id;
            CinemaId = cinemaId;
            Number = number;
        }
    }
}
