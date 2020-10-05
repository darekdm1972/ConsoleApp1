using System;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using Dapper;

namespace sqltest
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
                using SqlConnection connection = new SqlConnection(connectionString);

                string querySql = "SELECT TOP (10) [CustomerID],[FirstName],[LastName],[CompanyName],[EmailAddress],[Phone] FROM[AdventureWorksLT2019].[SalesLT].[Customer]";
                var users = connection.Query(querySql);
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.CustomerID} {user.FirstName} {user.LastName} {user.CompanyName} {user.EmailAddress}");
                }
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
    }
}