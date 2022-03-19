using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface ITeacherRepo
    {
        IEnumerable<TeacherModel> GetAllTeacher();
        TeacherModel GetTeacherById(int teacherId);
        public void AddTeacher(TeacherModel teacher);
        public void EditTeacher(TeacherModel teacher);
        public void DeleteTeacher(TeacherModel teacher);
    }
}
