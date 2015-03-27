using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace MobileTrackingApp
{
    public partial class Search : Form
    {
        public static String firstName;
        public static String lastName;
        public static int pid;
        


        public Search()
        {
            InitializeComponent();

            String query = "SELECT Device FROM Students";
            DataSet data = new DataSet();
            SQLiteConnection connect = new SQLiteConnection(Login.connection);

            try
            {
                connect.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);
                adapter.Fill(data, "Students");
                connect.Close();

                int i = 0;
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    listBoxItems.Items.Add(data.Tables["Students"].Rows[i]["Device"]);
                    i++;
                }
                listBoxItems.Sorted = true;
            }
            catch (SQLiteException exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
          
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Return to Home screen
            this.Visible = false;

            Home form = new Home();
            form.Show();

            this.Dispose();
        }

        private void listBoxItems_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deviceName = (string)listBoxItems.SelectedItem.ToString();
                        
            String query = "SELECT Device, FirstName, LastName, PID, CheckOutDate, CheckInDate FROM Students WHERE Device = '" + deviceName + "';";
            DataSet data = new DataSet();
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            
            try
            {
                connect.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);
                
                adapter.Fill(data, "Students");
                connect.Close();

                textBoxDevice.Text = data.Tables["Students"].Rows[0]["Device"].ToString();
                textBoxFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                textBoxLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();
                textBoxPID.Text = data.Tables["Students"].Rows[0]["PID"].ToString();
                textBoxCheckOut.Text = data.Tables["Students"].Rows[0]["CheckOutDate"].ToString();
                textBoxCheckIn.Text = data.Tables["Students"].Rows[0]["CheckInDate"].ToString();
            }
            catch (SQLiteException exp)
            {
                MessageBox.Show(exp.Message.ToString());
            }
            finally
            {
                if (connect.State == ConnectionState.Open)
                {
                    connect.Close();
                }
            }
        }

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
