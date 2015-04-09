namespace MobileTrackingApp
{
    partial class CheckOut
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckOut));
            this.buttonBack = new System.Windows.Forms.Button();
            this.buttonCheckOut = new System.Windows.Forms.Button();
            this.textBoxPID = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dateTimeCheckOut = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBoxSerial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxDevice = new System.Windows.Forms.TextBox();
            this.dateTimeDueDate = new System.Windows.Forms.DateTimePicker();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBoxComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.comboBoxAsset = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(108, 318);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(131, 51);
            this.buttonBack.TabIndex = 9;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonCheckOut
            // 
            this.buttonCheckOut.Location = new System.Drawing.Point(279, 318);
            this.buttonCheckOut.Name = "buttonCheckOut";
            this.buttonCheckOut.Size = new System.Drawing.Size(129, 51);
            this.buttonCheckOut.TabIndex = 8;
            this.buttonCheckOut.Text = "Check Out";
            this.buttonCheckOut.UseVisualStyleBackColor = true;
            this.buttonCheckOut.Click += new System.EventHandler(this.buttonCheckOut_Click);
            // 
            // textBoxPID
            // 
            this.textBoxPID.Location = new System.Drawing.Point(107, 56);
            this.textBoxPID.Name = "textBoxPID";
            this.textBoxPID.Size = new System.Drawing.Size(150, 20);
            this.textBoxPID.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(76, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "PID";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 85);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(84, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Check Out Date";
            // 
            // dateTimeCheckOut
            // 
            this.dateTimeCheckOut.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeCheckOut.Location = new System.Drawing.Point(108, 83);
            this.dateTimeCheckOut.Name = "dateTimeCheckOut";
            this.dateTimeCheckOut.Size = new System.Drawing.Size(103, 20);
            this.dateTimeCheckOut.TabIndex = 4;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(104, 14);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 42;
            this.label9.Text = "Name";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(276, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(27, 13);
            this.label7.TabIndex = 41;
            this.label7.Text = "S/N";
            // 
            // textBoxSerial
            // 
            this.textBoxSerial.Location = new System.Drawing.Point(279, 30);
            this.textBoxSerial.Name = "textBoxSerial";
            this.textBoxSerial.Size = new System.Drawing.Size(135, 20);
            this.textBoxSerial.TabIndex = 2;
            this.textBoxSerial.TextChanged += new System.EventHandler(this.textBoxSerial_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 39;
            this.label1.Text = "Device";
            // 
            // textBoxDevice
            // 
            this.textBoxDevice.Location = new System.Drawing.Point(107, 30);
            this.textBoxDevice.Name = "textBoxDevice";
            this.textBoxDevice.ReadOnly = true;
            this.textBoxDevice.Size = new System.Drawing.Size(150, 20);
            this.textBoxDevice.TabIndex = 100;
            // 
            // dateTimeDueDate
            // 
            this.dateTimeDueDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimeDueDate.Location = new System.Drawing.Point(107, 109);
            this.dateTimeDueDate.Name = "dateTimeDueDate";
            this.dateTimeDueDate.Size = new System.Drawing.Size(104, 20);
            this.dateTimeDueDate.TabIndex = 5;
            this.dateTimeDueDate.ValueChanged += new System.EventHandler(this.dateTimeDueDate_ValueChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(49, 115);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 47;
            this.label11.Text = "Due Date";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(46, 196);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 13);
            this.label10.TabIndex = 46;
            this.label10.Text = "Comments";
            // 
            // textBoxComments
            // 
            this.textBoxComments.Location = new System.Drawing.Point(108, 193);
            this.textBoxComments.Multiline = true;
            this.textBoxComments.Name = "textBoxComments";
            this.textBoxComments.Size = new System.Drawing.Size(307, 85);
            this.textBoxComments.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(32, 168);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(70, 13);
            this.label8.TabIndex = 44;
            this.label8.Text = "Device Asset";
            // 
            // comboBoxAsset
            // 
            this.comboBoxAsset.FormattingEnabled = true;
            this.comboBoxAsset.Items.AddRange(new object[] {
            "Case ",
            "Keyboard",
            "Power Adapter"});
            this.comboBoxAsset.Location = new System.Drawing.Point(108, 165);
            this.comboBoxAsset.Name = "comboBoxAsset";
            this.comboBoxAsset.Size = new System.Drawing.Size(150, 21);
            this.comboBoxAsset.TabIndex = 6;
            // 
            // CheckOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 381);
            this.Controls.Add(this.dateTimeDueDate);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBoxComments);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBoxAsset);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBoxSerial);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxDevice);
            this.Controls.Add(this.dateTimeCheckOut);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPID);
            this.Controls.Add(this.buttonCheckOut);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "CheckOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Out Form";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.CheckOut_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonCheckOut;
        private System.Windows.Forms.TextBox textBoxPID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dateTimeCheckOut;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBoxSerial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxDevice;
        private System.Windows.Forms.DateTimePicker dateTimeDueDate;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBoxComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBoxAsset;
    }
}