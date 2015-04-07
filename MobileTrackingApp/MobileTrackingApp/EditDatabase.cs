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

        public static String studentPIDSaved;
        
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
           

            // Check for any blank fields
            if (string.IsNullOrWhiteSpace(textBoxNewDevice.Text))
            {
                MessageBox.Show("Please type in the device name.");
            }

            if (string.IsNullOrWhiteSpace(textBoxNewSerial.Text))
            {
                MessageBox.Show("Please use the scanner or manually input the device serial number.");
            }

            if (string.IsNullOrWhiteSpace(textBoxNewCheckOut.Text))
            {
                MessageBox.Show("Please indicate the correct check out date.");
            }

            if (string.IsNullOrWhiteSpace(textBoxNewDueDate.Text))
            {
                MessageBox.Show("Please indicate the correct due date.");
            }

            //if (string.IsNullOrWhiteSpace(textBoxNewCheckIn.Text))
            //{
            //    MessageBox.Show("Please indicate the correct check in date.");
            //}

            if (string.IsNullOrWhiteSpace(textBoxNewDueDate.Text))
            {
                MessageBox.Show("Please indicate the correct due date.");
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
            
            else
            {
                if (MessageBox.Show("Are you sure you want to change the information in the database?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    SQLiteConnection connect = new SQLiteConnection(Login.connection);

                    try
                    {
                        String[] queries = new String[2];
                        queries[0] = "UPDATE History SET CheckOutDate = @CheckOutDate, DueDate = @DueDate, Assets = @Assets, Comments = @Comments, CheckInDate = @CheckInDate, ReturnComments = @ReturnComments " +
                            "WHERE PID = '" + textBoxPID.Text + "' AND CheckOutDate = '" + textBoxCheckOut.Text + "';"; 
                        queries[1] = "UPDATE CheckOut SET CheckOutDate = @CheckOutDate, DueDate = @DueDate, Assets = @Assets, Comments = @Comments " +
                            "WHERE CheckOutDate = '" + textBoxCheckOut.Text + "';";

                        foreach (String query in queries)
                        {
                            SQLiteCommand cmd = new SQLiteCommand(query, connect);
                            connect.Open();

                            cmd.Parameters.AddWithValue("@CheckOutDate", textBoxNewCheckOut.Text);
                            cmd.Parameters.AddWithValue("@DueDate", textBoxNewDueDate.Text);
                            cmd.Parameters.AddWithValue("@CheckInDate", textBoxNewCheckIn.Text);
                            cmd.Parameters.AddWithValue("@Comments", textBoxNewComments.Text);
                            cmd.Parameters.AddWithValue("@Assets", textBoxNewAsset.Text);
                            cmd.Parameters.AddWithValue("@ReturnComments", textBoxNewReturnComments.Text);
                            cmd.ExecuteNonQuery();
                            connect.Close();
                        }
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

        private void EditDatabase_Load(object sender, EventArgs e)
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

        private void dataGridViewSearch_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SQLiteConnection connect = new SQLiteConnection(Login.connection);

            if (e.RowIndex != -1) 
            {
                try
                {

                    String query = "SELECT * FROM History WHERE CheckOutDate = '" + dataGridViewSearch.Rows[e.RowIndex].Cells["CheckOutDate"].Value + "';";
                    DataTable dt = new DataTable();
                    connect.Open();
                    var da = new SQLiteDataAdapter(query, connect);
                    da.Fill(dt);
                    connect.Close();

                    foreach (DataRow dr in dt.Rows)
                    {
                        textBoxDevice.Text = dr["Device"].ToString();
                        textBoxSerial.Text = dr["SerialNumber"].ToString();
                        textBoxPID.Text = dr["PID"].ToString();
                        textBoxCheckOut.Text = dr["CheckOutDate"].ToString();
                        textBoxDueDate.Text = dr["DueDate"].ToString();
                        textBoxAsset.Text = dr["Assets"].ToString();
                        textBoxComments.Text = dr["Comments"].ToString();
                        textBoxCheckIn.Text = dr["CheckInDate"].ToString();
                        textBoxReturnComments.Text = dr["ReturnComments"].ToString();

                        textBoxNewDevice.Text = dr["Device"].ToString();
                        textBoxNewSerial.Text = dr["SerialNumber"].ToString();
                        textBoxNewPID.Text = dr["PID"].ToString();
                        textBoxNewCheckOut.Text = dr["CheckOutDate"].ToString();
                        textBoxNewDueDate.Text = dr["DueDate"].ToString();
                        textBoxNewAsset.Text = dr["Assets"].ToString();
                        textBoxNewComments.Text = dr["Comments"].ToString();
                        textBoxNewCheckIn.Text = dr["CheckInDate"].ToString();
                        textBoxNewReturnComments.Text = dr["ReturnComments"].ToString();

                        studentPIDSaved = dr["PID"].ToString();

                    }
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


                try
                {
                    String queryName = "SELECT * FROM Students WHERE PID = '" + dataGridViewSearch.Rows[e.RowIndex].Cells["PID"].Value + "';";
                    DataTable dtName = new DataTable();
                    connect.Open();
                    var daName = new SQLiteDataAdapter(queryName, connect);
                    daName.Fill(dtName);
                    connect.Close();

                    foreach (DataRow dr in dtName.Rows)
                    {
                        textBoxFirstName.Text = dr["FirstName"].ToString();
                        textBoxLastName.Text = dr["LastName"].ToString();

                        textBoxNewFirstName.Text = dr["FirstName"].ToString();
                        textBoxNewLastName.Text = dr["LastName"].ToString();
                    }

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
            else
            {

            }
        }

        private void buttonEditStudent_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            EditStudent form = new EditStudent();
            form.Show();

            this.Dispose();
        }
    }
}
