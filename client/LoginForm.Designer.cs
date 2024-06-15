namespace client
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.LoginUIidtxtBox = new System.Windows.Forms.TextBox();
            this.LoginUIidLabel = new System.Windows.Forms.Label();
            this.LoginUIpasswordLabel = new System.Windows.Forms.Label();
            this.LoginUIpwtxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.guna2Button1 = new Guna.UI2.WinForms.Guna2Button();
            this.회원가입 = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // LoginUIidtxtBox
            // 
            this.LoginUIidtxtBox.Location = new System.Drawing.Point(386, 123);
            this.LoginUIidtxtBox.Name = "LoginUIidtxtBox";
            this.LoginUIidtxtBox.Size = new System.Drawing.Size(167, 21);
            this.LoginUIidtxtBox.TabIndex = 3;
            // 
            // LoginUIidLabel
            // 
            this.LoginUIidLabel.AutoSize = true;
            this.LoginUIidLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.LoginUIidLabel.ForeColor = System.Drawing.Color.White;
            this.LoginUIidLabel.Location = new System.Drawing.Point(291, 122);
            this.LoginUIidLabel.Name = "LoginUIidLabel";
            this.LoginUIidLabel.Size = new System.Drawing.Size(50, 25);
            this.LoginUIidLabel.TabIndex = 4;
            this.LoginUIidLabel.Text = "학번";
            // 
            // LoginUIpasswordLabel
            // 
            this.LoginUIpasswordLabel.AutoSize = true;
            this.LoginUIpasswordLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.LoginUIpasswordLabel.ForeColor = System.Drawing.Color.White;
            this.LoginUIpasswordLabel.Location = new System.Drawing.Point(275, 176);
            this.LoginUIpasswordLabel.Name = "LoginUIpasswordLabel";
            this.LoginUIpasswordLabel.Size = new System.Drawing.Size(88, 25);
            this.LoginUIpasswordLabel.TabIndex = 5;
            this.LoginUIpasswordLabel.Text = "비밀번호";
            // 
            // LoginUIpwtxtBox
            // 
            this.LoginUIpwtxtBox.Location = new System.Drawing.Point(386, 176);
            this.LoginUIpwtxtBox.Name = "LoginUIpwtxtBox";
            this.LoginUIpwtxtBox.PasswordChar = '*';
            this.LoginUIpwtxtBox.Size = new System.Drawing.Size(167, 21);
            this.LoginUIpwtxtBox.TabIndex = 6;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(28, 29);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(196, 294);
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // guna2Button1
            // 
            this.guna2Button1.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.guna2Button1.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.guna2Button1.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.guna2Button1.FillColor = System.Drawing.Color.White;
            this.guna2Button1.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold);
            this.guna2Button1.ForeColor = System.Drawing.Color.Black;
            this.guna2Button1.Location = new System.Drawing.Point(589, 122);
            this.guna2Button1.Name = "guna2Button1";
            this.guna2Button1.Size = new System.Drawing.Size(90, 75);
            this.guna2Button1.TabIndex = 10;
            this.guna2Button1.Text = "로그인";
            this.guna2Button1.Click += new System.EventHandler(this.LoginUIsigninBtn_Click);
            // 
            // 회원가입
            // 
            this.회원가입.BackColor = System.Drawing.Color.White;
            this.회원가입.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.회원가입.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.회원가입.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.회원가입.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.회원가입.FillColor = System.Drawing.Color.White;
            this.회원가입.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.회원가입.ForeColor = System.Drawing.Color.Black;
            this.회원가입.Location = new System.Drawing.Point(386, 225);
            this.회원가입.Name = "회원가입";
            this.회원가입.Size = new System.Drawing.Size(167, 26);
            this.회원가입.TabIndex = 11;
            this.회원가입.Text = "회원가입";
            this.회원가입.Click += new System.EventHandler(this.LoginUIsignupBtn_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(713, 365);
            this.Controls.Add(this.회원가입);
            this.Controls.Add(this.guna2Button1);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.LoginUIpwtxtBox);
            this.Controls.Add(this.LoginUIpasswordLabel);
            this.Controls.Add(this.LoginUIidLabel);
            this.Controls.Add(this.LoginUIidtxtBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox LoginUIidtxtBox;
        private System.Windows.Forms.Label LoginUIidLabel;
        private System.Windows.Forms.Label LoginUIpasswordLabel;
        private System.Windows.Forms.TextBox LoginUIpwtxtBox;
        private System.Windows.Forms.PictureBox pictureBox2;
        private Guna.UI2.WinForms.Guna2Button guna2Button1;
        private Guna.UI2.WinForms.Guna2Button 회원가입;
    }
}

