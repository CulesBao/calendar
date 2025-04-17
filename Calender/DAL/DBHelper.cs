using Calender.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Principal;

namespace Calender.DAL
{
    internal class DBHelper
    {
        private SqlConnection _cnn;
        private static DBHelper _Instance;

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string s = @"Data Source=THANHTULAPTOP\SQLEXPRESS;Initial Catalog=OOAD;Integrated Security=True";
                    _Instance = new DBHelper(s);
                }
                return _Instance;
            }
            private set { }
        }

        public DBHelper(string s)
        {
            _cnn = new SqlConnection(s);
        }

        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(query, _cnn);
            _cnn.Open();
            da.Fill(dt);
            _cnn.Close();
            return dt;
        }

        public void ExecuteDB(string query)
        {
            SqlCommand cmd = new SqlCommand(query, _cnn);
            _cnn.Open();
            cmd.ExecuteNonQuery();
            _cnn.Close();
        }

        public void AddOrUpdateAppt(string query, Appt appt)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, _cnn);
                _cnn.Open();
                cmd.Parameters.AddWithValue("@IDAccount", appt.IDAccount); 
                cmd.Parameters.AddWithValue("@NameAppt", appt.NameAppt);
                cmd.Parameters.AddWithValue("@LocationAppt", appt.LocationAppt);
                cmd.Parameters.AddWithValue("@TimeStart", appt.TimeStart);
                cmd.Parameters.AddWithValue("@TimeEnd", appt.TimeEnd);
                cmd.Parameters.AddWithValue("@ReminderTime", appt.ReminderTime);
                cmd.Parameters.AddWithValue("@IsMeeting", appt.IsMeeting);
                cmd.ExecuteNonQuery();
                _cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public void AddMeeting(string query, Appt appt, int idAcc)
        {
            try
            {
                SqlCommand cmd = new SqlCommand(query, _cnn);
                _cnn.Open();
                cmd.Parameters.AddWithValue("@IDAppt", appt.IDAppt);
                cmd.Parameters.AddWithValue("@IDAccount", idAcc);
                cmd.ExecuteNonQuery();
                _cnn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
