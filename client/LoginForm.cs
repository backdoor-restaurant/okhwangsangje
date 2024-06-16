using commons.Table;
using commons.VirtualDB;
using System.Threading;
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
        private static readonly LoginInfo admin = new LoginInfo()
        {
            studentId = "0",
            password = "secret1234"
        };

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
            // false가 아니라 -1을 돌려줘서 입력안했다고 해야하나.
            return !(id == "" || pw == "");
        }
        private bool signIn(string id, string pw)
        {
            // 회원가입부터 완성해야 한다. // 회원가입에 있는 data를 찾는거다.  
            // 만약 ID가 있다면, 안에서 그리고 PW가 같다면 true;

            var vtable = new LoginVT();
            vtable.signin(admin);

            var tryUser = new LoginInfo() { studentId = id, password = pw };
            var key = tryUser.getKey();
            var login_result = vtable.read(key, out LoginInfo login);
            if (!login_result)
            {
                // table에 없음
                return false;
            }

            return login.password == pw;
        }
        private string findUserName(string id)
        {
            var vtable = new MemberVT();
            vtable.signin(admin);

            var key = (MemberInfoKey)id;
            var find_result = vtable.read(key, out MemberInfo member);
            if(!find_result) { return ""; }
            return member.name;
        }
        private void LoginUIsigninBtn_Click(object sender, EventArgs e)
        {
            string userId = this.LoginUIidtxtBox.Text;
            string userPw = this.LoginUIpwtxtBox.Text;
            
            if (!isValidDataUser(userId, userPw))
            {
                MessageBox.Show("ID, PASSWORD를 전부 입력해주세요.", "Input Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!signIn(userId, userPw))
            {
                MessageBox.Show("ID, PASSWORD가 일치하지 않습니다.", "ID/PW Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            string userName = findUserName(userId); 
            if(userName == "")
            {
                MessageBox.Show("중간에 데이터가 바뀌는 등 말도 안되는 일이 일어났습니다.", "ID/PW Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            // 사용자 이름 == userName
            MainForm newForm = new MainForm(userName);
            // 현재 폼 닫기
            this.Hide();
            // 새로운 폼 표시
            newForm.ShowDialog();
            // 새로운 폼이 닫히면 현재 폼 다시 보이기
            this.Show();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            // 사진을 넣을 것 사진은 구했다.
        }

        private void LoginUIsignupBtn_Click(object sender, EventArgs e)
        {
            signUp signupForm = new signUp();
            signupForm.ShowDialog();

        }

        private void findPWBtn_Click(object sender, EventArgs e)
        {
            FindPW findPWform = new FindPW();
            findPWform.ShowDialog();
        }
    }
}
