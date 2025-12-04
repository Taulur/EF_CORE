using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EF_CORE.Data;

namespace EF_CORE.Data
{
    public class UserInterestGroup : ObservableObject
    {
        private int _userId;
        private int _interestGroupId;
        private DateTime _joinedAt;
        private bool _isModerator;

        public int UserId
        {
            get => _userId;
            set => SetProperty(ref _userId, value);
        }

        public int InterestGroupId
        {
            get => _interestGroupId;
            set => SetProperty(ref _interestGroupId, value);
        }

        public DateTime JoinedAt
        {
            get => _joinedAt;
            set => SetProperty(ref _joinedAt, value);
        }

        private InterestGroup _interestGroup;
        public InterestGroup InterestGroup
        {
            get => _interestGroup;
            set => SetProperty(ref _interestGroup, value);
        }
        private Student _student;
        public Student Student
        {
            get => _student;
            set => SetProperty(ref _student, value);
        }

        public bool IsModerator
        {
            get => _isModerator;
            set => SetProperty(ref _isModerator, value);
        }
       
    }
}
