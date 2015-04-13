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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.dataGridViewSearch = new System.Windows.Forms.DataGridView();
            this.buttonShowAvailable = new System.Windows.Forms.Button();
            this.buttonShowCheckedOut = new System.Windows.Forms.Button();
            this.dateTimePickerStart = new System.Windows.Forms.DateTimePicker();
            this.dateTimePickerEnd = new System.Windows.Forms.DateTimePicker();
            this.buttonTime = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(10, 427);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(102, 32);
            this.buttonBack.TabIndex = 5;
            this.buttonBack.Text = "Back";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(10, 56);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(100, 27);
            this.buttonSearch.TabIndex = 3;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(7, 14);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(156, 13);
            this.label11.TabIndex = 51;
            this.label11.Text = "Search by PID or Device Name";
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(10, 30);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(153, 20);
            this.textBoxSearch.TabIndex = 2;
            this.textBoxSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxSearch_KeyPress);
            // 
            // dataGridViewSearch
            // 
            this.dataGridViewSearch.AllowUserToAddRows = false;
            this.dataGridViewSearch.AllowUserToDeleteRows = false;
            this.dataGridViewSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewSearch.Location = new System.Drawing.Point(181, 14);
            this.dataGridViewSearch.Name = "dataGridViewSearch";
            this.dataGridViewSearch.ReadOnly = true;
            this.dataGridViewSearch.Size = new System.Drawing.Size(783, 445);
            this.dataGridViewSearch.TabIndex = 58;
            // 
            // buttonShowAvailable
            // 
            this.buttonShowAvailable.Location = new System.Drawing.Point(10, 293);
            this.buttonShowAvailable.Name = "buttonShowAvailable";
            this.buttonShowAvailable.Size = new System.Drawing.Size(152, 48);
            this.buttonShowAvailable.TabIndex = 59;
            this.buttonShowAvailable.Text = "Show available devices";
            this.buttonShowAvailable.UseVisualStyleBackColor = true;
            this.buttonShowAvailable.Click += new System.EventHandler(this.buttonShowAvailable_Click);
            // 
            // buttonShowCheckedOut
            // 
            this.buttonShowCheckedOut.Location = new System.Drawing.Point(10, 347);
            this.buttonShowCheckedOut.Name = "buttonShowCheckedOut";
            this.buttonShowCheckedOut.Size = new System.Drawing.Size(152, 48);
            this.buttonShowCheckedOut.TabIndex = 60;
            this.buttonShowCheckedOut.Text = "Show Checked Out Devices";
            this.buttonShowCheckedOut.UseVisualStyleBackColor = true;
            this.buttonShowCheckedOut.Click += new System.EventHandler(this.buttonShowCheckedOut_Click);
            // 
            // dateTimePickerStart
            // 
            this.dateTimePickerStart.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerStart.Location = new System.Drawing.Point(12, 144);
            this.dateTimePickerStart.Name = "dateTimePickerStart";
            this.dateTimePickerStart.Size = new System.Drawing.Size(81, 20);
            this.dateTimePickerStart.TabIndex = 61;
            // 
            // dateTimePickerEnd
            // 
            this.dateTimePickerEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerEnd.Location = new System.Drawing.Point(10, 185);
            this.dateTimePickerEnd.Name = "dateTimePickerEnd";
            this.dateTimePickerEnd.Size = new System.Drawing.Size(83, 20);
            this.dateTimePickerEnd.TabIndex = 62;
            // 
            // buttonTime
            // 
            this.buttonTime.Location = new System.Drawing.Point(10, 221);
            this.buttonTime.Name = "buttonTime";
            this.buttonTime.Size = new System.Drawing.Size(100, 27);
            this.buttonTime.TabIndex = 63;
            this.buttonTime.Text = "Search";
            this.buttonTime.UseVisualStyleBackColor = true;
            this.buttonTime.Click += new System.EventHandler(this.buttonTime_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(99, 150);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 64;
            this.label1.Text = "Beginning Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(99, 191);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 13);
            this.label2.TabIndex = 65;
            this.label2.Text = "Ending Date";
            // 
            // Search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(976, 471);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonTime);
            this.Controls.Add(this.dateTimePickerEnd);
            this.Controls.Add(this.dateTimePickerStart);
            this.Controls.Add(this.buttonShowCheckedOut);
            this.Controls.Add(this.buttonShowAvailable);
            this.Controls.Add(this.dataGridViewSearch);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.buttonBack);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Search";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Search_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewSearch)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.DataGridView dataGridViewSearch;
        private System.Windows.Forms.Button buttonShowAvailable;
        private System.Windows.Forms.Button buttonShowCheckedOut;
        private System.Windows.Forms.DateTimePicker dateTimePickerStart;
        private System.Windows.Forms.DateTimePicker dateTimePickerEnd;
        private System.Windows.Forms.Button buttonTime;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

    }
}