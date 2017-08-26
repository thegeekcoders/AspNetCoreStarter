using System.Collections.Generic;
using AspNetCoreStarter.Models;
using AspNetCoreStarter.Services;
using AspNetCoreStarter.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreStarter
{
    public class StudentsController : Controller
    {
        private IStudentData _studentData;
        public StudentsController(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public IActionResult Index()
        {
            var model = _studentData.GetAll();
            return View(model);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentEditViewModel vm)
        {
            if(ModelState.IsValid)
            {
                var student = new Student();
                student.FirstName = vm.FirstName;
                student.LastName = vm.LastName;
                student.Email = vm.Email;
                student.Status = vm.Status;

               student =  _studentData.Add(student);

                return View("Index");
            }
            return View(vm);
        }


    }
}