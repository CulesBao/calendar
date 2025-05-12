using Calender.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Calendar.DAL
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

        private Appt GetApptByDataRow_DAL(DataRow row)
        {
            try
            {
                return new Appt
                {
                    IDAppt = Convert.ToInt32(row["Id"]),
                    IDAccount = Convert.ToInt32(row["AccountId"]),
                    NameAppt = row["NameAppt"]?.ToString(),
                    LocationAppt = row["LocationAppt"]?.ToString(),
                    TimeStart = Convert.ToDateTime(row["TimeStart"]),
                    TimeEnd = Convert.ToDateTime(row["TimeEnd"]),
                    ReminderTime = Convert.ToBoolean(row["ReminderTime"]),
                    IsMeeting = Convert.ToBoolean(row["IsMeeting"])
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping DataRow to Appt: {ex.Message}");
            }
        }

        private Meeting GetMeetingByDataRow_DAL(DataRow row)
        {
            try
            {
                return new Meeting
                {
                    IDAppt = Convert.ToInt32(row["AppointmentId"]),
                    IDAccount = Convert.ToInt32(row["AccountId"])
                };
            }
            catch (Exception ex)
            {
                throw new Exception($"Error mapping DataRow to Meeting: {ex.Message}");
            }
        }

        // List appt (bao gồm meeting và không phải meeting)
        public List<Appt> GetAllAppt_DAL(int IDAccount)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment";
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecords(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        // List appt (bao gồm meeting và không phải meeting) + có cùng IDAccount
        public List<Appt> GetAllApptByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE AccountId = @AccountId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", IDAccount)
            };
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        // List appt không phải là meeting + có cùng IDAccount
        public List<Appt> GetAllApptNotMtByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE AccountId = @AccountId AND IsMeeting = 0";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", IDAccount)
            };
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        // List appt là meeting + (có cùng và khác IDAccount)
        public List<Appt> GetAllApptMt_DAL()
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE IsMeeting = 1";
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecords(query);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        // List appt là meeting + có cùng IDAccount
        public List<Appt> GetAllApptMtByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE AccountId = @AccountId AND IsMeeting = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", IDAccount)
            };
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        // List appt là meeting + khác IDAccount
        public List<Appt> GetAllApptMtNotByIDAcc_DAL(int IDAccount)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE AccountId <> @AccountId AND IsMeeting = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", IDAccount)
            };
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        // Trả về appt là meeting có cùng IDAppt
        public Appt GetApptMtByIDAppt(int IDAppt)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE Id = @IDAppt AND IsMeeting = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDAppt", IDAppt)
            };
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return GetApptByDataRow_DAL(dt.Rows[0]);
            }
            return null;
        }

        // List meeting IDAccount tham gia
        public List<Meeting> GetAllMeetingByIDAccount_DAL(int IDAccount)
        {
            string query = "SELECT AppointmentId, AccountId FROM Meeting WHERE AccountId = @AccountId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", IDAccount)
            };
            List<Meeting> list = new List<Meeting>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetMeetingByDataRow_DAL(row));
            }
            return list;
        }

        // List reminder của 1 người
        public List<Appt> GetAllReminderByIDAccount_DAL(int IDAccount)
        {
            string query = "SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting FROM Appointment WHERE AccountId = @AccountId AND ReminderTime = 1";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", IDAccount)
            };
            List<Appt> list = new List<Appt>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetApptByDataRow_DAL(row));
            }
            return list;
        }

        public void AddAppt_DAL(Appt appt)
        {
            string query = "INSERT INTO Appointment (AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting) " +
                           "VALUES (@IDAccount, @NameAppt, @LocationAppt, @TimeStart, @TimeEnd, @ReminderTime, @IsMeeting)";
            DBHelper.Instance.AddOrUpdateAppt(query, appt);
        }

        public void UpdateAppt_DAL(Appt appt)
        {
            string query = "UPDATE Appointment SET AccountId = @IDAccount, NameAppt = @NameAppt, LocationAppt = @LocationAppt, " +
                           "TimeStart = @TimeStart, TimeEnd = @TimeEnd, ReminderTime = @ReminderTime, IsMeeting = @IsMeeting " +
                           "WHERE Id = @IDAppt";
            DBHelper.Instance.AddOrUpdateAppt(query, appt);
        }

        public void AddMeeting_DAL(Appt appt, int idAcc)
        {
            string query = "INSERT INTO Meeting (AppointmentId, AccountId) VALUES (@IDAppt, @IDAccount)";
            DBHelper.Instance.AddMeeting(query, appt, idAcc);
        }

        public List<int> GetListIDAccountSameMeeting_DAL(int IDAppt)
        {
            string query = "SELECT AppointmentId, AccountId FROM Meeting WHERE AppointmentId = @IDAppt";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@IDAppt", IDAppt)
            };
            List<int> list = new List<int>();
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            foreach (DataRow row in dt.Rows)
            {
                list.Add(GetMeetingByDataRow_DAL(row).IDAccount);
            }
            return list;
        }

        public Appt CheckAppointmentOverlap_DAL(int accountId, DateTime timeStart, DateTime timeEnd)
        {
            string query = @"
                SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting
                FROM Appointment
                WHERE AccountId = @AccountId
                AND TimeStart < @TimeEnd
                AND TimeEnd > @TimeStart";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", accountId),
                new SqlParameter("@TimeStart", timeStart),
                new SqlParameter("@TimeEnd", timeEnd)
            };
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return GetApptByDataRow_DAL(dt.Rows[0]);
            }
            return null;
        }

        public Appt CheckNonMeetingAppointmentOverlap_DAL(int accountId, DateTime timeStart, DateTime timeEnd)
        {
            string query = @"
                SELECT Id, AccountId, NameAppt, LocationAppt, TimeStart, TimeEnd, ReminderTime, IsMeeting
                FROM Appointment
                WHERE AccountId = @AccountId
                AND IsMeeting = 0
                AND TimeStart < @TimeEnd
                AND TimeEnd > @TimeStart";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", accountId),
                new SqlParameter("@TimeStart", timeStart),
                new SqlParameter("@TimeEnd", timeEnd)
            };
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            if (dt.Rows.Count > 0)
            {
                return GetApptByDataRow_DAL(dt.Rows[0]);
            }
            return null;
        }

        public bool CheckMeetingOverlap_DAL(int accountId, string nameAppt, DateTime timeStart, DateTime timeEnd)
        {
            string query = @"
            SELECT 1
            FROM Appointment a
            WHERE a.IsMeeting = 1
            AND (
                (a.AccountId = @AccountId AND a.NameAppt = @NameAppt AND a.TimeStart = @TimeStart AND a.TimeEnd = @TimeEnd)
                OR EXISTS (
                    SELECT 1
                    FROM Meeting m
                    INNER JOIN Appointment ap ON m.AppointmentId = ap.Id
                    WHERE m.AccountId = @AccountId
                    AND ap.NameAppt = @NameAppt
                    AND ap.TimeStart = @TimeStart
                    AND ap.TimeEnd = @TimeEnd
                )
            )";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@AccountId", accountId),
                new SqlParameter("@NameAppt", nameAppt ?? (object)DBNull.Value),
                new SqlParameter("@TimeStart", timeStart),
                new SqlParameter("@TimeEnd", timeEnd)
            };
            DataTable dt = DBHelper.Instance.GetRecordsWithParameters(query, parameters);
            return dt.Rows.Count > 0;
        }
    }
}