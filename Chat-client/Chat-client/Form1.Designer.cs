namespace Chat_client
{
    partial class Form1
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
            this.lchat = new System.Windows.Forms.ListBox();
            this.tchat = new System.Windows.Forms.TextBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tname = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // lchat
            // 
            this.lchat.FormattingEnabled = true;
            this.lchat.ItemHeight = 20;
            this.lchat.Location = new System.Drawing.Point(42, 36);
            this.lchat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lchat.Name = "lchat";
            this.lchat.Size = new System.Drawing.Size(385, 444);
            this.lchat.TabIndex = 0;
            // 
            // tchat
            // 
            this.tchat.Location = new System.Drawing.Point(42, 522);
            this.tchat.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tchat.Multiline = true;
            this.tchat.Name = "tchat";
            this.tchat.Size = new System.Drawing.Size(385, 87);
            this.tchat.TabIndex = 1;
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(483, 164);
            this.btnSend.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(123, 38);
            this.btnSend.TabIndex = 2;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLogin.Location = new System.Drawing.Point(483, 97);
            this.btnLogin.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(123, 42);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tname
            // 
            this.tname.Location = new System.Drawing.Point(483, 37);
            this.tname.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tname.Name = "tname";
            this.tname.Size = new System.Drawing.Size(123, 26);
            this.tname.TabIndex = 4;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 629);
            this.Controls.Add(this.tname);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tchat);
            this.Controls.Add(this.lchat);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lchat;
        private System.Windows.Forms.TextBox tchat;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox tname;
    }
}

