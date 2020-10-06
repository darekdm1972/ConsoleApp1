using System;
using System.Collections.Generic;
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
                // string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorksLT2019;Integrated Security=True";
                string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorksDW2017;Integrated Security=True"; 
                using SqlConnection connection = new SqlConnection(connectionString);

                string querySql = "SELECT TOP (10) [EmployeeKey],[FirstName],[LastName],[Title],[BirthDate],[EmailAddress],[Phone],[Status] FROM [dbo].[DimEmployee]";
                IEnumerable<User> users = connection.Query<User>(querySql);
                foreach (var user in users)
                {
                    Console.WriteLine($"{user.EmployeeKey} {user.FirstName} {user.LastName} {user.Title} {user.EmailAddress} {user.BirthDate} {user.Phone} {user.Status}");
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

    internal class User
    {
        public int EmployeeKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        public string FullName { get => $"{LastName} {FirstName}"; }
    }
}
