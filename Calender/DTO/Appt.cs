using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calender.DTO
{
    public class Appt
    {
        public int IDAppt { get; set; }
        public int IDAccount { get; set; }
        public string NameAppt { get; set; }
        public string LocationAppt { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public bool ReminderTime { get; set; }
        public bool IsMeeting { get; set; }
    }
}
