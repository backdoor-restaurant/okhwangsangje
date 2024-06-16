namespace client
{
    partial class fixPW
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
            this.PWTxtBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.RePWTxtBox = new System.Windows.Forms.TextBox();
            this.fixBtn = new System.Windows.Forms.Button();
            this.closeBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label1.Location = new System.Drawing.Point(110, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "비밀번호 재설정";
            // 
            // PWTxtBox
            // 
            this.PWTxtBox.Location = new System.Drawing.Point(154, 48);
            this.PWTxtBox.Name = "PWTxtBox";
            this.PWTxtBox.PasswordChar = '*';
            this.PWTxtBox.Size = new System.Drawing.Size(134, 21);
            this.PWTxtBox.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label2.Location = new System.Drawing.Point(40, 102);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(81, 12);
            this.label2.TabIndex = 7;
            this.label2.Text = "비밀번호 확인";
            // 
            // RePWTxtBox
            // 
            this.RePWTxtBox.Location = new System.Drawing.Point(154, 93);
            this.RePWTxtBox.Name = "RePWTxtBox";
            this.RePWTxtBox.PasswordChar = '*';
            this.RePWTxtBox.Size = new System.Drawing.Size(134, 21);
            this.RePWTxtBox.TabIndex = 8;
            // 
            // fixBtn
            // 
            this.fixBtn.Location = new System.Drawing.Point(62, 140);
            this.fixBtn.Name = "fixBtn";
            this.fixBtn.Size = new System.Drawing.Size(70, 23);
            this.fixBtn.TabIndex = 10;
            this.fixBtn.Text = "확인";
            this.fixBtn.UseVisualStyleBackColor = true;
            this.fixBtn.Click += new System.EventHandler(this.fixBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Location = new System.Drawing.Point(189, 140);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Size = new System.Drawing.Size(75, 23);
            this.closeBtn.TabIndex = 11;
            this.closeBtn.Text = "취소";
            this.closeBtn.UseVisualStyleBackColor = true;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.label3.Location = new System.Drawing.Point(40, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 12);
            this.label3.TabIndex = 12;
            this.label3.Text = "비밀번호 입력";
            // 
            // fixPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(341, 202);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.closeBtn);
            this.Controls.Add(this.fixBtn);
            this.Controls.Add(this.RePWTxtBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.PWTxtBox);
            this.Controls.Add(this.label1);
            this.Name = "fixPW";
            this.Text = "비밀번호 재설정";
            this.Load += new System.EventHandler(this.fixPW_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PWTxtBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox RePWTxtBox;
        private System.Windows.Forms.Button fixBtn;
        private System.Windows.Forms.Button closeBtn;
        private System.Windows.Forms.Label label3;
    }
}