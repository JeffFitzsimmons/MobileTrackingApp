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
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {           
            // Returns to login screen, admin is no longer logged in
            this.Visible = false;

            Login form = new Login();
            form.Show();

            this.Dispose();
        }

        
        private void EditDatabase_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            int PIDparse;
            int pid = Int32.Parse(textBoxPID.Text);
            String dateCheckOut = dateTimePicker1.Value.ToString();
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

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            AddDevice form = new AddDevice();
            form.Show();

            this.Dispose();
        }

        private void comboBoxSelect_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelect.SelectedIndex == 0)
            {
                listBoxList.Items.Clear();
                String query = "SELECT Device FROM Device";
                DataSet data = new DataSet();
                SQLiteConnection connect = new SQLiteConnection(Login.connection);

                try
                {
                    connect.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);
                    adapter.Fill(data, "Device");
                    connect.Close();

                    int i = 0;
                    foreach (DataRow row in data.Tables[0].Rows)
                    {
                        listBoxList.Items.Add(data.Tables["Device"].Rows[i]["Device"]);
                        i++;
                    }
                    listBoxList.Sorted = true;
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

            if (comboBoxSelect.SelectedIndex == 1)
            {
                listBoxList.Items.Clear();
                String query = "SELECT PID FROM Students";
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
                        listBoxList.Items.Add(data.Tables["Students"].Rows[i]["PID"]);
                        i++;
                    }
                    listBoxList.Sorted = true;
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
        }

        private void listBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxSelect.SelectedIndex == 0)
            {
                string deviceName = (string)listBoxList.SelectedItem.ToString();

                String query = "SELECT CheckOut.PID, CheckOut.SerialNumber, Checkout.Device, CheckOut.CheckOutDate, CheckOut.DueDate, CheckOut.CheckInDate, Checkout.Assets, CheckOut.Comments, Students.FirstName, Students.LastName FROM CheckOut INNER JOIN Students ON CheckOut.PID = Students.PID WHERE CheckOut.Device = '" + deviceName + "';";
                DataSet data = new DataSet();
                SQLiteConnection connect = new SQLiteConnection(Login.connection);

                try
                {
                    connect.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);

                    adapter.Fill(data, "CheckOut");
                    connect.Close();

                    textBoxPID.Text = data.Tables["CheckOut"].Rows[0]["PID"].ToString();
                    textBoxSerial.Text = data.Tables["CheckOut"].Rows[0]["SerialNumber"].ToString();
                    textBoxDevice.Text = data.Tables["Checkout"].Rows[0]["Device"].ToString();
                    textBoxCheckOut.Text = data.Tables["CheckOut"].Rows[0]["CheckOutDate"].ToString();
                    textBoxDueDate.Text = data.Tables["CheckOut"].Rows[0]["DueDate"].ToString();
                    textBoxCheckIn.Text = data.Tables["CheckOut"].Rows[0]["CheckInDate"].ToString();
                    textBoxAsset.Text = data.Tables["CheckOut"].Rows[0]["Assets"].ToString();
                    textBoxComments.Text = data.Tables["CheckOut"].Rows[0]["Comments"].ToString();


                    connect.Open();
                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(query, connect);

                    adapter2.Fill(data, "Students");
                    connect.Close();

                    textBoxFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                    textBoxLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();

                    //textBoxNewDevice.Text = data.Tables["Students"].Rows[0]["Device"].ToString();
                    //textBoxNewSerial.Text = data.Tables["Students"].Rows[0]["SerialNumber"].ToString();
                    //textBoxNewFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                    //textBoxNewLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();
                    //textBoxNewPID.Text = data.Tables["Students"].Rows[0]["PID"].ToString();
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
        }

        private void EditDatabase_Load(object sender, EventArgs e)
        {

        }
    }
}
