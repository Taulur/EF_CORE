using Microsoft.EntityFrameworkCore;
using EF_CORE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE.Service
{
    public class StudentsService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Student> Students { get; set; } = new();
        public StudentsService()
        {
            GetAll();
            GetGroups();
        }
        public void Add(Student user)
        {
            var _user = new Student
            {
                Login = user.Login,
                Name = user.Name,
                Email = user.Email,
                Password = user.Password,
                CreatedAt = user.CreatedAt,
                UserProfile = user.UserProfile,
                RoleId = user.RoleId,
                Role = user.Role,
            };
            _db.Add<Student>(_user);
            Commit();
        }
        public int Commit() => _db.SaveChanges();
        public void GetAll(int? roleId = null)
        {
            if (roleId != null)
            {
                var students = _db.Students
                                    .Include(s => s.UserProfile)
                                    .Include(s => s.Role)
                                    .Where(u => u.RoleId == roleId)
                                    .ToList();
                Students.Clear();
                foreach (var student in students)
                {
                    Students.Add(student);
                }
            }
            else
            {
                var users = _db.Students
                                            .Include(s => s.UserProfile)
                                            .Include(s => s.Role)
                                            .ToList();

                Students.Clear();
                foreach (var user in users)
                {
                    Students.Add(user);
                }
            }
        }
        public void GetGroups(int? studentId = null)
        {
            var interestTitles = _db.Students
    .Where(s => s.Id == studentId)
    .SelectMany(s => s.UserInterestGroup)
    .Select(uig => uig.InterestGroup.Title)
    .ToList();
        }
        public void Remove(Student user)
        {
            _db.Remove<Student>(user);
            if (Commit() > 0)
                if (Students.Contains(user))
                    Students.Remove(user);
        }

        public void AddProfile(UserProfile profile)
        {
            _db.UserProfiles.Add(profile);
        }

        public void UpdateProfile(UserProfile profile)
        {
            var existing = _db.UserProfiles.Find(profile.Id);
            if (existing != null)
            {
                existing.Phone = profile.Phone;
                existing.Birthday = profile.Birthday;
                existing.Bio = profile.Bio;
                existing.AvatarUrl = profile.AvatarUrl;
            }
        }


    }
}
