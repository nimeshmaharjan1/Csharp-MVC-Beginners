using Database_Coursework_MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Interface
{
    public interface IAddressRepo
    {
        IEnumerable<AddressModel> GetAllAddresses();
        AddressModel GetAddressById(int addressId);
        void AddAddress(AddressModel address);
        void EditAddress(AddressModel address);
        void DeleteAddress(AddressModel address);
    }
}
