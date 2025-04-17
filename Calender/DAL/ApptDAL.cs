using Calender.DTO;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Calender.DAL
{
    internal class ApptDAL
    {
        private static ApptDAL _Instance;

        public static ApptDAL Instance
        {
            get
            {
                if (_Instance == null)
                {
                    _Instance = new ApptDAL();
                }
                return _Instance;
            }
            private set { }
        }

        public ApptDAL()
        {

        }

        public Appt GetApptByDataRow_DAL(DataRow i)
        {
            Appt appt = new Appt()
            {
                IDAppt = Convert.ToInt32(i["IDAppt"].ToString()),
                IDAccount = Convert.ToInt32(i["IDAccount"].ToString()),
                NameAppt = i["NameAppt"].ToString(),
                LocationAppt = i["LocationAppt"].ToString(),
                TimeStart = Convert.ToDateTime(i["TimeStart"].ToString()),
                TimeEnd = Convert.ToDateTime(i["TimeEnd"].ToString()),
                IsMeeting = Convert.ToBoolean(i["IsMeeting"].ToString()),
                ReminderTime = Convert.ToBoolean(i["ReminderTime"].ToString())
            };
            return appt;
        }

        //list appt (bao gồm meeting và không phải meeting)
        public List<Appt> GetAllAppt_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Appointment";
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        //list appt (bao gồm meeting và không phải meeting) + có cùng IDAcc 
        public List<Appt> GetAllApptByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Appointment WHERE IDAccount = " + IDAccount;
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        //list appt không phải là meeting + có cùng IDAcc 
        public List<Appt> GetAllApptNotMtByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Appointment WHERE IDAccount = " + IDAccount + " AND IsMeeting = 0";
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        //list appt là meeting + (có cùng và khác IDAcc)
        public List<Appt> GetAllApptMt_DAL()
        {
            string query = "SELECT * FROM Appointment WHERE IsMeeting = 1";
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        //list appt là meeting + có cùng IDAcc
        public List<Appt> GetAllApptMtByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Appointment WHERE IDAccount = " + IDAccount + " AND IsMeeting = 1";
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        //list appt là meeting + khác IDAcc 
        public List<Appt> GetAllApptMtNotByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Appointment WHERE IDAccount <> " + IDAccount + " AND IsMeeting = 1";
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        //trả về appt là meeting có cùng IDAppt
        public Appt GetApptMtByIDAppt(int IDAppt)
        {
            string query = "SELECT * FROM Appointment WHERE IDAppt = " + IDAppt + " AND IsMeeting = 1";
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                return GetApptByDataRow_DAL(i);
            }
            return null;
        }

        //Meeting IDAcc tham gia
        public Meeting GetMeetingByDataRow_DAL(DataRow i)
        {
            Meeting meeting = new Meeting()
            {
                IDAppt = Convert.ToInt32(i["IDAppt"].ToString()),
                IDAccount = Convert.ToInt32(i["IDAccount"].ToString()),
            };
            return meeting;
        }

        //list meeting IDAcc tham gia
        public List<Meeting> GetAllMeetingByIDAccount_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Meeting WHERE IDAccount = " + IDAccount;
            List<Meeting> list = new List<Meeting>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetMeetingByDataRow_DAL(i));
            }
            return list;
        }

        //list reminder của 1 người
        public List<Appt> GetAllReminderByIDAccount_DAL(int IDAccount)
        {
            string query = "SELECT * FROM Appointment WHERE IDAccount = " + IDAccount + " AND ReminderTime = 1";
            List<Appt> list = new List<Appt>();
            foreach (DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetApptByDataRow_DAL(i));
            }
            return list;
        }

        public void AddAppt_DAL(Appt appt)
        {
            string query = "INSERT INTO Appointment (IDAccount, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting) VALUES (@IDAccount, @NameAppt, @LocationAppt, @TimeStart, @TimeEnd, @ReminderTime, @IsMeeting)";
            DBHelper.Instance.AddOrUpdateAppt(query, appt);
        }

        public void UpdateAppt_DAL(Appt appt)
        {
            string query = "UPDATE Appointment SET NameAppt = @NameAppt, LocationAppt = @LocationAppt, TimeStart = @TimeStart, TimeEnd = @TimeEnd, ReminderTime = @ReminderTime, IsMeeting = @IsMeeting WHERE IDAccount = @IDAccount AND TimeStart <= @TimeStart AND TimeEnd > @TimeStart";
            DBHelper.Instance.AddOrUpdateAppt(query, appt);
        }

        //thêm người vào meeting
        public void AddMeeting_DAL(Appt appt, int idAcc)
        {
            string query = "INSERT INTO Meeting (IDAppt, IDAccount) VALUES (@IDAppt, @IDAccount)";
            DBHelper.Instance.AddMeeting(query, appt, idAcc);
        }

        //list idAcc tham gia vào cùng 1 meeting
        public List<int> GetListIDAccountSameMeeting_DAL(int IDAppt)
        {
            string query = "SELECT * FROM MEETING WHERE IDAppt = " + IDAppt;
            List<int> list = new List<int>();
            foreach(DataRow i in DBHelper.Instance.GetRecords(query).Rows)
            {
                list.Add(GetMeetingByDataRow_DAL(i).IDAccount);
            }
            return list;
        }
    }
}
