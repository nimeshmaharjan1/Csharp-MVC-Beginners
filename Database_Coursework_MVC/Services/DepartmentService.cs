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
    public class DepartmentService : IDepartmentRepo
    {
        private readonly string _connectionString;
        public DepartmentService(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }
        public void AddDepartment(DepartmentModel department)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO department(department_id, department_name, department_contact) VALUES (" + department.DepartmentId + ", '" + department.DepartmentName + "', '" + department.DepartmentContact + "')";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteDepartment(DepartmentModel department)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "delete from department where department_id = " + department.DepartmentId + "";
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

        public void EditDepartment(DepartmentModel department)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "UPDATE department SET department_name ='" + department.DepartmentName + "', department_contact = '" + department.DepartmentContact + "' WHERE department_id = " + department.DepartmentId + "";
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

        public IEnumerable<DepartmentModel> GetAllDepartment()
        {
            List<DepartmentModel> DepartmentList = new List<DepartmentModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT department_id, department_name, department_contact FROM department";
                    //FOR READING DATA
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        DepartmentModel department = new DepartmentModel
                        {
                            DepartmentId = Convert.ToInt32(dataReader["department_id"]),
                            DepartmentName = dataReader["department_name"].ToString(),
                            DepartmentContact = dataReader["department_contact"].ToString()
                        };
                        DepartmentList.Add(department);
                    }
                }
            }
            return DepartmentList;
        }

        public DepartmentModel GetDepartmentById(int departmentId)
        {
            DepartmentModel department = new DepartmentModel();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "Select department_id, department_name, department_contact from department where department_id = " + departmentId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        department.DepartmentId = Convert.ToInt32(rdr["department_id"]);
                        department.DepartmentName = rdr["department_name"].ToString();
                        department.DepartmentContact = rdr["department_contact"].ToString();
                    }
                }
            }
            return department;
        }
    }
}
