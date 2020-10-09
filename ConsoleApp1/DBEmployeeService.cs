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

            public async Task<IEnumerable<User>> GetDapperQuery(string querySQL)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                {
                    IEnumerable<User> users = await connection.QueryAsync<User>(querySQL);
                    return users;
                }
            }

            public async Task<User> GetDapperQueryFirstOrDefault(string querySQL)
            {
                using SqlConnection connection = new SqlConnection(_connectionString);
                {
                    User user = await connection.QueryFirstOrDefaultAsync<User>(querySQL);
                    return user;
                }
            }
        }



       

    }
}

