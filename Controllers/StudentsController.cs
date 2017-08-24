using System.Collections.Generic;
using AspNetCoreStarter.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspNetCoreStarter
{
    public class StudentsController : Controller
    {
        public IActionResult Index()
        {
            var model = new List<Student>()
            {
                new Student { Id = 1, FirstName = "Chetan",LastName = "Kharel", Email = "chetankharel7@gmail.com",Status=true},
                 new Student { Id = 2, FirstName = "Lokesh",LastName = "Banskota", Email = "lokesh@gmail.com",Status=false}
            };
            return View(model);

        }
    }
}