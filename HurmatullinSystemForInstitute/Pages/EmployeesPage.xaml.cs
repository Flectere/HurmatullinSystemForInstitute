using HurmatullinSystemForInstitute.DB;
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

namespace HurmatullinSystemForInstitute.Pages
{
    /// <summary>
    /// Логика взаимодействия для EmployeesPage.xaml
    /// </summary>
    public partial class EmployeesPage : Page
    {
        public static List<Worker> employees { get; set; }
        public static Worker selectedEmployee;
        public EmployeesPage()
        {
            InitializeComponent();
            employees = new List<Worker>(DBConnection.Entity.Worker.ToList());
            UserNameTb.Text = AuthorizationPage.currentUser.fio;
            DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EmployeesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedEmployee = EmployeesList.SelectedItem as Worker;
            NavigationService.Navigate(new EditEmployeePage());
        }

        private void AddStudentExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddEmployee());
        }
    }
}
