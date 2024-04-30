using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static client.LoginForm;

namespace client
{
    public partial class DayDetailForm : Form
    {
        private DateTime date;
        private MainForm.CalData calDatas;
        private MainForm mainForm;
        
        
        public DayDetailForm(DateTime date,MainForm mainForm)
        {
            this.date = date;
            this.mainForm = mainForm;
            if(mainForm.dicDays.ContainsKey(date.ToString("yyyy-M-d")))
            {
                calDatas = mainForm.dicDays[date.ToString("yyyy-M-d")];
            } else calDatas = new MainForm.CalData(date.ToString("yyyy-M-d"), new List<MainForm.CalMemo>());
            InitializeComponent();
        }

        private void DayDetailForm_Load(object sender, EventArgs e)
        {
            lbDetailYMD.Text = date.Year + "년 " + date.Month + "월 " + date.Day + "일";
            foreach (MainForm.CalMemo memo in calDatas.memos) {
                DayDetailItemForm dayForm = new DayDetailItemForm(memo);
                Details.Controls.Add(dayForm);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            MainForm.CalMemo c = new MainForm.CalMemo("제목", "내용");
            calDatas.memos.Add(c);
            DayDetailItemForm dayForm = new DayDetailItemForm(c);
            Details.Controls.Add(dayForm);
        }

        private void DayDetailForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            calDatas.memos.Clear();
            foreach (DayDetailItemForm control in Details.Controls)
            {
                calDatas.memos.Add(control.getCalMemo());
                // 다른 타입의 컨트롤에 대해서도 필요에 따라 처리할 수 있습니다.
            }
            mainForm.dicDays[date.ToString("yyyy-M-d")] = calDatas;
            mainForm.displayDays();
        }
    }
}
