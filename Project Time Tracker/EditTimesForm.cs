using System.Xml.Linq;

namespace Project_Time_Tracker
{
    public partial class EditTimesForm : Form
    {
        private List<CustomerProjectList> customerProjectList = new();
        private List<TimeList> timeList = new();

        public EditTimesForm()
        {
            InitializeComponent();
        }

        private void EditTimesForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
        }

        #region FormObjects

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
        }

        private void cboCustomerProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            ResetFields();
            if (cboCustomerProjectList.SelectedIndex > -1)
            {
                PopulateTimeList((int)cboCustomerProjectList.SelectedValue);
                cboCustomerList.SelectedValue = customerProjectList.Single(cp => cp.CustomerProjectId == (int)cboCustomerProjectList.SelectedValue).CustomerId;
                cboProjectList.SelectedValue = customerProjectList.Single(cp => cp.CustomerProjectId == (int)cboCustomerProjectList.SelectedValue).ProjectId;
            }
            else
            {
                clbTimeList.Items.Clear();
            }
        }

        private void clbTimeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (clbTimeList.SelectedIndex > -1)
            {
                TimeListItem tli = (TimeListItem)clbTimeList.SelectedItem;
                dtpStart.Value = timeList.Single(t => t.TimeId == tli.TimeId).Start;
                dtpEnd.Value = timeList.Single(t => t.TimeId == tli.TimeId).End;
                txtNotes.Text = timeList.Single(t => t.TimeId == tli.TimeId).TimeNotes;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(dtpStart.Value.ToString()) && !string.IsNullOrEmpty(dtpEnd.Value.ToString()))
            {
                if (dtpStart.Value <= dtpEnd.Value)
                    if (Time.AddTime(dtpStart.Value.ToString(@"yyyy-MM-dd HH\:mm\:ss"), dtpEnd.Value.ToString(@"yyyy-MM-dd HH\:mm\:ss"), Time.GetDuration(dtpStart.Value, dtpEnd.Value),
                        Time.GetDurationDecimal(dtpStart.Value, dtpEnd.Value), txtNotes.Text, CustomerProject.GetCustomerProjectId(Customer.GetCustomerId(cboCustomerList.Text), Project.GetProjectId(cboProjectList.Text))) == -1)
                    {
                        MessageBox.Show("Failed to record time entry. Check logs for details.");
                    }
                    else
                    {
                        RefreshLists();
                        ResetFields();
                        MessageBox.Show("Time entry added.");
                    }
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (clbTimeList.SelectedIndex > -1)
            {
                TimeListItem tli = (TimeListItem)clbTimeList.SelectedItem;

                if (!string.IsNullOrEmpty(dtpStart.Value.ToString()) && !string.IsNullOrEmpty(dtpEnd.Value.ToString()))
                {
                    if (dtpStart.Value <= dtpEnd.Value)
                        if (Time.UpdateTime(tli.TimeId, dtpStart.Value.ToString(@"yyyy-MM-dd HH\:mm\:ss"), dtpEnd.Value.ToString(@"yyyy-MM-dd HH\:mm\:ss"), Time.GetDuration(dtpStart.Value, dtpEnd.Value),
                            Time.GetDurationDecimal(dtpStart.Value, dtpEnd.Value), txtNotes.Text, CustomerProject.GetCustomerProjectId(Customer.GetCustomerId(cboCustomerList.Text), Project.GetProjectId(cboProjectList.Text))) == -1)
                        {
                            MessageBox.Show("Failed to record time entry. Check logs for details.");
                        }
                        else
                        {
                            RefreshLists();
                            ResetFields();
                            MessageBox.Show("Time entry updated.");
                        }
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
        }

        private void cbSelectAll_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < clbTimeList.Items.Count; i++)
            {
                clbTimeList.SetItemChecked(i, cbSelectAll.Checked);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (clbTimeList.CheckedItems.Count > 0)
            {
                if (MessageBox.Show("Delete selected time entries?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    foreach (TimeListItem tli in clbTimeList.CheckedItems)
                    {
                        Time.DeleteTime(tli.TimeId, false);
                    }
                    RefreshLists();
                    ResetFields();
                    MessageBox.Show("Selected time entries deleted.");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all time entries for all customer projects?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Time.DeleteTime(-1, true);
                RefreshLists();
                ResetFields();
                MessageBox.Show("All time entries deleted.");
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
            PopulateCustomerProjectList();
            PopulateCustomerList();
            PopulateProjectList();
        }

        private void ResetFields()
        {
            DateTime curDateTime = DateTime.Now;
            clbTimeList.Items.Clear();
            cbSelectAll.Checked = false;
            dtpStart.Value = curDateTime;
            dtpEnd.Value = curDateTime;
            txtNotes.Text = "";
            cboCustomerList.SelectedIndex = -1;
            cboProjectList.SelectedIndex = -1;
        }

        private void PopulateCustomerProjectList()
        {
            customerProjectList = CustomerProject.GenerateCustomerProjectList(true);

            cboCustomerProjectList.DataSource = null;
            cboCustomerProjectList.DisplayMember = "CustomerProjectName";
            cboCustomerProjectList.ValueMember = "CustomerProjectID";
            cboCustomerProjectList.DataSource = customerProjectList;
            cboCustomerProjectList.SelectedIndex = -1;
        }

        private void PopulateTimeList(int customerProjectId)
        {
            timeList = Time.GenerateTimeList(customerProjectId);

            clbTimeList.Items.Clear();
            foreach (TimeList time in timeList)
            {
                clbTimeList.Items.Add(new TimeListItem { TimeId = time.TimeId, TimeSpan = time.TimeSpan });
            }

        }

        private void PopulateCustomerList()
        {
            cboCustomerList.DataSource = null;
            cboCustomerList.DisplayMember = "CustomerName";
            cboCustomerList.ValueMember = "CustomerId";
            cboCustomerList.DataSource = Customer.GenerateCustomerList(true);
            cboCustomerList.SelectedIndex = -1;
        }

        private void PopulateProjectList()
        {
            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectId";
            cboProjectList.DataSource = Project.GenerateProjectList(true, true);
            cboProjectList.SelectedIndex = -1;
        }

        #endregion

    }

    public class TimeListItem
    {
        public int TimeId { get; set; }
        public string? TimeSpan { get; set; }

        public override string ToString() => !string.IsNullOrEmpty(TimeSpan) ? TimeSpan : "";
    }
}