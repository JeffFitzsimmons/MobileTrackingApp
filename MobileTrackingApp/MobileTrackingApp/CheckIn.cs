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

            if (string.IsNullOrWhiteSpace(textBoxPID.Text))
            {
                MessageBox.Show("Please enter the student's PID.");
            }
            else
            {
                int pid = Int32.Parse(textBoxPID.Text);
            }

            String date = dateTimeSelect.Value.ToString();

            // Check for any blank fields
            if (string.IsNullOrWhiteSpace(textBoxDevice.Text))
            {
                MessageBox.Show("Please type in the device name.");
            }

            if (string.IsNullOrWhiteSpace(textBoxSerial.Text))
            {
                MessageBox.Show("Please use the scanner or manually input the device serial number.");
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
                    SQLiteConnection connect = new SQLiteConnection(Login.connection);
                    try
                    {
                        String studentPID = textBoxPID.Text.ToString();
                        String studentDevice = textBoxDevice.Text.ToString();
                        String studentSerial = textBoxSerial.Text.ToString();
                        String[] queries = new String[2];

                        //queries[0] = "UPDATE CheckOut SET CheckInDate = @CheckInDate, ReturnComments = @ReturnComments WHERE PID = '" + studentPID + "' AND Device = '" + studentDevice + "' AND SerialNumber = '" + studentSerial + "';";
                        //queries[1] = "UPDATE Device SET CheckOut = 'True' SerialNumber = '" + studentSerial + "' AND Device = '" + studentDevice + "';";
                        queries[0] = "UPDATE CheckOut SET CheckInDate = @CheckInDate, ReturnComments = @ReturnComments WHERE PID = @PID AND Device = @Device AND SerialNumber = @SerialNumber";
                        queries[1] = "UPDATE Device SET CheckOut = 'True' WHERE SerialNumber = @SerialNumber AND Device = @Device";

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
                    // Discard changes
                }
            }
        }

        private void CheckIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
