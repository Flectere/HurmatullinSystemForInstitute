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
    /// Логика взаимодействия для AddEmployeePage.xaml
    /// </summary>
    public partial class AddEmployeePage : Page
    {
        public static List<Role> roles { get; set; }
        public static List<Worker> employees { get; set; }
        public static List<Kafedra> departaments { get; set; }

        public AddEmployeePage()
        {
            InitializeComponent();
            departaments = DBConnection.Entity.Kafedra.ToList();
            roles = DBConnection.Entity.Role.ToList();
            employees = DBConnection.Entity.Worker.ToList();
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Worker employee = new Worker();
            employee.Role = RoleCb.SelectedItem as Role;
            employee.salary = int.Parse(SalaryTb.Text);
            employee.fio = LastNameTb.Text;
            employee.chef = (ChefCb.SelectedItem as Worker).chef;
            employee.Kafedra = DepartmentsCb.SelectedItem as Kafedra;
            DBConnection.Entity.Worker.Add(employee);
            DBConnection.Entity.SaveChanges();
            NavigationService.Navigate(new EmployeesPage());
        }

        private void GoBackbt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }
    }
}
