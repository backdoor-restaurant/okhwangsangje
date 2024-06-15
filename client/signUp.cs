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
    public partial class signUp : Form
    {
        private static readonly LoginInfo admin = new LoginInfo()
        {
            studentId = "0",
            password = "secret1234"
        };

        public signUp()
        {
            InitializeComponent();
        }

        private bool isValidData()
        {

            return !string.IsNullOrWhiteSpace(IDTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(PWTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(nameTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(phoneTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(departmentTxtBox.Text) &&
                   PWTxtBox.Text == PWTxtBoxRe.Text;
        }

        private void IDTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void nameTxtBox_KeyPress(object sender, KeyPressEventArgs e)
        {

        }


        private void signUpBtn_Click(object sender, EventArgs e)
        {
            if (!isValidData())
            {
                MessageBox.Show("입력 값이 잘못되었습니다", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
                return;
            }
            if(!send(IDTxtBox.Text, PWTxtBox.Text, nameTxtBox.Text, phoneTxtBox.Text, departmentTxtBox.Text))
            {
                MessageBox.Show("이미 가입되어 있는 회원입니다", "sign Up Error", MessageBoxButtons.OK);
                this.Close();
                return;
            }
            send(IDTxtBox.Text, PWTxtBox.Text, nameTxtBox.Text, phoneTxtBox.Text, departmentTxtBox.Text);
            MessageBox.Show("회원가입 성공", "Success", MessageBoxButtons.OK);
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool send(string id, string password, string name, string phone, string department)
        {

            // member Info create;
            var mtable = new MemberVT();
            mtable.signin(admin);

            var userData = new MemberInfo()
            {
                studentId = id,
                name = name,
                department = department,
                phoneNumber = phone
            };

            var m_result = mtable.create(userData);

            if (!m_result)
            {
                return false;
            }

            // ID,PW create
            var vtable = new LoginVT();
            vtable.signin(admin);

            var newUser = new LoginInfo()
            {
                studentId = id,
                password = password
            };

            var c_result = vtable.create(newUser);

            if (!c_result)
            {
                return false;
            }
            

            return true;
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
