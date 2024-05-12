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
    public partial class MainForm : Form
    {
        Form child;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCalendar();
        }

        private void ShowCalendar()
        {
            if(child != null)
                child.Close();
            this.Controls.Remove(child);

            child = new CalendarForm(Mode.Admin);
            child.MdiParent = this; 
            child.Show();
            (child as CalendarForm).parent = this;
            child.AutoScroll = false;
            child.Location = new Point(25, 0);
        }
        private void ShowEquip()
        {
            if (child != null)
                child.Close();
            this.Controls.Remove(child);

            child = new EquipmentForm(Mode.Admin);
            child.MdiParent = this;
            child.Show();
            (child as EquipmentForm).parent = this;
            child.AutoScroll = false;
            child.Location = new Point(25, 0);
        }
        private void ShowEquipStatus()
        {
            if (child != null)
                child.Close();
            this.Controls.Remove(child);

            child = new EquipmentHistoryForm(Mode.Admin);
            child.MdiParent = this;
            child.Show();
            (child as EquipmentHistoryForm).parent = this;
            child.AutoScroll = false;
            child.Location = new Point(25, 0);
        }
        private void CalendarBtn_Click(object sender, EventArgs e)
        {
            ShowCalendar();
        }

        private void EquipBtn_Click(object sender, EventArgs e)
        {
            ShowEquip();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (child != null)
                child.Close();
        }

        private void EquipStatusBtn_Click(object sender, EventArgs e)
        {
            ShowEquipStatus();
        }
    }
}
