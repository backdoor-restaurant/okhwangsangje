namespace client
{
    partial class EquipmentHistoryForm
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
            this.CheckBtn = new System.Windows.Forms.Button();
            this.historyView = new System.Windows.Forms.ListView();
            this.Rentee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Equipment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pieces = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Reason = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Status = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RentDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ReturnConfirmer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // CheckBtn
            // 
            this.CheckBtn.Location = new System.Drawing.Point(929, 14);
            this.CheckBtn.Name = "CheckBtn";
            this.CheckBtn.Size = new System.Drawing.Size(171, 71);
            this.CheckBtn.TabIndex = 14;
            this.CheckBtn.Text = "관리자 확인";
            this.CheckBtn.UseVisualStyleBackColor = true;
            this.CheckBtn.Click += new System.EventHandler(this.CheckBtn_Click);
            // 
            // historyView
            // 
            this.historyView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rentee,
            this.Equipment,
            this.Pieces,
            this.Reason,
            this.Status,
            this.RentDate,
            this.ReturnDate,
            this.ReturnConfirmer});
            this.historyView.HideSelection = false;
            this.historyView.Location = new System.Drawing.Point(12, 109);
            this.historyView.Name = "historyView";
            this.historyView.Size = new System.Drawing.Size(1120, 568);
            this.historyView.TabIndex = 15;
            this.historyView.UseCompatibleStateImageBehavior = false;
            this.historyView.View = System.Windows.Forms.View.Details;
            // 
            // Rentee
            // 
            this.Rentee.Text = "대여자";
            this.Rentee.Width = 89;
            // 
            // Equipment
            // 
            this.Equipment.Text = "장비";
            this.Equipment.Width = 238;
            // 
            // Pieces
            // 
            this.Pieces.Text = "개수";
            // 
            // Reason
            // 
            this.Reason.Text = "대여 사유";
            this.Reason.Width = 218;
            // 
            // Status
            // 
            this.Status.Text = "상태";
            this.Status.Width = 78;
            // 
            // RentDate
            // 
            this.RentDate.Text = "대여일";
            this.RentDate.Width = 78;
            // 
            // ReturnDate
            // 
            this.ReturnDate.Text = "반납일";
            this.ReturnDate.Width = 83;
            // 
            // ReturnConfirmer
            // 
            this.ReturnConfirmer.Text = "반납 확인자";
            this.ReturnConfirmer.Width = 102;
            // 
            // EquipmentHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1145, 688);
            this.Controls.Add(this.historyView);
            this.Controls.Add(this.CheckBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EquipmentHistoryForm";
            this.Text = "EquipmentForm";
            this.Load += new System.EventHandler(this.EquipmentHistoryForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CheckBtn;
        private System.Windows.Forms.ListView historyView;
        private System.Windows.Forms.ColumnHeader Rentee;
        private System.Windows.Forms.ColumnHeader Equipment;
        private System.Windows.Forms.ColumnHeader Pieces;
        private System.Windows.Forms.ColumnHeader Reason;
        private System.Windows.Forms.ColumnHeader Status;
        private System.Windows.Forms.ColumnHeader RentDate;
        private System.Windows.Forms.ColumnHeader ReturnDate;
        private System.Windows.Forms.ColumnHeader ReturnConfirmer;
    }
}