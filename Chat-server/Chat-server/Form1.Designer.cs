namespace Chat_server
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
            this.tnameServer = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btclose = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // tnameServer
            // 
            this.tnameServer.Location = new System.Drawing.Point(30, 27);
            this.tnameServer.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tnameServer.Multiline = true;
            this.tnameServer.Name = "tnameServer";
            this.tnameServer.Size = new System.Drawing.Size(437, 477);
            this.tnameServer.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(495, 42);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(78, 30);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btclose
            // 
            this.btclose.Location = new System.Drawing.Point(495, 93);
            this.btclose.Margin = new System.Windows.Forms.Padding(2);
            this.btclose.Name = "btclose";
            this.btclose.Size = new System.Drawing.Size(78, 28);
            this.btclose.TabIndex = 2;
            this.btclose.Text = "Close";
            this.btclose.UseVisualStyleBackColor = true;
            this.btclose.Click += new System.EventHandler(this.btclose_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 548);
            this.Controls.Add(this.btclose);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.tnameServer);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tnameServer;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btclose;
    }
}

