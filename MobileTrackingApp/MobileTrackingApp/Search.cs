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

        private void Search_Load(object sender, EventArgs e)
        {

        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            String query = "SELECT * FROM History WHERE PID = '" + textBoxSearch.Text.ToString() + "' OR Device = '" + textBoxSearch.Text.ToString() + "';";

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
            if (e.KeyChar == (char)13)
            {
                SQLiteConnection connect = new SQLiteConnection(Login.connection);
                String query = "SELECT * FROM History WHERE PID = '" + textBoxSearch.Text.ToString() + "' OR Device = '" + textBoxSearch.Text.ToString() + "';";

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

        private void buttonShowCheckedOut_Click(object sender, EventArgs e)
        {
            SQLiteConnection connect = new SQLiteConnection(Login.connection);
            String query = "SELECT * From CheckOut";

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
