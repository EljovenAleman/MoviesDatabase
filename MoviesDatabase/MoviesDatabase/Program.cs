using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MoviesDatabase
{
    class Program
    {
        static void Main(string[] args)
        {
            var postgres = new PostgresReviewRepositoy();
            postgres.SaveReview(new Review());

            Console.ReadKey();
        }
    }
}
