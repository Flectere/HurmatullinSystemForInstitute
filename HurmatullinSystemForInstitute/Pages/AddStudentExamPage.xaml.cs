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
    /// Логика взаимодействия для AddStudentExamPage.xaml
    /// </summary>
    public partial class AddStudentExamPage : Page
    {
        public static List<Student> students {get;set;}
        public Exam exam = new Exam();
        public AddStudentExamPage()
        {
            InitializeComponent();
            students = new List<Student>(DBConnection.Entity.Student.ToList());
            int [] scores = {1,2,3,4,5};
            ScoreCb.ItemsSource = scores;
            this.DataContext = this;
        }

        private void AddBtn_Click(object sender, RoutedEventArgs e)
        {
            exam.teacher_id = ExamsPage.selectedExam.teacher_id;
            exam.cabinet = ExamsPage.selectedExam.cabinet;
            exam.date = ExamsPage.selectedExam.date;
            exam.Discipline = ExamsPage.selectedExam.Discipline;
            DBConnection.Entity.Exam.Add(exam);
            DBConnection.Entity.SaveChanges();
            NavigationService.Navigate(new StudentsExamsPage());
        }

        private void StudentsCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exam.stud_id = (StudentsCb.SelectedItem as Student).id;
        }

        private void ScoreCb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            exam.score = Convert.ToInt32(ScoreCb.SelectedItem);
        }
    }
}
