using Microsoft.AspNetCore.Mvc;
using MVC_demo.Models;
using System.Diagnostics;

namespace MVC_demo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public string sampledemo1()
        {
            return "Udaya Sri";
        }
        public string sampledemo2(int age,string name)
        {
            return "The name"+name+" is having age "+age; 
        }
        public IActionResult sampledemo3()
        {
            int age = 24;
            string name = "siri";
            ViewBag.Name = name;
            ViewBag.Age = age;
            ViewData["Message"] = "Welcome to Asp.net core learning";
            ViewData["Year"]=DateTime.Now.Year;
            return View();
        }
        Employee e1 = new Employee()
        {
            EmployeeID = 101,
            EmpName = "Mahi",
            Salary = 50000
        };

        List<Employee> emplist = new List<Employee>()
        {
            new Employee{EmployeeID=101,EmpName="siri",Salary=50000,ImageUrl="/images/emp1.jpg"},
            new Employee{EmployeeID=102,EmpName="mahi",Salary=34000,ImageUrl="/images/emp2.jpg"},
            new Employee{EmployeeID=103,EmpName="stefan",Salary=55000,ImageUrl="/images/emp3.jpg"}
        };
        public IActionResult collectionobjpassing()
        {
            return View(emplist);
        }
        public IActionResult singleobjpassing()
        {
            return View(e1);
        }
        public IActionResult display()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
