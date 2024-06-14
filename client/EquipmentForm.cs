using System;
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
    public partial class EquipmentForm : Form
    {
        public Form parent;
        private LoginForm.Mode mode;
        private DateTime date;

        public class Equip
        {
            public string equip;
            public int pound;
            public string serial;
            public int count;
            public bool rentable;

            public Equip(string equip, int pound, string serial, int count, bool rentable)
            {
                this.equip = equip;
                this.pound = pound;
                this.serial = serial;
                this.count = count;
                this.rentable = rentable;
            }
        }
        public EquipmentForm(LoginForm.Mode mode)
        {
            this.mode = mode;
            date = DateTime.Now;
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {

        }

        private void RentBtn_Click(object sender, EventArgs e)
        {

        }

        private void DelBtn_Click(object sender, EventArgs e)
        {

        }

        private void AddBtn_Click(object sender, EventArgs e)
        {

        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            ListViewItem lvi;
            lvi = new ListViewItem(new string[] {"현무궁 25(중장)","1","25","2-1-001036"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 26","1","26","N11385"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 28 (중장)","1","28","2-1-001037"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 30 (1, 장궁)","1","30","N33104"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 32(장궁)","1","32","N33106"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 34","1","34","N33107"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 35 (1, 장궁) ","1","35","N33108"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 35 (2, 중장좌)","1","35","2-1-002043"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 35 (3)","1","35","-"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 40 (1, 중궁)","1","40","1-2-002043"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 40 (2, 중궁)","1","40","N42738"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"화살 대여용 빈 가방","1","",""});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"활 운반 용 큰 가방","1","",""});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"활 운반 용 배낭","1","",""});
this.equipView.Items.Add(lvi);

        }
    }
}
