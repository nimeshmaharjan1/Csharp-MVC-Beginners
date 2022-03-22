using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface IDepartmentRepo
    {
        IEnumerable<DepartmentModel> GetAllDepartment();
        DepartmentModel GetDepartmentById(int departmentId);
        void AddDepartment(DepartmentModel department);
        void EditDepartment(DepartmentModel department);
        void DeleteDepartment(DepartmentModel department);
    }
}
