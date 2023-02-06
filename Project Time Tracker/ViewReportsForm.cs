using Elements.Database;
using System.Data.SQLite;

namespace Project_Time_Tracker
{
    public partial class ViewReportsForm : Form
    {
        public ViewReportsForm()
        {
            InitializeComponent();
        }

        private void ViewTimesForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
            cboReportType.SelectedIndex = 0;
        }

        #region FormObjects

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
        }

        private void cboReportType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetFields();
            if (cboReportType.SelectedIndex == 0)
            {
                dtpStart.Enabled = true;
                dtpEnd.Enabled = true;
                cboCustomerList.Enabled = true;
                cboProjectList.Enabled = true;
                txtNotes.Enabled = true;
            }
            else if (cboReportType.SelectedIndex == 1)
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                cboCustomerList.Enabled = true;
                cboProjectList.Enabled = false;
                txtNotes.Enabled = false;
            }
            else if (cboReportType.SelectedIndex == 2)
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                cboCustomerList.Enabled = false;
                cboProjectList.Enabled = true;
                txtNotes.Enabled = true;
            }
            else if (cboReportType.SelectedIndex == 3)
            {
                dtpStart.Enabled = false;
                dtpEnd.Enabled = false;
                cboCustomerList.Enabled = true;
                cboProjectList.Enabled = true;
                txtNotes.Enabled = true;
            }
        }

        private void cboCustomerList_EnabledChanged(object sender, EventArgs e)
        {
            if (!cboCustomerList.Enabled)
            {
                cboCustomerList.SelectedIndex = -1;
                cboCustomerList.Text = "";
                cbExactCustomer.Checked = false;
                cbExactCustomer.Enabled = false;
            }
            else
            {
                cbExactCustomer.Enabled = true;
            }
        }

        private void cboProjectList_EnabledChanged(object sender, EventArgs e)
        {
            if (!cboProjectList.Enabled)
            {
                cboProjectList.SelectedIndex = -1;
                cboProjectList.Text = "";
                cbExactProject.Checked = false;
                cbExactProject.Enabled = false;
            }
            else
            {
                cbExactProject.Enabled = true;
            }
        }

        private void txtNotes_EnabledChanged(object sender, EventArgs e)
        {
            if (!txtNotes.Enabled)
            {
                txtNotes.Text = "";
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (cboReportType.SelectedIndex == 0)
            {
                if (!string.IsNullOrEmpty(dtpStart.Value.ToString()) && !string.IsNullOrEmpty(dtpEnd.Value.ToString()))
                {
                    if (dtpStart.Value <= dtpEnd.Value)
                        SearchTimes();
                    else
                    {
                        MessageBox.Show("Start cannot be after End.");
                    }
                }
                else
                {
                    MessageBox.Show("Start and End must contain a valid datetime.");
                }
            }
            else if (cboReportType.SelectedIndex == 1)
            {
                SearchCustomers();
            }
            else if (cboReportType.SelectedIndex == 2)
            {
                SearchProjects();
            }
            else if (cboReportType.SelectedIndex == 3)
            {
                SearchAssignments();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Functions

        private void RefreshLists()
        {
            PopulateCustomerList();
            PopulateProjectList();
        }

        private void ResetFields()
        {
            dgvResults.DataSource = null;
            dtpStart.Value = DateTime.Now.AddDays(-30);
            dtpEnd.Value = DateTime.Now;
            cboCustomerList.SelectedIndex = -1;
            cboCustomerList.Text = "";
            cbExactCustomer.Checked = false;
            cboProjectList.SelectedIndex = -1;
            cboProjectList.Text = "";
            cbExactProject.Checked = false;
            txtNotes.Text = "";
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

        private void SearchTimes()
        {
            dgvResults.DataSource = null;

            SQLite.spl.Add(new SQLiteParameter("@Start", dtpStart.Value));
            SQLite.spl.Add(new SQLiteParameter("@End", dtpEnd.Value));
            string query = "select c.CustomerName, p.ProjectName, t.Start, t.End, t.Duration, t.DurationDecimal, t.TimeNotes from Times t " +
                "inner join CustomerProject cp on cp.CustomerProjectID = t.CustomerProjectID " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                "where date(t.Start) >= date(@Start) and date(t.End) <= date(@End)";

            if (!string.IsNullOrEmpty(cboCustomerList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerName", cboCustomerList.Text));
                if (cbExactCustomer.Checked)
                {
                    query += " and c.CustomerName = @CustomerName";
                }
                else
                {
                    query += " and c.CustomerName like '%' || @CustomerName || '%'";
                }
            }
            if (!string.IsNullOrEmpty(cboProjectList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", cboProjectList.Text));
                if (cbExactProject.Checked)
                {
                    query += " and p.ProjectName = @ProjectName";
                }
                else
                {
                    query += " and p.ProjectName like '%' || @ProjectName || '%'";
                }
            }
            if (!string.IsNullOrEmpty(txtNotes.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@TimeNotes", txtNotes.Text));
                query += " and t.TimeNotes like '%' || @TimeNotes || '%'";
            }
            query += " order by c.CustomerName, p.ProjectName, t.Start";

            dgvResults.DataSource = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void SearchCustomers()
        {
            dgvResults.DataSource = null;

            string query = "select c.CustomerName from Customers c";

            if (!string.IsNullOrEmpty(cboCustomerList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerName", cboCustomerList.Text));
                if (cbExactCustomer.Checked)
                {
                    query += " where c.CustomerName = @CustomerName";
                }
                else
                {
                    query += " where c.CustomerName like '%' || @CustomerName || '%'";
                }
            }
            query += " order by c.CustomerName";

            dgvResults.DataSource = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void SearchProjects()
        {
            dgvResults.DataSource = null;

            string query = "select p.ProjectName, case p.Active when 1 then 'Yes' else 'No' end Active, p.ProjectNotes from Projects p " +
                "where p.Active in (1, 0)";

            if (!string.IsNullOrEmpty(cboProjectList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", cboProjectList.Text));
                if (cbExactProject.Checked)
                {
                    query += " and p.ProjectName = @ProjectName";
                }
                else
                {
                    query += " and p.ProjectName like '%' || @ProjectName || '%'";
                }
            }
            if (!string.IsNullOrEmpty(txtNotes.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", txtNotes.Text));
                query += " and p.ProjectNotes like '%' || @ProjectNotes || '%'";
            }
            query += " order by p.ProjectName";

            dgvResults.DataSource = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void SearchAssignments()
        {
            dgvResults.DataSource = null;

            string query = "select c.CustomerName, p.ProjectName, case p.Active when 1 then 'Yes' else 'No' end Active, p.ProjectNotes from CustomerProject cp " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                "where p.Active in (1, 0)";

            if (!string.IsNullOrEmpty(cboCustomerList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerName", cboCustomerList.Text));
                if (cbExactCustomer.Checked)
                {
                    query += " and c.CustomerName = @CustomerName";
                }
                else
                {
                    query += " and c.CustomerName like '%' || @CustomerName || '%'";
                }
            }
            if (!string.IsNullOrEmpty(cboProjectList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", cboProjectList.Text));
                if (cbExactProject.Checked)
                {
                    query += " and p.ProjectName = @ProjectName";
                }
                else
                {
                    query += " and p.ProjectName like '%' || @ProjectName || '%'";
                }
            }
            if (!string.IsNullOrEmpty(txtNotes.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", txtNotes.Text));
                query += " and p.ProjectNotes like '%' || @ProjectNotes || '%'";
            }
            query += " order by c.CustomerName, p.ProjectName";

            dgvResults.DataSource = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        #endregion
    }
}