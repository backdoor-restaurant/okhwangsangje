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
            this.btnTmp = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.LoginUIsigninBtn = new System.Windows.Forms.Button();
            this.LoginUIidtxtBox = new System.Windows.Forms.TextBox();
            this.LoginUIidLabel = new System.Windows.Forms.Label();
            this.LoginUIpasswordLabel = new System.Windows.Forms.Label();
            this.LoginUIpwtxtBox = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LoginUIsignupBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTmp
            // 
            this.btnTmp.Location = new System.Drawing.Point(17, 18);
            this.btnTmp.Margin = new System.Windows.Forms.Padding(4);
            this.btnTmp.Name = "btnTmp";
            this.btnTmp.Size = new System.Drawing.Size(290, 39);
            this.btnTmp.TabIndex = 0;
            this.btnTmp.Text = "임시 메인 창 가는 버튼(유저)";
            this.btnTmp.UseVisualStyleBackColor = true;
            this.btnTmp.Click += new System.EventHandler(this.btnTmp_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(17, 66);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(290, 39);
            this.button1.TabIndex = 1;
            this.button1.Text = "임시 메인 창 가는 버튼(어드민)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // LoginUIsigninBtn
            // 
            this.LoginUIsigninBtn.Location = new System.Drawing.Point(682, 262);
            this.LoginUIsigninBtn.Name = "LoginUIsigninBtn";
            this.LoginUIsigninBtn.Size = new System.Drawing.Size(75, 75);
            this.LoginUIsigninBtn.TabIndex = 2;
            this.LoginUIsigninBtn.Text = "Login";
            this.LoginUIsigninBtn.UseVisualStyleBackColor = true;
            this.LoginUIsigninBtn.Click += new System.EventHandler(this.LoginUIsigninBtn_Click);
            // 
            // LoginUIidtxtBox
            // 
            this.LoginUIidtxtBox.Location = new System.Drawing.Point(499, 257);
            this.LoginUIidtxtBox.Name = "LoginUIidtxtBox";
            this.LoginUIidtxtBox.Size = new System.Drawing.Size(167, 21);
            this.LoginUIidtxtBox.TabIndex = 3;
            // 
            // LoginUIidLabel
            // 
            this.LoginUIidLabel.AutoSize = true;
            this.LoginUIidLabel.Location = new System.Drawing.Point(427, 262);
            this.LoginUIidLabel.Name = "LoginUIidLabel";
            this.LoginUIidLabel.Size = new System.Drawing.Size(29, 12);
            this.LoginUIidLabel.TabIndex = 4;
            this.LoginUIidLabel.Text = "학번";
            // 
            // LoginUIpasswordLabel
            // 
            this.LoginUIpasswordLabel.AutoSize = true;
            this.LoginUIpasswordLabel.Location = new System.Drawing.Point(413, 312);
            this.LoginUIpasswordLabel.Name = "LoginUIpasswordLabel";
            this.LoginUIpasswordLabel.Size = new System.Drawing.Size(53, 12);
            this.LoginUIpasswordLabel.TabIndex = 5;
            this.LoginUIpasswordLabel.Text = "비밀번호";
            // 
            // LoginUIpwtxtBox
            // 
            this.LoginUIpwtxtBox.Location = new System.Drawing.Point(499, 309);
            this.LoginUIpwtxtBox.Name = "LoginUIpwtxtBox";
            this.LoginUIpwtxtBox.Size = new System.Drawing.Size(167, 21);
            this.LoginUIpwtxtBox.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(430, 172);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(327, 64);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LoginUIsignupBtn
            // 
            this.LoginUIsignupBtn.Location = new System.Drawing.Point(511, 367);
            this.LoginUIsignupBtn.Name = "LoginUIsignupBtn";
            this.LoginUIsignupBtn.Size = new System.Drawing.Size(155, 23);
            this.LoginUIsignupBtn.TabIndex = 8;
            this.LoginUIsignupBtn.Text = "회원가입";
            this.LoginUIsignupBtn.UseVisualStyleBackColor = true;
            this.LoginUIsignupBtn.Click += new System.EventHandler(this.LoginUIsignupBtn_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 175);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 15);
            this.button2.TabIndex = 2;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1143, 675);
            this.Controls.Add(this.LoginUIsignupBtn);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LoginUIpwtxtBox);
            this.Controls.Add(this.LoginUIpasswordLabel);
            this.Controls.Add(this.LoginUIidLabel);
            this.Controls.Add(this.LoginUIidtxtBox);
            this.Controls.Add(this.LoginUIsigninBtn);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTmp);
            this.Controls.Add(this.button2);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "LoginForm";
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTmp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button LoginUIsigninBtn;
        private System.Windows.Forms.TextBox LoginUIidtxtBox;
        private System.Windows.Forms.Label LoginUIidLabel;
        private System.Windows.Forms.Label LoginUIpasswordLabel;
        private System.Windows.Forms.TextBox LoginUIpwtxtBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button LoginUIsignupBtn;
        private System.Windows.Forms.Button button2;
    }
}

