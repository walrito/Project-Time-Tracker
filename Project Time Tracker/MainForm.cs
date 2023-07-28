using System.Data.SQLite;
using Elements.Database;

namespace Project_Time_Tracker
{
    public partial class MainForm : Form
    {
        private List<CustomerProjectList> customerProjectList = new();
        private List<CustomerList> customerList = new();
        private List<ProjectList> projectList = new();
        private List<Tuple<DateTime, DateTime>> timerList = new();
        private int timerSeconds;
        private TimeSpan timerDuration;
        private DateTime startTime;
        private bool paused = false;

        public MainForm()
        {
            InitializeComponent();

            SQLite.CreateDatabase("ProjectTimeTracker");
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateCustomerProjectList();
            PopulateCustomerList();
            PopulateProjectList();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopTrackingTime();
        }

        #region Form Objects

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void customerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditCustomersForm f = new();
            f.ShowDialog();
            RefreshFields();
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProjectsForm f = new();
            f.ShowDialog();
            RefreshFields();
        }

        private void editTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTimesForm f = new();
            f.ShowDialog();
            RefreshFields();
        }

        private void reportsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewReportsForm f = new();
            f.ShowDialog();
        }

        private void cboCustomerProject_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerProjectList.SelectedIndex > -1)
            {
                if ((int)cboCustomerProjectList.SelectedValue == 0)
                {
                    cboCustomerList.SelectedIndex = -1;
                    cboProjectList.SelectedIndex = -1;
                }
                else
                {
                    cboCustomerList.SelectedValue = customerProjectList.Single(cp => cp.CustomerProjectId == (int)cboCustomerProjectList.SelectedValue).CustomerId;
                    cboProjectList.SelectedValue = customerProjectList.Single(cp => cp.CustomerProjectId == (int)cboCustomerProjectList.SelectedValue).ProjectId;
                }
            }
        }

        private void btnPause_Click(object sender, EventArgs e)
        {
            if (tmrMain.Enabled && !paused)
            {
                PauseTrackingTime();
            }
            else
            {
                ResumeTrackingTime();
            }
        }

        private void btnToggleTimer_Click(object sender, EventArgs e)
        {
            if (tmrMain.Enabled || paused)
            {
                StopTrackingTime();
            }
            else
            {
                StartTrackingTime();
            }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            timerSeconds += 1;
            timerDuration = TimeSpan.FromSeconds(timerSeconds);
            txtTimerDuration.Text = timerDuration.ToString(@"d\:hh\:mm\:ss");
        }

        #endregion

        #region Functions

        private void RefreshFields()
        {
            tmrMain.Stop();
            btnPause.Enabled = false;
            paused = false;
            btnPause.Text = "Pause";
            btnToggleTimer.Text = "Start";
            timerSeconds = 0;
            editToolStripMenuItem.Enabled = true;
            PopulateCustomerProjectList();
            PopulateCustomerList();
            PopulateProjectList();
            txtNotes.Text = string.Empty;
            txtTimerStart.Text = string.Empty;
            txtTimerDuration.Text = string.Empty;
            cboCustomerProjectList.Focus();
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

        private void PopulateCustomerList()
        {
            customerList = Customer.GenerateCustomerList(true);

            cboCustomerList.DataSource = null;
            cboCustomerList.DisplayMember = "CustomerName";
            cboCustomerList.ValueMember = "CustomerId";
            cboCustomerList.DataSource = customerList;
            cboCustomerList.SelectedIndex = -1;
        }

        private void PopulateProjectList()
        {
            projectList = Project.GenerateProjectList(true, true);

            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectId";
            cboProjectList.DataSource = projectList;
            cboProjectList.SelectedIndex = -1;
        }

        private void StartTrackingTime()
        {
            editToolStripMenuItem.Enabled = false;
            paused = false;
            tmrMain.Start();
            btnPause.Enabled = true;
            btnToggleTimer.Text = "Stop";
            startTime = DateTime.Now;
            txtTimerStart.Text = startTime.ToString(@"yyyy-MM-dd HH\:mm\:ss");
        }

        private void StopTrackingTime()
        {
            tmrMain.Stop();
            if (!paused) timerList.Add(new Tuple<DateTime, DateTime>(startTime, DateTime.Now));
            foreach (var t in timerList)
            {
                RecordTime(t.Item1, t.Item2);
            }
            editToolStripMenuItem.Enabled = true;
            paused = false;
            timerList.Clear();
            RefreshFields();
        }

        private void PauseTrackingTime()
        {
            tmrMain.Stop();
            timerList.Add(new Tuple<DateTime, DateTime>(startTime, DateTime.Now));
            paused = true;
            btnPause.Text = "Resume";
        }

        private void ResumeTrackingTime()
        {
            tmrMain.Start();
            paused = false;
            btnPause.Text = "Pause";
            startTime = DateTime.Now;
        }

        private void RecordTime(DateTime startTime, DateTime endTime)
        {
            if (Time.AddTime(startTime.ToString(@"yyyy-MM-dd HH\:mm\:ss"), endTime.ToString(@"yyyy-MM-dd HH\:mm\:ss"), Time.GetDuration(startTime, endTime),
                Time.GetDurationDecimal(startTime, endTime), txtNotes.Text, CustomerProject.GetCustomerProjectId(Customer.GetCustomerId(cboCustomerList.Text), Project.GetProjectId(cboProjectList.Text))) == -1)
            {
                MessageBox.Show("Failed to record time entry. Check logs for details.");
            }
        }

        #endregion

    }
}