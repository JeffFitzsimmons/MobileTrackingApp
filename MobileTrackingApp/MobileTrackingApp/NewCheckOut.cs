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
    public partial class NewCheckOut : Form
    {
        public NewCheckOut()
        {
            InitializeComponent();
        }

        // Back to the home screen
        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Return to Home screen
            this.Visible = false;

            Home form = new Home();
            form.Show();

            this.Dispose();
        }

                
        // Submits new check out data once the data has been checked for errors
        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            // Code for converting necessary PID and Date fields so the database doesn't have problems
            int PIDparse;
            //dateTimeCheckOut.MinDate = DateTime.Now;
            //dateTimeDueDate.MinDate = DateTime.Now;
            String checkOutDate = dateTimeCheckOut.Value.ToString();
            String dueDate = dateTimeDueDate.Value.ToShortDateString();

            // Check for any blank fields
            if (string.IsNullOrWhiteSpace(textBoxDevice.Text))
            {
                MessageBox.Show("Please scan the serial number and device name will populate itself.");
            }

            if (string.IsNullOrWhiteSpace(textBoxSerial.Text))
            {
                MessageBox.Show("Please use the scanner or manually input the device serial number.");
            }

            if (string.IsNullOrWhiteSpace(textBoxPID.Text))
            {
                MessageBox.Show("Please enter the student's PID.");
            }
            else
            {
                int pid = Int32.Parse(textBoxPID.Text);
            }


            // Verify that the PID is approprite in length and type (6 numbers)
            if (textBoxPID.Text.Length != 6 || !int.TryParse(textBoxPID.Text, out PIDparse))
            {
                MessageBox.Show("The PID entered was not valid. Please enter a valid PID (6 numbers long)");
            }

            // Check for a blank first or last name
            else if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                MessageBox.Show("Please enter the student's first name.");
            }
            else if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                MessageBox.Show("Please enter the student's last name.");
            }
            
            else
            {
                // Prompts the user for any last changes
                if (MessageBox.Show("Are you sure you want to check this device out? (Make sure to verify the check out date)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    // Pull device info for the one specified
                    SQLiteConnection connectAvailable = new SQLiteConnection(Login.connection);
                    connectAvailable.Open();
                    String queryAvailable = "SELECT Device FROM CheckOut WHERE Device = '" + textBoxDevice.Text + "';";
                    SQLiteCommand cmdCheck = new SQLiteCommand(queryAvailable, connectAvailable);
                    object check = cmdCheck.ExecuteScalar();

                    // Check if the device is available
                    if (check == null)
                    {
                        SQLiteConnection connect = new SQLiteConnection(Login.connection);
                        try
                        {
                            // If the device is available, update the database, add the new student info, and swith the device to unavailable
                            String[] queries = new String[4];

                            queries[0] = "INSERT INTO CheckOut (Device, SerialNumber, PID, CheckOutDate, DueDate, Comments, Assets) VALUES (@Device, @SerialNumber, @PID, @CheckOutDate, @DueDate, @Comments, @Assets)";
                            queries[1] = "INSERT INTO History (Device, SerialNumber, PID, CheckOutDate, DueDate, Comments, Assets) VALUES (@Device, @SerialNumber, @PID, @CheckOutDate, @DueDate, @Comments, @Assets)";
                            queries[2] = "INSERT INTO Students (PID, FirstName, LastName) VALUES (@PID, @FirstName, @LastName)";
                            queries[3] = "UPDATE Device SET CheckOut = 'True' WHERE SerialNumber = @SerialNumber AND Device = @Device";

                            foreach (String query in queries)
                            {
                                SQLiteCommand cmd = new SQLiteCommand(query, connect);
                                connect.Open();

                                cmd.Parameters.AddWithValue("@Device", textBoxDevice.Text);
                                cmd.Parameters.AddWithValue("@SerialNumber", textBoxSerial.Text);
                                cmd.Parameters.AddWithValue("@PID", textBoxPID.Text);
                                cmd.Parameters.AddWithValue("@FirstName", textBoxFirstName.Text);
                                cmd.Parameters.AddWithValue("@LastName", textBoxLastName.Text);
                                cmd.Parameters.AddWithValue("@CheckOutDate", checkOutDate);
                                cmd.Parameters.AddWithValue("@DueDate", dueDate);
                                cmd.Parameters.AddWithValue("@Comments", textBoxComments.Text);
                                cmd.Parameters.AddWithValue("@Assets", comboBoxAsset.Text);
                                cmd.ExecuteNonQuery();
                                connect.Close();
                            }
                        }
                        catch (SQLiteException exception)
                        {
                            MessageBox.Show(exception.Message.ToString());
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

                        Home form = new Home();
                        form.Show();

                        this.Dispose();
                    }
                    else
                    {
                        MessageBox.Show("This device is already checked out. Please verify the device name and serial number on the label.");
                    }
                }
                else
                {
                    // Discard changes
                }
            }         
        }

        private void NewCheckOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {
            // Auto populate the device name when a valid serial number is entered
            textBoxDevice.Clear();
            SQLiteConnection connectAvailable = new SQLiteConnection(Login.connection);
            connectAvailable.Open();
            String serialNumber = textBoxSerial.Text.ToString();
            String queryAvailable = "SELECT Device FROM Device WHERE SerialNumber = '" + serialNumber + "';";
            SQLiteCommand cmdCheck = new SQLiteCommand(queryAvailable, connectAvailable);
            object check = cmdCheck.ExecuteScalar();

            if (check != null) 
            {
                String query = "SELECT Device FROM Device WHERE SerialNumber = '" + serialNumber + "';";
                SQLiteConnection connect = new SQLiteConnection(Login.connection);
                DataSet data = new DataSet();

                try
                {
                    connect.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);

                    adapter.Fill(data, "Device");
                    connect.Close();

                    textBoxDevice.Text = data.Tables["Device"].Rows[0]["Device"].ToString();
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
                finally
                {
                    if (connect.State == ConnectionState.Open)
                    {
                        connect.Close();
                    }
                }
                
            }
        }

        private void dateTimeDueDate_ValueChanged(object sender, EventArgs e)
        {
            // Compare the checkout date and due date, ensuring the due date is not set before or equal to the checkout date
            if (dateTimeCheckOut.Value >= dateTimeDueDate.Value)
            {
                MessageBox.Show("The due date is not valid. (Must be a date after the check out date)");
            }
        }
    }
}
