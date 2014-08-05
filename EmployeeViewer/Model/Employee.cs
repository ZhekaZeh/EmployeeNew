using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeViewer.Model
{
    class Employee
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public bool Sex { get; set; }
        public EnumPositions Position  { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

    }
}
