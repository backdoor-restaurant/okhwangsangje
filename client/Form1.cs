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
    public partial class LoginForm : Form
    {
        public enum Mode
        {
            User = 0,
            Admin = 1
        }
        public LoginForm()
        {
            InitializeComponent();
        }

        private void btnTmp_Click(object sender, EventArgs e)
        {
            CalendarForm newForm = new CalendarForm(Mode.User);

            // 현재 폼 닫기
            this.Hide();

            // 새로운 폼 표시
            newForm.ShowDialog();

            // 새로운 폼이 닫히면 현재 폼 다시 보이기
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CalendarForm newForm = new CalendarForm(Mode.Admin);

            // 현재 폼 닫기
            this.Hide();

            // 새로운 폼 표시
            newForm.ShowDialog();

            // 새로운 폼이 닫히면 현재 폼 다시 보이기
            this.Show();
        }

        private void btnMain_Click(object sender, EventArgs e)
        {
        }

        private bool isValidDataUser(string id, string pw)
        {
            if(id == ""||pw == "")
            {
                return false;
            }
            if (true)
            {
                // 데이터베이스
                return true;
            }
            return false;
        }
        private void LoginUIsigninBtn_Click(object sender, EventArgs e)
        {
            string userId = this.LoginUIidtxtBox.Text;
            string userPw = this.LoginUIpwtxtBox.Text;
            
            // 함수명에 대해 기준을 세우는 회의가 필요할 듯
            if (isValidDataUser(userId, userPw))
            {
                MainForm newForm = new MainForm();
                // 현재 폼 닫기
                this.Hide();
                // 새로운 폼 표시
                newForm.ShowDialog();
                // 새로운 폼이 닫히면 현재 폼 다시 보이기
                this.Show();
                MessageBox.Show("test Login sucesss");
            }
            else
            {
                MessageBox.Show("test Login fail");
            }

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // 사진을 넣을 것
        }

        private void LoginUIsignupBtn_Click(object sender, EventArgs e)
        {
            signUp signupForm = new signUp();
            signupForm.ShowDialog();

        }
    }
}
