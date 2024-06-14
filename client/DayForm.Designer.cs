namespace client
{
    partial class DayForm
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbDay = new System.Windows.Forms.Label();
            this.tbDayMemo = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lbDay
            // 
            this.lbDay.AutoSize = true;
            this.lbDay.Dock = System.Windows.Forms.DockStyle.Top;
            this.lbDay.Font = new System.Drawing.Font("나눔고딕", 8.999999F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lbDay.Location = new System.Drawing.Point(0, 0);
            this.lbDay.Margin = new System.Windows.Forms.Padding(3, 0, 10, 0);
            this.lbDay.Name = "lbDay";
            this.lbDay.Size = new System.Drawing.Size(15, 14);
            this.lbDay.TabIndex = 0;
            this.lbDay.Text = "0";
            this.lbDay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbDay.Click += new System.EventHandler(this.lbDay_Click);
            // 
            // tbDayMemo
            // 
            this.tbDayMemo.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.tbDayMemo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.tbDayMemo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbDayMemo.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.tbDayMemo.Location = new System.Drawing.Point(0, 14);
            this.tbDayMemo.Multiline = true;
            this.tbDayMemo.Name = "tbDayMemo";
            this.tbDayMemo.ReadOnly = true;
            this.tbDayMemo.Size = new System.Drawing.Size(152, 89);
            this.tbDayMemo.TabIndex = 1;
            this.tbDayMemo.WordWrap = false;
            this.tbDayMemo.TextChanged += new System.EventHandler(this.tbDayMemo_TextChanged);
            this.tbDayMemo.DoubleClick += new System.EventHandler(this.tbDayMemo_DoubleClick);
            // 
            // DayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.tbDayMemo);
            this.Controls.Add(this.lbDay);
            this.Name = "DayForm";
            this.Size = new System.Drawing.Size(152, 103);
            this.Load += new System.EventHandler(this.DayForm_Load);
            this.Click += new System.EventHandler(this.DayForm_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbDay;
        private System.Windows.Forms.TextBox tbDayMemo;
    }
}
