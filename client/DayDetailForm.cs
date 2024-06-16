using commons.Table;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static client.LoginForm;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

namespace client
{
    public partial class DayDetailForm : Form
    {
        private DateTime date;
        private ScheduleInfo[] calDatas;
        private List<DayDetailItemForm> updateCalDatas;
        private List<DayDetailItemForm> addCalDatas;
        private CalendarForm calForm;
        
        
        public DayDetailForm(DateTime date,CalendarForm calForm)
        {
            this.date = date;
            this.calForm = calForm;
            addCalDatas = new List<DayDetailItemForm>();
            updateCalDatas = new List<DayDetailItemForm>();
            var result = calForm.vtable.readFromDate(date.ToString("yyyy-MM-dd"), out calDatas);
            if(!result) calDatas = new ScheduleInfo[0];
            InitializeComponent();
        }

        private void DayDetailForm_Load(object sender, EventArgs e)
        {
            lbDetailYMD.Text = date.Year + "년 " + date.Month + "월 " + date.Day + "일";
            foreach (ScheduleInfo s in calDatas) {
                DayDetailItemForm dayForm = new DayDetailItemForm(s);
                Details.Controls.Add(dayForm);
                updateCalDatas.Add(dayForm);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var newData = new ScheduleInfo()
            {
                date = date.ToString("yyyy-MM-dd"),
                title = "제목",
                content = "내용"
            };
            DayDetailItemForm dayForm = new DayDetailItemForm(newData);
            addCalDatas.Add(dayForm);
            Details.Controls.Add(dayForm);
        }

        private void DayDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (DayDetailItemForm s in updateCalDatas)
            {
                if(s.status == 1)
                {
                    string changeTitle = s.scheduleInfo.title;
                    s.scheduleInfo.title = s.baseTitle;
                    calForm.vtable.delete(s.scheduleInfo.getKey());
                    s.scheduleInfo.title = changeTitle;
                    calForm.vtable.create(s.scheduleInfo);
                }
                if (s.status == 2)
                    calForm.vtable.delete(s.scheduleInfo.getKey());
            }
            foreach (DayDetailItemForm s in addCalDatas)
            {
                if (s.status == 0 || s.status == 1)
                    calForm.vtable.create(s.scheduleInfo);
                else if(s.status == 2)
                    calForm.vtable.delete(s.scheduleInfo.getKey());
            }
            calForm.displayDays();
        }

        public void setMode(LoginForm.Mode mode)
        {
            switch (mode)
            {
                case LoginForm.Mode.User:
                    foreach (DayDetailItemForm control in Details.Controls)
                    {
                        control.setUserMode();
                    }
                    btnAdd.Visible = false;
                    break;
            }
        }
    }
}
