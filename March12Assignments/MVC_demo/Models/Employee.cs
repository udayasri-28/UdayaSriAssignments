namespace MVC_demo.Models
{
    public class Employee
    {
        public int EmployeeID { get; set; }
        public string? EmpName { get; set; }
        public int Salary { get; set; }
        public string? ImageUrl { get; set; }
        //FK+reference
        public int DeptID { get; set; }
        public Department? Department { get; set; }


    }
}
