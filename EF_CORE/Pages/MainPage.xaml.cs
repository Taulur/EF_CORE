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
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public StudentsService service { get; set; } = new();
        public Student? user { get; set; } = null;

        public MainPage()
        {
            InitializeComponent();
        }
        public void go_form(object sender, EventArgs e)
        {
            NavigationService.Navigate(new UserFormPage());
        }

        public void go_role(object sender, EventArgs e)
        {
            NavigationService.Navigate(new GroupList());
        }

        public void Edit(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new UserFormPage(user));
        }
        public void remove(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите запись!");
                return;
            }
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Удалить?",
            MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                service.Remove(user);
            }
        }

        public void editProfile(object sender, EventArgs e)
        {
            NavigationService.Navigate(new EditProfilePage(user));
        }

        private void go_interest(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new InterestList());
        }

        private void go_studentInterest(object sender, RoutedEventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Выберите элемент из списка!");
                return;
            }
            NavigationService.Navigate(new EditStudentInterestPage(user));
        }
    }
}
