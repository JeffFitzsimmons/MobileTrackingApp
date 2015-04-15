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
    public partial class CheckIn : Form
    {
        public CheckIn()
        {
            InitializeComponent();
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            // Return to Home screen
            this.Visible = false;

            Home form = new Home();
            form.Show();

            this.Dispose();
        }

        private void buttonCheckIn_Click(object sender, EventArgs e)
        {
            // Code for converting necessary PID and Date fields so the database doesn't have problems
            int PIDparse;
            dateTimeSelect.MinDate = DateTime.Now;
            String date = dateTimeSelect.Value.ToString();
            
            if (string.IsNullOrWhiteSpace(textBoxPID.Text))
            {
                MessageBox.Show("Please enter the student's PID.");
            }
            else
            {
                int pid = Int32.Parse(textBoxPID.Text);
            }
            

            // Check for any blank fields
            if (string.IsNullOrWhiteSpace(textBoxDevice.Text))
            {
                MessageBox.Show("Please scan the serial number and device name will populate itself.");
            }

             // Verify that the PID is approprite in length and type (6 numbers)
            else if (textBoxPID.Text.Length != 6 || !int.TryParse(textBoxPID.Text, out PIDparse))
            {
                MessageBox.Show("The PID entered was not valid. Please enter a valid PID (6 numbers long)");
            }

            else
            {
                // Prompts the user for any last changes
                if (MessageBox.Show("Are you sure you want to check this device in?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLiteConnection connectAvailable = new SQLiteConnection(Login.connection);
                    connectAvailable.Open();
                    String queryAvailable = "SELECT Device FROM CheckOut WHERE Device = '" + textBoxDevice.Text + "';";
                    SQLiteCommand cmdCheck = new SQLiteCommand(queryAvailable, connectAvailable);
                    object check = cmdCheck.ExecuteScalar();

                    SQLiteConnection connectPID = new SQLiteConnection(Login.connection);
                    connectPID.Open();
                    String queryPID = "SELECT PID FROM Students WHERE PID = '" + textBoxPID.Text + "';";
                    SQLiteCommand cmdCheckPID = new SQLiteCommand(queryPID, connectPID);
                    object checkPID = cmdCheckPID.ExecuteScalar();

                    // Ensures the student has checked out a device previously 
                    if (checkPID == null)
                    {
                        MessageBox.Show("The student is not registered. Please verify that the Student's PID is correct.");
                    }
                    
                    // Ensures the device has not already been checked in
                    else if (check != null) 
                    {
                        SQLiteConnection connect = new SQLiteConnection(Login.connection);
                        try
                        {
                            // If the student is in the database and the device is not already checked in, update the database and check in the device
                            String[] queries = new String[3];

                            queries[0] = "UPDATE History SET CheckInDate = @CheckInDate, ReturnComments = @ReturnComments WHERE SerialNumber = @SerialNumber AND PID = @PID";
                            queries[1] = "UPDATE Device SET CheckOut = 'False' WHERE SerialNumber = @SerialNumber AND Device = @Device";
                            queries[2] = "DELETE FROM CheckOut WHERE SerialNumber = @SerialNumber";

                            foreach (String query in queries)
                            {
                                SQLiteCommand cmd = new SQLiteCommand(query, connect);
                                connect.Open();

                                cmd.Parameters.AddWithValue("@CheckInDate", date);
                                cmd.Parameters.AddWithValue("@ReturnComments", textBoxComments.Text);
                                cmd.Parameters.AddWithValue("@PID", textBoxPID.Text);
                                cmd.Parameters.AddWithValue("@Device", textBoxDevice.Text);
                                cmd.Parameters.AddWithValue("@SerialNumber", textBoxSerial.Text);
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
                            connectAvailable.Close();
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
                        MessageBox.Show("This device is not checked out. Please verify the device name and serial number on the label.");
                    }

                }
                else
                {
                    // Discard changes
                }
            }
        }

        private void CheckIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void textBoxSerial_TextChanged(object sender, EventArgs e)
        {
            // Auto populate the device name when a valid serial number is entered
            textBoxDevice.Clear();
            textBoxPID.Clear();
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

            // Auto populate the PID according to the one in the database relating to that specific checkout instance

            SQLiteConnection connectAutoPID = new SQLiteConnection(Login.connection);
            connectAutoPID.Open();
            String autoPID = "SELECT PID FROM CheckOut WHERE SerialNumber = '" + serialNumber + "';";
            SQLiteCommand cmdAutoPID = new SQLiteCommand(autoPID, connectAutoPID);
            object auto = cmdAutoPID.ExecuteScalar();


            if (auto != null)
            {
                String queryPIDFill = "SELECT PID FROM CheckOut WHERE SerialNumber = '" + serialNumber + "';";
                SQLiteConnection connectPIDFill = new SQLiteConnection(Login.connection);
                DataSet ds = new DataSet();

                try
                {
                    connectPIDFill.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(queryPIDFill, connectPIDFill);

                    adapter.Fill(ds, "CheckOut");
                    connectPIDFill.Close();

                    textBoxPID.Text = ds.Tables["CheckOut"].Rows[0]["PID"].ToString();
                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.Message.ToString());
                }
                finally
                {
                    if (connectAutoPID.State == ConnectionState.Open)
                    {
                        connectAutoPID .Close();
                    }
                }
            }
        }
    }
}