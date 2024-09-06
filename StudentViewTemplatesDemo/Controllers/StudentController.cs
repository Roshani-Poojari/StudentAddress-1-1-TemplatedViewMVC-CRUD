using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using StudentViewTemplatesDemo.Models;

namespace StudentViewTemplatesDemo.Controllers
{
    [RoutePrefix("students")]
    public class StudentController : Controller
    {
        static List<Student> students = new List<Student>()
        {
            new Student(){Id=1,Name="John",Age=28,Address=new Address(){ Id=101, Country="United States", State="California",City="Los Angeles"}},
            new Student(){Id=2,Name="Aisha",Age=24,Address=new Address(){Id=102,Country="Egypt",State="Cairo Governorate",City="Cairo"}},
            new Student(){Id=3,Name="Hiroshi",Age=30,Address=new Address(){Id=103,Country="Japan",State="Tokyo",City="Shibuya"}},
            new Student(){Id=4,Name="Anna",Age=19,Address=new Address(){Id=104,Country="Germany",State="Bavaria",City="Munich"}},
            new Student(){Id=5,Name="Carlos",Age=45,Address=new Address(){Id=105,Country="Brazil",State="Rio de Janeiro",City="Rio de Janeiro"}}
        };

        [Route("")]
        public ActionResult GetAllStudents()
        {
            return View(students);
        }

        [Route("{id}")]
        public ActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);
            return View(student);
        }
        [Route("address/{id}")]
        public ActionResult GetAddressOfStudentById(int id)
        {
            var studentAddress = students.Where(st => st.Id == id).FirstOrDefault();
            ViewBag.StudentId = studentAddress.Id;
            return View(studentAddress.Address);
        }

        [Route("createstudent")]
        public ActionResult CreateStudent()
        {
            return View();
        }
        [HttpPost]
        [Route("createstudent")]
        public ActionResult CreateStudent(Student student)
        {
            if (ModelState.IsValid)
            {
                student.Id = students.Count() + 1;
                students.Add(student);
                return RedirectToAction("GetAllStudents");
            }
            return View();
        }
        [Route("delete/{id}")]
        public ActionResult Delete(int id)
        {
            var student = students.FirstOrDefault(students => students.Id == id);
            return View(student);
        }

        [HttpPost]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            var deleteStudent = students.FirstOrDefault(students => students.Id == id);
            students.Remove(deleteStudent);
            return RedirectToAction("GetAllStudents");
        }


        [Route("edit/{id}")]
        public ActionResult Edit(int id)
        {
            var editStudent = students.FirstOrDefault(students => students.Id == id);
            return View(editStudent);

        }
        [HttpPost]
        [Route("edit/{id}")]
        public ActionResult Edit(Student student)
        {
            if (ModelState.IsValid)
            {
                var updateStudent = students.FirstOrDefault(s => s.Id == student.Id);
                updateStudent.Name = student.Name;
                updateStudent.Age = student.Age;
                return RedirectToAction("GetAllStudents");
            }
            return View();
        }

        [Route("editaddress/{studentId}/{addressId}")]
        public ActionResult EditAddress(int studentId, int addressId)
        {
            var student = students.FirstOrDefault(s => s.Id == studentId && s.Address.Id == addressId);
            //TempData["StudentId"] = studentId;
            ViewBag.StudentId = student.Id;
            return View(student.Address);
        }
        [HttpPost]
        [Route("editaddress/{studentId}/{addressId}")]
        public ActionResult EditAddress(int studentId, int addressId, Address address)
        {
            if (ModelState.IsValid)
            {
                var updateStudentAddress = students.FirstOrDefault(s => s.Id == studentId && s.Address.Id == addressId);
                updateStudentAddress.Address.City = address.City;
                updateStudentAddress.Address.State = address.State;
                updateStudentAddress.Address.Country = address.Country;
                return RedirectToAction("GetAddressOfStudentById", new { id = studentId });
            }
            return View(address);
        }
        [Route("deleteaddress/{studentId}/{addressId}")]
        public ActionResult DeleteAddress(int studentId, int addressId)
        {
            var studentAddress = students.FirstOrDefault(s => s.Id == studentId && s.Address.Id == addressId);
            ViewBag.StudentId = studentAddress.Id;
            return View(studentAddress.Address);
        }

        [HttpPost]
        [Route("deleteaddress/{studentId}/{addressId}")]
        public ActionResult DeleteAddressConfirmed(int studentId, int addressId)
        {
            var deleteStudentAddress = students.FirstOrDefault(s => s.Id == studentId && s.Address.Id == addressId);
            deleteStudentAddress.Address = null;
            return RedirectToAction("GetAllStudents");
        }
        [Route("addaddress/{studentId}")]
        public ActionResult AddAddress(int studentId)
        {
            var addStudentAddress = students.FirstOrDefault(s => s.Id == studentId);
            ViewBag.StudentId = studentId;
            return View(new Address());
        }
        [HttpPost]
        [Route("addaddress/{studentId}")]
        public ActionResult AddAddress(int studentId, Address address)
        {

            var addStudentAddress = students.FirstOrDefault(s => s.Id == studentId);
            if (addStudentAddress.Address == null)
            {
                addStudentAddress.Address = new Address();
            }
            if (ModelState.IsValid)
            {
                addStudentAddress.Address.Id = students.Count() + 101;
                addStudentAddress.Address.Country = address.Country;
                addStudentAddress.Address.State = address.State;
                addStudentAddress.Address.City = address.City;
                return RedirectToAction("GetAddressOfStudentById", new { id = studentId });
            }
            ViewBag.StudentId = studentId;
            return View(address);
        }
    }
}