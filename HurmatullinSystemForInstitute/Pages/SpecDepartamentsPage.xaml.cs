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
    /// Логика взаимодействия для SpecDepartamentsPage.xaml
    /// </summary>
    public partial class SpecDepartamentsPage : Page
    {
        public static List<Spec> specializations { get; set; }
        public SpecDepartamentsPage()
        {
            InitializeComponent();
            specializations = new List<Spec>(DBConnection.Entity.Spec.Where(i => i.kafedra_code == DepartmentsPage.selectedKafedra.code).ToList());
            NameSpec.Text = $"СПЕЦИАЛЬНОСТИ\nВ КАФЕДРЕ:{DepartmentsPage.selectedKafedra.kname}";
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddSpecBt_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddSpecPage());
        }

        private void SpecDepartmentList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            NavigationService.Navigate(new EditSpecDepPage(SpecDepartmentList.SelectedItem as Spec));
        }
    }
}