using System.Collections.ObjectModel;
using EF_CORE.Data;

namespace EF_CORE.Data
{
    public class Role : ObservableObject
    {
        private int _id;
        private string _title;
        private ObservableCollection<Student> _students;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        
        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }
        
        public ObservableCollection<Student> Students
        {
            get => _students;
            set => SetProperty(ref _students, value);
        }
    }
}
