using Calender.DTO;
using Calender.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

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

        public AccountBLL()
        {

        }

        public Account CheckAccount_BLL(string username, string pwd)
        {
            foreach (Account acc in AccountDAL.Instance.GetAllAccount_DAL())
            {
                if (username == acc.Username && pwd == acc.Pwd) return acc;
            }
            return null;
        }

        public string GetUsername(int id)
        {
            foreach (Account acc in AccountDAL.Instance.GetAllAccount_DAL())
            {
                if (id == acc.IDAccount) return acc.Username;
            }
            return null;
        }
    }
}
