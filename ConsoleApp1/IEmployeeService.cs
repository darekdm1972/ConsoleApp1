using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        interface IEmployeeService
        {
            IEnumerable<User> Dapper_Query(string ConnectionString, string QuerySQL);
            User Dapper_QueryFirstOrDefault(string ConnectionString, string QuerySQL);
            Task<User> QueryFirstOrDefaultAsync(string ConnectionString, string QuerySQL);
        }

       

    }
}

