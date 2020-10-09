using System.Collections.Generic;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

namespace ConsoleApp1
{
    partial class Program
    {
        class DBEmployeeService : IEmployeeService
        {
            private readonly string _connectionString;

            public DBEmployeeService(string connectionString)
            {
                _connectionString = connectionString;
            }

            public IEnumerable<User> GetDapperQuery(string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                {
                    IEnumerable<User> users = connection.Query<User>(QuerySQL);
                    return users;
                }
            }

            public User GetDapperQueryFirstOrDefault(string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                {
                    User users = connection.QueryFirstOrDefault<User>(QuerySQL);
                    return users;
                }
            }

            public async Task<User> GetDapperQueryFirstOrDefaultAsync(string QuerySQL)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                {
                    User user = await connection.QueryFirstOrDefaultAsync<User>(QuerySQL);
                    return user;
                }
            }
        }



       

    }
}

