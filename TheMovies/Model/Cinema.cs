using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class Cinema
    {
        // hej Casper
        public int Id { get; set; }
        public string Name { get; }
        public  string Address { get;  }
        public string Phone { get; }
        public string Email { get; }

        public Cinema(string name, string address, string phone, string email) 
        {
            Name = name;
            Address = address;
            Phone = phone;
            Email = email;
        }
        
    }
}
