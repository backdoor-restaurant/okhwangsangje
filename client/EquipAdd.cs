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
            foreach(ListViewItem i in mainForm.GetListView().Items)
            {
                if (i.SubItems[0].Text == tbxName.Text)
                {
                    int new_amount = Int32.Parse(i.SubItems[1].Text) + Int32.Parse(tbxCount.Text);
                    i.SubItems[1].Text = new_amount.ToString();
                    var updated = new ItemInfo()
                    {
                        itemName = tbxName.Text,
                        amount = new_amount,
                    };
                    mainForm.ItemTable.update(updated);
                    i.Tag = updated.getKey();
                    return;
                }
            }
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