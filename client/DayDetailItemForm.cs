using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client
{
    public partial class DayDetailItemForm : UserControl
    {
        private MainForm.CalMemo TmpData;
        public DayDetailItemForm(MainForm.CalMemo tmpData)
        {
            this.TmpData = tmpData; 
            InitializeComponent();
        }

        private void DayDetailItemForm_Load(object sender, EventArgs e)
        {
            tbTitle.Text = TmpData.title;
            txContent.Text = TmpData.content;
            txContent.Height += 20*TmpData.content.Split('\n').Length - 1;
        }


        private void txContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txContent.Height += 20;
            }
        }
        public MainForm.CalMemo getCalMemo()
        {
            TmpData.title = tbTitle.Text;
            TmpData.content = txContent.Text;
            return TmpData;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
        }

        public void setUserMode()
        {
            tbTitle.ReadOnly = true;
            txContent.ReadOnly = true;
            btnRemove.Visible = false;
        }
    }
}
