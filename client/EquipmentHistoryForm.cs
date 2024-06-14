using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static client.EquipmentForm;


namespace client
{
    public partial class EquipmentHistoryForm : Form
    {
        public Form parent;
        private LoginForm.Mode mode;

        public enum status
        {
            Using,
            Returned,
        }
        public class History
        {
            public string rentee;
            public Equip equip;
            public int count;
            public string reason;
            public status status;
            public DateTime rentdate;
            public DateTime returndate;
            public string confrimer;


            public History(string rentee, Equip equip, int count, string reason)
            {
                this.rentee = rentee;
                this.equip = equip;
                this.count = count;
                this.reason = reason;
                this.rentdate = DateTime.Now;
            }
        }
        public EquipmentHistoryForm(LoginForm.Mode mode)
        {
            this.mode = mode;
            InitializeComponent();
        }

        private void CheckBtn_Click(object sender, EventArgs e)
        {

        }

        private void EquipmentHistoryForm_Load(object sender, EventArgs e)
        {
            ListViewItem lvi;
            lvi = new ListViewItem(new string[] { "8기/조천운", "가야궁 40 (1, 장궁)", "2", "예시) 석호정 원사 습사용", "진행 중", "2021년 10월 3일", "2021년 10월 17일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "5기/문성준", " 현무궁 30 (1, 장궁)", "", "2021 청소년 우리활쏘기대회 출전", "완료", "2021년 10월 6일", "2021년 12월 1일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "3기/정성엽", "현무궁 35 (1, 장궁) ", "", "2021 청소년 우리활쏘기대회 출전", "완료", "2021년 10월 8일", "2022년 1월 28일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "7기/조민아", " 현무궁 30 (1, 장궁)", "", "중급반 연습", "완료", "2021년 10월 30일", "2021년 12월 1일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최현성", "현무궁 30 (2, 중장)", "", "석호정 근사대 연습", "완료", "2021년 11월 6일", "2021년 12월 1일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최현성", "카본 화살 6.5 x 6.5 ", "3", "석호정 근사대 연습", "완료", "2021년 11월 5일", "2021년 12월 1일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최은영", "현무궁 26", "", "2021 청소년 우리활쏘기대회 출전", "완료", "2021년 10월 24일", "2021년 12월 1일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "1기/김태양", "현무궁 35 (3)", "", "보관중", "완료", "보관중 (반납완료)", "2021년 12월 17일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최정훈", "현무궁 31(1, 중장)", "", "2021 청소년 우리활쏘기대회 출전", "완료", "2021년 10월 24일", "2021년 11월 28일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "7기/정지훈", "현무궁 31(2, 중장)", "", "중급반 연습", "완료", "2021년 11월 13일", "2022년 2월 24일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최정훈", "현무궁 31(1, 중장)", "", "석호정 근사대 연습", "완료", "2021년 12월 1일", "2021년 12월 7일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최은영", "현무궁 28 (중장)", "", "석호정 근사대 연습", "완료", "2021년 12월 3일", "2021년 12월 21일", "정성엽" });
            this.historyView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] { "8기/최정훈", "현무궁 35 (3)", "", "석호정 근사대 연습", "완료", "2021년 12월 7일", "2022년 2월 9일", "정성엽" });
            this.historyView.Items.Add(lvi);

        }
    }
}