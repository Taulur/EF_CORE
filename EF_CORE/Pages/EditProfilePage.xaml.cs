using EF_CORE.Data;
using EF_CORE.Service;
using EF_CORE;
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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EF_CORE.Pages
{
    /// <summary>
    /// Логика взаимодействия для EditProfilePage.xaml
    /// </summary>
    public partial class EditProfilePage : Page
    {
        private StudentsService _service = new();
        public Student _student = new();
        bool isNewProfile = false;
        public EditProfilePage(Student? user = null)
        {
            InitializeComponent();

            if (user != null)
            {
                
                _student = user;

                if (_student.UserProfile == null)
                {
                    _student.UserProfile = new UserProfile
                    {
                        UserId = _student.Id,
                        Student = _student
                    };
                    isNewProfile = true;
                    _service.AddProfile(_student.UserProfile);
                }
            }

            DataContext = _student;
        }

        private void save(object sender, RoutedEventArgs e)
        {
            try
            {
                if (isNewProfile && _student.UserProfile != null)
                {
                    _student.UserProfile.UserId = _student.Id;
                }

                _service.Commit();

                MessageBox.Show("Профиль сохранен успешно!");
                NavigationService.GoBack();
            }
            catch (Exception ex)
            {
                string errorMessage = $"Ошибка: {ex.Message}";
                if (ex.InnerException != null)
                {
                    errorMessage += $"\nВнутренняя ошибка: {ex.InnerException.Message}";
                }
                MessageBox.Show(errorMessage);
            }
        }
        private void back(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AvatarAdd(object sender, MouseButtonEventArgs e)
        {
            var openFileDialog = new Microsoft.Win32.OpenFileDialog
            {
                Filter = "Image files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg|All files (*.*)|*.*"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                string fileName = openFileDialog.FileName;

                _student.UserProfile.AvatarUrl = fileName;
            }
        }
    }
}
