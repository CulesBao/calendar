namespace Calender.View
{
    partial class MainForm
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
            this.dgv = new System.Windows.Forms.DataGridView();
            this.btn_appt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_add = new System.Windows.Forms.Button();
            this.lb_username = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_meeting = new System.Windows.Forms.Button();
            this.btn_reminder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv
            // 
            this.dgv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv.Location = new System.Drawing.Point(102, 124);
            this.dgv.Name = "dgv";
            this.dgv.RowHeadersWidth = 51;
            this.dgv.RowTemplate.Height = 24;
            this.dgv.Size = new System.Drawing.Size(686, 255);
            this.dgv.TabIndex = 0;
            this.dgv.RowHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgv_RowHeaderMouseClick);
            // 
            // btn_appt
            // 
            this.btn_appt.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btn_appt.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_appt.Location = new System.Drawing.Point(102, 400);
            this.btn_appt.Name = "btn_appt";
            this.btn_appt.Size = new System.Drawing.Size(205, 49);
            this.btn_appt.TabIndex = 1;
            this.btn_appt.Text = "View list of appointments";
            this.btn_appt.UseVisualStyleBackColor = true;
            this.btn_appt.Click += new System.EventHandler(this.btn_appt_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Indigo;
            this.label1.Location = new System.Drawing.Point(234, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(392, 35);
            this.label1.TabIndex = 8;
            this.label1.Text = "ADD APPOINTMENT CALENDER";
            // 
            // btn_add
            // 
            this.btn_add.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btn_add.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btn_add.ForeColor = System.Drawing.Color.White;
            this.btn_add.Location = new System.Drawing.Point(665, 68);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(123, 50);
            this.btn_add.TabIndex = 9;
            this.btn_add.Text = "Add appt";
            this.btn_add.UseVisualStyleBackColor = false;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // lb_username
            // 
            this.lb_username.AutoSize = true;
            this.lb_username.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lb_username.Location = new System.Drawing.Point(171, 87);
            this.lb_username.Name = "lb_username";
            this.lb_username.Size = new System.Drawing.Size(59, 23);
            this.lb_username.TabIndex = 10;
            this.lb_username.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(105, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "User:";
            // 
            // btn_meeting
            // 
            this.btn_meeting.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btn_meeting.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_meeting.Location = new System.Drawing.Point(348, 400);
            this.btn_meeting.Name = "btn_meeting";
            this.btn_meeting.Size = new System.Drawing.Size(205, 49);
            this.btn_meeting.TabIndex = 12;
            this.btn_meeting.Text = "View list of meetings";
            this.btn_meeting.UseVisualStyleBackColor = true;
            this.btn_meeting.Click += new System.EventHandler(this.btn_meeting_Click);
            // 
            // btn_reminder
            // 
            this.btn_reminder.Font = new System.Drawing.Font("Segoe UI", 8F, System.Drawing.FontStyle.Bold);
            this.btn_reminder.ForeColor = System.Drawing.Color.DarkSlateBlue;
            this.btn_reminder.Location = new System.Drawing.Point(583, 400);
            this.btn_reminder.Name = "btn_reminder";
            this.btn_reminder.Size = new System.Drawing.Size(205, 49);
            this.btn_reminder.TabIndex = 13;
            this.btn_reminder.Text = "View list of reminders";
            this.btn_reminder.UseVisualStyleBackColor = true;
            this.btn_reminder.Click += new System.EventHandler(this.btn_reminder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(873, 488);
            this.Controls.Add(this.btn_reminder);
            this.Controls.Add(this.btn_meeting);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lb_username);
            this.Controls.Add(this.btn_add);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_appt);
            this.Controls.Add(this.dgv);
            this.Name = "MainForm";
            this.Text = "MainForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv;
        private System.Windows.Forms.Button btn_appt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label lb_username;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_meeting;
        private System.Windows.Forms.Button btn_reminder;
    }
}

