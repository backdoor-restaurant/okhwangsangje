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
        private string userName;
        private Mode mode;
        public MainForm(string userName)
        {
            this.userName = userName;
            if (userName == "root") mode = Mode.Admin;
            else mode = Mode.User;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            ShowCalendar();
            lbNickname.Text = userName;
        }

        private void ShowCalendar()
        {
            calBar.Visible = true;
            equipBar.Visible = false;
            if (child != null)
                child.Close();
            this.Controls.Remove(child);

            child = new CalendarForm(mode);
            child.MdiParent = this; 
            child.Show();
            (child as CalendarForm).parent = this;
            child.AutoScroll = false;
            child.Location = new Point(25, 0);
        }
        private void ShowEquip()
        {
            calBar.Visible = false;
            equipBar.Visible = true;
            if (child != null)
                child.Close();
            this.Controls.Remove(child);

            child = new EquipmentForm(mode);
            child.MdiParent = this;
            child.Show();
            (child as EquipmentForm).parent = this;
            child.AutoScroll = false;
            child.Location = new Point(25, 0);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (child != null)
                child.Close();
        }

        private void equipBtn_Click(object sender, EventArgs e)
        {
            ShowEquip();
        }

        private void calBtn_Click(object sender, EventArgs e)
        {
            ShowCalendar();
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void lbNickname_Click(object sender, EventArgs e)
        {

        }

        private void saveFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
