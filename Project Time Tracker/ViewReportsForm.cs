using Elements.Database;
using Elements.Logger;
using System.Data;
using System.Data.SQLite;
using System.Net;
using System.Text;

namespace Project_Time_Tracker
{
    public partial class ViewReportsForm : Form
    {
        DataTable? dtReport = null;

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

        private void dtpStart_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value) { dtpEnd.Value = dtpStart.Value; }
        }

        private void dtpEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dtpEnd.Value < dtpStart.Value) { dtpStart.Value = dtpEnd.Value; }
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
            if (dtReport != null) { BuildHtml(dtReport); }
        }

        private void btnExportToCsv_Click(object sender, EventArgs e)
        {
            if (dtReport != null)
            {
                if (sfdExport.ShowDialog() == DialogResult.OK)
                {
                    ExportReport(dtReport, sfdExport.FileName);
                }
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
            wvResults.Source = new Uri("about:blank");
            dtReport = null;
            dtpStart.Value = DateTime.Now.AddDays(-6);
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
            SQLite.spl.Add(new SQLiteParameter("@Start", dtpStart.Value));
            SQLite.spl.Add(new SQLiteParameter("@End", dtpEnd.Value));

            string whereClause = "where date(t.Start) >= date(@Start) and date(t.End) <= date(@End) ";
            if (!string.IsNullOrEmpty(cboCustomerList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerName", cboCustomerList.Text));
                if (cbExactCustomer.Checked)
                {
                    whereClause += "and c.CustomerName = @CustomerName ";
                }
                else
                {
                    whereClause += "and c.CustomerName like '%' || @CustomerName || '%' ";
                }
            }
            if (!string.IsNullOrEmpty(cboProjectList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", cboProjectList.Text));
                if (cbExactProject.Checked)
                {
                    whereClause += "and p.ProjectName = @ProjectName ";
                }
                else
                {
                    whereClause += "and p.ProjectName like '%' || @ProjectName || '%' ";
                }
            }
            if (!string.IsNullOrEmpty(txtNotes.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@TimeNotes", txtNotes.Text));
                whereClause += "and t.TimeNotes like '%' || @TimeNotes || '%' ";
            }

            string query = "with TimesList as ( " +
                "select '1' Type, t.CustomerProjectID, t.Start, t.End, t.Duration, t.DurationDecimal, t.TimeNotes from Times t " +
                "inner join CustomerProject cp on cp.CustomerProjectID = t.CustomerProjectID " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                whereClause +
                "union " +
                "select '0' Type, t.CustomerProjectID, date(t.Start) Start, '', '', round(sum(t.durationdecimal), 2), '' from Times t " +
                "inner join CustomerProject cp on cp.CustomerProjectID = t.CustomerProjectID " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                whereClause +
                "group by date(t.Start), t.CustomerProjectID) " +
                "select tl.Type, c.CustomerName 'Customer Name', p.ProjectName 'Project Name', tl.Start, tl.End, tl.Duration, tl.DurationDecimal 'Duration Decimal', tl.TimeNotes 'Time Notes' from TimesList tl " +
                "inner join CustomerProject cp on cp.CustomerProjectID = tl.CustomerProjectID " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                "order by date(tl.Start), dense_rank() over (order by date(tl.Start), c.CustomerName, p.ProjectName), tl.Type, c.CustomerName, p.ProjectName";

            dtReport = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void SearchCustomers()
        {
            string whereClause = "where c.CustomerID > -1 ";
            if (!string.IsNullOrEmpty(cboCustomerList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerName", cboCustomerList.Text));
                if (cbExactCustomer.Checked)
                {
                    whereClause += "and c.CustomerName = @CustomerName ";
                }
                else
                {
                    whereClause += "and c.CustomerName like '%' || @CustomerName || '%' ";
                }
            }

            string query = "select '1' Type, c.CustomerName 'Customer Name' from Customers c " +
                whereClause +
                "order by c.CustomerName";

            dtReport = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void SearchProjects()
        {
            string whereClause = "where p.ProjectID > -1 ";
            if (!string.IsNullOrEmpty(cboProjectList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", cboProjectList.Text));
                if (cbExactProject.Checked)
                {
                    whereClause += "and p.ProjectName = @ProjectName ";
                }
                else
                {
                    whereClause += "and p.ProjectName like '%' || @ProjectName || '%' ";
                }
            }
            if (!string.IsNullOrEmpty(txtNotes.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", txtNotes.Text));
                whereClause += "and p.ProjectNotes like '%' || @ProjectNotes || '%' ";
            }

            string query = "select '1' Type, p.ProjectName 'Project Name', case p.Active when 1 then 'Yes' else 'No' end Active, p.ProjectNotes 'Project Notes' from Projects p " +
                whereClause +
                "order by p.ProjectName";

            dtReport = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void SearchAssignments()
        {
            string whereClause = "where p.Active in (1, 0) ";
            if (!string.IsNullOrEmpty(cboCustomerList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@CustomerName", cboCustomerList.Text));
                if (cbExactCustomer.Checked)
                {
                    whereClause += "and c.CustomerName = @CustomerName ";
                }
                else
                {
                    whereClause += "and c.CustomerName like '%' || @CustomerName || '%' ";
                }
            }
            if (!string.IsNullOrEmpty(cboProjectList.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectName", cboProjectList.Text));
                if (cbExactProject.Checked)
                {
                    whereClause += "and p.ProjectName = @ProjectName ";
                }
                else
                {
                    whereClause += "and p.ProjectName like '%' || @ProjectName || '%' ";
                }
            }
            if (!string.IsNullOrEmpty(txtNotes.Text))
            {
                SQLite.spl.Add(new SQLiteParameter("@ProjectNotes", txtNotes.Text));
                whereClause += "and p.ProjectNotes like '%' || @ProjectNotes || '%' ";
            }

            string query = "select '1' Type, c.CustomerName 'Customer Name', p.ProjectName 'Project Name', case p.Active when 1 then 'Yes' else 'No' end Active, p.ProjectNotes 'Project Notes' from CustomerProject cp " +
                "inner join Customers c on c.CustomerID = cp.CustomerID " +
                "inner join Projects p on p.ProjectID = cp.ProjectID " +
                whereClause +
                "order by c.CustomerName, p.ProjectName";

            dtReport = SQLite.FillDataTable(query, SQLite.spl, "ProjectTimeTracker");
        }

        private void BuildHtml(DataTable dt)
        {
            try
            {
                StringBuilder html = new();
                string? nextRowType = "";
                bool firstDataRow = false;

                html.AppendLine("<!DOCTYPE html>");
                html.AppendLine("<head>");
                html.AppendLine("   <title>Project Time Tracker Report</title>");
                html.AppendLine("   <style>");
                html.AppendLine("       .reportTable { background-color: #EEEEEE; width: 100%; text-align: left; border-collapse: collapse; white-space: pre-line; }");
                html.AppendLine("       .reportTable td, .reportTable th { border: 1px solid #AAAAAA; padding: 3px 2px; }");
                html.AppendLine("       .reportTable tbody td { font-size: 13px; -webkit-touch-callout:all; -webkit-user-select:all; -khtml-user-select:all; -moz-user-select:all; -ms-user-select:all; -o-user-select:all; user-select:all; }");
                html.AppendLine("       .reportTable thead { background: #AABCCA; border-bottom: 2px solid #444444; }");
                html.AppendLine("       .reportTable thead th { font-size: 15px; font-weight: bold; text-align: center; }");
                html.AppendLine("       .summaryRow { background: #AAAAAA; font-weight: bold; }");
                html.AppendLine("       .dataRow tr:nth-child(odd) { background: #C8DDED; }");
                html.AppendLine("   </style>");
                html.AppendLine("</head>");
                html.AppendLine("<body>");
                html.AppendLine("   <table class='reportTable'>");
                html.AppendLine("       <thead>");
                html.AppendLine("           <tr>");
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    html.AppendLine("               <th>" + WebUtility.UrlDecode(WebUtility.HtmlEncode((dt.Columns[i].ToString()))) + "</th>");
                }
                html.AppendLine("           </tr>");
                html.AppendLine("       </thead>");
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    nextRowType = i + 1 < dt.Rows.Count ? dt.Rows[i + 1][0].ToString() : "";
                    if (i == 0 || dt.Rows[i][0].ToString() == "0") { firstDataRow = true; };
                    if (dt.Rows[i][0].ToString() == "0")
                    {
                        html.AppendLine("       <tbody class='summaryRow'>");
                        html.AppendLine("           <tr>");
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            html.AppendLine("               <td>" + WebUtility.UrlDecode(WebUtility.HtmlEncode((dt.Rows[i][j].ToString()))) + "</td>");
                        }
                        html.AppendLine("           </tr>");
                        html.AppendLine("       </tbody>");
                    }
                    else if (dt.Rows[i][0].ToString() == "1")
                    {
                        if (firstDataRow) { html.AppendLine("       <tbody class='dataRow'>"); firstDataRow = false; }
                        html.AppendLine("           <tr>");
                        for (int j = 1; j < dt.Columns.Count; j++)
                        {
                            html.AppendLine("               <td>" + WebUtility.UrlDecode(WebUtility.HtmlEncode((dt.Rows[i][j].ToString()))) + "</td>");
                        }
                        html.AppendLine("           </tr>");
                        if (i == dt.Rows.Count - 1 || nextRowType == "0") { html.AppendLine("       </tbody>"); }
                    }
                }

                html.AppendLine("   </table>");
                html.AppendLine("</body>");
                html.AppendLine("</html>");
                File.WriteAllText(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\report.html", html.ToString());
                Uri htmlReportFile = new(AppDomain.CurrentDomain.BaseDirectory.TrimEnd('\\') + "\\report.html");
                wvResults.Source = new Uri("about:blank");
                wvResults.Source = htmlReportFile;
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "BuildHtml");
                MessageBox.Show("Unable to generate data. See logs for details.");
            }
        }

        private void ExportReport(DataTable dt, string savePath)
        {
            try
            {
                StringBuilder sb = new();
                for (int i = 1; i < dt.Columns.Count; i++)
                {
                    sb.Append(string.Concat("\"", dt.Columns[i].ToString().Replace("\"", "\"\""), "\""));
                    if (i < dt.Columns.Count - 1) { sb.Append(","); }
                }
                sb.AppendLine();
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 1; j < dt.Columns.Count; j++)
                    {
                        sb.Append(string.Concat("\"", (dt.Rows[i][j].ToString() ?? "").Replace("\"", "\"\""), "\""));
                        if (j < dt.Columns.Count - 1) { sb.Append(","); }
                    }
                    sb.AppendLine();
                }
                File.WriteAllText(savePath, sb.ToString());
                MessageBox.Show("CSV exported to '" + savePath + "'");
            }
            catch (Exception ex)
            {
                Logging.LogMessage("ErrorLog", ex.Message, "error", "ExportReport");
                MessageBox.Show("Unable to export CSV. See logs for details.");
            }
        }

        #endregion

    }
}