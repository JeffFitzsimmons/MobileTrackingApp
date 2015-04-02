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
        public Search()
        {
            InitializeComponent();

            comboBoxSearch.SelectedIndex = 0;
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

            if (comboBoxSearch.SelectedIndex == 0)
            {
                //string studentName = (string)listBoxItems.SelectedItem.ToString();
                string studentPID = (string)textBoxSearch.Text.ToString();

                String query = "SELECT History.PID, History.SerialNumber, History.Device, history.CheckOutDate, History.DueDate, History.CheckInDate, History.Assets, History.Comments, History.ReturnComments, Students.FirstName, Students.LastName " +
                "FROM History INNER JOIN Students ON History.PID = Students.PID " +
                "WHERE History.PID = '" + studentPID + "';";
                DataSet data = new DataSet();
                SQLiteConnection connect = new SQLiteConnection(Login.connection);

                try
                {
                    connect.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);

                    adapter.Fill(data, "History");
                    connect.Close();

                    textBoxPID.Text = data.Tables["History"].Rows[0]["PID"].ToString();
                    textBoxSerial.Text = data.Tables["History"].Rows[0]["SerialNumber"].ToString();
                    textBoxDevice.Text = data.Tables["History"].Rows[0]["Device"].ToString();
                    textBoxCheckOut.Text = data.Tables["History"].Rows[0]["CheckOutDate"].ToString();
                    textBoxDueDate.Text = data.Tables["History"].Rows[0]["DueDate"].ToString();
                    textBoxCheckIn.Text = data.Tables["History"].Rows[0]["CheckInDate"].ToString();
                    textBoxAsset.Text = data.Tables["History"].Rows[0]["Assets"].ToString();
                    textBoxComments.Text = data.Tables["History"].Rows[0]["Comments"].ToString();
                    textBoxReturnComments.Text = data.Tables["History"].Rows[0]["ReturnComments"].ToString();


                    connect.Open();
                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(query, connect);

                    adapter2.Fill(data, "Students");
                    connect.Close();

                    textBoxFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                    textBoxLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();
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

            if (comboBoxSearch.SelectedIndex == 1)
            {
                string deviceName = (string)listBoxItems.SelectedItem.ToString();

                String query = "SELECT History.PID, History.SerialNumber, History.Device, history.CheckOutDate, History.DueDate, History.CheckInDate, History.Assets, History.Comments, History.ReturnComments, Students.FirstName, Students.LastName " + 
                "FROM History INNER JOIN Students ON History.PID = Students.PID " + 
                "WHERE History.Device = '" + deviceName + "';";
                DataSet data = new DataSet();
                SQLiteConnection connect = new SQLiteConnection(Login.connection);

                try
                {
                    connect.Open();
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(query, connect);

                    adapter.Fill(data, "History");
                    connect.Close();

                    //textBoxPID.Text = data.Tables["History"].Rows[0]["PID"].ToString() + "   " + data.Tables["History"].Rows[0]["PID"].ToString();
                    textBoxPID.Text = data.Tables["History"].Rows[0]["PID"].ToString();
                    textBoxSerial.Text = data.Tables["History"].Rows[0]["SerialNumber"].ToString();
                    textBoxDevice.Text = data.Tables["History"].Rows[0]["Device"].ToString();
                    textBoxCheckOut.Text = data.Tables["History"].Rows[0]["CheckOutDate"].ToString();
                    textBoxDueDate.Text = data.Tables["History"].Rows[0]["DueDate"].ToString();
                    textBoxCheckIn.Text = data.Tables["History"].Rows[0]["CheckInDate"].ToString();
                    textBoxAsset.Text = data.Tables["History"].Rows[0]["Assets"].ToString();
                    textBoxComments.Text = data.Tables["History"].Rows[0]["Comments"].ToString();
                    textBoxReturnComments.Text = data.Tables["History"].Rows[0]["ReturnComments"].ToString();

                    connect.Open();
                    SQLiteDataAdapter adapter2 = new SQLiteDataAdapter(query, connect);

                    adapter2.Fill(data, "Students");
                    connect.Close();

                    textBoxFirstName.Text = data.Tables["Students"].Rows[0]["FirstName"].ToString();
                    textBoxLastName.Text = data.Tables["Students"].Rows[0]["LastName"].ToString();
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

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void comboBoxSearch_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            if (comboBoxSearch.SelectedIndex == 0)
            {
                listBoxItems.Items.Clear();
                String studentPIDSearch = textBoxSearch.Text.ToString();
                String query = "SELECT FirstName, LastName FROM Students WHERE PID = '" + studentPIDSearch + "'";
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
                        listBoxItems.Items.Add(data.Tables["Students"].Rows[i]["LastName"] + ", " + data.Tables["Students"].Rows[i]["FirstName"]);
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

            if (comboBoxSearch.SelectedIndex == 1)
            {
                listBoxItems.Items.Clear();
                String deviceSearch = textBoxSearch.Text.ToString();
                String query = "SELECT Device, SerialNumber FROM Device WHERE Device = '" + deviceSearch + "'";
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
                        listBoxItems.Items.Add(data.Tables["Device"].Rows[i]["Device"]);
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
        }
    }
}
