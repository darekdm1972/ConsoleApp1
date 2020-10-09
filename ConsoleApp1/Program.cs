using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string ConnectionString = "Data Source=localhost;Initial Catalog=AdventureWorks;Integrated Security=True";
            string querySql1 = "SELECT [EmployeeKey],[FirstName],[LastName],[Title],[BirthDate],[EmailAddress],[Phone],[Status] FROM [dbo].[DimEmployee]";
            string querySql2 = querySql1 + " where [Status]='Current'";
            string querySql3 = querySql1 + " where [Status] is null";

            try
            {
                Employee emp = new Employee();

                Console.WriteLine("q1----------------");
                IEnumerable<User> u1 = emp.Dapper_Query(ConnectionString, QuerySQL: querySql1);
                foreach (User user in u1)
                {
                    Console.WriteLine(user.ToString());
                }

                Console.WriteLine("q2----------------");
                User u2 = emp.Dapper_QueryFirstOrDefault(ConnectionString, QuerySQL: querySql2);
                Console.WriteLine(u2.ToString());

                Console.WriteLine("q3----------------");
                User u3 = await emp.QueryFirstOrDefaultAsync(ConnectionString, QuerySQL: querySql3);
                Console.WriteLine(u3.ToString());


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
            IEnumerable<User> Dapper_Query(string ConnectionString, string QuerySQL);
            User Dapper_QueryFirstOrDefault(string ConnectionString, string QuerySQL);
            Task<User> QueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL);
        }

        public class Employee:IReadFromSQLServer
        {
            public IEnumerable<User> Dapper_Query(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    IEnumerable<User> users = connection.Query<User>(QuerySQL);
                    return users;
                }
            }

            public User Dapper_QueryFirstOrDefault(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    User users = connection.QueryFirstOrDefault<User>(QuerySQL);
                    return users;
                }
            }

            public async Task<User> QueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    User user = await connection.QueryFirstOrDefaultAsync<User>(QuerySQL);
                    return user;
                }
            }

        }

       

    }
}

