using EF_CORE.Data;
using EF_CORE.Service;
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

namespace EF_CORE.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public Student _user = new();

        public ProfilePage(Student? user = null)
        {
            InitializeComponent();
            if (user != null)
                _user = user;

            if (_user.UserProfile == null)
            {
                _user.UserProfile = new UserProfile();
            }

            DataContext = _user;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new EditProfilePage(_user));
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
