using Microsoft.AspNetCore.Mvc;
using StudentsMangement.Data;
using StudentsMangement.Models;
using StudentsMangement.Models.Entitles;

namespace StudentsMangement.Controllers
{
    [Route("[Controller]")]
    [ApiController]
    public class StudentController : Controller
    { public ApplicationDbContext dbContext { get; }
        public StudentController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public IActionResult DisplayStudents()
        {
            var allStudents = dbContext.students.ToList();

            return View(allStudents);
        }

        [HttpPost]
        public IActionResult AddStudent([FromForm]AddStudentDto addStudentDto)
        {
            var student = new Student()
            {
                Name = addStudentDto.Name,
                Gender = addStudentDto.Gender,
                Grade = addStudentDto.Grade
            };


            dbContext.students.Add(student);
            dbContext.SaveChanges();

            return RedirectToAction("DisplayStudents", "Student");
        }


        [HttpGet]
        [Route("{Id:Guid}")]
        public IActionResult Delete(Guid Id)
        {
            var student = dbContext.students.Find(Id);
            if(student is null)
            {
                return NotFound();
            }
            dbContext.students.Remove(student);
            dbContext.SaveChanges();
            return RedirectToAction("DisplayStudents", "Student");
        }
        [HttpGet]
        [Route("Edit/{Id:Guid}")]
        public IActionResult Edit(Guid Id)
        {
            var student = dbContext.students.Find(Id);
            return View(student);
        }

        [HttpPost]
        [Route("{Id:Guid}")]
        public IActionResult Update(Guid Id,[FromForm] UpdateStudent updateStudent)
        {
            View(Id);
            var student = dbContext.students.Find(Id);
            if (student is null)
            {
                return NotFound();
            }
            student.Name = updateStudent.Name;
            student.Gender = updateStudent.Gender;
            student.Grade = updateStudent.Grade;
            dbContext.SaveChanges();
            return RedirectToAction("DisplayStudents", "Student");
        }
    }
}
