namespace client
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.calBtn = new Guna.UI2.WinForms.Guna2Button();
            this.calBar = new Guna.UI2.WinForms.Guna2Panel();
            this.equipBar = new Guna.UI2.WinForms.Guna2Panel();
            this.equipBtn = new Guna.UI2.WinForms.Guna2Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lbNickname = new System.Windows.Forms.Label();
            this.exitBtn = new Guna.UI2.WinForms.Guna2Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1184, 76);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
            // 
            // calBtn
            // 
            this.calBtn.BackColor = System.Drawing.Color.Transparent;
            this.calBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.calBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.calBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.calBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.calBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.calBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calBtn.ForeColor = System.Drawing.Color.White;
            this.calBtn.Image = ((System.Drawing.Image)(resources.GetObject("calBtn.Image")));
            this.calBtn.ImageOffset = new System.Drawing.Point(0, 2);
            this.calBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.calBtn.Location = new System.Drawing.Point(17, 17);
            this.calBtn.Name = "calBtn";
            this.calBtn.Size = new System.Drawing.Size(203, 34);
            this.calBtn.TabIndex = 5;
            this.calBtn.Text = "Calendar";
            this.calBtn.Click += new System.EventHandler(this.calBtn_Click);
            // 
            // calBar
            // 
            this.calBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.calBar.Location = new System.Drawing.Point(17, 57);
            this.calBar.Name = "calBar";
            this.calBar.Size = new System.Drawing.Size(203, 5);
            this.calBar.TabIndex = 6;
            // 
            // equipBar
            // 
            this.equipBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(232)))), ((int)(((byte)(166)))));
            this.equipBar.Location = new System.Drawing.Point(238, 57);
            this.equipBar.Name = "equipBar";
            this.equipBar.Size = new System.Drawing.Size(203, 5);
            this.equipBar.TabIndex = 10;
            // 
            // equipBtn
            // 
            this.equipBtn.BackColor = System.Drawing.Color.Transparent;
            this.equipBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.equipBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.equipBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.equipBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.equipBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.equipBtn.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.equipBtn.ForeColor = System.Drawing.Color.White;
            this.equipBtn.Image = ((System.Drawing.Image)(resources.GetObject("equipBtn.Image")));
            this.equipBtn.ImageOffset = new System.Drawing.Point(0, 2);
            this.equipBtn.ImageSize = new System.Drawing.Size(30, 30);
            this.equipBtn.Location = new System.Drawing.Point(239, 17);
            this.equipBtn.Name = "equipBtn";
            this.equipBtn.Size = new System.Drawing.Size(203, 34);
            this.equipBtn.TabIndex = 9;
            this.equipBtn.Text = "Equipment";
            this.equipBtn.Click += new System.EventHandler(this.equipBtn_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(953, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // lbNickname
            // 
            this.lbNickname.AutoSize = true;
            this.lbNickname.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.lbNickname.Font = new System.Drawing.Font("나눔고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbNickname.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lbNickname.Location = new System.Drawing.Point(1011, 28);
            this.lbNickname.Name = "lbNickname";
            this.lbNickname.Size = new System.Drawing.Size(69, 19);
            this.lbNickname.TabIndex = 17;
            this.lbNickname.Text = "김석희님";
            this.lbNickname.Click += new System.EventHandler(this.lbNickname_Click);
            // 
            // exitBtn
            // 
            this.exitBtn.DisabledState.BorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.CustomBorderColor = System.Drawing.Color.DarkGray;
            this.exitBtn.DisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(169)))), ((int)(((byte)(169)))), ((int)(((byte)(169)))));
            this.exitBtn.DisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(141)))), ((int)(((byte)(141)))), ((int)(((byte)(141)))));
            this.exitBtn.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.exitBtn.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.exitBtn.ForeColor = System.Drawing.Color.White;
            this.exitBtn.Image = ((System.Drawing.Image)(resources.GetObject("exitBtn.Image")));
            this.exitBtn.ImageSize = new System.Drawing.Size(45, 45);
            this.exitBtn.Location = new System.Drawing.Point(1109, 17);
            this.exitBtn.Name = "exitBtn";
            this.exitBtn.Size = new System.Drawing.Size(50, 45);
            this.exitBtn.TabIndex = 19;
            this.exitBtn.Click += new System.EventHandler(this.exitBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1184, 877);
            this.Controls.Add(this.exitBtn);
            this.Controls.Add(this.lbNickname);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.equipBar);
            this.Controls.Add(this.equipBtn);
            this.Controls.Add(this.calBar);
            this.Controls.Add(this.calBtn);
            this.Controls.Add(this.splitter1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private Guna.UI2.WinForms.Guna2Button calBtn;
        private Guna.UI2.WinForms.Guna2Panel calBar;
        private Guna.UI2.WinForms.Guna2Panel equipBar;
        private Guna.UI2.WinForms.Guna2Button equipBtn;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lbNickname;
        private Guna.UI2.WinForms.Guna2Button exitBtn;
    }
}