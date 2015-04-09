using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace MobileTrackingApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        // Go to Check Out
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            CheckOut form = new CheckOut();
            form.Show();

            this.Dispose();
        }

        // Go to New Check Out
        private void buttonNewCheckOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            NewCheckOut form = new NewCheckOut();
            form.Show();

            this.Dispose();
        }

        // Go to Check In
        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            CheckIn form = new CheckIn();
            form.Show();

            this.Dispose();
        }

        // Go to Search
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            Search form = new Search();
            form.Show();

            this.Dispose();
        }

        private void Home_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Logout the user, return to login page
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            // Logs the user out and returns to the login screen            
            this.Visible = false;

            Login form = new Login();
            form.Show();

            this.Dispose();
        }

        // Shows ABOUT information
        private void aboutTheMobileDeviceTrackingSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("The Mobile Device Tracking System was designed and developed for the Colorado State University - Pueblo" +
                " Propel Center. Authors: Jeff Fitzsimmons, Daniel Santistevan and Tom Vaupel");
        }

        // Brings up the support documentation on the computer's defualt PDF reader
        private void operationInstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(@"Innovative Technologies Support Documentation Final.pdf");
        }
    }
}
