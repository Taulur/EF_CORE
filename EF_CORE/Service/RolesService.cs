using EF_CORE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EF_CORE.Service
{
    public class RolesService
    {
        private readonly AppDbContext _db = BaseDbService.Instance.Context;
        public ObservableCollection<Role> Roles { get; set; } = new();
        public void GetAll()
        {
            var groups = _db.Roles.ToList();
            Roles.Clear();
            foreach (var group in groups)
                Roles.Add(group);
        }
        public int Commit() => _db.SaveChanges();
        public RolesService()
        {
            GetAll();
        }
        public void Add(Role group)
        {
            var _group = new Role
            {
                Title = group.Title,
            };
            _db.Add<Role>(_group);
            Commit();
            Roles.Add(_group);
        }
        public void Remove(Role group)
        {
            _db.Remove<Role>(group);
            if (Commit() > 0)
                if (Roles.Contains(group))
                    Roles.Remove(group);
        }

        public void LoadRelation(Role group, string relation)
        {
            var entry = _db.Entry(group);
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
