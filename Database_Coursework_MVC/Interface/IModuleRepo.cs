using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface IModuleRepo
    {
        IEnumerable<ModuleModel> GetAllModules();
        ModuleModel GetModuleById(int moduleId);
        void AddModule(ModuleModel module);
        void DeleteModule(ModuleModel module);
        void EditModule(ModuleModel module);
    }
}
