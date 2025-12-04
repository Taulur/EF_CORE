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
    /// Логика взаимодействия для EditStudentInterestPage.xaml
    /// </summary>
    public partial class EditStudentInterestPage : Page
    {
        public InterestGroupService interestService { get; set; } = new();
        public UserInterestGroupService userInterestService { get; set; } = new();
        public UserInterestGroup userInterest { get; set; } = new();
        public InterestGroup? current { get; set; } = null;
        public Student? user { get; set; }

        public EditStudentInterestPage(Student? _user)
        {
            user = _user;
            InitializeComponent();
            
            //DataContext = new { user};
        }

        private void add(object sender, RoutedEventArgs e)
        {
            if (current != null && user != null)
            {

                userInterestService.UserInterestAttach(user, current);

                userInterest.InterestGroupId = current.Id;
                userInterest.UserId = user.Id;

                userInterest.Student = user;
                userInterest.InterestGroup = current;

                //if (current.UserInterestGroup == null)
                //{
                //    current.UserInterestGroup = new ObservableCollection<UserInterestGroup>();
                //}
                //current.UserInterestGroup.Add(userInterest);
                //if (user.UserInterestGroup == null)
                //{
                //    user.UserInterestGroup = new ObservableCollection<UserInterestGroup>();
                //}
                //user.UserInterestGroup.Add(userInterest);

                userInterestService.Add(userInterest);
                NavigationService.GoBack();
            }
            else
                MessageBox.Show("Выберите группу по интересам");

           
        }
    }
}
