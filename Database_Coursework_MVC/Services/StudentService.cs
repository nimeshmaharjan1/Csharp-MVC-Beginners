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
    public class StudentService : IStudentRepo
    {
        private readonly string _connectionString;

        public StudentService(IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }

        public void AddStudent(StudentModel student)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO Student(student_id, student_name) VALUES ("+student.StudentId+",'"+student.StudentName+"')";
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

        public void EditStudent(StudentModel student)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "UPDATE student SET student_name ='"+student.StudentName+"' WHERE student_id = "+student.StudentId+"";
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
        public void DeleteStudent(StudentModel student)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        int id = student.StudentId;
                        command.CommandText = "delete from student where student_id = "+id+"";
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

        public IEnumerable<StudentModel> GetAllStudent()
        {
            List<StudentModel> studentList = new List<StudentModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using(OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT student_id, student_name FROM student";
                    //FOR READING DATA
                    OracleDataReader dataReader = command.ExecuteReader();
                    while(dataReader.Read())
                    {
                        StudentModel student = new StudentModel
                        {
                            StudentId = Convert.ToInt32(dataReader["student_id"]),
                            StudentName = dataReader["student_name"].ToString()
                        };
                        studentList.Add(student);
                    }
                }
            }
            return studentList;
        }

        public StudentModel GetStudentById(int stuId)
        {
            StudentModel student = new StudentModel();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "Select student_id, student_name from student where student_id = "+stuId+"";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        student.StudentId = Convert.ToInt32(rdr["student_id"]);
                        student.StudentName = rdr["student_name"].ToString();
                    }
                }
            }
            return student;
        }
    }
}
