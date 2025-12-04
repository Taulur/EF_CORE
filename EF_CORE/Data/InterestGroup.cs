using EF_CORE.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE.Data
{
    public class InterestGroup : ObservableObject
    {
        private int _id;
        private string _title;
        private string _desc;
      

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

        public string Description
        {
            get => _desc;
            set => SetProperty(ref _desc, value);
        }

        private ObservableCollection<UserInterestGroup> _userInterestGroup;
        public ObservableCollection<UserInterestGroup> UserInterestGroup
        {
            get => _userInterestGroup;
            set => SetProperty(ref _userInterestGroup, value);
        }
    }
}
