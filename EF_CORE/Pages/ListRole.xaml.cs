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
    /// Логика взаимодействия для ListRole.xaml
    /// </summary>
    public partial class ListRole : Page
    {
        Role _role = new();
        StudentsService _service = new();
        public ListRole(Role? role = null)
        {
            InitializeComponent();
            if (role != null)
            {
                _role = role;
                _service.GetAll(_role.Id);                
            }
            DataContext = _service;
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
