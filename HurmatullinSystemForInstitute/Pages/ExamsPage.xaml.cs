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
    /// Логика взаимодействия для ExamsPage.xaml
    /// </summary>
    public partial class ExamsPage : Page
    {
        public static Exam selectedExam;
        public static List<Exam> sortExams { get; set; }
        
        public ExamsPage()
        {
            InitializeComponent();
            sortExams = new List<Exam>();
            List<Exam> exams = new List<Exam>(DBConnection.Entity.Exam.ToList());
            foreach (Exam i in exams)
            {
                if (sortExams.FirstOrDefault(x => x.date == i.date && x.Discipline == i.Discipline) == null)
                {
                    sortExams.Add(i);
                }
            }
            sortExams = sortExams.Where(i => i.teacher_id == AuthorizationPage.currentUser.id).ToList();
            UserNameTb.Text = $"Преподаватель: {AuthorizationPage.currentUser.fio}";
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void ExamsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            selectedExam = ExamsList.SelectedItem as Exam;
            
            NavigationService.Navigate(new StudentsExamsPage());
        }
    }
}