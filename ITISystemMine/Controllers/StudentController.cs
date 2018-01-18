using ITISystemMine.Models;
using ITISystemMine.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ITISystemMine.Controllers
{
    public class StudentController : Controller
    {
        ApplicationDbContext ITI;
        public StudentController()
        {
            ITI = new ApplicationDbContext();
        }
        public ActionResult Index()
        {
            var x = 56;
            IList<Student> Students = ITI.Students.ToList();
            return View(Students);
        }
        public ActionResult StudentForm()
        {
            StudentDepartmentViewModel StdDprt = new StudentDepartmentViewModel()
            {
                Student = new Student(),
                Departments = ITI.Departments.ToList()
            };
            return View(StdDprt);
        }
        public ActionResult Details(int Id)
        {
            var Student = ITI.Students.Include("Department").SingleOrDefault(c => c.Id == Id);
            return View(Student);
        }
        [HttpPost]
        public ActionResult Save(Student student)
        {
            if (!ModelState.IsValid)
            {
                Student Student = ITI.Students.SingleOrDefault(std => std.Id == student.Id);
                StudentDepartmentViewModel StdDprt = new StudentDepartmentViewModel()
                {
                    Student = Student,
                    Departments = ITI.Departments.ToList()
                };
                return View("StudentForm", StdDprt);
            }
            else
            {
                if (student.Id == 0)
                {
                    //not add a student to a department if the number of students in this department equal to the capacity of the department
                    //In this case set the student department to null
                    int departCapacity = ITI.Departments.SingleOrDefault(d => d.Id == student.Department_Key).Capacity;
                    int StdCountInDepart = ITI.Students.Where(std => std.Department_Key == student.Department_Key).ToList().Count();

                    if (StdCountInDepart < departCapacity)
                    {
                        ITI.Students.Add(student);                      
                    }
                    else
                    {
                        student.Department_Key = null;
                        ITI.Students.Add(student);                       
                    }
                    ITI.SaveChanges();
                }
                else
                {
                    Student Std = ITI.Students.SingleOrDefault(std => std.Id == student.Id);
                    Std.FirstName = student.FirstName;
                    Std.LastName = student.LastName;
                    Std.Address.Country = student.Address.Country;
                    Std.Address.City = student.Address.City;
                    Std.Address.Street = student.Address.Street;
                    Std.Attend_Balance = student.Attend_Balance;
                    Std.BirthDate = student.BirthDate;
                    Std.Department_Key = student.Department_Key;
                    Std.Email = student.Email;
                    Std.Password = student.Password;
                    Std.Telephone = student.Telephone;
                    Std.UserName = student.UserName;
                    ITI.SaveChanges();
                }
                return RedirectToAction("Index");
            }
        }
        public ActionResult Back()
        {
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int Id)
        {
            Student Student = ITI.Students.SingleOrDefault(std => std.Id == Id);
            StudentDepartmentViewModel StdDprt = new StudentDepartmentViewModel()
            {
                Student = Student,
                Departments = ITI.Departments.ToList()
            };
            return View("StudentForm", StdDprt);
        }
        public ActionResult Delete(int Id)
        {
            Student student = ITI.Students.SingleOrDefault(s=>s.Id==Id);
            ITI.Students.Remove(student);
            ITI.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}