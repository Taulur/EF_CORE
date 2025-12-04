using Pract12.Data;
using Pract12.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pract12.Pages
{
    /// <summary>
    /// Логика взаимодействия для UserInterestGroup.xaml
    /// </summary>
    public partial class UserInterestGroupPage : Page
    {
        public UserInterestGroupService serviceUser { get; set; } = new();
        public UserInterestGroup? currentUser { get; set; } = null;

        public InterestGroupService service { get; set; } = new();
        public InterestGroup? current { get; set; } = null;

        private User? _selectedUser;

        public UserInterestGroupPage(User? user = null)
        {
            InitializeComponent();
            _selectedUser = user;
            serviceUser.GetAllGroupsForUser(_selectedUser.Id);
        }

        private void add_group_user(object sender, RoutedEventArgs e)
        {
            if (current != null && _selectedUser != null)
            {
                var userInterestGroup = new UserInterestGroup
                {
                    UserId = _selectedUser.Id,
                    InterestGroupId = current.Id,
                    JoinedAt = DateOnly.FromDateTime(DateTime.Now),
                    IsModerator = false,
                    User = _selectedUser,
                    InterestGroup = current
                };

                serviceUser.Add(userInterestGroup);

                serviceUser.GetAllGroupsForUser(_selectedUser.Id);
            }
        }

        private void remove_group_user(object sender, RoutedEventArgs e)
        {
            if (currentUser != null)
            {
                if (MessageBox.Show("Вы действительно хотите удалить группу интереса?",
                "Удалить группу?", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    serviceUser.Remove(currentUser);
                }
            }
            else
            {
                MessageBox.Show("Выберите группу интереса для удаления", "Выберите группу интереса",
                MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void isModeratorClick(object sender, RoutedEventArgs e)
        {
            var checkBox = sender as CheckBox;
            if (checkBox?.DataContext is UserInterestGroup userInterestGroup)
            {
                serviceUser.UpdateModeratorStatus(userInterestGroup.UserId,
                                                 userInterestGroup.InterestGroupId,
                                                 userInterestGroup.IsModerator);
            }
        }
    }
}
