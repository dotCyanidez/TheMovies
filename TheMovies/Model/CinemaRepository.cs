using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class CinemaRepository
    {
        public Cinema Cinema { get; set; }

        public List<Cinema> Cinemas { get; set; }

        public CinemaRepository()
        {
          
        }

        public void Add(Cinema cinema) 
        {
            Cinemas.Add(cinema);
        }

    }

    

    

}
