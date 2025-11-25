using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE.Data
{
    public class StudentsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Student> Students { get; set; } = new();
        public StudentsService()
        {
            GetAll();
        }

        public void Add(Student student)
        {
            var _student = new Student
            {
                Login = student.Login,
                Name = student.Name,
                Email = student.Email,
                Password = student.Password,
                CreatedAt = student.CreatedAt,
            };
            _db.Add<Student>(_student);
            Commit();
        }

        public int Commit() => _db.SaveChanges();

        public void GetAll()
        {
            var students = _db.Students.ToList();
            Students.Clear();
            foreach (var student in students)
            {
                Students.Add(student);
            }
        }

        public void Remove(Student student)
        {
            _db.Remove<Student>(student);
            if (Commit() > 0)
                if (Students.Contains(student))
                    Students.Remove(student);
        }


    }
}
