using Calendar.DAL;
using Calender.DTO;
using System;

namespace Calender.BLL
{
    internal class AccountBLL
    {
        private static AccountBLL _Instance;

        public static AccountBLL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new AccountBLL();
                }
                return _Instance;
            }
            private set { }
        }

        public Account CheckAccount_BLL(string username, string pwd)
        {
            try
            {
                Account acc = AccountDAL.Instance.AuthenticateUser_DAL(username, pwd);
                return acc;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error checking account: {ex.Message}");
            }
        }

        public string GetUsername(int id)
        {
            try
            {
                Account acc = AccountDAL.Instance.GetAccountByIDAcc(id);
                return acc?.Username;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error getting username for ID {id}: {ex.Message}");
            }
        }
    }
}