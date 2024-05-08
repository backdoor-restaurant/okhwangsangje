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
            this.button2 = new System.Windows.Forms.Button();
            this.btnMain = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTmp
            // 
            this.btnTmp.Location = new System.Drawing.Point(12, 12);
            this.btnTmp.Name = "btnTmp";
            this.btnTmp.Size = new System.Drawing.Size(203, 26);
            this.btnTmp.TabIndex = 0;
            this.btnTmp.Text = "임시 메인 창 가는 버튼(유저)";
            this.btnTmp.UseVisualStyleBackColor = true;
            this.btnTmp.Click += new System.EventHandler(this.btnTmp_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(203, 26);
            this.button1.TabIndex = 1;
            this.button1.Text = "임시 메인 창 가는 버튼(어드민)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(470, 175);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(52, 15);
            this.button2.TabIndex = 2;
            this.button2.Text = "Login";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btnMain
            // 
            this.btnMain.Location = new System.Drawing.Point(12, 76);
            this.btnMain.Name = "btnMain";
            this.btnMain.Size = new System.Drawing.Size(203, 26);
            this.btnMain.TabIndex = 3;
            this.btnMain.Text = "메인 창 가기 버튼";
            this.btnMain.UseVisualStyleBackColor = true;
            this.btnMain.Click += new System.EventHandler(this.btnMain_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnMain);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnTmp);
            this.Name = "LoginForm";
            this.Text = "Login";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTmp;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnMain;
    }
}

