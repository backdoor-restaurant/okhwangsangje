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
    public partial class signUp : Form
    {
        public signUp()
        {
            InitializeComponent();
        }

        private bool isValidData()
        {
            return !string.IsNullOrWhiteSpace(IDTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(PWTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(nameTxtBox.Text) &&
                   !string.IsNullOrWhiteSpace(phoneTxtBox.Text);
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
            if (isValidData())
            {
                send(IDTxtBox.Text, PWTxtBox.Text, nameTxtBox.Text, phoneTxtBox.Text);
                MessageBox.Show("회원가입 성공", "Success", MessageBoxButtons.OK);
            }
            else
            {
                MessageBox.Show("입력 값이 잘못되었습니다", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void send(string id, string password, string name, string phone)
        {
            MessageBox.Show("임시", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
