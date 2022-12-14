using Elements.Database;

namespace Project_Time_Tracker
{
    public partial class EditProjectsForm : Form
    {
        private List<ProjectList> projectList = new();

        public EditProjectsForm()
        {
            InitializeComponent();
        }

        private void EditProjectsForm_Load(object sender, EventArgs e)
        {
            RefreshFields();
        }

        #region FormObjects

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void cboProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProjectList.SelectedIndex > -1)
            {
                txtName.Text = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).ProjectName;
                cbActive.Checked = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).Active;
                txtNotes.Text = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).ProjectNotes;
                cboCustomerList.SelectedValue = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).CustomerId;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                int customerId = Customer.GetCustomerId(cboCustomerList.Text);
                bool recordExists = projectList.Any(p => string.Equals(p.ProjectName, txtName.Text, StringComparison.CurrentCultureIgnoreCase) && p.CustomerId == customerId);

                if (!recordExists)
                {
                    Project.AddProject(txtName.Text, cbActive.Checked, txtNotes.Text, customerId);
                    RefreshFields();
                    MessageBox.Show("Project added.");
                }
                else
                {
                    MessageBox.Show("Project name already exists for selected customer.");
                }
            }
            else
            {
                MessageBox.Show("Project name cannot be blank.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cboProjectList.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    int customerId = Customer.GetCustomerId(cboCustomerList.Text);
                    bool recordExists = projectList.Any(p => string.Equals(p.ProjectName, txtName.Text, StringComparison.CurrentCultureIgnoreCase) && p.CustomerId == customerId);
                    ProjectList queryList = projectList.First(c => c.ProjectId == (int)cboProjectList.SelectedValue);

                    if (!recordExists || (recordExists && queryList.ProjectName == txtName.Text && queryList.CustomerName == cboCustomerList.Text))
                    {
                        Project.UpdateProject((int)cboProjectList.SelectedValue, txtName.Text, cbActive.Checked, txtNotes.Text, customerId);
                        RefreshFields();
                        MessageBox.Show("Project updated.");
                    }
                    else
                    {
                        MessageBox.Show("Project name already exists for selected customer.");
                    }
                }
                else
                {
                    MessageBox.Show("Project name cannot be blank.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboProjectList.SelectedIndex > -1)
            {
                if (MessageBox.Show("This will also delete all associated time entries. Continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Project.DeleteProject((int)cboProjectList.SelectedValue, false);
                    RefreshFields();
                    MessageBox.Show("Project deleted.");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("This will delete all projects and all associated time entries. Continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Project.DeleteProject(-1, true);
                RefreshFields();
                MessageBox.Show("All projects deleted.");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #endregion

        #region Functions

        private void RefreshFields()
        {
            PopulateProjectList();
            txtName.Text = "";
            cbActive.Checked = false;
            txtNotes.Text = "";
            PopulateCustomerList();
        }

        private void PopulateProjectList()
        {
            projectList = Project.GenerateProjectList(false, true);

            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectId";
            cboProjectList.DataSource = projectList;
            cboProjectList.SelectedIndex = -1;
        }

        private void PopulateCustomerList()
        {
            cboCustomerList.DataSource = null;
            cboCustomerList.DisplayMember = "CustomerName";
            cboCustomerList.ValueMember = "CustomerId";
            cboCustomerList.DataSource = Customer.GenerateCustomerList(true);
            cboCustomerList.SelectedIndex = -1;
        }

        #endregion
    }
}