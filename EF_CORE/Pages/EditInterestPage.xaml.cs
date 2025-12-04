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
    /// Логика взаимодействия для EditInterestPage.xaml
    /// </summary>
    public partial class EditInterestPage : Page
    {
        InterestGroup _interestGroup = new();
        InterestGroupService service = new();
        bool IsEdit = false;
        public EditInterestPage(InterestGroup? interestGroup = null)
        {
            InitializeComponent();
            if (interestGroup != null)
            {
                //service.LoadRelation(role, "Users");
                _interestGroup = interestGroup;
                IsEdit = true;
            }
            DataContext = _interestGroup;
        }
        private void save(object sender, RoutedEventArgs e)
        {
            if (IsEdit)
                service.Commit();
            else
                service.Add(_interestGroup);
            back(sender, e);
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
