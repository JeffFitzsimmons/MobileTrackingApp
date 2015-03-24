using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MobileTrackingApp
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            CheckOut form = new CheckOut();
            form.Show();

            this.Dispose();
        }

        private void buttonNewCheckOut_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            NewCheckOut form = new NewCheckOut();
            form.Show();

            this.Dispose();
        }

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            CheckIn form = new CheckIn();
            form.Show();

            this.Dispose();
        }

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
    }
}
