using System;

namespace ConsoleApp1
{

    internal class User
    {
        public int EmployeeKey { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public DateTime BirthDate { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public string Status { get; set; }

        public string FullName { get => $"{LastName} {FirstName}"; }
    }

}