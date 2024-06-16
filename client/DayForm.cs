using commons.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static client.LoginForm;

namespace client
{
    public partial class DayForm : UserControl
    {
        private LoginForm.Mode mode;
        private DateTime date;
        private CalendarForm calForm;

        public DayForm(LoginForm.Mode mode, DateTime date)
        {
            this.mode = mode;
            this.date = date;
            InitializeComponent();
            foreach (Control control in this.Controls)
            {
                control.Click += DayForm_Click; // 폼 내의 모든 컨트롤 클릭
            }
        }

        private void DayForm_Load(object sender, EventArgs e)
        {
            calForm = ParentForm as CalendarForm;
            lbDay.Text = date.Day.ToString();

            var result = calForm.vtable.readFromDate(date.ToString("yyyy-MM-dd"),out ScheduleInfo[] schedules);
            if (result)
            {
                int count = 0;
                foreach(ScheduleInfo s in schedules)
                {
                    if (count > 4) break;
                    if (count == 4 && schedules.Length>3)
                        tbDayMemo.Text += "•••";
                    else
                        tbDayMemo.Text += s.title + "\r\n";
                    count++;
                }
            }
        }
        public void setBlank()
        {
            BackColor = Color.Transparent;
            lbDay.Text = "";
            tbDayMemo.Visible = false;
            BorderStyle = BorderStyle.None;
        }


        private void tbDayMemo_DoubleClick(object sender, EventArgs e)
        {
            DayDetailForm preForm = calForm.getSelectDay();
            if (preForm != null)
            {
                preForm.Close();
                preForm = null;
            }
            DayDetailForm newForm = new DayDetailForm(date, calForm);
            newForm.Show();
            newForm.Location = new Point(this.Location.X + calForm.Location.X + calForm.GetCalendarLocation().X+15, this.Location.Y + calForm.Location.Y + calForm.GetCalendarLocation().Y+130);
            calForm.setSelectDay(newForm);
            newForm.setMode(mode);
        }


        private void DayForm_Click(object sender, EventArgs e)
        {
            DayDetailForm preForm = calForm.getSelectDay();
            if (preForm != null)
            {
                preForm.Close();
                preForm = null;
            }
        }

        private void tbDayMemo_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbDay_Click(object sender, EventArgs e)
        {

        }
    }
}
