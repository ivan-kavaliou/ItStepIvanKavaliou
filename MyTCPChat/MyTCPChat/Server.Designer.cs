namespace MyTCPChat
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
            this.btnMakeClient = new System.Windows.Forms.Button();
            this.lstbClients = new System.Windows.Forms.ListBox();
            this.lstbMainChat = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // btnMakeClient
            // 
            this.btnMakeClient.Location = new System.Drawing.Point(13, 13);
            this.btnMakeClient.Name = "btnMakeClient";
            this.btnMakeClient.Size = new System.Drawing.Size(83, 23);
            this.btnMakeClient.TabIndex = 0;
            this.btnMakeClient.Text = "Make a Client";
            this.btnMakeClient.UseVisualStyleBackColor = true;
            this.btnMakeClient.Click += new System.EventHandler(this.btnMakeClient_Click);
            // 
            // lstbClients
            // 
            this.lstbClients.FormattingEnabled = true;
            this.lstbClients.Location = new System.Drawing.Point(12, 49);
            this.lstbClients.Name = "lstbClients";
            this.lstbClients.Size = new System.Drawing.Size(84, 329);
            this.lstbClients.TabIndex = 1;
            // 
            // lstbMainChat
            // 
            this.lstbMainChat.FormattingEnabled = true;
            this.lstbMainChat.Location = new System.Drawing.Point(102, 13);
            this.lstbMainChat.Name = "lstbMainChat";
            this.lstbMainChat.Size = new System.Drawing.Size(232, 368);
            this.lstbMainChat.TabIndex = 2;
            // 
            // Server
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 409);
            this.Controls.Add(this.lstbMainChat);
            this.Controls.Add(this.lstbClients);
            this.Controls.Add(this.btnMakeClient);
            this.Name = "Server";
            this.Text = "Server";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMakeClient;
        private System.Windows.Forms.ListBox lstbClients;
        private System.Windows.Forms.ListBox lstbMainChat;
    }
}

