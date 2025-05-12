using Calender.DTO;
using Calender.BLL;
using System;
using System.Windows.Forms;
using System.Globalization;

namespace Calender.View
{
    public partial class AddForm : Form
    {
        public delegate void MyDelegate(int id);
        public MyDelegate d { get; set; }

        int iDAcc { get; set; }
        public AddForm(int IDAcc)
        {
            InitializeComponent();
            iDAcc = IDAcc;
        }

        public bool checkValidTime()
        {
            if(dtp_timeStart.Value > dtp_timeEnd.Value)
            {
                return false;
            }
            if(cbb_timeStart.SelectedItem != null && cbb_timeEnd.SelectedItem != null)
            {
                DateTime dateTime_Start = Convert.ToDateTime(cbb_timeStart.SelectedItem.ToString());
                DateTime dateTime_End = Convert.ToDateTime(cbb_timeEnd.SelectedItem.ToString());
                if(dateTime_Start >= dateTime_End)
                {
                    return false;
                }
            }
            return true;
        }

        private void AddForm_Load(object sender, EventArgs e)
        {
            dtp_timeStart.Value = DateTime.Now;
            dtp_timeEnd.Value = dtp_timeStart.Value;
            DateTime time = DateTime.Today;
            for(DateTime _time = time.AddHours(0); _time < time.AddHours(24); _time = _time.AddMinutes(30))
            {
                cbb_timeStart.Items.Add(_time.ToShortTimeString());
                cbb_timeEnd.Items.Add(_time.ToShortTimeString());
            }
            cbb_timeStart.SelectedIndex = 0;
            cbb_timeEnd.SelectedIndex = 0;
        }

        public Appt GetAppt()
        {
            DateTime date1 = dtp_timeStart.Value.Date;
            string timeStr1 = cbb_timeStart.Text.ToString();
            DateTime time1 = DateTime.ParseExact(timeStr1, "h:mm tt", CultureInfo.InvariantCulture);
            DateTime dstart = date1.Add(time1.TimeOfDay);

            DateTime date2 = dtp_timeEnd.Value.Date;
            string timeStr2 = cbb_timeEnd.Text.ToString();
            DateTime time2 = DateTime.ParseExact(timeStr2, "h:mm tt", CultureInfo.InvariantCulture);
            DateTime dend = date2.Add(time2.TimeOfDay);

            bool isMeeting;
            if(rbIsMeeting.Checked)
            {
                isMeeting = true;
            }
            else
            {
                isMeeting = false;
            }

            Appt appt = new Appt()
            {
                IDAccount = iDAcc,
                NameAppt = txt_name.Text,
                LocationAppt = txt_location.Text,
                TimeStart = dstart,
                TimeEnd = dend,
                ReminderTime = cb_reminder.Checked,
                IsMeeting = isMeeting,
            };
            return appt;
        }

        public void AddOrUpdateAppt()
        {
            Appt appt = GetAppt();
            //kiểm tra có appt không phải meeting bị trùng không
            //=> nếu có thì hỏi có muốn thay thế k -> chọn có thì đổi không thì thôi
            //=> nếu không thì kiểm tra tiếp
            if (ApptBLL.Instance.CheckSameApptNotMtByIDAcc_BLL(appt) != null)
            {
                if(rbNotMeeting.Checked) //nếu đang chọn không phải meeting thì hỏi có muốn thay thế không, còn là meeting thì show có appt tại thời điểm đó
                {
                    DialogResult result = MessageBox.Show("An appointment has already been scheduled by you for this time! \nDo you want to replace with this new appointment?", "Announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result == DialogResult.Yes)
                    {
                        ApptBLL.Instance.UpdateAppt_BLL(appt);
                        this.Close();
                        return;
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("You have an appointment at this time!");
                    return;
                }
            }

            //kiểm tra có appt mà IDAcc tạo hoặc tham gia bị trùng không
            //=> nếu có thì show có meeting tại thời điểm đó
            //=> nếu không thì kiểm tra tiếp
            if (ApptBLL.Instance.IsSameApptViewMt_BLL(appt) == true) 
            {
                MessageBox.Show("You have a meeting at this time!");
            }
            else
            {
                //kiểm tra có appt của IDAcc khác mà trùng tên và tgian không
                //=> nếu đang chọn là meeting và có trùng thì hỏi có muốn tgia vào 1 trong các meeting của người khác không => nếu chọn có thì show bảng, không thì tự tạo meeting của chính IDAcc
                //=> nếu đang chọn không là meeting thì tạo appt của chính IDAcc
                if (appt.IsMeeting == true && ApptBLL.Instance.GetSameApptMtNotByIDAcc_BLL(appt).Count != 0) 
                {
                    DialogResult result = MessageBox.Show("There are some meetings at this time! \n Would you like to join one of these meetings?", "Announcement", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (result == DialogResult.Yes)
                    {
                        SameTimeMeeting sameTimeMt = new SameTimeMeeting(appt, iDAcc);
                        sameTimeMt.Show();
                        this.Close();
                    }
                    else
                    {
                        ApptBLL.Instance.AddAppt_BLL(appt);
                        this.Close();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show("okk");
                    ApptBLL.Instance.AddAppt_BLL(appt);
                    this.Close();
                    return;
                }
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if(txt_name.Text == null || txt_location.Text == null || (rbIsMeeting.Checked == false && rbNotMeeting.Checked == false))
            {
                MessageBox.Show("Incomplete information entered!");
            }
            else
            {
                if(checkValidTime() == false)
                {
                    MessageBox.Show("Time end must be after time start!");
                }
                else
                {
                    AddOrUpdateAppt();
                    d(iDAcc);
                }
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
