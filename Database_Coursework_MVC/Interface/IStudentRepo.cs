using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface IStudentRepo
    {
        IEnumerable<StudentModel> GetAllStudent();
        StudentModel GetStudentById(int StudentId);
        void AddStudent(StudentModel student);
        void EditStudent(StudentModel student);
        void DeleteStudent(StudentModel student);
    }
}
