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
using commons.Table;
using commons.VirtualDB;

namespace client
{
    public partial class EquipAdd : Form
    {

        private EquipmentForm mainForm;
        public EquipAdd(EquipmentForm mainform)
        {
            this.mainForm = mainform;
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ListViewItem lvi;
            lvi = new ListViewItem(new string[] { tbxName.Text, tbxCount.Text });
            var item = new ItemInfo()
            {
                itemName = tbxName.Text,
                amount = Int32.Parse(tbxCount.Text),
            };
            mainForm.ItemTable.create(item);
            lvi.Tag = item.getKey();
            mainForm.GetListView().Items.Add(lvi);
        }
    }
}