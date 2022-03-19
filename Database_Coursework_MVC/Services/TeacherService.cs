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
    public class TeacherService : ITeacherRepo
    {
        private readonly string _connectionString;
        public TeacherService (IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }
        public void AddTeacher(TeacherModel teacher)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO teacher(teacher_id, teacher_name, teacher_email) VALUES (" + teacher.TeacherId + ",'" + teacher.TeacherName + "', '"+teacher.TeacherEmail+"')";
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

        public void DeleteTeacher(TeacherModel teacher)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "delete from teacher where teacher_id = " + teacher.TeacherId + "";
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

        public void EditTeacher(TeacherModel teacher)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "UPDATE teacher SET teacher_name ='" + teacher.TeacherName + "', teacher_email = '"+teacher.TeacherEmail+"' WHERE teacher_id = " + teacher.TeacherId + "";
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

        public IEnumerable<TeacherModel> GetAllTeacher()
        {
            List<TeacherModel> teacherList = new List<TeacherModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT teacher_id, teacher_name, teacher_email FROM teacher";
                    //FOR READING DATA
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        TeacherModel teacher = new TeacherModel
                        {
                            TeacherId = Convert.ToInt32(dataReader["teacher_id"]),
                            TeacherName = dataReader["teacher_name"].ToString(),
                            TeacherEmail = dataReader["teacher_email"].ToString()
                        };
                        teacherList.Add(teacher);
                    }
                }
            }
            return teacherList;
        }

        public TeacherModel GetTeacherById(int teacherId)
        {
            TeacherModel teacher = new TeacherModel();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "Select teacher_id, teacher_name, teacher_email from teacher where teacher_id = " + teacherId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        teacher.TeacherId = Convert.ToInt32(rdr["teacher_id"]);
                        teacher.TeacherName = rdr["teacher_name"].ToString();
                        teacher.TeacherEmail = rdr["teacher_email"].ToString();
                    }
                }
            }
            return teacher;
        }
    }
}
