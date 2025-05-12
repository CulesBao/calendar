using System;

namespace Calender.DTO
{
    public class ApptView
    {
        public int IDAppt {  get; set; }   
        public string Creator {  get; set; }
        public string NameAppt { get; set; }
        public string LocationAppt { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
    }

    public class Participant
    {
        public int STT { get; set; }
        public string NameOfParticipant { get; set; }
    }
}
