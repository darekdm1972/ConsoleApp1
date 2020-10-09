using System.Collections.Generic;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    partial class Program
    {
        interface IEmployeeService
        {
            Task<IEnumerable<User>> GetDapperQuery(string querySQL);
            Task<User> GetDapperQueryFirstOrDefault(string querySQL);
        }
    }
}

