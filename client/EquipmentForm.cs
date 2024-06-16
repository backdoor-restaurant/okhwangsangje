using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using commons.Table;
using commons.VirtualDB;


namespace client
{
    public partial class EquipmentForm : Form
    {
        public Form parent;
        private LoginForm.Mode mode;
        public ItemVT ItemTable;
        public LentInfoVT RentTable;
        private static readonly LoginInfo admin = new LoginInfo() // make it to static?
        {
            studentId = "0",
            password = "secret1234"
        };

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
            InitializeComponent();
        }

        private void ReturnBtn_Click(object sender, EventArgs e)
        {
            for (int i = rentView.Items.Count - 1; i >= 0; i--)
            {
                if (rentView.Items[i].Selected)
                {
                    LentInfoKey key = (LentInfoKey)rentView.Items[i].Tag;
                    RentTable.delete(key);
                    rentView.Items[i].Remove();
                }
            }
        }

        private void RentBtn_Click(object sender, EventArgs e)
        {
            for (int i = equipView.Items.Count - 1; i >= 0; i--)
            {
                if (equipView.Items[i].Selected)
                {
                    ListViewItem selected = equipView.Items[i];
                    ListViewItem lvi;
                    var rent = new LentInfo()
                    {
                        itemName = selected.SubItems[0].Text,
                        amount = Int32.Parse(selected.SubItems[1].Text),
                        studentId = admin.studentId,
                        startDate = DateTime.Now.ToString("yyyyMMdd"),
                    };
                    RentTable.create(rent);
                    lvi = (ListViewItem)selected.Clone();
                    lvi.Tag = rent.getKey();
                    rentView.Items.Add(lvi);
                }
            }
        }

        private void DelBtn_Click(object sender, EventArgs e)
        {
            for(int i = equipView.Items.Count - 1; i >= 0; i--)
            {
                if (equipView.Items[i].Selected)
                {
                    ItemInfoKey key = (ItemInfoKey)equipView.Items[i].Tag;
                    ItemTable.delete(key);
                    equipView.Items[i].Remove();
                }
            }
        }

        private void AddBtn_Click(object sender, EventArgs e)
        {
            EquipAdd addform = new EquipAdd(this);
            addform.ShowDialog();
        }

        public ListView GetListView()
        {
            return equipView;
        }

        private void EquipmentForm_Load(object sender, EventArgs e)
        {
            ItemTable = new ItemVT();
            ItemTable.signin(admin);
            RentTable = new LentInfoVT();
            RentTable.signin(admin);

         //   var r_result = vtable.read(key, out ItemInfo item);
           // Console.WriteLine($"Read Result: {r_result}, {item}");



            ListViewItem lvi;
            lvi = new ListViewItem(new string[] {"현무궁 25(중장)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 26","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 28 (중장)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 30 (1, 장궁)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 32(장궁)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 34","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 35 (1, 장궁) ","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 35 (2, 중장좌)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 35 (3)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 40 (1, 중궁)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"현무궁 40 (2, 중궁)","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"화살 대여용 빈 가방","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"활 운반 용 큰 가방","1"});
this.equipView.Items.Add(lvi);
            lvi = new ListViewItem(new string[] {"활 운반 용 배낭","1"});
this.equipView.Items.Add(lvi);

        }
    }
}
