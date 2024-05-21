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
        private CalendarForm mainForm;

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
            mainForm = ParentForm as CalendarForm;
            lbDay.Text = date.Day.ToString();
            if (mainForm.dicDays.ContainsKey(date.ToString("yyyy-M-d")))
            {
                int count = 0;
                CalendarForm.CalData c = mainForm.dicDays[date.ToString("yyyy-M-d")];
                foreach(CalendarForm.CalMemo m in c.memos)
                {
                    if (count > 4) break;
                    if (count == 4 && c.memos.Count>3)
                        tbDayMemo.Text += "•••";
                    else
                        tbDayMemo.Text += m.title + "\r\n";
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
            DayDetailForm preForm = mainForm.getSelectDay();
            if (preForm != null)
            {
                preForm.Close();
                preForm = null;
            }
            DayDetailForm newForm = new DayDetailForm(date, mainForm);
            newForm.Show();
            newForm.Location = new Point(this.Location.X + mainForm.Location.X + mainForm.GetCalendarLocation().X+15, this.Location.Y + mainForm.Location.Y + mainForm.GetCalendarLocation().Y+130);
            mainForm.setSelectDay(newForm);
            newForm.setMode(mode);
        }


        private void DayForm_Click(object sender, EventArgs e)
        {
            DayDetailForm preForm = mainForm.getSelectDay();
            if (preForm != null)
            {
                preForm.Close();
                preForm = null;
            }
        }

    }
}
