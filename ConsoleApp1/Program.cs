using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string ConnectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Integrated Security=True";
            string querySql1 = "SELECT [EmployeeKey],[FirstName],[LastName],[Title],[BirthDate],[EmailAddress],[Phone],[Status] FROM [dbo].[DimEmployee]";
            string querySql2 = "SELECT [EmployeeKey],[FirstName],[LastName],[Title],[BirthDate],[EmailAddress],[Phone],[Status] FROM [dbo].[DimEmployee] where [Status]='Current'";

            try
            {
                DaneZSerwera_Query dane = new DaneZSerwera_Query(ConnectionString, querySql1);
                Console.WriteLine(dane);
                
                Console.WriteLine("\nDone. Press enter."); 
                Console.ReadLine();
                
                DaneZSerwera_QueryFirstOrDefault dane2 = new DaneZSerwera_QueryFirstOrDefault(ConnectionString, querySql2);
                Console.WriteLine(dane2);
            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }


        public class DaneZSerwera_Query
        {
            public DaneZSerwera_Query(string ConnectionString ,string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    IEnumerable<User> users = connection.Query<User>(QuerySQL);
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.EmployeeKey} {user.FirstName} {user.LastName} {user.Title} {user.EmailAddress} {user.BirthDate} {user.Phone} {user.Status}");
                    }
                }
            }
        }

        public class DaneZSerwera_QueryFirstOrDefault
        {
            public DaneZSerwera_QueryFirstOrDefault(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    var users = connection.QueryFirstOrDefault<User>(QuerySQL);
                    Console.WriteLine($"{users.FullName}");                    
                }
            }
        }
    }
}
