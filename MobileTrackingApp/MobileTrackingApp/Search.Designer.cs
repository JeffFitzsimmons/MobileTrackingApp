namespace MobileTrackingApp
{
    partial class Search
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Search));
            this.buttonBack = new System.Windows.Forms.Button();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.textBoxFirstName = new System.Windows.Forms.TextBox();
            this.textBoxLastName = new System.Windows.Forms.TextBox();
            this.textBoxPID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxDevice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCheckOut = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBoxCheckIn = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxDueDate = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBoxAsset = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(434, 371);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(102, 32);
            this.buttonBack.TabIndex = 26;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(12, 12);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(145, 394);
            this.listBoxItems.TabIndex = 27;
            this.listBoxItems.SelectedIndexChanged += new System.EventHandler(this.listBoxItems_SelectedIndexChanged);
            // 
            // textBoxFirstName
            // 
            this.textBoxFirstName.Location = new System.Drawing.Point(265, 63);
            this.textBoxFirstName.Name = "textBoxFirstName";
            this.textBoxFirstName.ReadOnly = true;
            this.textBoxFirstName.Size = new System.Drawing.Size(226, 20);
            this.textBoxFirstName.TabIndex = 28;
            // 
            // textBoxLastName
            // 
            this.textBoxLastName.Location = new System.Drawing.Point(265, 89);
            this.textBoxLastName.Name = "textBoxLastName";
            this.textBoxLastName.ReadOnly = true;
            this.textBoxLastName.Size = new System.Drawing.Size(226, 20);
            this.textBoxLastName.TabIndex = 29;
            // 
            // textBoxPID
            // 
            this.textBoxPID.Location = new System.Drawing.Point(265, 115);
            this.textBoxPID.Name = "textBoxPID";
            this.textBoxPID.ReadOnly = true;
            this.textBoxPID.Size = new System.Drawing.Size(226, 20);
            this.textBoxPID.TabIndex = 30;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 13);
            this.label1.TabIndex = 31;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(201, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 32;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(234, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(25, 13);
            this.label3.TabIndex = 33;
            this.label3.Text = "PID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(218, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 13);
            this.label4.TabIndex = 35;
            this.label4.Text = "Device";
            // 
            // textBoxDevice
            // 
            this.textBoxDevice.Location = new System.Drawing.Point(265, 12);
            this.textBoxDevice.Name = "textBoxDevice";
            this.textBoxDevice.ReadOnly = true;
            this.textBoxDevice.Size = new System.Drawing.Size(226, 20);
            this.textBoxDevice.TabIndex = 34;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(202, 144);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(58, 13);
            this.label5.TabIndex = 37;
            this.label5.Text = "Check Out";
            // 
            // textBoxCheckOut
            // 
            this.textBoxCheckOut.Location = new System.Drawing.Point(265, 141);
            this.textBoxCheckOut.Name = "textBoxCheckOut";
            this.textBoxCheckOut.ReadOnly = true;
            this.textBoxCheckOut.Size = new System.Drawing.Size(226, 20);
            this.textBoxCheckOut.TabIndex = 36;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(209, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(50, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "Check In";
            // 
            // textBoxCheckIn
            // 
            this.textBoxCheckIn.Location = new System.Drawing.Point(265, 193);
            this.textBoxCheckIn.Name = "textBoxCheckIn";
            this.textBoxCheckIn.ReadOnly = true;
            this.textBoxCheckIn.Size = new System.Drawing.Size(226, 20);
            this.textBoxCheckIn.TabIndex = 38;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(186, 40);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "Serial Number";
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Location = new System.Drawing.Point(265, 37);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.ReadOnly = true;
            this.textBoxSerial.Size = new System.Drawing.Size(226, 20);
            this.textBoxSerial.TabIndex = 40;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(206, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 13);
            this.label8.TabIndex = 43;
            this.label8.Text = "Due Date";
            // 
            // textBoxDueDate
            // 
            this.textBoxDueDate.Location = new System.Drawing.Point(265, 167);
            this.textBoxDueDate.Name = "textBoxDueDate";
            this.textBoxDueDate.ReadOnly = true;
            this.textBoxDueDate.Size = new System.Drawing.Size(226, 20);
            this.textBoxDueDate.TabIndex = 42;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(221, 222);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(38, 13);
            this.label9.TabIndex = 45;
            this.label9.Text = "Assets";
            // 
            // textBoxAsset
            // 
            this.textBoxAsset.Location = new System.Drawing.Point(265, 219);
            this.textBoxAsset.Name = "textBoxAsset";
            this.textBoxAsset.ReadOnly = true;
            this.textBoxAsset.Size = new System.Drawing.Size(226, 20);
            this.textBoxAsset.TabIndex = 44;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(209, 248);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 47;
            this.label10.Text = "Comments";
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(265, 245);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.ReadOnly = true;
            this.textBoxComments.Size = new System.Drawing.Size(226, 63);
            this.textBoxComments.TabIndex = 46;
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(548, 415);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBoxAsset);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxDueDate);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSerial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBoxCheckIn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCheckOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxDevice);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxPID);
            this.Controls.Add(this.textBoxLastName);
            this.Controls.Add(this.textBoxFirstName);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.TextBox textBoxFirstName;
        private System.Windows.Forms.TextBox textBoxLastName;
        private System.Windows.Forms.TextBox textBoxPID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxDevice;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCheckOut;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBoxCheckIn;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSerial;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxDueDate;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBoxAsset;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxComments;

    }
}