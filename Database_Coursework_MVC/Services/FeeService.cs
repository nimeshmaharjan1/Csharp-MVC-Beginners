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
    public class FeeService : IFeeDepartmentRepo
    {
        private readonly string _connectionString;
        public FeeService (IConfiguration _configuration)
        {
            _connectionString = _configuration.GetConnectionString("OracleDBConnection");
        }

        void IFeeDepartmentRepo.AddFee(FeeModel fee)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand ())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "INSERT INTO fee(fee_id, fee_name, fee_amount) VALUES (" + fee.FeeId + ", '" + fee.FeeName + "', " + fee.FeeAmount + ")";
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void DeleteFee(FeeModel fee)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "delete from fee where fee_id = " + fee.FeeId + "";
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

        public void EditFee(FeeModel fee)
        {
            try
            {
                using (OracleConnection connection = new OracleConnection(_connectionString))
                {
                    using (OracleCommand command = new OracleCommand())
                    {
                        connection.Open();
                        command.Connection = connection;
                        command.CommandText = "UPDATE fee SET fee_name ='" + fee.FeeName + "', fee_amount = "+fee.FeeAmount+" WHERE fee_id = " + fee.FeeId + "";
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

        public IEnumerable<FeeModel> GetAllFee()
        {
            List<FeeModel> FeeList = new List<FeeModel>();
            using (OracleConnection connection = new OracleConnection(_connectionString))
            {
                using (OracleCommand command = new OracleCommand())
                {
                    connection.Open();
                    command.Connection = connection;
                    command.BindByName = true;
                    command.CommandText = "SELECT fee_id, fee_name, fee_amount FROM fee";
                    //FOR READING DATA
                    OracleDataReader dataReader = command.ExecuteReader();
                    while (dataReader.Read())
                    {
                        FeeModel fee = new FeeModel
                        {
                            FeeId = Convert.ToInt32(dataReader["fee_id"]),
                            FeeName = dataReader["fee_name"].ToString(),
                            FeeAmount = Convert.ToDecimal(dataReader["fee_amount"])
                        };
                        FeeList.Add(fee);
                    }
                }
            }
            return FeeList;
        }

        FeeModel IFeeDepartmentRepo.GetFeeById(int feeId)
        {
            FeeModel fee = new FeeModel();
            using (OracleConnection con = new OracleConnection(_connectionString))
            {
                using (OracleCommand cmd = new OracleCommand())
                {
                    con.Open();
                    cmd.Connection = con;
                    cmd.BindByName = true;
                    cmd.CommandText = "Select fee_id, fee_name, fee_amount from fee where fee_id = " + feeId + "";
                    OracleDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        fee.FeeId = Convert.ToInt32(rdr["fee_id"]);
                        fee.FeeName = rdr["fee_name"].ToString();
                        fee.FeeAmount = Convert.ToDecimal(rdr["fee_amount"]);
                    }
                }
            }
            return fee;
        }
    }
}
