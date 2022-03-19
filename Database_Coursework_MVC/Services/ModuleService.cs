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
    public class ModuleService : IModuleRepo
    {
        private readonly string _connectionString;
        public ModuleService (IConfiguration _configuartion)
        {
            _connectionString = _configuartion.GetConnectionString("OracleDBConnection");
        }
        public void AddModule(ModuleModel module)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO module(module_code, module_name, credit_hours) VALUES (" + module.ModuleCode + ",'" + module.ModuleName + "', "+module.CreditHours+")";
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

        public void DeleteModule(ModuleModel module)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "delete from module where module_code = " + module.ModuleCode + "";
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

        public void EditModule(ModuleModel module)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "UPDATE module SET module_name ='" + module.ModuleName + "', credit_hours = "+module.CreditHours+" WHERE module_code = " + module.ModuleCode + "";
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

        public IEnumerable<ModuleModel> GetAllModules()
        {
            List<ModuleModel> moduleList = new List<ModuleModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "select module_code, module_name, credit_hours from module";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        ModuleModel module = new ModuleModel
                        {
                            ModuleCode = Convert.ToInt32(dataReader["module_code"]),
                            ModuleName = dataReader["module_name"].ToString(),
                            CreditHours = Convert.ToInt32(dataReader["credit_hours"])
                        };
                        moduleList.Add(module);
                    }
                }
            }
            return moduleList;
        }

        public ModuleModel GetModuleById(int moduleId)
        {
            ModuleModel module = new ModuleModel();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "Select module_code, module_name, credit_hours from module where module_code = " + moduleId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        module.ModuleCode = Convert.ToInt32(rdr["module_code"]);
                        module.ModuleName = rdr["module_name"].ToString();
                        module.CreditHours = Convert.ToInt32(rdr["credit_hours"]);
                    }
                }
            }
            return module;
        }
    }
}
