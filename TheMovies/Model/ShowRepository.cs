using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Shell;

namespace TheMovies.Model
{
    public class ShowRepository : IRepository
    {
        private Show show;

        public void Add(int movieId, int hallId, DateTime showDate)
        {
            using SqlConnection con = new(IRepository.connectionString);
            {
                con.Open();
                SqlCommand cmd = new("INSERT INTO Show(MovieId, HallId, Date)"+
                    "VALUES(@movieId,@hallId,@showDate)", con);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@hallId", hallId);
                cmd.Parameters.AddWithValue("@showDate", showDate);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public void Delete(int id)
        {
            using SqlConnection con = new(IRepository.connectionString);
            {
                con.Open();
                SqlCommand cmd = new("DELETE Show WHERE Id = @id", con);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

        public Show Get(int id)
        {
            using SqlConnection con = new(IRepository.connectionString);
            {
                con.Open();
                SqlCommand cmd = new("SELECT * FROM MovieShowView WHERE ShowId = @id", con);
                cmd.Parameters.AddWithValue("@id", id);

                 SqlDataReader Reader = cmd.ExecuteReader();
                if (Reader.Read())
                {
                    show = new(Reader[nameof(Show.MovieTitle)].ToString(),
                        Reader[nameof(Show.MovieGenre)].ToString(),
                        Convert.ToInt32(Reader[nameof(Show.Duration)]),
                        Convert.ToInt32(Reader[nameof(Show.ShowId)]),
                        Reader[nameof(Show.CinemaName)].ToString(),
                        Convert.ToDateTime(Reader[nameof(Show.ShowDate)]));
                }
                con.Close();
                
            }

            return show; 
        }

        public List<Show> GetAll() 
        {
            List<Show> tempList = new();
            using SqlConnection con = new(IRepository.connectionString);
            {
                con.Open();
                SqlCommand cmd = new("SELECT * FROM MovieShowView", con);
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    show = new(Reader[nameof(Show.MovieTitle)].ToString(),
                        Reader[nameof(Show.MovieGenre)].ToString(),
                        Convert.ToInt32(Reader[nameof(Show.Duration)]),
                        Convert.ToInt32(Reader[nameof(Show.ShowId)]),
                        Reader[nameof(Show.CinemaName)].ToString(),
                        Convert.ToDateTime(Reader[nameof(Show.ShowDate)]));
                    tempList.Add(show);
                }
                con.Close();
                return tempList;
            }
        }

        public List<Show> GetAllWhitin30() 
        {
            List<Show> tempList = new();
            DateTime dt = DateTime.Now.AddMonths(1);
            using SqlConnection con = new(IRepository.connectionString);
            {
                con.Open();
                SqlCommand cmd = new("SELECT * FROM MovieShowView"+
                    " WHERE ShowDate BETWEEN @StartDate AND @EndDate", con);
                cmd.Parameters.AddWithValue("@startDate", DateTime.Today);
                cmd.Parameters.AddWithValue("@EndDate", dt);
                SqlDataReader Reader = cmd.ExecuteReader();
                while (Reader.Read())
                {
                    show = new(Reader[nameof(Show.MovieTitle)].ToString(),
                        Reader[nameof(Show.MovieGenre)].ToString(),
                        Convert.ToInt32(Reader[nameof(Show.Duration)]),
                        Convert.ToInt32(Reader[nameof(Show.ShowId)]),
                        Reader[nameof(Show.CinemaName)].ToString(),
                        Convert.ToDateTime(Reader[nameof(Show.ShowDate)]));
                    tempList.Add(show);
                }
                con.Close();
                return tempList;
            }
        }

        public void Update(int showId, int movieId, int hallId, DateTime date)
        {
            using SqlConnection conn = new(IRepository.connectionString);
            {
                conn.Open();
                SqlCommand cmd = new("UPDATE Show SET MovieId = @movieId,"+
                    " HallId = @hallId, Date = @date WHERE Id = @id", conn);
                cmd.Parameters.AddWithValue("@id", showId);
                cmd.Parameters.AddWithValue("@movieId", movieId);
                cmd.Parameters.AddWithValue("@hallId", hallId);
                cmd.Parameters.AddWithValue("@date", date);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }
}
