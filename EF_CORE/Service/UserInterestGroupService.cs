using EF_CORE.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace EF_CORE.Service
{
    public class UserInterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<UserInterestGroup> UserInterestGroups { get; set; } = new();
        public int Commit() => _db.SaveChanges();
        public void Add(UserInterestGroup groupUser)
        {
            var _groupUser = new UserInterestGroup
            {
                UserId = groupUser.UserId,
                InterestGroupId = groupUser.InterestGroupId,

                JoinedAt = groupUser.JoinedAt,
                IsModerator = groupUser.IsModerator,

                Student = groupUser.Student,
                InterestGroup = groupUser.InterestGroup,
            };
            _db.Add<UserInterestGroup>(_groupUser);
            _db.SaveChanges();
        }
        public void GetAll(int? groupId = null)
        {
            if (groupId != null)
            {



                var users = _db.UserInterestGroups
                                   .Include(s => s.Student)
                                   .ThenInclude(u => u.UserProfile)
                                   .Include(uig => uig.InterestGroup)
                                   .Where(uig => uig.InterestGroupId == groupId)
                                   .ToList();

                UserInterestGroups.Clear();

                foreach (var user in users)
                {
                    UserInterestGroups.Add(user);
                }
            }
        }

        public void GetAllGroupsForUser(int userId)
        {
            var userGroups = _db.UserInterestGroups
                               .Include(ug => ug.Student)
                               .Include(ug => ug.InterestGroup)
                               .Where(ug => ug.UserId == userId)
                               .ToList();

            UserInterestGroups.Clear();

            foreach (var userGroup in userGroups)
            {
                UserInterestGroups.Add(userGroup);
            }
        }

        public void UserInterestAttach(Student student, InterestGroup interestGroup)
        {
            _db.Students.Attach(student);
            _db.InterestGroups.Attach(interestGroup);
        }

        public UserInterestGroupService()
        {
            GetAll();
        }
        public void Remove(UserInterestGroup userInterestGroup)
        {
            _db.Remove<UserInterestGroup>(userInterestGroup);
            if (Commit() > 0)
                if (UserInterestGroups.Contains(userInterestGroup))
                    UserInterestGroups.Remove(userInterestGroup);
        }

        public void LoadRelation(UserInterestGroup userInterestGroup, string relation)
        {
            var entry = _db.Entry(userInterestGroup);
            var navigation = entry.Metadata.FindNavigation(relation)
            ?? throw new InvalidOperationException($"Navigation '{relation}' not found");

            if (navigation.IsCollection)
            {
                entry.Collection(relation).Load();
            }
            else
            {
                entry.Reference(relation).Load();
            }
        }
    }
}
