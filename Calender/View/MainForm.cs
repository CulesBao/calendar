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
using System.Security.Principal;
using System.Globalization;

namespace Calender.View
{
    public partial class MainForm : Form
    {
        int IDAcc { get; set; }
        public MainForm(int IDAccount, string username)
        {
            InitializeComponent();
            IDAcc = IDAccount;
            lb_username.Text = username;
        }
        
        public void ReloadDGVAppt(int idAcc)
        {
            List<ApptView> listApptView = ApptBLL.Instance.GetListApptViewNotMtByIDAcc_BLL(idAcc);
            if (listApptView != null)
            {
                dgv.DataSource = listApptView;
            }
            else
            {
                MessageBox.Show("Do not have any appointments!");
            }
        }

        public void ReloadDGVMeeting(int idAcc)
        {
            List<ApptView> listApptView = ApptBLL.Instance.GetListApptViewMt_BLL(idAcc);
            if (listApptView != null)
            {
                dgv.DataSource = listApptView;
            }
            else
            {
                MessageBox.Show("Do not have any meetings!");
            }
        }

        public void ReloadDGVReminder(int idAcc)
        {
            List<ApptView> listApptView = ApptBLL.Instance.GetApptViewReminderByIDAcc_BLL(idAcc);
            if (listApptView != null)
            {
                dgv.DataSource = listApptView;
            }
            else
            {
                MessageBox.Show("Do not have any appointments!");
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            AddForm addForm = new AddForm(IDAcc);
            addForm.d = new AddForm.MyDelegate(ReloadDGVAppt);
            addForm.Show();
        }

        private void btn_appt_Click(object sender, EventArgs e)
        {
            ReloadDGVAppt(IDAcc);
        }

        private void btn_meeting_Click(object sender, EventArgs e)
        {
            ReloadDGVMeeting(IDAcc);
        }

        private void btn_reminder_Click(object sender, EventArgs e)
        {
            ReloadDGVReminder(IDAcc);
        }

        public ApptView GetAppt(DataGridViewRow row)
        {
            ApptView av = new ApptView()
            {
                IDAppt = Convert.ToInt32(row.Cells["IDAppt"].Value),
                Creator = row.Cells["Creator"].Value.ToString(),
                NameAppt = row.Cells["NameAppt"].Value.ToString(),
                LocationAppt = row.Cells["LocationAppt"].Value.ToString(),
                TimeStart = Convert.ToDateTime(row.Cells["TimeStart"].Value),
                TimeEnd = Convert.ToDateTime(row.Cells["TimeEnd"].Value),
            };
            return av;
        }

        public Participant GetParticipant(Account acc, int i)
        {
            Participant participant = new Participant()
            {
                STT = i,
                NameOfParticipant = acc.Username
            };
            return participant;
        }

        private void dgv_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Lấy dữ liệu từ hàng được chọn
            DataGridViewRow selectedRow = dgv.Rows[e.RowIndex];

            ApptView av = GetAppt(selectedRow);

            List<Participant> list = new List<Participant>();

            int i = 1;
            foreach (Account acc in ApptBLL.Instance.GetListAccountSameMeeting_BLL(av.IDAppt))
            {
                list.Add(GetParticipant(acc, i));
                i++;
            }

            ParticipantsOfMeeting participantsOfMeeting = new ParticipantsOfMeeting(list, av);
            participantsOfMeeting.Show();
        }
    }
}
