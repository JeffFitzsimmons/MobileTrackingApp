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
    public partial class CheckOut : Form
    {
        public CheckOut()
        {
            InitializeComponent();
        }

        private void buttonCheckOut_Click(object sender, EventArgs e)
        {
            

            if (string.IsNullOrWhiteSpace(textBoxPID.Text))
            {
                MessageBox.Show("Please enter the student's PID.");
            }

            // Code for converting necessary PID and Date fields so the database doesn't have problems
            int PIDparse;
            String checkOutDate = dateTimeCheckOut.Value.ToShortDateString();
            String dueDate = dateTimeDueDate.Value.ToShortDateString();
            int pid = Int32.Parse(textBoxPID.Text);

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
                if (MessageBox.Show("Are you sure you want check this device out? (Make sure to verify the check out date)", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    SQLiteConnection connect = new SQLiteConnection(Login.connection);
                    try
                    {
                        String studentPID = textBoxPID.Text.ToString();
                        String[] queries = new String[2];

                        queries[0] = "INSERT INTO CheckOut (Device, SerialNumber, PID, CheckOutDate, DueDate, Comments, Assets) VALUES (@Device, @SerialNumber, @PID, @CheckOutDate, @DueDate, @Comments, @Assets)";
                        queries[1] = "UPDATE Device SET CheckOut = 'True' WHERE SerialNumber = @SerialNumber AND Device = @Device";
                        //queries[2] = "INSERT INTO CheckOut (FirstName, LastName) SELECT FirstName, LastName FROM Students WHERE PID = '" + studentPID + "';";
                        foreach (String query in queries)
                        {
                            SQLiteCommand cmd = new SQLiteCommand(query, connect);
                            connect.Open();

                            cmd.Parameters.AddWithValue("@Device", textBoxDevice.Text);
                            cmd.Parameters.AddWithValue("@SerialNumber", textBoxSerial.Text);
                            cmd.Parameters.AddWithValue("@PID", pid);
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
                    // Discard changes
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

        private void CheckOut_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
