using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calender.DTO;

namespace Calender.View
{
    public partial class ParticipantsOfMeeting : Form
    {
        public ParticipantsOfMeeting(List<Participant> participants, ApptView av)
        {
            InitializeComponent();
            dgv.DataSource = participants;
            lb_username.Text = av.Creator;
            label_nameMt.Text = av.NameAppt;
            label_location.Text = av.LocationAppt;
            label_timeStart.Text = av.TimeStart.ToString();
            label_timeEnd.Text = av.TimeEnd.ToString();
        }
    }
}
