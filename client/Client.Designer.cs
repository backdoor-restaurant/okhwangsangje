namespace client
{
    partial class Client
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
            this.ConnectButton = new System.Windows.Forms.Button();
            this.SendButton = new System.Windows.Forms.Button();
            this.ConnectionDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.LogTextBox = new System.Windows.Forms.RichTextBox();
            this.ControlTextBox = new System.Windows.Forms.TextBox();
            this.ConnectionDetailGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(611, 11);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(177, 44);
            this.ConnectButton.TabIndex = 14;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.UseVisualStyleBackColor = true;
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(713, 416);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 13;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // ConnectionDetailGroupBox
            // 
            this.ConnectionDetailGroupBox.Controls.Add(this.PortTextBox);
            this.ConnectionDetailGroupBox.Controls.Add(this.HostLabel);
            this.ConnectionDetailGroupBox.Controls.Add(this.PortLabel);
            this.ConnectionDetailGroupBox.Controls.Add(this.HostTextBox);
            this.ConnectionDetailGroupBox.Location = new System.Drawing.Point(12, 11);
            this.ConnectionDetailGroupBox.Name = "ConnectionDetailGroupBox";
            this.ConnectionDetailGroupBox.Size = new System.Drawing.Size(340, 44);
            this.ConnectionDetailGroupBox.TabIndex = 12;
            this.ConnectionDetailGroupBox.TabStop = false;
            this.ConnectionDetailGroupBox.Text = "Connection Details";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(257, 14);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(60, 21);
            this.PortTextBox.TabIndex = 2;
            this.PortTextBox.Text = "3000";
            // 
            // HostLabel
            // 
            this.HostLabel.AutoSize = true;
            this.HostLabel.Location = new System.Drawing.Point(6, 18);
            this.HostLabel.Name = "HostLabel";
            this.HostLabel.Size = new System.Drawing.Size(30, 12);
            this.HostLabel.TabIndex = 4;
            this.HostLabel.Text = "Host";
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(212, 18);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(27, 12);
            this.PortLabel.TabIndex = 5;
            this.PortLabel.Text = "Port";
            // 
            // HostTextBox
            // 
            this.HostTextBox.Location = new System.Drawing.Point(64, 14);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(132, 21);
            this.HostTextBox.TabIndex = 3;
            this.HostTextBox.Text = "0.0.0.0";
            // 
            // LogTextBox
            // 
            this.LogTextBox.Location = new System.Drawing.Point(12, 61);
            this.LogTextBox.Name = "LogTextBox";
            this.LogTextBox.Size = new System.Drawing.Size(776, 349);
            this.LogTextBox.TabIndex = 11;
            this.LogTextBox.Text = "";
            // 
            // ControlTextBox
            // 
            this.ControlTextBox.Location = new System.Drawing.Point(12, 418);
            this.ControlTextBox.Name = "ControlTextBox";
            this.ControlTextBox.Size = new System.Drawing.Size(682, 21);
            this.ControlTextBox.TabIndex = 10;
            // 
            // Client
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ConnectionDetailGroupBox);
            this.Controls.Add(this.LogTextBox);
            this.Controls.Add(this.ControlTextBox);
            this.Name = "Client";
            this.Text = "옥황상제";
            this.ConnectionDetailGroupBox.ResumeLayout(false);
            this.ConnectionDetailGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ConnectButton;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.GroupBox ConnectionDetailGroupBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.RichTextBox LogTextBox;
        private System.Windows.Forms.TextBox ControlTextBox;
    }
}

