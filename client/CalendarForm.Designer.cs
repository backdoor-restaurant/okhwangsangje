namespace client
{
    partial class CalendarForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CalendarForm));
            this.Calendar = new System.Windows.Forms.FlowLayoutPanel();
            this.lbYMD = new System.Windows.Forms.Label();
            this.lbSunday = new System.Windows.Forms.Label();
            this.lbMonday = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.preBtn = new Guna.UI2.WinForms.Guna2Button();
            this.nxtBtn = new Guna.UI2.WinForms.Guna2Button();
            this.SuspendLayout();
            // 
            // Calendar
            // 
            this.Calendar.Location = new System.Drawing.Point(12, 109);
            this.Calendar.Name = "Calendar";
            this.Calendar.Size = new System.Drawing.Size(1120, 657);
            this.Calendar.TabIndex = 9;
            // 
            // lbYMD
            // 
            this.lbYMD.AutoSize = true;
            this.lbYMD.Font = new System.Drawing.Font("나눔고딕", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbYMD.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbYMD.Location = new System.Drawing.Point(487, 26);
            this.lbYMD.Name = "lbYMD";
            this.lbYMD.Size = new System.Drawing.Size(187, 36);
            this.lbYMD.TabIndex = 12;
            this.lbYMD.Text = "2024년 4월";
            // 
            // lbSunday
            // 
            this.lbSunday.AutoSize = true;
            this.lbSunday.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbSunday.ForeColor = System.Drawing.Color.OrangeRed;
            this.lbSunday.Location = new System.Drawing.Point(68, 81);
            this.lbSunday.Name = "lbSunday";
            this.lbSunday.Size = new System.Drawing.Size(31, 25);
            this.lbSunday.TabIndex = 13;
            this.lbSunday.Text = "일";
            // 
            // lbMonday
            // 
            this.lbMonday.AutoSize = true;
            this.lbMonday.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbMonday.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbMonday.Location = new System.Drawing.Point(228, 81);
            this.lbMonday.Name = "lbMonday";
            this.lbMonday.Size = new System.Drawing.Size(31, 25);
            this.lbMonday.TabIndex = 14;
            this.lbMonday.Text = "월";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label2.Location = new System.Drawing.Point(548, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "수";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label3.Location = new System.Drawing.Point(388, 81);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 25);
            this.label3.TabIndex = 15;
            this.label3.Text = "화";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label4.Location = new System.Drawing.Point(868, 81);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(31, 25);
            this.label4.TabIndex = 18;
            this.label4.Text = "금";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.label5.Location = new System.Drawing.Point(708, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(31, 25);
            this.label5.TabIndex = 17;
            this.label5.Text = "목";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Location = new System.Drawing.Point(1028, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(31, 25);
            this.label6.TabIndex = 19;
            this.label6.Text = "토";
            // 
            // preBtn
            // 
            this.preBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.preBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.preBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.preBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.preBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.preBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.preBtn.ForeColor = System.Drawing.Color.White;
            this.preBtn.Image = ((System.Drawing.Image)(resources.GetObject("preBtn.Image")));
            this.preBtn.Location = new System.Drawing.Point(433, 25);
            this.preBtn.Name = "preBtn";
            this.preBtn.Size = new System.Drawing.Size(48, 45);
            this.preBtn.TabIndex = 20;
            this.preBtn.Click += new System.EventHandler(this.preBtn_Click);
            // 
            // nxtBtn
            // 
            this.nxtBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.nxtBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.nxtBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.nxtBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.nxtBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.nxtBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.nxtBtn.ForeColor = System.Drawing.Color.White;
            this.nxtBtn.Image = ((System.Drawing.Image)(resources.GetObject("nxtBtn.Image")));
            this.nxtBtn.Location = new System.Drawing.Point(680, 25);
            this.nxtBtn.Name = "nxtBtn";
            this.nxtBtn.Size = new System.Drawing.Size(48, 45);
            this.nxtBtn.TabIndex = 21;
            this.nxtBtn.Click += new System.EventHandler(this.nxtBtn_Click);
            // 
            // CalendarForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(43)))), ((int)(((byte)(60)))));
            this.ClientSize = new System.Drawing.Size(1145, 778);
            this.Controls.Add(this.nxtBtn);
            this.Controls.Add(this.preBtn);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbMonday);
            this.Controls.Add(this.lbSunday);
            this.Controls.Add(this.lbYMD);
            this.Controls.Add(this.Calendar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CalendarForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CalendarForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Click += new System.EventHandler(this.MainForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel Calendar;
        private System.Windows.Forms.Label lbYMD;
        private System.Windows.Forms.Label lbSunday;
        private System.Windows.Forms.Label lbMonday;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private Guna.UI2.WinForms.Guna2Button preBtn;
        private Guna.UI2.WinForms.Guna2Button nxtBtn;
    }
}