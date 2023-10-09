using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class HallRepository
    {
        public  Hall Hall { get; set; }
        public List<Hall> Halls{ get; set; }

        public void Add(Hall hall)
        { Halls.Add(hall); }

        public void GetAll()
        {

        }
        public void Get(int Id)
        {

        }
    }
}
