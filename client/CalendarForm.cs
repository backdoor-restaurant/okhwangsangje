using commons.Table;
using commons.VirtualDB;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace client
{
    public partial class CalendarForm : Form
    {
        public Form parent;
        public ScheduleVT vtable;
        private static readonly LoginInfo admin = new LoginInfo()
        {
            studentId = "0",
            password = "secret1234"
        };

        private LoginForm.Mode mode;
        private DateTime date;
        private DayDetailForm selectDay;
        public CalendarForm(LoginForm.Mode mode)
        {
            this.mode = mode;
            date = DateTime.Now;
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Click += MainForm_Click; // 폼 내의 모든 컨트롤 클릭
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            vtable = new ScheduleVT();
            vtable.signin(admin);
            displayDays();
        }

        public void displayDays()
        {
            Calendar.Controls.Clear();
            DateTime startOfMonth = new DateTime(date.Year, date.Month, 1);
            lbYMD.Text = date.Year + "년 " + date.Month + "월";
            int days  = DateTime.DaysInMonth(date.Year, date.Month);  
            int dayOfTheWeek = Convert.ToInt32(startOfMonth.DayOfWeek.ToString("d"));
            for (int i=0;i<dayOfTheWeek;i++)
            {
                DayForm dayForm = new DayForm(mode, startOfMonth);
                Calendar.Controls.Add(dayForm);
                dayForm.setBlank();
            }
            for (int i = 0; i < days; i++)
            {
                DayForm dayForm = new DayForm(mode, startOfMonth.AddDays(i));
                Calendar.Controls.Add(dayForm);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            date = date.AddMonths(-1);
            displayDays();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            date = date.AddMonths(1);
            displayDays();
        }

        public void setSelectDay(DayDetailForm f)
        {
            selectDay = f;
        }
        public DayDetailForm getSelectDay() 
        {  
            return selectDay; 
        }
        public Point GetCalendarLocation()
        {
            return new Point(Calendar.Location.X + parent.Location.X, Calendar.Location.Y + parent.Location.Y);
        }


        private void MainForm_Click(object sender, EventArgs e)
        {
            if (selectDay != null)
            {
                selectDay.Close();
                selectDay = null;
            }
        }

        private void CalendarForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (selectDay != null)
            {
                selectDay.Close();
                selectDay = null;
            }
        }

        private void preBtn_Click(object sender, EventArgs e)
        {
            date = date.AddMonths(-1);
            displayDays();
        }

        private void nxtBtn_Click(object sender, EventArgs e)
        {
            date = date.AddMonths(1);
            displayDays();
        }
    }
}
