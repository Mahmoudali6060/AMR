using AMR_Server.Models;
using System.Collections.Generic;

namespace AMR_Server.Utility
{
    public static class DataStorage
    {
        public static List<Employee> GetAllEmployess() =>
            new List<Employee>
            {
                new Employee { Name="محمد ", LastName="علي", Age=35, Gender="Male"},
                new Employee { Name="Sonja", LastName="Markus", Age=22, Gender="Female"},
                new Employee { Name="Luck", LastName="Martins", Age=40, Gender="Male"},
                new Employee { Name="محمود", LastName="سلمان", Age=30, Gender="Female"},
                new Employee { Name="John", LastName="Doe", Age=45, Gender="Male"}
            };
    }
}
