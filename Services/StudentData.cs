using System.Collections.Generic;
using AspNetCoreStarter.Models;
using System.Linq;

namespace AspNetCoreStarter.Services
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Student Add(Student s);
        void Edit(Student s);
    }
    public class InMemoryStudentData : IStudentData
    {
        static InMemoryStudentData()
        {
            _students = new List<Student>
            {
                 new Student { Id = 1, FirstName = "Chetan",LastName = "Kharel", Email = "chetankharel7@gmail.com",Status=true},
                 new Student { Id = 2, FirstName = "Lokesh",LastName = "Banskota", Email = "lokesh@gmail.com",Status=false}
            };
        }
       
        public Student Add(Student newStudent)
        {
        newStudent.Id = _students.Max(s => s.Id) + 1;
            _students.Add(newStudent);
            return newStudent;

        }

        public void Edit(Student s)
        {
            var student = GetById(s.Id);
            student.FirstName = s.FirstName;
            student.LastName = s.LastName;
            student.Email = s.Email;
            student.Status = s.Status;
        }

        public IEnumerable<Student> GetAll()
        {
            return _students;
        }

        public Student GetById(int id)
        {
            return _students.FirstOrDefault(s => s.Id == id);
        }

          static List<Student> _students;
    }
}