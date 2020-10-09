using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Reflection.Metadata;
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
            string querySql3 = "SELECT [EmployeeKey],[FirstName],[LastName],[Title],[BirthDate],[EmailAddress],[Phone],[Status] FROM [dbo].[DimEmployee] where [Status] is null";

            try
            {
                DaneZSerwera d1 = new DaneZSerwera();

                Console.WriteLine("q1----------------");
                d1.Dapper_Query(ConnectionString, QuerySQL: querySql1);
                Console.WriteLine("q2----------------");
                d1.Dapper_QueryFirstOrDefault(ConnectionString, QuerySQL: querySql2);
                Console.WriteLine("q3----------------");
                d1.QueryFirstOrDefaultAsync(ConnectionString, QuerySQL: querySql3);
                Console.WriteLine("end----------------");


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }

        interface IReadFromSQLServer
        {
            void Dapper_Query(string ConnectionString, string QuerySQL);
            void Dapper_QueryFirstOrDefault(string ConnectionString, string QuerySQL);
            void QueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL);
        }

        public class DaneZSerwera:IReadFromSQLServer
        {
            public void Dapper_Query(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    IEnumerable<User> users = connection.Query<User>(QuerySQL).AsList();
                    foreach (var user in users)
                    {
                        Console.WriteLine($"{user.EmployeeKey} {user.FirstName} {user.LastName} {user.Title} {user.EmailAddress} {user.BirthDate} {user.Phone} {user.Status}");
                    }

                }
            }

            public void Dapper_QueryFirstOrDefault(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    var users = connection.QueryFirstOrDefault<User>(QuerySQL);
                    Console.WriteLine($"{users.FullName}");
                }
            }

            public async void QueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    var users = await connection.QueryFirstOrDefaultAsync(QuerySQL);
                    Console.WriteLine($"{users.Result}");
                }
            }

        }

       

    }
}

