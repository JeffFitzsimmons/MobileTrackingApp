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
    public partial class EditStudent : Form
    {
        public EditStudent()
        {
            InitializeComponent();

            String query = "SELECT FirstName, LastName, PID FROM Students WHERE PID = '" + EditDatabase.studentPIDSaved + "'";
            SQLiteConnection connect = new SQLiteConnection(Login.connection);

            try
            {
                DataTable dt = new DataTable();
                connect.Open();
                var da = new SQLiteDataAdapter(query, connect);
                da.Fill(dt);
                connect.Close();

                foreach (DataRow dr in dt.Rows)
                {
                    textBoxPID.Text = dr["PID"].ToString();
                    textBoxFirstName.Text = dr["FirstName"].ToString();
                    textBoxLastName.Text = dr["LastName"].ToString();

                    textBoxNewPID.Text = dr["PID"].ToString();
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

        private void EditStudent_Load(object sender, EventArgs e)
        {

        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            EditDatabase form = new EditDatabase();
            form.Show();

            this.Dispose();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to change this student's information?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SQLiteConnection connect = new SQLiteConnection(Login.connection);

                try
                {
                    String[] queries = new String[3];

                    queries[0] = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, PID = @PID WHERE PID = '" + textBoxPID.Text + "';";
                    queries[1] = "UPDATE HISTORY SET PID = @PID WHERE PID = '" + textBoxPID.Text + "';";
                    queries[2] = "UPDATE CheckOut SET PID = @PID WHERE PID = '" + textBoxPID.Text + "';";

                    foreach (String query in queries)
                    {
                        SQLiteCommand cmd = new SQLiteCommand(query, connect);
                        connect.Open();
                        cmd.Parameters.AddWithValue("@FirstName", textBoxNewFirstName.Text);
                        cmd.Parameters.AddWithValue("@LastName", textBoxNewLastName.Text);
                        cmd.Parameters.AddWithValue("@PID", textBoxNewPID.Text);
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

                // Refresh back to Edit Database once record is updated
                this.Visible = false;

                EditDatabase form = new EditDatabase();
                form.Show();

                this.Dispose();
            }
            else
            {
                // Do Nothing and discard changes
            }
        }
    }
}
