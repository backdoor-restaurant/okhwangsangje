namespace client
{
    partial class EquipmentForm
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
            this.equipView = new System.Windows.Forms.ListView();
            this.Equipment = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pound = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Number = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pieces = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AddBtn = new System.Windows.Forms.Button();
            this.DelBtn = new System.Windows.Forms.Button();
            this.RentBtn = new System.Windows.Forms.Button();
            this.ReturnBtn = new System.Windows.Forms.Button();
            this.rentView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // equipView
            // 
            this.equipView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Equipment,
            this.Pound,
            this.Pieces,
            this.Number});
            this.equipView.HideSelection = false;
            this.equipView.Location = new System.Drawing.Point(12, 294);
            this.equipView.Name = "equipView";
            this.equipView.Size = new System.Drawing.Size(1120, 383);
            this.equipView.TabIndex = 16;
            this.equipView.UseCompatibleStateImageBehavior = false;
            this.equipView.View = System.Windows.Forms.View.Details;
            // 
            // Equipment
            // 
            this.Equipment.DisplayIndex = 1;
            this.Equipment.Text = "장비";
            // 
            // Pound
            // 
            this.Pound.DisplayIndex = 0;
            this.Pound.Text = "파운드";
            // 
            // Number
            // 
            this.Number.Text = "넘버";
            // 
            // Pieces
            // 
            this.Pieces.Text = "개수";
            this.Pieces.Width = 165;
            // 
            // AddBtn
            // 
            this.AddBtn.Location = new System.Drawing.Point(608, 217);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(171, 71);
            this.AddBtn.TabIndex = 17;
            this.AddBtn.Text = "장비 추가";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // DelBtn
            // 
            this.DelBtn.Location = new System.Drawing.Point(785, 217);
            this.DelBtn.Name = "DelBtn";
            this.DelBtn.Size = new System.Drawing.Size(171, 71);
            this.DelBtn.TabIndex = 18;
            this.DelBtn.Text = "장비 제거";
            this.DelBtn.UseVisualStyleBackColor = true;
            this.DelBtn.Click += new System.EventHandler(this.DelBtn_Click);
            // 
            // RentBtn
            // 
            this.RentBtn.Location = new System.Drawing.Point(962, 217);
            this.RentBtn.Name = "RentBtn";
            this.RentBtn.Size = new System.Drawing.Size(171, 71);
            this.RentBtn.TabIndex = 19;
            this.RentBtn.Text = "대여";
            this.RentBtn.UseVisualStyleBackColor = true;
            this.RentBtn.Click += new System.EventHandler(this.RentBtn_Click);
            // 
            // ReturnBtn
            // 
            this.ReturnBtn.Location = new System.Drawing.Point(961, 12);
            this.ReturnBtn.Name = "ReturnBtn";
            this.ReturnBtn.Size = new System.Drawing.Size(171, 71);
            this.ReturnBtn.TabIndex = 20;
            this.ReturnBtn.Text = "반납";
            this.ReturnBtn.UseVisualStyleBackColor = true;
            this.ReturnBtn.Click += new System.EventHandler(this.ReturnBtn_Click);
            // 
            // rentView
            // 
            this.rentView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4});
            this.rentView.HideSelection = false;
            this.rentView.Location = new System.Drawing.Point(12, 89);
            this.rentView.Name = "rentView";
            this.rentView.Size = new System.Drawing.Size(1120, 122);
            this.rentView.TabIndex = 21;
            this.rentView.UseCompatibleStateImageBehavior = false;
            this.rentView.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.DisplayIndex = 1;
            this.columnHeader1.Text = "장비";
            this.columnHeader1.Width = 114;
            // 
            // columnHeader2
            // 
            this.columnHeader2.DisplayIndex = 0;
            this.columnHeader2.Text = "파운드";
            this.columnHeader2.Width = 75;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "넘버";
            this.columnHeader3.Width = 121;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "개수";
            this.columnHeader4.Width = 165;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Dotum", 15F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(10, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 22;
            this.label1.Text = "대여 중인 장비";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Dotum", 15F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(10, 246);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 20);
            this.label2.TabIndex = 23;
            this.label2.Text = "장비 목록";
            // 
            // EquipmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.ClientSize = new System.Drawing.Size(1145, 688);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rentView);
            this.Controls.Add(this.ReturnBtn);
            this.Controls.Add(this.RentBtn);
            this.Controls.Add(this.DelBtn);
            this.Controls.Add(this.AddBtn);
            this.Controls.Add(this.equipView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "EquipmentForm";
            this.Text = "EquipmentForm";
            this.Load += new System.EventHandler(this.EquipmentForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView equipView;
        private System.Windows.Forms.ColumnHeader Pound;
        private System.Windows.Forms.ColumnHeader Equipment;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader Pieces;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.Button DelBtn;
        private System.Windows.Forms.Button RentBtn;
        private System.Windows.Forms.Button ReturnBtn;
        private System.Windows.Forms.ListView rentView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}