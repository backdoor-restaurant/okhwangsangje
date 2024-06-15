namespace client
{
    partial class signUp
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.IDTxtBox = new System.Windows.Forms.TextBox();
            this.PWTxtBox = new System.Windows.Forms.TextBox();
            this.nameTxtBox = new System.Windows.Forms.TextBox();
            this.phoneTxtBox = new System.Windows.Forms.TextBox();
            this.signUpBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.PWTxtBoxRe = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.departmentTxtBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(76, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "학번";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(61, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Location = new System.Drawing.Point(76, 151);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "이름";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label4.Location = new System.Drawing.Point(61, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "전화번호";
            // 
            // IDTxtBox
            // 
            this.IDTxtBox.Location = new System.Drawing.Point(168, 39);
            this.IDTxtBox.Name = "IDTxtBox";
            this.IDTxtBox.Size = new System.Drawing.Size(134, 21);
            this.IDTxtBox.TabIndex = 4;
            this.IDTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDTxtBox_KeyPress);
            // 
            // PWTxtBox
            // 
            this.PWTxtBox.Location = new System.Drawing.Point(168, 77);
            this.PWTxtBox.Name = "PWTxtBox";
            this.PWTxtBox.PasswordChar = '*';
            this.PWTxtBox.Size = new System.Drawing.Size(134, 21);
            this.PWTxtBox.TabIndex = 5;
            // 
            // nameTxtBox
            // 
            this.nameTxtBox.Location = new System.Drawing.Point(168, 148);
            this.nameTxtBox.Name = "nameTxtBox";
            this.nameTxtBox.Size = new System.Drawing.Size(134, 21);
            this.nameTxtBox.TabIndex = 6;
            // 
            // phoneTxtBox
            // 
            this.phoneTxtBox.Location = new System.Drawing.Point(168, 183);
            this.phoneTxtBox.Name = "phoneTxtBox";
            this.phoneTxtBox.Size = new System.Drawing.Size(134, 21);
            this.phoneTxtBox.TabIndex = 7;
            this.phoneTxtBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.IDTxtBox_KeyPress);
            // 
            // signUpBtn
            // 
            this.signUpBtn.Location = new System.Drawing.Point(97, 275);
            this.signUpBtn.Name = "signUpBtn";
            this.signUpBtn.Size = new System.Drawing.Size(75, 23);
            this.signUpBtn.TabIndex = 8;
            this.signUpBtn.Text = "회원가입";
            this.signUpBtn.UseVisualStyleBackColor = true;
            this.signUpBtn.Click += new System.EventHandler(this.signUpBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(227, 275);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 9;
            this.closeBtn.Text = "취소";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label5.Location = new System.Drawing.Point(43, 114);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 12);
            this.label5.TabIndex = 10;
            this.label5.Text = "Password 재확인";
            // 
            // PWTxtBoxRe
            // 
            this.PWTxtBoxRe.Location = new System.Drawing.Point(168, 111);
            this.PWTxtBoxRe.Name = "PWTxtBoxRe";
            this.PWTxtBoxRe.PasswordChar = '*';
            this.PWTxtBoxRe.Size = new System.Drawing.Size(134, 21);
            this.PWTxtBoxRe.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label6.Location = new System.Drawing.Point(76, 219);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 12);
            this.label6.TabIndex = 12;
            this.label6.Text = "학과";
            this.label6.Click += new System.EventHandler(this.label6_Click);
            // 
            // departmentTxtBox
            // 
            this.departmentTxtBox.Location = new System.Drawing.Point(168, 216);
            this.departmentTxtBox.Name = "departmentTxtBox";
            this.departmentTxtBox.Size = new System.Drawing.Size(134, 21);
            this.departmentTxtBox.TabIndex = 13;
            // 
            // signUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 322);
            this.Controls.Add(this.departmentTxtBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.PWTxtBoxRe);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.signUpBtn);
            this.Controls.Add(this.phoneTxtBox);
            this.Controls.Add(this.nameTxtBox);
            this.Controls.Add(this.PWTxtBox);
            this.Controls.Add(this.IDTxtBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "signUp";
            this.Text = "회원가입";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox IDTxtBox;
        private System.Windows.Forms.TextBox PWTxtBox;
        private System.Windows.Forms.TextBox nameTxtBox;
        private System.Windows.Forms.TextBox phoneTxtBox;
        private System.Windows.Forms.Button signUpBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox PWTxtBoxRe;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox departmentTxtBox;
    }
}