using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        interface IEmployeeService
        {
            IEnumerable<User> GetDapperQuery(string ConnectionString, string QuerySQL);
            User GetDapperQueryFirstOrDefault(string ConnectionString, string QuerySQL);
            Task<User> GetDapperQueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL);
        }

       

    }
}

