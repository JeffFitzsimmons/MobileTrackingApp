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
    public partial class Login : Form
    {
        public static String connection = "Data Source=PropelDB.sqlite; Version=3;";
        
        public Login()
        {
            InitializeComponent();
        }

        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            // Initial error checking for blank username or password
            if (textBoxUsername.Text.ToString() == "")
            {
                MessageBox.Show("Please enter your username");
            }

            else if (textBoxPassword.Text.ToString() == "")
            {
                MessageBox.Show("Please enter your password");
            }
            else
            {
                // Check credentials against database for login
                SQLiteConnection connect = new SQLiteConnection(Login.connection);
                bool login = false;                    
                DataSet ds = new DataSet();
                String query = "SELECT Username, Password FROM Users;";

                try
                {
                    connect.Open();
                    SQLiteDataAdapter da = new SQLiteDataAdapter(query, connect);
                    da.Fill(ds, "Users");
                    connect.Close();

                    int i = 0;
                    foreach (DataRow dr in ds.Tables[0].Rows)
                    {
                        if ((string)ds.Tables["Users"].Rows[i]["Username"] == textBoxUsername.Text.ToString() && (string)ds.Tables["Users"].Rows[i]["Password"] == textBoxPassword.Text.ToString())
                        {
                            login = true;
                            break;
                        }
                        i++;
                    }
                    
                    if (login == true && textBoxUsername.Text == "admin")
                    {
                        // Save the login date and time to database
                        String loginDate = DateTime.Now.ToString();
                        SQLiteConnection connectLog = new SQLiteConnection(Login.connection);
                        try
                        {
                            String queryLog = "UPDATE Users SET LastLogin = @LastLogin WHERE Username = '" + textBoxUsername.Text + "';";
                            SQLiteCommand cmd = new SQLiteCommand(queryLog, connectLog);
                            connectLog.Open();
                            cmd.Parameters.AddWithValue("@LastLogin", loginDate);
                            cmd.ExecuteNonQuery();
                            connectLog.Close();
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
                            else if (connectLog.State == ConnectionState.Open)
                            {
                                connectLog.Close();
                            }
                        }
                        
                        //User has administrator rights, Edit Database is available
                        this.Visible = false;

                        EditDatabase form = new EditDatabase();
                        form.Visible = true;
                    }
                    else if (login == true && textBoxUsername.Text != "admin")
                    {
                        // Save the login date and time to database
                        String loginDate = DateTime.Now.ToString();
                        SQLiteConnection connectLog = new SQLiteConnection(Login.connection);
                        try
                        {
                            String queryLog = "UPDATE Users SET LastLogin = @LastLogin WHERE Username = '" + textBoxUsername.Text + "';";
                            SQLiteCommand cmd = new SQLiteCommand(queryLog, connectLog);
                            connectLog.Open();
                            cmd.Parameters.AddWithValue("@LastLogin", loginDate);
                            cmd.ExecuteNonQuery();
                            connectLog.Close();
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
                            else if (connectLog.State == ConnectionState.Open)
                            {
                                connectLog.Close();
                            }
                        }

                        // User is not admin, edit database is not available
                        this.Visible = false;

                        Home form = new Home();
                        form.Visible = true;
                    }
                    else
                    {
                        labelAlert.Text = "Invalid username or password";
                    }

                }
                catch (SQLiteException exception)
                {
                    MessageBox.Show(exception.ToString());
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
