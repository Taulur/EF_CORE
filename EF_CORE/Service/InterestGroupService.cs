using EF_CORE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE.Service
{
    public class InterestGroupService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public static ObservableCollection<InterestGroup> InterestGroups { get; set; } = new();
        public int Commit() => _db.SaveChanges();
        public void Add(InterestGroup interestGroup)
        {
            var _interestGroup = new InterestGroup
            {
                Id = interestGroup.Id,
                Title = interestGroup.Title,
                Description = interestGroup.Description,
            };
            _db.Add<InterestGroup>(_interestGroup);
            Commit();
            InterestGroups.Add(_interestGroup);
        }
        public void GetAll(int? groupId = null)
        {
            var interestGroups = _db.InterestGroups.ToList();
            InterestGroups.Clear();
            foreach (var interestGroup in interestGroups)
            {
                InterestGroups.Add(interestGroup);
            }


        }
        public InterestGroupService()
        {
            GetAll();
        }
        public void Remove(InterestGroup interestGroup)
        {
            _db.Remove<InterestGroup>(interestGroup);
            if (Commit() > 0)
                if (InterestGroups.Contains(interestGroup))
                    InterestGroups.Remove(interestGroup);
        }


        public void LoadRelation(InterestGroup interestGroup, string relation)
        {
            var entry = _db.Entry(interestGroup);
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
