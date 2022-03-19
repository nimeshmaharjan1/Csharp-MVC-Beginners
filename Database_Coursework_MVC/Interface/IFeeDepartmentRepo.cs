using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface IFeeDepartmentRepo
    {
        IEnumerable<FeeModel> GetAllFee();
        FeeModel GetFeeById(int feeId);
        void AddFee(FeeModel fee);
        void EditFee(FeeModel fee);
        void DeleteFee(FeeModel fee);
    }
}
