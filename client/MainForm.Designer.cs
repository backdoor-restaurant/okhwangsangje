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
            this.CalendarBtn = new System.Windows.Forms.Button();
            this.EquipBtn = new System.Windows.Forms.Button();
            this.EquipStatusBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // splitter1
            // 
            this.splitter1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(1184, 86);
            this.splitter1.TabIndex = 1;
            this.splitter1.TabStop = false;
            // 
            // CalendarBtn
            // 
            this.CalendarBtn.Location = new System.Drawing.Point(0, 0);
            this.CalendarBtn.Name = "CalendarBtn";
            this.CalendarBtn.Size = new System.Drawing.Size(396, 86);
            this.CalendarBtn.TabIndex = 2;
            this.CalendarBtn.Text = "Calendar";
            this.CalendarBtn.UseVisualStyleBackColor = true;
            this.CalendarBtn.Click += new System.EventHandler(this.CalendarBtn_Click);
            // 
            // EquipBtn
            // 
            this.EquipBtn.Location = new System.Drawing.Point(390, 0);
            this.EquipBtn.Name = "EquipBtn";
            this.EquipBtn.Size = new System.Drawing.Size(400, 86);
            this.EquipBtn.TabIndex = 3;
            this.EquipBtn.Text = "장비 목록";
            this.EquipBtn.UseVisualStyleBackColor = true;
            this.EquipBtn.Click += new System.EventHandler(this.EquipBtn_Click);
            // 
            // EquipStatusBtn
            // 
            this.EquipStatusBtn.Location = new System.Drawing.Point(788, 0);
            this.EquipStatusBtn.Name = "EquipStatusBtn";
            this.EquipStatusBtn.Size = new System.Drawing.Size(396, 86);
            this.EquipStatusBtn.TabIndex = 5;
            this.EquipStatusBtn.Text = "장비 상태";
            this.EquipStatusBtn.UseVisualStyleBackColor = true;
            this.EquipStatusBtn.Click += new System.EventHandler(this.EquipStatusBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1184, 798);
            this.Controls.Add(this.EquipStatusBtn);
            this.Controls.Add(this.EquipBtn);
            this.Controls.Add(this.CalendarBtn);
            this.Controls.Add(this.splitter1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.Button CalendarBtn;
        private System.Windows.Forms.Button EquipBtn;
        private System.Windows.Forms.Button EquipStatusBtn;
    }
}