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
    public partial class EditDatabase : Form
    {
        public EditDatabase()
        {
            InitializeComponent();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {           
            // Returns to login screen, admin is no longer logged in
            this.Visible = false;

            Login form = new Login();
            form.Show();

            this.Dispose();
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            // List Devices
            if (listBoxSelect.SelectedIndex == 0)
            {

            }
            
            // List Students and Faculty
            if (listBoxSelect.SelectedIndex == 1)
            {

            }
        }
    }
}
