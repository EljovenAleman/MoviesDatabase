using System.Threading.Tasks;
using Npgsql;
using System.Data;
using System.Collections.Generic;
using System;

namespace MoviesDatabase
{
    public class PostgresReviewRepositoy
    {
        private const string connectionString = "Server=127.0.0.1;User Id=main; " + "Password=39510745Db;Database=BettReviews;";


        NpgsqlDataAdapter dataAdapter;
        DataSet dataSet;


        public Task<Review> GetReview(string movieID, string reviewerEmail)
        {
            throw new System.NotImplementedException();

        }

        public List<Review> GetAllReviews()
        {
            ExecuteCommand("SELECT * FROM reviews");
                            
            return new List<Review>();
        }

        public Task SaveReview(Review review)
        {
            ExecuteCommand("INSERT INTO reviews (body, score, reviewer_name, reviewer_email ,movie_id) VALUES ('este es el body', " + 9 + ", 'el nombre del reviewer2', 'el email2', 'alienID')");
            return Task.CompletedTask;
        }

        private NpgsqlDataReader ExecuteCommand(string command)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            var cmd = new NpgsqlCommand(command, connection);

            var reader = cmd.ExecuteReader();

            /*while (reader.Read())
            {                                        
                 Console.WriteLine(reader.GetString(0));                    
            }*/
            return reader;
            
            connection.Close();                        
        }

        private DataSet Execute(string command)
        {
            NpgsqlConnection connection = new NpgsqlConnection(connectionString);
            connection.Open();

            dataSet = new DataSet();
            dataAdapter = new NpgsqlDataAdapter(command, connection);

            dataAdapter.Fill(dataSet);
            

            connection.Close();

            return dataSet;
        }
    }
}
