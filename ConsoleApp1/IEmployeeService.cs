using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        interface IEmployeeService
        {
            IEnumerable<User> GetDapperQuery(string QuerySQL);
            User GetDapperQueryFirstOrDefault(string QuerySQL);
            Task<User> GetDapperQueryFirstOrDefaultAsync(string QuerySQL);
        }

       

    }
}

