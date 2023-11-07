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
    /// Логика взаимодействия для AddSpecPage.xaml
    /// </summary>
    public partial class AddSpecPage : Page
    {
        public Spec spec = new Spec();
        public AddSpecPage()
        {
            InitializeComponent();
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            spec.snumber = CodeSpecTb.Text;
            spec.kafedra_code = DepartmentsPage.selectedKafedra.code;
            spec.sname = NameSpecTb.Text;
            Functions.AddSpec(spec);
            NavigationService.Navigate(new SpecDepartamentsPage());
        }
    }
}