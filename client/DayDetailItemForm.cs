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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace client
{
    public partial class DayDetailItemForm : UserControl
    {
        public ScheduleInfo scheduleInfo;
        // 0 : default, 1 : update, 2 : delete
        public int status = 0;
        public string baseTitle;

        public DayDetailItemForm(ScheduleInfo scheduleInfo)
        {
            this.scheduleInfo = scheduleInfo;
            baseTitle = scheduleInfo.title;
            InitializeComponent();
        }

        private void DayDetailItemForm_Load(object sender, EventArgs e)
        {
            tbTitle.Text = scheduleInfo.title;
            txContent.Text = scheduleInfo.content;
            txContent.Height += 20* scheduleInfo.content.Split('\n').Length - 1;
        }


        private void txContent_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txContent.Height += 20;
            }
        }
        public ScheduleInfo getCalMemo()
        {
            scheduleInfo.title = tbTitle.Text;
            scheduleInfo.content = txContent.Text;
            return scheduleInfo;
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            Parent.Controls.Remove(this);
            status = 2;
        }

        public void setUserMode()
        {
            tbTitle.ReadOnly = true;
            txContent.ReadOnly = true;
            btnRemove.Visible = false;
        }

        private void tbTitle_TextChanged(object sender, EventArgs e)
        {
            status = 1;
            scheduleInfo.title = tbTitle.Text;
        }

        private void txContent_TextChanged(object sender, EventArgs e)
        {
            status = 1;
            scheduleInfo.content = txContent.Text;
        }
    }
}
