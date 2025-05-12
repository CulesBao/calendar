using Calender.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Calendar.DAL
{
    internal class AccountDAL
    {
        private static AccountDAL _Instance;

        public static AccountDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountDAL();
                }
                return _Instance;
            }
            private set { }
        }

        private Account GetAccountByDataRow_DAL(DataRow row)
        {
            try
            {
                return new Account
                {
                    IDAccount = Convert.ToInt32(row["Id"]), // Sửa tên cột từ IDAccount thành Id
                    Username = row["Username"]?.ToString(),
                    Pwd = row["Pwd"]?.ToString()
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping DataRow to Account: {ex.Message}");
            }
        }

        public List<Account> GetAllAccount_DAL()
        {
            string query = "SELECT Id, Username, Pwd FROM Account";
            List<Account> list = new List<Account>();

            DataTable dt = DBHelper.Instance.GetRecords(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetAccountByDataRow_DAL(row));
            }

            return list;
        }

        public Account GetAccountByIDAcc(int idAcc)
        {
            string query = "SELECT Id, Username, Pwd FROM Account WHERE Id = @IDAccount";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@IDAccount", idAcc)
                };
                DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return GetAccountByDataRow_DAL(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error retrieving account with ID {idAcc}: {ex.Message}");
            }
        }

        public Account AuthenticateUser_DAL(string username, string password)
        {
            string query = "SELECT Id, Username, Pwd FROM Account WHERE Username = @Username AND Pwd = @Password";
            try
            {
                SqlParameter[] parameters = new SqlParameter[]
                {
                    new SqlParameter("@Username", username),
                    new SqlParameter("@Password", password)
                };
                DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
                if (dt.Rows.Count > 0)
                {
                    return GetAccountByDataRow_DAL(dt.Rows[0]);
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error authenticating user: {ex.Message}");
            }
        }
    }
}