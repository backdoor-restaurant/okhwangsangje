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
        public class CalData
        {
            //"2024-4-5"
            public string YMD;
            public List<CalMemo> memos;
            public CalData(string yMD, List<CalMemo> memos)
            {
                YMD = yMD;
                this.memos = memos;
            }
        }
        public class CalMemo
        {
            public string title;
            public string content;
            public CalMemo(string title, string content)
            {
                this.title = title;
                this.content = content;
            }
        }

        private LoginForm.Mode mode;
        private DateTime date;
        private DayDetailForm selectDay;
        public Dictionary<string, CalData> dicDays = new Dictionary<string, CalData>();
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
            List<CalMemo> list = new List<CalMemo>();
            list.Add(new CalMemo("정기 활 쏘기","인원수 : 5\r\n장소:공원"));
            list.Add(new CalMemo("활 교육", "인원수 : 5\r\n장소:공원"));
            dicDays["2024-5-3"] = new CalData("2024-5-3",list);
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
            selectDay.Close();
        }
    }
}
