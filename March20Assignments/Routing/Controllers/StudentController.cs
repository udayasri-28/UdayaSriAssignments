using Microsoft.AspNetCore.Mvc;
using Routing.Models;
namespace Routing.Controllers
{
    public class StudentController : Controller
    {
        List<Student> stuli = new List<Student>()
        {
            new Student{Id=101,Name="Siri",Class="class4"},
            new Student{Id=102,Name="Mahi",Class="class5"},
            new Student{Id=103,Name="Vini",Class="class7"}

        };
        [Route("studs")]
        public IActionResult GetAllStudents()
        {
            return View(stuli);
        }
        [Route("studs/{id}")]
        public IActionResult GetStudent(int id)
        {
            var student = stuli.FirstOrDefault(x=>x.Id==id);
            return View(student);
        }
        [Route("studsfew")]
        public IActionResult fewcol()
        {
            var fewcolm = stuli.Select(x => new Student
            {
                Class = x.Class,
                Name = x.Name,
            });
            return View(fewcolm);
        }
    }
}
