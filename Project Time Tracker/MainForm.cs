using System.Data;
using System.Data.SQLite;
using System.Xml.Linq;
using Elements.Database;

namespace Project_Time_Tracker
{
    public partial class MainForm : Form
    {
        private List<ProjectList> projectList = new();
        private int timerSeconds;
        private TimeSpan timerDuration;
        private DateTime startTime;

        public MainForm()
        {
            InitializeComponent();
            if (SQLite.CreateDatabase("ProjectTimeTracker"))
            {
                SQLite.PopulateDatabaseTables("ProjectTimeTracker");
                SQLite.PopulateDefaultTableValues("ProjectTimeTracker");
            }
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            PopulateProjectList();
        }

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
        }

        private void projectsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditProjectsForm f = new();
            f.ShowDialog();
            PopulateProjectList();
        }

        private void editTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            EditTimesForm f = new();
            f.ShowDialog();
        }

        private void viewTimesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewTimesForm f = new();
            f.ShowDialog();
        }

        private void PopulateProjectList()
        {
            int selectedValue = -1;
            if (tmrMain.Enabled && cboProjectList.SelectedIndex > -1) { selectedValue = (int)cboProjectList.SelectedValue; }

            projectList = Project.GenerateProjectList(true, true);

            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectId";
            cboProjectList.DataSource = projectList;
            cboProjectList.SelectedIndex = -1;

            if (tmrMain.Enabled && selectedValue > -1 && projectList.Any(i => i.ProjectId == selectedValue)) cboProjectList.SelectedValue = selectedValue;
        }

        private void RefreshFields()
        {
            tmrMain.Stop();
            timerSeconds = 0;
            PopulateProjectList();
            txtNotes.Text = string.Empty;
            txtTimerStart.Text = string.Empty;
            txtTimerDuration.Text = string.Empty;
        }

        private void btnToggleTimer_Click(object sender, EventArgs e)
        {
            if (tmrMain.Enabled)
            {
                StopTrackingTime();
            }
            else
            {
                StartTrackingTime();
            }
        }

        private void StartTrackingTime()
        {
            tmrMain.Start();
            btnToggleTimer.Text = "Stop";
            startTime = DateTime.Now;
            txtTimerStart.Text = startTime.ToString(@"yyyy-MM-dd HH\:mm\:ss");
        }

        private void StopTrackingTime()
        {
            tmrMain.Stop();
            btnToggleTimer.Text = "Start";
            LogTrackedTime(DateTime.Now);
            RefreshFields();
        }

        private void LogTrackedTime(DateTime endTime)
        {
            SQLite.spl.Add(new SQLiteParameter("@ProjectID", Project.GetProjectId(cboProjectList.Text, 0)));
            SQLite.spl.Add(new SQLiteParameter("@Start", startTime.ToString(@"yyyy-MM-dd HH\:mm\:ss")));
            SQLite.spl.Add(new SQLiteParameter("@End", endTime.ToString(@"yyyy-MM-dd HH\:mm\:ss")));
            SQLite.spl.Add(new SQLiteParameter("@Duration", endTime.Subtract(startTime).ToString(@"d\:hh\:mm\:ss")));
            SQLite.spl.Add(new SQLiteParameter("@TimeNotes", txtNotes.Text));
            if (!SQLite.ExecuteNonQuery("insert into Times (Start, End, Duration, TimeNotes, ProjectID) values (@Start, @End, @Duration, @TimeNotes, @ProjectID)", SQLite.spl, "ProjectTimeTracker"))
            {
                MessageBox.Show("Failed to record tracked time. Check logs for details.");
            }
        }

        private void tmrMain_Tick(object sender, EventArgs e)
        {
            timerSeconds += 1;
            timerDuration = TimeSpan.FromSeconds(timerSeconds);
            txtTimerDuration.Text = timerDuration.ToString(@"d\:hh\:mm\:ss");
        }
    }
}