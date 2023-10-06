using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheMovies.Model
{
    public class MovieRepository : IRepository
    {
        private Movie _movie = new();

        public Exception? Add(Movie movie)
        {
            using (SqlConnection con = new(IRepository.connectionString))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new("INSERT INTO Movie(Title, Duration, Genre)"
                        + " VALUES(@title,@duration,@genre)", con);
                    cmd.Parameters.Add("@title", SqlDbType.NVarChar).Value = movie.Title;
                    cmd.Parameters.Add("@duration", SqlDbType.Int).Value = movie.Duration;
                    cmd.Parameters.Add("@genre", SqlDbType.NVarChar).Value = movie.Genre;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                catch (Exception e)
                {

                   return e;
                }
                return null;
                
            }
        }


    }
}
