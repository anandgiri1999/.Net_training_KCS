//using DemoMVC.Models;
using MyNewApplication.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data; 
using System.Data.SqlClient;
using System.Linq;
using System.Web;



namespace MyNewApplication.ComanHelper
{
    public class DBUserMasterConnect
    {
        SqlConnection con = null;
        SqlCommand cmd = null;

        public DBUserMasterConnect()
        {
            con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["DBconnection"].ConnectionString);
            con.Open();
        }

        public int InsertRecord(InsertRecord IR)
        {
            if (IR.Id == 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("CreateNewAccount1_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = IR.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = IR.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = IR.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = IR.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = IR.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = IR.Password;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = IR.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = IR.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            else
            {
                using (con)
                {
                    cmd = new SqlCommand("CreateNewAccount1_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = IR.Id;
                    cmd.Parameters.AddWithValue("@CreatedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@EditedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MM/yyyy | hh:mm:ss tt"); 
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = null;
                    cmd.Parameters.AddWithValue("@FirstName", SqlDbType.VarChar).Value = IR.FirstName;
                    cmd.Parameters.AddWithValue("@LastName", SqlDbType.VarChar).Value = IR.LastName;
                    cmd.Parameters.AddWithValue("@ContactNo", SqlDbType.VarChar).Value = IR.ContactNo;
                    cmd.Parameters.AddWithValue("@EmailId", SqlDbType.VarChar).Value = IR.EmailId;
                    cmd.Parameters.AddWithValue("@Password", SqlDbType.VarChar).Value = IR.Password;
                    cmd.Parameters.AddWithValue("@Gender", SqlDbType.Char).Value = IR.Gender;
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = IR.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;

        }


        public List<InsertRecord> GetUserData(string OrderBy, string WhereClause)
        {
            List<InsertRecord> Rlst = new List<InsertRecord>();
            using (con)
            {
                cmd = new SqlCommand("SP_GetUserRecord", con);
                cmd.Parameters.AddWithValue("@OrderBy", SqlDbType.VarChar).Value = OrderBy;
                cmd.Parameters.AddWithValue("@WhereClause", SqlDbType.VarChar).Value = WhereClause;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    InsertRecord IR = new InsertRecord();
                    IR.setId(Convert.ToInt32(reader["ID"]));
                    IR.setFirstName(Convert.ToString(reader["FirstName"]));
                    IR.setLastName(Convert.ToString(reader["LastName"]));
                    IR.setEmailId(Convert.ToString(reader["EmailId"]));
                    IR.setContactNo(Convert.ToString(reader["ContactNo"]));
                    IR.setGender(Convert.ToChar(reader["Gender"]));
                    IR.setStatus(Convert.ToChar(reader["Status"]));
                    IR.setCreatedAt(Convert.ToString(reader["CreatedAt"]));
                    IR.setEditedAt(Convert.ToString(reader["EditedAt"]));
                    IR.setDeletedAt(Convert.ToString(reader["DeletedAt"]));
                    Rlst.Add(IR);
                }
            }
            return Rlst;
        }
        public int UpdateUserStatus(InsertRecord IR)
        {
            if (IR.Id != 0)
            {
                using (con)
                {
                    cmd = new SqlCommand("UpdateUserStatus1_SP", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", SqlDbType.Int).Value = IR.Id;
                    cmd.Parameters.AddWithValue("@DeletedAt", SqlDbType.VarChar).Value = DateTime.Now.ToString("dd/MMM/YYYY | hh:mm:ss tt");
                    cmd.Parameters.AddWithValue("@Status", SqlDbType.Char).Value = IR.Status;
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return 1;
        }
        public List<UserChartResponseModel> GetUserChartData(string SelectAsLabel, string GroupBy)
        {
            List<UserChartResponseModel> RLst = new List<UserChartResponseModel>();
            using (con)
            {
                cmd = new SqlCommand("GetUserRecordsChart", con);
                cmd.Parameters.AddWithValue("@SelectAsLabel", SqlDbType.VarChar).Value = SelectAsLabel;
                cmd.Parameters.AddWithValue("@GroupBy", SqlDbType.VarChar).Value = GroupBy;
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    UserChartResponseModel U = new UserChartResponseModel();
                    U.setLabel(Convert.ToString(rdr["label"]));
                    U.setValue(Convert.ToInt32(rdr["value"]));
                    RLst.Add(U);
                }
            }
            return RLst;
        }
    }
}