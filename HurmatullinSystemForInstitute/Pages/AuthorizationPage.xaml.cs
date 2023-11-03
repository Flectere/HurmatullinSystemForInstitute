using HurmatullinSystemForInstitute.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
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
    /// Логика взаимодействия для AuthorizationPage.xaml
    /// </summary>
    public partial class AuthorizationPage : Page
    {
        public static Worker currentUser;
        public static List<Worker> Workers { get; set; }
        public AuthorizationPage()
        {
            InitializeComponent();
        }
        
        private void loginBtn_Click(object sender, RoutedEventArgs e)
        {
            string login = loginTb.Text.Trim();
            string password = passwordTb.Password.Trim();
            Workers = new List<Worker>(DBConnection.Entity.Worker.ToList());
            currentUser = Workers.FirstOrDefault(x => x.login == login && x.password == password);
            if (currentUser != null && currentUser.idRole==2)
            {
                NavigationService.Navigate(new ExamsPage());
            }
            else if (currentUser != null && currentUser.idRole == 1)
            {
                NavigationService.Navigate(new DepartmentsPage());
            }
        }

        private void GuestBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DisciplinePage());
        }
    }
}
