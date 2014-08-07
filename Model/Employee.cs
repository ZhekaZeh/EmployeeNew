using System;

namespace EmployeeViewer.Model
{
    [Serializable]
    public class Employee
    {
        public string CompanyName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public Genders Sex { get; set; }
        public Positions Position  { get; set; }
        public int Salary { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
    }
}
