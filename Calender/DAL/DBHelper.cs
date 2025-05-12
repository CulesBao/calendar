using Calender.DTO;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Calendar.DAL
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
                    string connectionString = @"Data Source=HUYNHTIENNHAT;Initial Catalog=ooad;Integrated Security=True;";
                    _Instance = new DBHelper(connectionString);
                }
                return _Instance;
            }
            private set { }
        }

        public DBHelper(string connectionString)
        {
            _cnn = new SqlConnection(connectionString);
        }

        // Lấy dữ liệu từ database với truy vấn không tham số
        public DataTable GetRecords(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlDataAdapter da = new SqlDataAdapter(query, _cnn))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Lấy dữ liệu với truy vấn có tham số
        public DataTable GetRecordsWithParameters(string query, SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _cnn))
                {
                    if (parameters != null)
                    {
                        cmd.Parameters.AddRange(parameters);
                    }
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(dt);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving records: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return dt;
        }

        // Thực thi câu lệnh INSERT, UPDATE, DELETE
        public void ExecuteDB(string query)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _cnn))
                {
                    _cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error executing query: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                    _cnn.Close();
            }
        }

        // Thêm hoặc cập nhật Appointment
        public void AddOrUpdateAppt(string query, Appt appt)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _cnn))
                {
                    cmd.Parameters.AddWithValue("@IDAccount", appt.IDAccount);
                    cmd.Parameters.AddWithValue("@NameAppt", appt.NameAppt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@LocationAppt", appt.LocationAppt ?? (object)DBNull.Value);
                    cmd.Parameters.AddWithValue("@TimeStart", appt.TimeStart);
                    cmd.Parameters.AddWithValue("@TimeEnd", appt.TimeEnd);
                    cmd.Parameters.AddWithValue("@ReminderTime", appt.ReminderTime);
                    cmd.Parameters.AddWithValue("@IsMeeting", appt.IsMeeting);

                    _cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (SqlException ex) when (ex.Message.Contains("New appointment overlaps with an existing appointment"))
            {
                MessageBox.Show("The appointment overlaps with an existing one. Please choose a different time.", "Overlap Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding/updating appointment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                    _cnn.Close();
            }
        }

        // Thêm người tham gia vào Meeting
        public void AddMeeting(string query, Appt appt, int idAcc)
        {
            try
            {
                using (SqlCommand cmd = new SqlCommand(query, _cnn))
                {
                    cmd.Parameters.AddWithValue("@IDAppt", appt.IDAppt);
                    cmd.Parameters.AddWithValue("@IDAccount", idAcc);

                    _cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error adding to meeting: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (_cnn.State == ConnectionState.Open)
                    _cnn.Close();
            }
        }
    }
}