namespace Calender.View
{
    partial class AddForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_name = new System.Windows.Forms.TextBox();
            this.txt_location = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtp_timeStart = new System.Windows.Forms.DateTimePicker();
            this.dtp_timeEnd = new System.Windows.Forms.DateTimePicker();
            this.cb_reminder = new System.Windows.Forms.CheckBox();
            this.time_notify = new System.Windows.Forms.Timer(this.components);
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cbb_timeStart = new System.Windows.Forms.ComboBox();
            this.cbb_timeEnd = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rbNotMeeting = new System.Windows.Forms.RadioButton();
            this.rbIsMeeting = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(273, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(258, 35);
            this.label1.TabIndex = 14;
            this.label1.Text = "ADD APPOINTMENT";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label2.Location = new System.Drawing.Point(94, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(162, 23);
            this.label2.TabIndex = 15;
            this.label2.Text = "Appointment Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label3.Location = new System.Drawing.Point(93, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 23);
            this.label3.TabIndex = 16;
            this.label3.Text = "Location";
            // 
            // txt_name
            // 
            this.txt_name.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_name.Location = new System.Drawing.Point(280, 87);
            this.txt_name.Name = "txt_name";
            this.txt_name.Size = new System.Drawing.Size(405, 27);
            this.txt_name.TabIndex = 17;
            // 
            // txt_location
            // 
            this.txt_location.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txt_location.Location = new System.Drawing.Point(279, 138);
            this.txt_location.Name = "txt_location";
            this.txt_location.Size = new System.Drawing.Size(405, 27);
            this.txt_location.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label4.Location = new System.Drawing.Point(93, 193);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(86, 23);
            this.label4.TabIndex = 19;
            this.label4.Text = "Time start";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label5.Location = new System.Drawing.Point(93, 252);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 23);
            this.label5.TabIndex = 20;
            this.label5.Text = "Time end";
            // 
            // dtp_timeStart
            // 
            this.dtp_timeStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_timeStart.Location = new System.Drawing.Point(279, 193);
            this.dtp_timeStart.Name = "dtp_timeStart";
            this.dtp_timeStart.Size = new System.Drawing.Size(252, 27);
            this.dtp_timeStart.TabIndex = 21;
            // 
            // dtp_timeEnd
            // 
            this.dtp_timeEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtp_timeEnd.Location = new System.Drawing.Point(279, 252);
            this.dtp_timeEnd.Name = "dtp_timeEnd";
            this.dtp_timeEnd.Size = new System.Drawing.Size(252, 27);
            this.dtp_timeEnd.TabIndex = 22;
            // 
            // cb_reminder
            // 
            this.cb_reminder.AutoSize = true;
            this.cb_reminder.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cb_reminder.Location = new System.Drawing.Point(97, 370);
            this.cb_reminder.Name = "cb_reminder";
            this.cb_reminder.Size = new System.Drawing.Size(223, 27);
            this.cb_reminder.TabIndex = 25;
            this.cb_reminder.Text = "Add to your reminder list";
            this.cb_reminder.UseVisualStyleBackColor = true;
            // 
            // time_notify
            // 
            this.time_notify.Enabled = true;
            this.time_notify.Interval = 60000;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_cancel.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ForeColor = System.Drawing.Color.White;
            this.btn_cancel.Location = new System.Drawing.Point(152, 427);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(128, 50);
            this.btn_cancel.TabIndex = 28;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_save.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.ForeColor = System.Drawing.Color.White;
            this.btn_save.Location = new System.Drawing.Point(479, 427);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(128, 50);
            this.btn_save.TabIndex = 29;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cbb_timeStart
            // 
            this.cbb_timeStart.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbb_timeStart.FormattingEnabled = true;
            this.cbb_timeStart.Location = new System.Drawing.Point(572, 192);
            this.cbb_timeStart.Name = "cbb_timeStart";
            this.cbb_timeStart.Size = new System.Drawing.Size(112, 28);
            this.cbb_timeStart.TabIndex = 30;
            // 
            // cbb_timeEnd
            // 
            this.cbb_timeEnd.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cbb_timeEnd.FormattingEnabled = true;
            this.cbb_timeEnd.Location = new System.Drawing.Point(572, 251);
            this.cbb_timeEnd.Name = "cbb_timeEnd";
            this.cbb_timeEnd.Size = new System.Drawing.Size(112, 28);
            this.cbb_timeEnd.TabIndex = 31;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label8.Location = new System.Drawing.Point(94, 312);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(260, 23);
            this.label8.TabIndex = 32;
            this.label8.Text = "Appointment is a group meeting\r\n";
            // 
            // rbNotMeeting
            // 
            this.rbNotMeeting.AutoSize = true;
            this.rbNotMeeting.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbNotMeeting.Location = new System.Drawing.Point(374, 314);
            this.rbNotMeeting.Name = "rbNotMeeting";
            this.rbNotMeeting.Size = new System.Drawing.Size(54, 27);
            this.rbNotMeeting.TabIndex = 33;
            this.rbNotMeeting.TabStop = true;
            this.rbNotMeeting.Text = "No";
            this.rbNotMeeting.UseVisualStyleBackColor = true;
            // 
            // rbIsMeeting
            // 
            this.rbIsMeeting.AutoSize = true;
            this.rbIsMeeting.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.rbIsMeeting.Location = new System.Drawing.Point(453, 314);
            this.rbIsMeeting.Name = "rbIsMeeting";
            this.rbIsMeeting.Size = new System.Drawing.Size(55, 27);
            this.rbIsMeeting.TabIndex = 34;
            this.rbIsMeeting.TabStop = true;
            this.rbIsMeeting.Text = "Yes";
            this.rbIsMeeting.UseVisualStyleBackColor = true;
            // 
            // AddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 509);
            this.Controls.Add(this.rbIsMeeting);
            this.Controls.Add(this.rbNotMeeting);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cbb_timeEnd);
            this.Controls.Add(this.cbb_timeStart);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.cb_reminder);
            this.Controls.Add(this.dtp_timeEnd);
            this.Controls.Add(this.dtp_timeStart);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_location);
            this.Controls.Add(this.txt_name);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AddForm";
            this.Text = "AddForm";
            this.Load += new System.EventHandler(this.AddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_name;
        private System.Windows.Forms.TextBox txt_location;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtp_timeStart;
        private System.Windows.Forms.DateTimePicker dtp_timeEnd;
        private System.Windows.Forms.CheckBox cb_reminder;
        private System.Windows.Forms.Timer time_notify;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ComboBox cbb_timeStart;
        private System.Windows.Forms.ComboBox cbb_timeEnd;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rbNotMeeting;
        private System.Windows.Forms.RadioButton rbIsMeeting;
    }
}