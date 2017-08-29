using System.Collections.Generic;
using System.Threading.Tasks;
using AspNetCoreStarter.Models;
using AspNetCoreStarter.Services;
using AspNetCoreStarter.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace AspNetCoreStarter
{
    public class StudentsController : Controller
    {
        private IStudentData _studentData;
        public StudentsController(IStudentData studentData)
        {
            _studentData = studentData;
        }
        public IActionResult Index(string searchString)
        {
            var model = _studentData.GetAll();

            if (!string.IsNullOrEmpty(searchString))
            {
               model = _studentData.GetAll().Where(s => s.FirstName.StartsWith(searchString));
            }
            return View(model.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(StudentEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var student = new Student();
                student.FirstName = vm.FirstName;
                student.LastName = vm.LastName;
                student.Email = vm.Email;
                student.Status = vm.Status;

                student = _studentData.Add(student);

                return RedirectToAction("Index");
            }
            return View(vm);
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            int sid = id ?? 0;
            Student s = _studentData.GetById(sid);

            StudentEditViewModel vm = new StudentEditViewModel()
            {
                FirstName = s.FirstName,
                LastName = s.LastName,
                Email = s.Email,
                Status = s.Status
            };

            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, StudentEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                int sid = id ?? 0;
                var student = _studentData.GetById(sid);
                student.FirstName = vm.FirstName;
                student.LastName = vm.LastName;
                student.Email = vm.Email;
                student.Status = vm.Status;

                _studentData.Edit(student);
                return RedirectToAction("Index");
            }

            return View(vm);

        }
        public IActionResult Delete(int? id)
        {
            if(id == null)
            {
                return RedirectToAction("Index");
            }
            int sid = id ?? 0;
            var student = _studentData.GetById(sid);
            _studentData.Delete(student);
            return RedirectToAction("Index");
        }


    }
}