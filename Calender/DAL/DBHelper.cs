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
using MySql.Data.MySqlClient;

namespace Calender.DAL
{
    internal class DBHelper
    {
        private MySqlConnection _cnn;   
        private static DBHelper _Instance;

        public static DBHelper Instance
        {
            get
            {
                if (_Instance == null)
                {
                    string s = @"datasource=127.0.0.1;port=3306;username=root;password=;database=ooad;";
                    _Instance = new DBHelper(s);
                }
                return _Instance;
            }
            private set { }
        }

        public DBHelper(string s)
        {
            _cnn = new MySqlConnection(s);
        }

        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(query, _cnn);
            _cnn.Open();
            da.Fill(dt);
            _cnn.Close();
            return dt;
        }

        public void ExecuteDB(string query)
        {
            MySqlCommand cmd = new MySqlCommand(query, _cnn);
            _cnn.Open();
            cmd.ExecuteNonQuery();
            _cnn.Close();
        }

        public void AddOrUpdateAppt(string query, Appt appt)
        {
            try
            {
                MySqlCommand cmd = new MySqlCommand(query, _cnn);
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
                MySqlCommand cmd = new MySqlCommand(query, _cnn);
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
