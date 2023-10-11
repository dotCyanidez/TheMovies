using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
namespace TheMovies.Model
{
    public class HallRepository : IRepository
    {
        #region Props
        public Hall Hall { get; set; }
        public List<Hall> Halls { get; set; }
        #endregion

        public void Add(Hall hall)
        {

            using (SqlConnection connection = new(IRepository.connectionString))
            {
                try
                {
                    connection.Open();
                    SqlCommand sqlCommand = new("exec sp_AddNewHall @CinemaId = @cinemaId, @Number = @number;", connection);
                    sqlCommand.Parameters.AddWithValue("@cinemaId", hall.CinemaId);
                    sqlCommand.Parameters.AddWithValue("@number", hall.Number);
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
                SqlCommand sqlCommand = new("exec  sp_SelectAllFromHall", connection);
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
                SqlCommand command = new("exec sp_SpecificHall @ID = @Id ", connection);
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

        public void Delete(int Id)
        {
            using SqlConnection connection = new(IRepository.connectionString);
            {
                connection.Open();
                SqlCommand command = new("exec sp_DeleteHall @ID = @Id", connection);
                command.Parameters.AddWithValue("@Id", Id);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Hall hall)
        {
            using SqlConnection connection = new(IRepository.connectionString);
            {
                connection.Open();
                SqlCommand command = new("exec sp_UpdateHall @ID = @Id, @CinemaId = @cinemaId, @Number = @number", connection);
                command.Parameters.AddWithValue("@Id", hall.Id);
                command.Parameters.AddWithValue("@cinemaId", hall.CinemaId);
                command.Parameters.AddWithValue("@number", hall.Number);
                command.ExecuteScalar();
            }
        }
    }
}
