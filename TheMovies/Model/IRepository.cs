using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public interface IRepository
    {
        protected static IConfiguration _config = new ConfigurationBuilder().AddJsonFile("appsettings.Json").Build();
        protected static string connectionString = _config.GetConnectionString("MyDbConnection");
    }
}
