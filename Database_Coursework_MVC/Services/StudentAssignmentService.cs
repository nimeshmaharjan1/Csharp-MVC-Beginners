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
    public class StudentAssignmentService : IStudentAssignmentRepo
    {
        public readonly string _connectionString;
        public StudentAssignmentService (IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }

        public IEnumerable<StudentAssignmentModel> GetAllStudents()
        {
            List<StudentAssignmentModel> studentList = new List<StudentAssignmentModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "select student_id, student_name from student";
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        StudentAssignmentModel student = new StudentAssignmentModel
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

        public IEnumerable<StudentAssignmentModel> GetAssignmentResultOfStudent(int studentId)
        {
            List<StudentAssignmentModel> studentAssignmentList = new List<StudentAssignmentModel>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "select student_module.module_code, student_module_assignment.assignment_type, student_module_assignment.grade, student_module.student_id, student_module_assignment.status from student_module, student_module_assignment where student_module_assignment.module_code = student_module.module_code and student_module_assignment.student_id = " + studentId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        StudentAssignmentModel studentFee = new StudentAssignmentModel
                        {
                            StudentId = Convert.ToInt32(rdr["student_id"]),
                            ModuleCode = Convert.ToInt32(rdr["module_code"]),
                            AssignmentType = rdr["assignment_type"].ToString(),
                            Grade = rdr["grade"].ToString(),
                            Status = rdr["status"].ToString(),
                        };
                        studentAssignmentList.Add(studentFee);
                    }
                }
            }
            return studentAssignmentList;
        }
    }
}
