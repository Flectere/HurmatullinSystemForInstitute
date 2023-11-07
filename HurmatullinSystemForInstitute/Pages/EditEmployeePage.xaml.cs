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
    /// Логика взаимодействия для EditEmployeePage.xaml
    /// </summary>
    public partial class EditEmployeePage : Page
    {
        public static List<Role> role { get; set; }
        public EditEmployeePage()
        {
            InitializeComponent();
            role = DBConnection.Entity.Role.ToList();
            LastNameTb.Text = EmployeesPage.selectedEmployee.fio;
            SalaryTb.Text = EmployeesPage.selectedEmployee.salary.ToString();
            RoleNameTb.Text = EmployeesPage.selectedEmployee.Role.name;
            if (EmployeesPage.selectedEmployee.chef == EmployeesPage.selectedEmployee.id)
            {
                ChefTb.IsChecked = true;
            }
            DataContext = this;
        }

        private void GoBackbt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            EmployeesPage.selectedEmployee.fio = LastNameTb.Text.Trim();
            EmployeesPage.selectedEmployee.salary = int.Parse(SalaryTb.Text.Trim());
            if (ChefTb.IsChecked == true)
            {
                EmployeesPage.selectedEmployee.chef = EmployeesPage.selectedEmployee.id;
            }
            else
            {
                EmployeesPage.selectedEmployee.chef = null;
            }
            DBConnection.Entity.SaveChanges();
            NavigationService.Navigate(new EmployeesPage());
        }

        private void DelBt_Click(object sender, RoutedEventArgs e)
        {
            Functions.DeleteEmployee(EmployeesPage.selectedEmployee);
            NavigationService.Navigate(new EmployeesPage());
        }
    }
}