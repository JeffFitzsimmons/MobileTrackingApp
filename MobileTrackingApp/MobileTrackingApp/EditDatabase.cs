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
    public partial class EditDatabase : Form
    {
        public EditDatabase()
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

        private void buttonLogout_Click(object sender, EventArgs e)
        {           
            // Returns to login screen, admin is no longer logged in
            this.Visible = false;

            Login form = new Login();
            form.Show();

            this.Dispose();
        }

        private void listBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            string deviceName = (string)listBoxItems.SelectedItem.ToString();
                        
            String query = "SELECT Device, FirstName, LastName, PID, CheckOutDate, CheckInDate, SerialNumber FROM Students WHERE Device = '" + deviceName + "';";
            DataSet data = new DataSet();
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            
            try
            {
                connect.Open();
                SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);
                
                adapter.Fill(data, "Students");
                connect.Close();

                textBoxDevice.Text = data.Tables["Students"].Rows[0]["Device"].ToString();
                textBoxSerial.Text = data.Tables["Students"].Rows[0]["SerialNumber"].ToString();
                textBoxFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                textBoxLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();
                textBoxPID.Text = data.Tables["Students"].Rows[0]["PID"].ToString();
                textBoxCheckOut.Text = data.Tables["Students"].Rows[0]["CheckOutDate"].ToString();
                textBoxCheckIn.Text = data.Tables["Students"].Rows[0]["CheckInDate"].ToString();

                textBoxNewDevice.Text = data.Tables["Students"].Rows[0]["Device"].ToString();
                textBoxNewSerial.Text = data.Tables["Students"].Rows[0]["SerialNumber"].ToString();
                textBoxNewFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                textBoxNewLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();
                textBoxNewPID.Text = data.Tables["Students"].Rows[0]["PID"].ToString();
                //textBoxNewCheckOut.Text = data.Tables["Students"].Rows[0]["CheckOutDate"].ToString();
                //textBoxNewCheckIn.Text = data.Tables["Students"].Rows[0]["CheckInDate"].ToString();
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
        private void EditDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int PIDparse;
            int pid = Int32.Parse(textBoxPID.Text);
            String dateCheckOut = dateTimePicker1.Value.ToShortDateString();
            String dateCheckIn = dateTimePicker2.Value.ToShortDateString();

            // Check for any blank fields
            if (string.IsNullOrWhiteSpace(textBoxNewDevice.Text))
            {
                MessageBox.Show("Please type in the device name.");
            }

            if (string.IsNullOrWhiteSpace(textBoxNewSerial.Text))
            {
                MessageBox.Show("Please use the scanner or manually input the device serial number.");
            }

            // Verify that the PID is approprite in length and type (6 numbers)
            else if (string.IsNullOrWhiteSpace(textBoxNewPID.Text))
            {
                MessageBox.Show("Please enter the student's PID.");
            }
            else if (textBoxNewPID.Text.Length != 6 || !int.TryParse(textBoxNewPID.Text, out PIDparse))
            {
                MessageBox.Show("The PID entered was not valid. Please enter a valid PID (6 numbers long)");
            }
            
            // Check for a blank first or last name
            else if (string.IsNullOrWhiteSpace(textBoxNewFirstName.Text))
            {
                MessageBox.Show("Please enter the student's first name.");
            }
            else if (string.IsNullOrWhiteSpace(textBoxNewLastName.Text))
            {
                MessageBox.Show("Please enter the student's last name.");
            }

            else
            {
                if (MessageBox.Show("Are you sure you want to change the information in the database?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SQLiteConnection connect = new SQLiteConnection(Login.connection);

                    try
                    {
                        String studentPID = textBoxPID.Text.ToString();
                        String query = "UPDATE Students SET Device = @Device, SerialNumber = @SerialNumber, FirstName = @FirstName, LastName = @LastName, PID = @PID, CheckOutDate = @CheckOutDate, CheckInDate = @CheckInDate WHERE PID = " + studentPID + ";";
                        SQLiteCommand cmd = new SQLiteCommand(query, connect);
                        connect.Open();

                        cmd.Parameters.AddWithValue("@Device", textBoxNewDevice);
                        cmd.Parameters.AddWithValue("@SerialNumber", textBoxNewSerial);
                        cmd.Parameters.AddWithValue("@FirstName", textBoxNewFirstName);
                        cmd.Parameters.AddWithValue("@LastName", textBoxNewLastName);
                        cmd.Parameters.AddWithValue("@PID", textBoxNewPID);
                        cmd.Parameters.AddWithValue("@CheckOutDate", dateCheckOut);
                        cmd.Parameters.AddWithValue("@CheckInDate", dateCheckIn);
                        cmd.ExecuteNonQuery();
                        connect.Close();
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

                    // Refresh back to Home after New Check Out is completed
                    this.Visible = false;

                    EditDatabase form = new EditDatabase();
                    form.Show();

                    this.Dispose();
                }
                else
                {
                    // Discard changes
                }
            }
        }
    }
}
