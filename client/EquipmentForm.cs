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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


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
                    RentInfoKey key = (RentInfoKey)rentView.Items[i].Tag;
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
                    var rent = new RentInfo()
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

            RentTable.readFromStudentID(admin.studentId, out RentInfo[] info);
            if (mode == LoginForm.Mode.User)
            {
                AddBtn.Visible = false;
                DelBtn.Visible = false;
            }
            ListViewItem lvi;
            foreach (var i in info)
            {
                lvi = new ListViewItem(new string[] { i.itemName, i.amount.ToString(), i.startDate });
                rentView.Items.Add(lvi);
            }
        }
    }
}
