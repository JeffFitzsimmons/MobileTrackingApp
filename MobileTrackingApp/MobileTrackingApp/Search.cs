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
using System.Globalization;

namespace MobileTrackingApp
{
    public partial class Search : Form
    {
        public Search()
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

        private void Search_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            // Get the database info for the selected PID or device name
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            String query = "SELECT Students.FirstName, Students.LastName, History.PID, History.SerialNumber, History.Device, History.CheckOutDate, History.Assets, History.Comments, History.DueDate, History.CheckInDate, History.ReturnComments FROM History LEFT JOIN Students ON History.PID = Students.PID WHERE History.PID = '" + textBoxSearch.Text.ToString() + "' OR History.Device = '" + textBoxSearch.Text.ToString() + "';";
            
            try
            {
                DataSet data = new DataSet();
                connect.Open();
                var da = new SQLiteDataAdapter(query, connect);
                da.Fill(data);
                dataGridViewSearch.DataSource = data.Tables[0].DefaultView;
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

        private void textBoxSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Same code as previous function, but adds functionality for the Enter button instead of clicking the Search button
            if (e.KeyChar == (char)13)
            {
                SQLiteConnection connect = new SQLiteConnection(Login.connection);
                String query = "SELECT Students.FirstName, Students.LastName, History.PID, History.SerialNumber, History.Device, History.CheckOutDate, History.Assets, History.Comments, History.DueDate, History.CheckInDate, History.ReturnComments FROM History LEFT JOIN Students ON History.PID = Students.PID WHERE History.PID = '" + textBoxSearch.Text.ToString() + "' OR History.Device = '" + textBoxSearch.Text.ToString() + "';";

                try
                {
                    DataSet data = new DataSet();
                    connect.Open();
                    var da = new SQLiteDataAdapter(query, connect);
                    da.Fill(data);
                    dataGridViewSearch.DataSource = data.Tables[0].DefaultView;
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

        // Shows all available devices that are not checked out
        private void buttonShowAvailable_Click(object sender, EventArgs e)
        {
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            String query = "SELECT SerialNumber, Device FROM Device WHERE CheckOut = 'False';";

            try
            {
                DataSet data = new DataSet();
                connect.Open();
                var da = new SQLiteDataAdapter(query, connect);
                da.Fill(data);
                dataGridViewSearch.DataSource = data.Tables[0].DefaultView;
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

        // Show all devices that are currently checked out, including info about the student and checkout details
        private void buttonShowCheckedOut_Click(object sender, EventArgs e)
        {
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            String query = "SELECT Students.FirstName, Students.LastName, CheckOut.PID, CheckOut.SerialNumber, CheckOut.Device, CheckOut.CheckOutDate, CheckOut.Assets, CheckOut.Comments, CheckOut.DueDate FROM CheckOut LEFT JOIN Students ON CheckOut.PID = Students.PID";

            try
            {
                DataSet data = new DataSet();
                connect.Open();
                var da = new SQLiteDataAdapter(query, connect);
                da.Fill(data);
                dataGridViewSearch.DataSource = data.Tables[0].DefaultView;
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

        private void buttonTime_Click(object sender, EventArgs e)
        {
            String startDate = dateTimePickerStart.Value.ToString();
            String endDate = dateTimePickerEnd.Value.ToString();
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            String query = "SELECT * FROM History WHERE CheckOutDate >= '" + startDate + "' AND CheckOutDate <= '" + endDate + "';";
            
            try
            {
                DataSet data = new DataSet();
                connect.Open();
                var da = new SQLiteDataAdapter(query, connect);
                da.Fill(data);
                dataGridViewSearch.DataSource = data.Tables[0].DefaultView;
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
