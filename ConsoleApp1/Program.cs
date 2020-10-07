using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1
{
    class Program
    {
        private static Task<object> count;

        static void Main(string[] args)
        {
           
            try
            {
                // string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorksDW2019;Integrated Security=True";
                string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Integrated Security=True";
                string querySql = "SELECT [EmployeeKey],[FirstName],[LastName],[Title],[BirthDate],[EmailAddress],[Phone],[Status] FROM [dbo].[DimEmployee]";

                using SqlConnection connection = new SqlConnection(connectionString);
                {
                    IEnumerable<User> users = connection.Query<User>(querySql);
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.EmployeeKey} {user.FirstName} {user.LastName} {user.Title} {user.EmailAddress} {user.BirthDate} {user.Phone} {user.Status}");
                    }
                }

                var c = CountEmployeeAsync("Current");
                Console.WriteLine(c);

            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        private static async Task<string> CountEmployeeAsync(string v)
        {
            string connectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Integrated Security=True";
            using SqlConnection connection = new SqlConnection(connectionString);
            {
                var sql = "select count(*) from [dbo].[DimEmployee] where [Status]=" + v;
                return (string)await (count = (Task<object>)connection.Query(sql));
            }
        }

       
   
    }

}
