namespace Project_Time_Tracker
{
    public partial class EditAssignmentsForm : Form
    {
        private List<CustomerProjectList> customerProjectList = new();
        private List<CustomerList> customerList = new();
        private List<ProjectList> projectLists = new();

        public EditAssignmentsForm()
        {
            InitializeComponent();
        }

        private void EditAssignmentsForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
            ResetFields();
        }

        #region Form Objects

        private void btnRefresh_Click(object sender, EventArgs e)
        {

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
}