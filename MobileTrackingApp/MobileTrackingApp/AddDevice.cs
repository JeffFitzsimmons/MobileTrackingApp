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
    public partial class AddDevice : Form
    {
        public AddDevice()
        {
            InitializeComponent();
        }

        private void buttonAddDevice_Click(object sender, EventArgs e)
        {
            // Prompt for changes
            if (MessageBox.Show("Are you sure you want to add this device?", "Confirmation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                SQLiteConnection connect = new SQLiteConnection(Login.connection);

                // Adds the new Serial Number and Device Name to the Devices table in the database
                try
                    {
                        String query = "INSERT INTO Device (SerialNumber, Device) VALUES (@SerialNumber, @Device);";
                        SQLiteCommand cmd = new SQLiteCommand(query, connect);
                        connect.Open();

                        cmd.Parameters.AddWithValue("@SerialNumber", textBoxSerial.Text);
                        cmd.Parameters.AddWithValue("@Device", textBoxDevice.Text);
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

                    // Refresh after the device has been added
                    this.Visible = false;

                    AddDevice form = new AddDevice();
                    form.Show();

                    this.Dispose();
                }
            else
            {
                    // Discard changes
            }
        }

        private void AddDevice_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        // Return to the Edit Database form
        private void buttonBack_Click(object sender, EventArgs e)
        {
            this.Visible = false;

            EditDatabase form = new EditDatabase();
            form.Show();

            this.Dispose();
        }
    }
}
