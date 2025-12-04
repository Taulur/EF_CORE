using EF_CORE.Data;
using EF_CORE.Service;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace EF_CORE.Pages
{
    /// <summary>
    /// Логика взаимодействия для InterestUsersPage.xaml
    /// </summary>
    public partial class InterestUsersPage : Page
    {
        public ObservableCollection<UserInterestGroup> UserInterestGroup { get; set; } = new();
        public UserInterestGroupService UserInterestGroupService { get; set; } = new();
        public InterestUsersPage(InterestGroup interestGroup)
        {
            UserInterestGroupService.GetAll(interestGroup.Id);
            MessageBox.Show(UserInterestGroup[0].Student.Name);
            //if (interestGroup.UserInterestGroup != null)
            //{
            //    foreach (var userInterestGroup in interestGroup.UserInterestGroup)
            //    {
            //        UserInterestGroup.Add(userInterestGroup);
            //    }
            //}
            InitializeComponent();

        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
