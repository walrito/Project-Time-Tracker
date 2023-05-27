namespace Project_Time_Tracker
{
    public partial class EditCustomersForm : Form
    {
        private List<CustomerList> customerList = new();
        private List<ProjectList> projectList = new();
        private List<CustomerProjectList> customerProjectList = new();
        private List<CustomerProjectList> filteredCustomerProjectList = new();

        public EditCustomersForm()
        {
            InitializeComponent();
        }

        private void EditCustomersForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
        }

        #region Form Objects

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
        }

        private void cboCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerList.SelectedIndex > -1)
            {
                txtName.Text = customerList.Single(c => c.CustomerId == (int)cboCustomerList.SelectedValue).CustomerName;
                filteredCustomerProjectList.Clear();
                filteredCustomerProjectList.AddRange(customerProjectList.Where(cp => cp.CustomerId == (int)cboCustomerList.SelectedValue));

                for (int i = 0; i < clbProjectList.Items.Count; i++)
                {
                    clbProjectList.SetItemChecked(i, filteredCustomerProjectList.Any(cp => cp.ProjectId == ((ProjectListItem)clbProjectList.Items[i]).ProjectId));
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text;

            if (!string.IsNullOrEmpty(customerName))
            {
                bool recordExists = customerList.Any(c => string.Equals(c.CustomerName, customerName, StringComparison.CurrentCultureIgnoreCase));

                if (!recordExists)
                {
                    int customerId = Customer.AddCustomer(customerName);

                    for (int i = 0; i < clbProjectList.Items.Count; i++)
                    {
                        ProjectListItem pli = (ProjectListItem)clbProjectList.Items[i];
                        if (clbProjectList.GetItemChecked(i)) { CustomerProject.AddCustomerProject(customerId, pli.ProjectId); }
                        else { CustomerProject.DeleteCustomerProject(customerId, pli.ProjectId); }
                    }

                    RefreshLists();
                    ResetFields();
                    MessageBox.Show("Customer added.");
                }
                else
                {
                    MessageBox.Show("Customer name already exists.");
                }
            }
            else
            {
                MessageBox.Show("Customer name cannot be blank.");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            string customerName = txtName.Text;

            if (cboCustomerList.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(customerName))
                {
                    int customerId = (int)cboCustomerList.SelectedValue;
                    if (customerId == 0) { customerName = "<Unassigned>"; }
                    bool recordExists = customerList.Any(c => string.Equals(c.CustomerName, customerName, StringComparison.CurrentCultureIgnoreCase));
                    CustomerList queryList = customerList.First(c => c.CustomerId == (int)cboCustomerList.SelectedValue);

                    if (!recordExists || (recordExists && string.Equals(queryList.CustomerName, customerName, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        if (MessageBox.Show("Removal of projects from customer will delete associated time entries. Continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            Customer.UpdateCustomer(customerId, customerName);

                            for (int i = 0; i < clbProjectList.Items.Count; i++)
                            {
                                ProjectListItem pli = (ProjectListItem)clbProjectList.Items[i];
                                if (clbProjectList.GetItemChecked(i)) { CustomerProject.AddCustomerProject(customerId, pli.ProjectId); }
                                else { CustomerProject.DeleteCustomerProject(customerId, pli.ProjectId); }
                            }

                            RefreshLists();
                            ResetFields();
                            MessageBox.Show("Customer updated.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Customer name already exists.");
                    }
                }
                else
                {
                    MessageBox.Show("Customer name cannot be blank.");
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (cboCustomerList.SelectedIndex > -1)
            {
                if (MessageBox.Show("Delete '" + cboCustomerList.GetItemText(cboCustomerList.SelectedItem) + "' and associated time entries?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Customer.DeleteCustomer((int)cboCustomerList.SelectedValue, false);
                    RefreshLists();
                    ResetFields();
                    MessageBox.Show("Customer deleted.");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete all customers and associated time entries?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Customer.DeleteCustomer(-1, true);
                RefreshLists();
                ResetFields();
                MessageBox.Show("All customers deleted.");
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
            customerProjectList = CustomerProject.GenerateCustomerProjectList(false);
            txtName.Text = "";
        }

        private void PopulateCustomerList()
        {
            customerList = Customer.GenerateCustomerList(false);

            cboCustomerList.DataSource = null;
            cboCustomerList.DisplayMember = "CustomerName";
            cboCustomerList.ValueMember = "CustomerId";
            cboCustomerList.DataSource = customerList;
            cboCustomerList.SelectedIndex = -1;
        }

        private void PopulateProjectList()
        {
            projectList = Project.GenerateProjectList(true, false);

            clbProjectList.Items.Clear();
            foreach (ProjectList project in projectList)
            {
                clbProjectList.Items.Add(new ProjectListItem { ProjectId = project.ProjectId, ProjectName = project.ProjectName });
            }
        }

        #endregion
    }

    public class ProjectListItem
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }

        public override string ToString() => !string.IsNullOrEmpty(ProjectName) ? ProjectName : "";
    }
}