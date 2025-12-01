using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CORE;
using EF_CORE.Data;

namespace EF_CORE.Data
{
    public class UserProfile : ObservableObject
    {
        private int _id;
        private string _avatarUrl;
        private string _phone;
        private DateTime _birthday;
        private string _bio;
        private int _UserId;
        private Student _student;

        public int Id
        {
            get => _id;
            set => SetProperty(ref _id, value);
        }
        
        public string AvatarUrl
        {
            get => _avatarUrl;
            set => SetProperty(ref _avatarUrl, value);
        }
       
        public string Phone
        {
            get => _phone;
            set => SetProperty(ref _phone, value);
        }

        public DateTime Birthday
        {
            get => _birthday;
            set => SetProperty(ref _birthday, value);
        }

        public string Bio
        {
            get => _bio;
            set => SetProperty(ref _bio, value);
        }

        //

        public int UserId
        {
            get => _UserId;
            set => SetProperty(ref _UserId, value);
        }
        
        public Student Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }
    }
}
