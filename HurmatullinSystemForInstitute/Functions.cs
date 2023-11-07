using HurmatullinSystemForInstitute.DB;
using HurmatullinSystemForInstitute.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HurmatullinSystemForInstitute
{
    public class Functions
    {
        public static void AddStudent(Exam exam)
        {
            DBConnection.Entity.Exam.Add(exam);
            DBConnection.Entity.SaveChanges();
        }
        public static void AddEmployee(Worker employee)
        {
            DBConnection.Entity.Worker.Add(employee);
            DBConnection.Entity.SaveChanges();
        }
        public static void AddSpec(Spec spec)
        {
            DBConnection.Entity.Spec.Add(spec);
            DBConnection.Entity.SaveChanges();
        }
        public static void DeleteEmployee(Worker employee)
        {
            DBConnection.Entity.Worker.Remove(EmployeesPage.selectedEmployee);
            DBConnection.Entity.SaveChanges();
        }
    }
}
