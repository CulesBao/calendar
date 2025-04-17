using Calender.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace Calender.DAL
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

        public Account GetAccountByDataRow_DAL(DataRow i)
        {
            Account acc = new Account()
            {
                IDAccount = Convert.ToInt32(i["IDAccount"].ToString()),
                Username = i["Username"].ToString(),
                Pwd = i["Pwd"].ToString()
            };
            return acc;
        }

        public List<Account> GetAllAccount_DAL()
        {
            string query = "SELECT * FROM Account";
            List<Account> list = new List<Account>();

            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetAccountByDataRow_DAL(i));
            }
            return list;
        }

        public Account GetAccountByIDAcc(int IDAcc)
        {
            string query = "SELECT * FROM Account WHERE IDAccount = " + IDAcc;
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                return GetAccountByDataRow_DAL(i);
            }
            return null;
        }
    }
}
