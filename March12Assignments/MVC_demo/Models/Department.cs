namespace MVC_demo.Models
{
    public class Department
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public List<Department> DeptList { get; set; } = new List<Department>();
    }
}
