namespace server
{
    partial class Server
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
            this.ControlTextBox = new System.Windows.Forms.TextBox();
            this.ServerLogTextBox = new System.Windows.Forms.RichTextBox();
            this.PortTextBox = new System.Windows.Forms.TextBox();
            this.HostTextBox = new System.Windows.Forms.TextBox();
            this.HostLabel = new System.Windows.Forms.Label();
            this.PortLabel = new System.Windows.Forms.Label();
            this.ServerDetailGroupBox = new System.Windows.Forms.GroupBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.ServerStartButton = new System.Windows.Forms.Button();
            this.ServerDetailGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ControlTextBox
            // 
            this.ControlTextBox.Location = new System.Drawing.Point(12, 419);
            this.ControlTextBox.Name = "ControlTextBox";
            this.ControlTextBox.Size = new System.Drawing.Size(682, 21);
            this.ControlTextBox.TabIndex = 0;
            // 
            // ServerLogTextBox
            // 
            this.ServerLogTextBox.Location = new System.Drawing.Point(12, 62);
            this.ServerLogTextBox.Name = "ServerLogTextBox";
            this.ServerLogTextBox.Size = new System.Drawing.Size(776, 349);
            this.ServerLogTextBox.TabIndex = 1;
            this.ServerLogTextBox.Text = "";
            // 
            // PortTextBox
            // 
            this.PortTextBox.Location = new System.Drawing.Point(257, 14);
            this.PortTextBox.Name = "PortTextBox";
            this.PortTextBox.Size = new System.Drawing.Size(60, 21);
            this.PortTextBox.TabIndex = 2;
            this.PortTextBox.Text = "3000";
            // 
            // HostTextBox
            // 
            this.HostTextBox.Location = new System.Drawing.Point(64, 14);
            this.HostTextBox.Name = "HostTextBox";
            this.HostTextBox.Size = new System.Drawing.Size(132, 21);
            this.HostTextBox.TabIndex = 3;
            this.HostTextBox.Text = "0.0.0.0";
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
            // ServerDetailGroupBox
            // 
            this.ServerDetailGroupBox.Controls.Add(this.PortTextBox);
            this.ServerDetailGroupBox.Controls.Add(this.HostLabel);
            this.ServerDetailGroupBox.Controls.Add(this.PortLabel);
            this.ServerDetailGroupBox.Controls.Add(this.HostTextBox);
            this.ServerDetailGroupBox.Location = new System.Drawing.Point(12, 12);
            this.ServerDetailGroupBox.Name = "ServerDetailGroupBox";
            this.ServerDetailGroupBox.Size = new System.Drawing.Size(340, 44);
            this.ServerDetailGroupBox.TabIndex = 7;
            this.ServerDetailGroupBox.TabStop = false;
            this.ServerDetailGroupBox.Text = "Server Details";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(713, 417);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(75, 23);
            this.SendButton.TabIndex = 8;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            // 
            // ServerStartButton
            // 
            this.ServerStartButton.Location = new System.Drawing.Point(611, 12);
            this.ServerStartButton.Name = "ServerStartButton";
            this.ServerStartButton.Size = new System.Drawing.Size(177, 44);
            this.ServerStartButton.TabIndex = 9;
            this.ServerStartButton.Text = "Server Start";
            this.ServerStartButton.UseVisualStyleBackColor = true;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ServerStartButton);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.ServerDetailGroupBox);
            this.Controls.Add(this.ServerLogTextBox);
            this.Controls.Add(this.ControlTextBox);
            this.Name = "Server";
            this.Text = "옥황상제 서버";
            this.ServerDetailGroupBox.ResumeLayout(false);
            this.ServerDetailGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ControlTextBox;
        private System.Windows.Forms.RichTextBox ServerLogTextBox;
        private System.Windows.Forms.TextBox PortTextBox;
        private System.Windows.Forms.TextBox HostTextBox;
        private System.Windows.Forms.Label HostLabel;
        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.GroupBox ServerDetailGroupBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Button ServerStartButton;
    }
}

