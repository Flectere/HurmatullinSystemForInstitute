using System;
using HurmatullinSystemForInstitute.DB;
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
    /// Логика взаимодействия для StudentsExamsPage.xaml
    /// </summary>
    public partial class StudentsExamsPage : Page
    {
        public static List<Exam> exams { get; set; }
        public StudentsExamsPage()
        {
            InitializeComponent();
            exams = DBConnection.Entity.Exam.Where(i => i.date == ExamsPage.selectedExam.date && i.Discipline == ExamsPage.selectedExam.Discipline).ToList();
            NameExam.Text = $"Экзамен по предмету {ExamsPage.selectedExam.Discipline.dname}\nПреподаватель: {AuthorizationPage.currentUser.fio}";
            this.DataContext = this;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void AddStudentExam_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddStudentExamPage());
        }
    }
}