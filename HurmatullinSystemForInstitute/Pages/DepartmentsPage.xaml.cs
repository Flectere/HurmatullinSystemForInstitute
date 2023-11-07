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
using HurmatullinSystemForInstitute.DB;

namespace HurmatullinSystemForInstitute.Pages
{
    /// <summary>
    /// Логика взаимодействия для DepartmentsPage.xaml
    /// </summary>
    public partial class DepartmentsPage : Page
    {
        public static List<Kafedra> departments { get; set; }
        public static Kafedra selectedKafedra;
        public DepartmentsPage()
        {
            InitializeComponent();
            departments = new List<Kafedra>(DBConnection.Entity.Kafedra);
            UserNameTb.Text = AuthorizationPage.currentUser.fio;
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void DepartmentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedKafedra = DepartmentsList.SelectedItem as Kafedra;
            NavigationService.Navigate(new SpecDepartamentsPage());
        }
    }
}
