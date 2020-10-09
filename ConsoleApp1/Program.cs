using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1
{
    partial class Program
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
                IEnumerable<User> u1 = emp.GetDapperQuery(ConnectionString, QuerySQL: querySql1);
                foreach (User user in u1)
                {
                    Console.WriteLine(user.ToString());
                }

                Console.WriteLine("q2----------------");
                User u2 = emp.GetDapperQueryFirstOrDefault(ConnectionString, QuerySQL: querySql2);
                Console.WriteLine(u2.ToString());

                Console.WriteLine("q3----------------");
                User u3 = await emp.GetDapperQueryFirstOrDefaultAsync(ConnectionString, QuerySQL: querySql3);
                Console.WriteLine(u3.ToString());


            }
            catch (SqlException e)
            {
                Console.WriteLine(e.ToString());
            }
            Console.WriteLine("\nDone. Press enter.");
            Console.ReadLine();
        }
        
        public class Employee : IEmployeeService
        {
            public IEnumerable<User> GetDapperQuery(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    IEnumerable<User> users = connection.Query<User>(QuerySQL);
                    return users;
                }
            }

            public User GetDapperQueryFirstOrDefault(string ConnectionString, string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(ConnectionString);
                {
                    User users = connection.QueryFirstOrDefault<User>(QuerySQL);
                    return users;
                }
            }

            public async Task<User> GetDapperQueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL)
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

