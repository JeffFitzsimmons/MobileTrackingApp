﻿using System;
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
     
            DateTimePicker dtp = new DateTimePicker();
            string date = dtp.Value.Date.ToShortDateString();

            // Check for any blank fields
            if (string.IsNullOrWhiteSpace(textBoxDevice.Text))
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
                        //String studentDevice = textBoxDevice.Text.ToString();
                        String query = "UPDATE Students SET CheckInDate = @CheckInDate WHERE PID = " + studentPID + ";";
                        SQLiteCommand cmd = new SQLiteCommand(query, connect);
                        connect.Open();

                        cmd.Parameters.AddWithValue("@CheckInDate", date);
                        cmd.ExecuteNonQuery();
                        connect.Close();
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
