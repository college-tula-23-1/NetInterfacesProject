using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetXmlFormatsProject
{
    public class Employee
    {
        public Employee() { }
        public string? FirstName { get; set; }
        public string LastName { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public decimal Salary { get; set; }
    }
}
