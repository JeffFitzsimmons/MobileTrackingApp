namespace MobileTrackingApp
{
    partial class Home
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
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.buttonCheckIn = new System.Windows.Forms.Button();
            this.buttonNewCheckOut = new System.Windows.Forms.Button();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonEditDatabase = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Location = new System.Drawing.Point(97, 61);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(114, 56);
            this.buttonCheckOut.TabIndex = 0;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // buttonCheckIn
            // 
            this.buttonCheckIn.Location = new System.Drawing.Point(97, 141);
            this.buttonCheckIn.Name = "buttonCheckIn";
            this.buttonCheckIn.Size = new System.Drawing.Size(114, 56);
            this.buttonCheckIn.TabIndex = 5;
            this.buttonCheckIn.Text = "Check In";
            this.buttonCheckIn.UseVisualStyleBackColor = true;
            this.buttonCheckIn.Click += new System.EventHandler(this.buttonCheckIn_Click);
            // 
            // buttonNewCheckOut
            // 
            this.buttonNewCheckOut.Location = new System.Drawing.Point(233, 61);
            this.buttonNewCheckOut.Name = "buttonNewCheckOut";
            this.buttonNewCheckOut.Size = new System.Drawing.Size(114, 56);
            this.buttonNewCheckOut.TabIndex = 6;
            this.buttonNewCheckOut.Text = "New Check Out";
            this.buttonNewCheckOut.UseVisualStyleBackColor = true;
            this.buttonNewCheckOut.Click += new System.EventHandler(this.buttonNewCheckOut_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(233, 141);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(114, 56);
            this.buttonSearch.TabIndex = 7;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonEditDatabase
            // 
            this.buttonEditDatabase.Location = new System.Drawing.Point(165, 262);
            this.buttonEditDatabase.Name = "buttonEditDatabase";
            this.buttonEditDatabase.Size = new System.Drawing.Size(114, 56);
            this.buttonEditDatabase.TabIndex = 8;
            this.buttonEditDatabase.Text = "Edit Database";
            this.buttonEditDatabase.UseVisualStyleBackColor = true;
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(478, 330);
            this.Controls.Add(this.buttonEditDatabase);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonNewCheckOut);
            this.Controls.Add(this.buttonCheckIn);
            this.Controls.Add(this.buttonCheckOut);
            this.Name = "Home";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.Button buttonCheckIn;
        private System.Windows.Forms.Button buttonNewCheckOut;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonEditDatabase;
    }
}