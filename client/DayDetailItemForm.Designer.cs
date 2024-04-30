namespace client
{
    partial class DayDetailItemForm
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
            this.txContent = new System.Windows.Forms.TextBox();
            this.tbTitle = new System.Windows.Forms.TextBox();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txContent
            // 
            this.txContent.Location = new System.Drawing.Point(3, 29);
            this.txContent.Multiline = true;
            this.txContent.Name = "txContent";
            this.txContent.Size = new System.Drawing.Size(378, 40);
            this.txContent.TabIndex = 1;
            this.txContent.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txContent_KeyDown);
            // 
            // tbTitle
            // 
            this.tbTitle.BackColor = System.Drawing.SystemColors.Info;
            this.tbTitle.Location = new System.Drawing.Point(3, 2);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(115, 21);
            this.tbTitle.TabIndex = 2;
            // 
            // btnRemove
            // 
            this.btnRemove.Location = new System.Drawing.Point(306, 2);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(75, 23);
            this.btnRemove.TabIndex = 3;
            this.btnRemove.Text = "삭제";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // DayDetailItemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.tbTitle);
            this.Controls.Add(this.txContent);
            this.Name = "DayDetailItemForm";
            this.Padding = new System.Windows.Forms.Padding(10);
            this.Size = new System.Drawing.Size(394, 82);
            this.Load += new System.EventHandler(this.DayDetailItemForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txContent;
        private System.Windows.Forms.TextBox tbTitle;
        private System.Windows.Forms.Button btnRemove;
    }
}
