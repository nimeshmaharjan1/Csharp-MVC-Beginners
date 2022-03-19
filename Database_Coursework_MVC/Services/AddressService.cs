using Database_Coursework_MVC.Interface;
using Database_Coursework_MVC.Models;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Database_Coursework_MVC.Services
{
    public class AddressService : IAddressRepo
    {
        public readonly string _connectionString;
        public AddressService (IConfiguration _configuartion)
        {
            _connectionString = _configuartion.GetConnectionString("OracleDBConnection");
        }
        public void AddAddress(AddressModel address)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO address(address_id, address_name) VALUES (" + address.AddressId + ",'" + address.AddressName + "')";
                        /*,'"++"'*/
                        //FOR INSERTING, UPDATING AND DELETING DATA
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteAddress(AddressModel address)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "delete from address where address_id = " + address.AddressId + "";
                        /*,'"++"'*/
                        //FOR INSERTING, UPDATING AND DELETING DATA
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void EditAddress(AddressModel address)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "UPDATE address SET address_name ='" + address.AddressName + "' WHERE address_id = " + address.AddressId + "";
                        /*,'"++"'*/
                        //FOR INSERTING, UPDATING AND DELETING DATA
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public AddressModel GetAddressById(int addressId)
        {
            AddressModel address = new AddressModel();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "Select address_id, address_name from address where address_id = " + addressId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        address.AddressId = Convert.ToInt32(rdr["address_id"]);
                        address.AddressName = rdr["address_name"].ToString();
                    }
                }
            }
            return address;
        }

        public IEnumerable<AddressModel> GetAllAddresses()
        {
            List<AddressModel> addressList = new List<AddressModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "select address_id, address_name from address";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        AddressModel address = new AddressModel
                        {
                            AddressId = Convert.ToInt32(dataReader["address_id"]),
                            AddressName = dataReader["address_name"].ToString()
                        };
                        addressList.Add(address);
                    }
                }
            }
            return addressList;
        }
    }
}
