namespace client
{
    partial class DayDetailForm
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
            this.lbDetailYMD = new System.Windows.Forms.Label();
            this.Details = new System.Windows.Forms.FlowLayoutPanel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbDetailYMD
            // 
            this.lbDetailYMD.AutoSize = true;
            this.lbDetailYMD.Font = new System.Drawing.Font("나눔고딕", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDetailYMD.Location = new System.Drawing.Point(15, 9);
            this.lbDetailYMD.Name = "lbDetailYMD";
            this.lbDetailYMD.Size = new System.Drawing.Size(133, 17);
            this.lbDetailYMD.TabIndex = 0;
            this.lbDetailYMD.Text = "2024년 4월 30일";
            // 
            // Details
            // 
            this.Details.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Details.AutoSize = true;
            this.Details.BackColor = System.Drawing.SystemColors.HighlightText;
            this.Details.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.Details.Location = new System.Drawing.Point(6, 37);
            this.Details.Name = "Details";
            this.Details.Size = new System.Drawing.Size(388, 276);
            this.Details.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Font = new System.Drawing.Font("나눔고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnAdd.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnAdd.Location = new System.Drawing.Point(313, 9);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "일정 추가";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // DayDetailForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(76)))), ((int)(((byte)(75)))), ((int)(((byte)(105)))));
            this.ClientSize = new System.Drawing.Size(400, 313);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.Details);
            this.Controls.Add(this.lbDetailYMD);
            this.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DayDetailForm";
            this.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "DayDetailForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DayDetailForm_FormClosing);
            this.Load += new System.EventHandler(this.DayDetailForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDetailYMD;
        private System.Windows.Forms.FlowLayoutPanel Details;
        private System.Windows.Forms.Button btnAdd;
    }
}