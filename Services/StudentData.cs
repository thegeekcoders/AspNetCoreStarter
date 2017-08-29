using System.Collections.Generic;
using AspNetCoreStarter.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreStarter.Services
{
    public interface IStudentData
    {
        IEnumerable<Student> GetAll();
        Student GetById(int id);
        Student Add(Student s);
        void Edit(Student s);
        void Delete(Student s);

        void Commit();
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

        public void Commit()
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Student s)
        {
            throw new System.NotImplementedException();
        }

        static List<Student> _students;
    }

    public class SqlStudentData : IStudentData
    {
        private AppDbContext _db;
        public SqlStudentData(AppDbContext db)
        {
            _db = db;
        }
        public Student Add(Student s)
        {
            _db.Students.Add(s);
            Commit();
            return s;
        }

        public void Commit()
        {
            _db.SaveChanges();
        }

        public void Edit(Student s)
        {
            _db.Entry(s).State = EntityState.Modified;
            Commit();
        }

        public void Delete(Student s)
        {
            _db.Remove(s);
            Commit();
        }

        public IEnumerable<Student> GetAll()
        {
            return _db.Students;
        }

        public Student GetById(int id)
        {
            var student = _db.Students.FirstOrDefault(s => s.Id == id);
            return (student != null) ? student : null;
        }
    }
}