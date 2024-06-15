using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using commons.VirtualDB;
using commons.Table;
using System.Threading;

namespace client
{
    public partial class fixPW : Form
    {
        private string uID;
        private static readonly LoginInfo admin = new LoginInfo()
        {
            studentId = "0",
            password = "secret1234"
        };
        public fixPW(string ID)
        {
            uID = ID;
            if(uID == null)
            {
                MessageBox.Show("ID를 가져오지 못했습니다..", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            InitializeComponent();
        }

        private void fixPW_Load(object sender, EventArgs e)
        {

        }

        private bool isValidData()
        {

            return !string.IsNullOrWhiteSpace(PWTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(RePWTxtBox.Text) &&
                   !(PWTxtBox.Text!=RePWTxtBox.Text);
        }

        private bool changePW(string pw)
        {
            var vtable = new LoginVT();
            vtable.signin(admin);

            var userData = new LoginInfo()
            {
                studentId = uID,
                password = pw
            };
            var updateUserPW = vtable.update(userData);
            if (!updateUserPW) return false;
            return true;
        }
        private void fixBtn_Click(object sender, EventArgs e)
        {
            if (!isValidData())
            {
                MessageBox.Show("올바른 값을 입력해 주세요.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if(changePW(PWTxtBox.Text))
                MessageBox.Show("비밀번호 재설정 완료", "Success", MessageBoxButtons.OK);
            else
                MessageBox.Show("비밀번호 재설정 실패.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            this.Close();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
