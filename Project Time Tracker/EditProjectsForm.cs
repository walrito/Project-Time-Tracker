namespace Project_Time_Tracker
{
    public partial class EditProjectsForm : Form
    {
        private List<ProjectList> projectList = new();
        private List<CustomerList> customerList = new();
        private List<CustomerProjectList> customerProjectList = new();
        private List<CustomerProjectList> filteredCustomerProjectList = new();

        public EditProjectsForm()
        {
            InitializeComponent();
        }

        private void EditProjectsForm_Load(object sender, EventArgs e)
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

        private void cboProjectList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboProjectList.SelectedIndex > -1)
            {
                txtName.Text = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).ProjectName;
                cbActive.Checked = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).Active;
                txtNotes.Text = projectList.Single(p => p.ProjectId == (int)cboProjectList.SelectedValue).ProjectNotes;

                filteredCustomerProjectList.Clear();
                filteredCustomerProjectList.AddRange(customerProjectList.Where(cp => cp.ProjectId == (int)cboProjectList.SelectedValue));

                for (int i = 0; i < clbCustomerList.Items.Count; i++)
                {
                    clbCustomerList.SetItemChecked(i, filteredCustomerProjectList.Any(cp => cp.CustomerId == ((CustomerListItem)clbCustomerList.Items[i]).CustomerId));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string projectName = txtName.Text;

            if (!string.IsNullOrEmpty(projectName))
            {
                bool recordExists = projectList.Any(p => string.Equals(p.ProjectName, projectName, StringComparison.CurrentCultureIgnoreCase));

                if (!recordExists)
                {
                    int projectId = Project.AddProject(projectName, cbActive.Checked, txtNotes.Text);

                    for (int i = 0; i < clbCustomerList.Items.Count; i++)
                    {
                        CustomerListItem cli = (CustomerListItem)clbCustomerList.Items[i];
                        if (clbCustomerList.GetItemChecked(i)) { CustomerProject.AddCustomerProject(cli.CustomerId, projectId); }
                        else { CustomerProject.DeleteCustomerProject(cli.CustomerId, projectId); }
                    }

                    RefreshLists();
                    ResetFields();
                    MessageBox.Show("Project added.");
                }
                else
                {
                    MessageBox.Show("Project name already exists.");
                }
            }
            else
            {
                MessageBox.Show("Project name cannot be blank.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string projectName = txtName.Text;

            if (cboProjectList.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(projectName))
                {
                    int projectId = (int)cboProjectList.SelectedValue;
                    bool recordExists = projectList.Any(p => string.Equals(p.ProjectName, projectName, StringComparison.CurrentCultureIgnoreCase));
                    ProjectList queryList = projectList.First(p => p.ProjectId == (int)cboProjectList.SelectedValue);

                    if (!recordExists || (recordExists && string.Equals(queryList.ProjectName, projectName, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (MessageBox.Show("Removal of customers from project will delete associated time entries. Continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Project.UpdateProject(projectId, projectName, cbActive.Checked, txtNotes.Text);

                            for (int i = 0; i < clbCustomerList.Items.Count; i++)
                            {
                                CustomerListItem cli = (CustomerListItem)clbCustomerList.Items[i];
                                if (clbCustomerList.GetItemChecked(i)) { CustomerProject.AddCustomerProject(cli.CustomerId, projectId); }
                                else { CustomerProject.DeleteCustomerProject(cli.CustomerId, projectId); }
                            }

                            RefreshLists();
                            ResetFields();
                            MessageBox.Show("Project updated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Project name already exists.");
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
                if (MessageBox.Show("Delete '" + cboProjectList.GetItemText(cboProjectList.SelectedItem) + "' and associated time entries?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Project.DeleteProject((int)cboProjectList.SelectedValue, false);
                    RefreshLists();
                    ResetFields();
                    MessageBox.Show("Project deleted.");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all projects and associated time entries?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Project.DeleteProject(-1, true);
                RefreshLists();
                ResetFields();
                MessageBox.Show("All projects deleted.");
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
            PopulateProjectList();
            PopulateCustomerList();
        }

        private void ResetFields()
        {
            customerProjectList = CustomerProject.GenerateCustomerProjectList(false);
            txtName.Text = "";
            cbActive.Checked = true;
            txtNotes.Text = "";
        }

        private void PopulateProjectList()
        {
            projectList = Project.GenerateProjectList(false, false);

            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectId";
            cboProjectList.DataSource = projectList;
            cboProjectList.SelectedIndex = -1;
        }

        private void PopulateCustomerList()
        {
            customerList = Customer.GenerateCustomerList(false);

            clbCustomerList.Items.Clear();
            foreach (CustomerList customer in customerList)
            {
                clbCustomerList.Items.Add(new CustomerListItem { CustomerId = customer.CustomerId, CustomerName = customer.CustomerName });
            }
        }

        #endregion
    }

    public class CustomerListItem
    {
        public int CustomerId { get; set; }
        public string? CustomerName { get; set; }

        public override string ToString() => !string.IsNullOrEmpty(CustomerName) ? CustomerName : "";
    }
}