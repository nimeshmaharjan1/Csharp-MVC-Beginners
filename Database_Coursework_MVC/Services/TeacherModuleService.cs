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
    public class TeacherModuleService : ITeacherModuleRepo
    {
        public readonly string _connectionString;
        public TeacherModuleService(IConfiguration _configuartion)
        {
            _connectionString = _configuartion.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<TeacherModuleModel> GetAllTeacher()
        {
            List<TeacherModuleModel> teacherModuleList = new List<TeacherModuleModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "select teacher_id, teacher_name from teacher";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TeacherModuleModel teacherModule = new TeacherModuleModel
                        {
                            TeacherId = Convert.ToInt32(dataReader["teacher_id"]),
                            TeacherName = dataReader["teacher_name"].ToString()
                        };
                        teacherModuleList.Add(teacherModule);
                    }
                }
            }
            return teacherModuleList;
        }

        public IEnumerable<TeacherModuleModel> GetAllModulesOfTeacher(int teacherId)
        {
            List<TeacherModuleModel> teacherModuleList = new List<TeacherModuleModel>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "select  module.MODULE_CODE, module.MODULE_NAME, teacher_module.CREDIT_HOURS, teacher_module.TEACHER_ID from module, teacher_module where teacher_module.MODULE_ID = module.MODULE_CODE and teacher_module.TEACHER_ID = " + teacherId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        TeacherModuleModel teacherModule = new TeacherModuleModel
                        {
                            TeacherId = Convert.ToInt32(rdr["teacher_id"]),
                            ModuleCode = Convert.ToInt32(rdr["module_code"]),
                            CreditHours = Convert.ToInt32(rdr["credit_hours"]),
                            ModuleName = rdr["module_name"].ToString(),
                        };
                        teacherModuleList.Add(teacherModule);
                    }
                }
            }
            return teacherModuleList;
        }
    }
}
