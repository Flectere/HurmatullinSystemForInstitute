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
    /// Логика взаимодействия для EditSpecDepPage.xaml
    /// </summary>
    public partial class EditSpecDepPage : Page
    {
        public Spec selectedSpecialization;
        public EditSpecDepPage(Spec selectedSpec)
        {
            InitializeComponent();
            selectedSpecialization = selectedSpec;
            NameTb.Text = selectedSpec.sname;
            CodeTb.Text = selectedSpec.snumber;
        }

        private void GoBackbt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new DepartmentsPage());
        }

        private void DelBt_Click(object sender, RoutedEventArgs e)
        {
            DBConnection.Entity.Spec.Remove(selectedSpecialization);
            DBConnection.Entity.SaveChanges();
            NavigationService.Navigate(new DepartmentsPage());
        }

        private void EditBt_Click(object sender, RoutedEventArgs e)
        {
            selectedSpecialization.sname = NameTb.Text;
            selectedSpecialization.snumber = CodeTb.Text;
            selectedSpecialization.kafedra_code = DepartmentsPage.selectedKafedra.code;
            DBConnection.Entity.SaveChanges();
            NavigationService.Navigate(new DepartmentsPage());
        }
    }
}
