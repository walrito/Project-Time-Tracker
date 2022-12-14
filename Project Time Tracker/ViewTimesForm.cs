using Elements.Database;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Time_Tracker
{
    public partial class ViewTimesForm : Form
    {
        public ViewTimesForm()
        {
            InitializeComponent();
        }

        private void ViewTimesForm_Load(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void RefreshAll()
        {
            dtpStart.Value = DateTime.Now.AddDays(-30);
            dtpEnd.Value = DateTime.Now;
            PopulateCustomerList();
            PopulateProjectList();
            cbCustomer.Checked = false;
            cbProject.Checked = false;
            dgvTimeResults.DataSource = null;
        }

        private void PopulateCustomerList()
        {
            cboCustomerList.DataSource = null;
            cboCustomerList.DisplayMember = "CustomerName";
            cboCustomerList.ValueMember = "CustomerId";
            cboCustomerList.DataSource = Customer.GenerateCustomerList(false);
            cboCustomerList.SelectedIndex = -1;
        }

        private void PopulateProjectList()
        {
            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectID";
            cboProjectList.DataSource = Project.GenerateProjectList(true, false);
            cboProjectList.SelectedIndex = -1;
        }

        private void FindTimes()
        {
            dgvTimeResults.DataSource = null;

            SQLite.spl.Add(new SQLiteParameter("@Start", dtpStart.Value));
            SQLite.spl.Add(new SQLiteParameter("@End", dtpEnd.Value));
            string query = "select c.CustomerName, p.ProjectName, p.ProjectNotes, t.Start, t.End, t.Duration, t.TimeNotes from Times t";
            query += " inner join Projects p on p.ProjectID = t.ProjectID inner join Customers c on c.CustomerID = p.CustomerID";
            query += " where date(t.Start) >= date(@Start) and date(t.End) <= date(@End)";
            if (cbCustomer.Checked && cboCustomerList.SelectedIndex > -1)
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerID", cboCustomerList.SelectedValue));
                query += " and c.CustomerID = @CustomerID";
            }
            if (cbProject.Checked && cboProjectList.SelectedIndex > -1)
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectID", cboProjectList.SelectedValue));
                query += " and p.ProjectID = @ProjectID";
            }

            dgvTimeResults.DataSource = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshAll();
        }

        private void cbCustomer_CheckedChanged(object sender, EventArgs e)
        {
            if (cbCustomer.Checked)
            {
                cboCustomerList.Enabled = true;
            }
            else
            {
                cboCustomerList.SelectedIndex = -1;
                cboCustomerList.Enabled = false;
            }
        }

        private void cbProject_CheckedChanged(object sender, EventArgs e)
        {
            if (cbProject.Checked)
            {
                cboProjectList.Enabled = true;
            }
            else
            {
                cboProjectList.SelectedIndex = -1;
                cboProjectList.Enabled = false;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (dtpStart.Value <= dtpEnd.Value)
            {
                FindTimes();
            }
            else
            {
                MessageBox.Show("Start date cannot be after end date.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}