using Microsoft.IdentityModel.Tokens;
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
    /// Логика взаимодействия для UserFormPage.xaml
    /// </summary>
    public partial class UserFormPage : Page
    {
        private StudentsService _service = new();
        public Student _user = new();
        bool isEdit = false;
        public UserFormPage(Student? _editUser = null)
        {
            InitializeComponent();
            if (_editUser != null)
            {
                _user = _editUser;
                isEdit = true;
            }
            if (_user.Role == null)
                _user.Role = new();
            DataContext = _user;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (!(String.IsNullOrEmpty(_user.Login) && String.IsNullOrEmpty(_user.Name) && String.IsNullOrEmpty(_user.Email) && String.IsNullOrEmpty(_user.Password)))
            {
                if (isEdit)
                    _service.Commit();
                else
                {
                    _user.CreatedAt = DateTime.Now;
                    _service.Add(_user);
                }
                NavigationService.GoBack();
            }
            else MessageBox.Show("Заполните все поля");
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
