using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //string connString = DataLayer.DB.ConnectionString;
                DataLayer.DB.ApplicationName = "WinDemo Application";
                DataLayer.DB.ConnectionTimeout = 5;
                SqlConnection conn = DataLayer.DB.GetSqlConnection();
                conn.Close();

                DataTable tableLog = DataLayer.ApplicationLog.GetLog("WinDemo Application");
                dataGridViewAppLog.DataSource = tableLog;

            }
            catch (SqlException sqlex)
            {
                // Connection error...
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void buttonGetEmployee_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.Employees es = new DataLayer.Employees();

                DataLayer.DB.EnableStatistics = true;

                DataLayer.Employee employee = es.GetEmployee(int.Parse(textBoxEID.Text));
                RefreshStatistics(DataLayer.DB.LastStatistics);

                DataLayer.DB.EnableStatistics = false;

                textBoxFName.Text = employee.FirstName;
                textBoxLName.Text = employee.LastName;
                textBoxDName.Text = employee.DepartmentName;
                labelDeptId.Text = employee.DepartmentId.ToString();
                labelOldName.Text = employee.DepartmentName;    // for concurrency

                DataLayer.ApplicationLog.Add4("Searched for user id: " + textBoxEID.Text);

                DataTable tableLog = DataLayer.ApplicationLog.GetLog("WinDemo Application");
                dataGridViewAppLog.DataSource = tableLog;


            }
            catch (SqlException sqlex)
            {
                // Connection error...
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void buttonDeleteLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataLayer.ApplicationLog.DeleteCommentsForApp("WinDemo Application");

                // Refresh log
                DataTable tableLog = DataLayer.ApplicationLog.GetLog("WinDemo Application");
                dataGridViewAppLog.DataSource = tableLog;

            }
            catch (SqlException sqlex)
            {
                // Connection error...
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void linkLabelUpdateDepartmentName_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // A search must first be performed
                if (textBoxEID.Text.Length > 0
                    && textBoxDName.Text.Length > 0)
                {
                    DataLayer.Employees employees = new DataLayer.Employees();
                    int deptId = int.Parse(labelDeptId.Text);
                    employees.UpdateDepartmentName(deptId, textBoxDName.Text, labelOldName.Text);

                    // Reload the data to refresh the hidden fields
                    buttonGetEmployee_Click(sender, null);

                }
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void buttonUpdateLog_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable table = (DataTable)dataGridViewAppLog.DataSource;
                DataLayer.DB.EnableStatistics = true;
                DataTable tableRes = DataLayer.ApplicationLog.UpdateLogChanges(table);
                RefreshStatistics(DataLayer.DB.LastStatistics);
                DataLayer.DB.EnableStatistics = false;
                dataGridViewAppLog.DataSource = tableRes;
            }
            catch (SqlException sqlex)
            {
                // Connection error...
                System.Windows.Forms.MessageBox.Show(this, sqlex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (DBConcurrencyException cex)
            {
                // Concurrency error...
                System.Windows.Forms.MessageBox.Show(this, cex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch { }
        }

        private void RefreshStatistics(DataLayer.ConnectionStatistics connectionStatistics)
        {
            listViewStats.Items.Clear();
            foreach (string key in connectionStatistics.OriginalStats.Keys)
            {
                ListViewItem lvi = new ListViewItem(key);
                lvi.SubItems.Add(connectionStatistics.OriginalStats[key].ToString());
                listViewStats.Items.Add(lvi);
            }
        }

        private void dataGridViewAppLog_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
