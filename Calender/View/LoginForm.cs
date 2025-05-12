using Calender.DTO;
using Calender.BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calender.View
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            if(AccountBLL.Instance.CheckAccount_BLL(txt_username.Text, txt_pwd.Text) != null)
            {
                Account acc = AccountBLL.Instance.CheckAccount_BLL(txt_username.Text, txt_pwd.Text);
                this.Hide();
                MainForm mainform = new MainForm(acc.IDAccount, txt_username.Text);
                mainform.Closed += (s, args) => this.Close(); 
                mainform.ShowDialog();
            }
            else
            {
                MessageBox.Show("Incorrect username or password!");
            }
        }
    }
}
