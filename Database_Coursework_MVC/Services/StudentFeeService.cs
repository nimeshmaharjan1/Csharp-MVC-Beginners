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
    public class StudentFeeService : IStudentFeeRepo
    {
        public readonly string _connectionString;
        public StudentFeeService(IConfiguration _configuartion)
        {
            _connectionString = _configuartion.GetConnectionString("OracleDBConnection");
        }
        public IEnumerable<StudentFeeModel> GetAllStudents()
        {
            List<StudentFeeModel> studentList = new List<StudentFeeModel>();
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
                        StudentFeeModel student = new StudentFeeModel
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

        public IEnumerable<StudentFeeModel> GetAllFeesOfStudent(int studentId)
        {
            List<StudentFeeModel> studentFeeList = new List<StudentFeeModel>();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "select fee.fee_id, fee.fee_name, student_fee.paid, student_fee.paid_amount, student_fee.student_id, student_fee.paid_date from fee, student_fee where student_fee.fee_id = fee.fee_id and student_fee.student_id = " + studentId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        StudentFeeModel studentFee = new StudentFeeModel
                        {
                            StudentId = Convert.ToInt32(rdr["student_id"]),
                            FeeId = Convert.ToInt32(rdr["fee_id"]),
                            PaidAmount = Convert.ToInt32(rdr["paid_amount"]),
                            Paid = rdr["paid"].ToString(),
                            FeeName = rdr["fee_name"].ToString(),
                            PaymentDate = Convert.ToDateTime(rdr["paid_date"])
                        };
                        studentFeeList.Add(studentFee);
                    }
                }
            }
            return studentFeeList;
        }
    }
}
