using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface ITeacherModuleRepo
    {
        IEnumerable<TeacherModuleModel> GetAllTeacher();
        IEnumerable<TeacherModuleModel> GetAllModulesOfTeacher(int teacherId);
    }
}
