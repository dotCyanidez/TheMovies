using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace TheMovies.Model
{
    public class HallRepository : IRepository
    {
        public Hall Hall { get; set; }
        public List<Hall> Halls { get; set; }

        public void Add(Hall hall)
        {

            using (SqlConnection connection = new(IRepository.connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlCommand = new("INSER INTO Hall (CinemaId, Number) Values (@CinemaId, @Number);", connection);
                    sqlCommand.Parameters.AddWithValue("CinemaId", hall.CinemaId);
                    sqlCommand.Parameters.AddWithValue("@Number", hall.Number);
                    sqlCommand.ExecuteScalar();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

        }

        public List<Hall> GetAll()
        {
            List<Hall> tempList = new List<Hall>();
            int id = 0;
            int cinemaId = 0;
            int number = 0;

            using (SqlConnection connection = new(IRepository.connectionString))
            {
                connection.Open();
                SqlCommand sqlCommand = new("SELECT * FROM Hall");
                SqlDataReader reader = sqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["Id"]);
                    cinemaId = Convert.ToInt32(reader["CinemaId"]);
                    number = Convert.ToInt32(reader["Number"]);
                    tempList.Add(new Hall(id, cinemaId, number));
                }
            }
            return tempList;
        }
        public Hall Get(int Id)
        {
            Hall Hall = new(1, 1, 1);

            using SqlConnection connection = new(IRepository.connectionString);
            {
                connection.Open();
                SqlCommand command = new($"SELECT * FROM Hall Where Id = @Id", connection);
                command.Parameters.Add("@Id", SqlDbType.Int).Value = Id;

                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Hall.Id = Convert.ToInt32(reader["Id"]);
                    Hall.CinemaId = Convert.ToInt32(reader["CinemaId"]);
                    Hall.Number = Convert.ToInt32(reader["Number"]);
                }
                return Hall;
            }
        }
    }
}
