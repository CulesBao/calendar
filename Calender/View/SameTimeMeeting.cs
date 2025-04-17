using Calender.BLL;
using Calender.DTO;
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
    public partial class SameTimeMeeting : Form
    {
        int idAcc { get; set; }
        public SameTimeMeeting(Appt a, int iDAcc)
        {
            InitializeComponent();
            ReloadDGVMeeting(a);
            idAcc = iDAcc;
        }

        public void ReloadDGVMeeting(Appt a)
        {
            List<ApptView> listApptView = ApptBLL.Instance.GetSameApptMtNotByIDAcc_BLL(a);
            if (listApptView.Count != 0)
            {
                dgv.DataSource = listApptView;
            }
            else
            {
                MessageBox.Show("Do not have any appointments!");
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_join_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to join this meeting?", "Announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Appt a = ApptBLL.Instance.GetApptMtByIDAppt_BLL(Convert.ToInt32(dgv.SelectedRows[0].Cells["IDAppt"].Value));
                ApptBLL.Instance.AddMeeting_BLL(a, idAcc);
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
