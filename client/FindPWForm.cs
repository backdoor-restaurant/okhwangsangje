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
    public partial class FindPW : Form
    {
        private static readonly LoginInfo admin = new LoginInfo()
        {
            studentId = "0",
            password = "secret1234"
        };
        public FindPW()
        {
            InitializeComponent();
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool isValidData()
        {

            return !string.IsNullOrWhiteSpace(IDTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(nameTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(phoneTxtBox.Text);
        }

        private bool isUser(string id, string name, string phone) 
        {
            var vtable = new MemberVT();
            vtable.signin(admin);

            var tryUser = new MemberInfo()
            {
                studentId = id,
                name = name,
                phoneNumber = phone
            };
            var Key = tryUser.getKey();
            var find_user = vtable.read(Key, out MemberInfo member);
            if (!find_user) return false;
            return (member.studentId == id) ||
                    (member.name == name) ||
                   (member.phoneNumber == phone);
        }
        private void signUpBtn_Click(object sender, EventArgs e)
        {
            if (!isValidData())
            {
                MessageBox.Show("값을 입력해 주세요.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!isUser(IDTxtBox.Text,nameTxtBox.Text,phoneTxtBox.Text))
            {
                MessageBox.Show("존재하지 않는 유저입니다.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            fixPW fixPWForm = new fixPW(IDTxtBox.Text);
            fixPWForm.ShowDialog();
        }
    }
}
