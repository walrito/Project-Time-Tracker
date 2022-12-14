using Elements.Database;

namespace Project_Time_Tracker
{
    public partial class EditCustomersForm : Form
    {
        private List<CustomerList> customerList = new();

        public EditCustomersForm()
        {
            InitializeComponent();
        }

        private void EditCustomersForm_Load(object sender, EventArgs e)
        {
            RefreshFields();
        }

        #region FormObjects

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void cboCustomerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboCustomerList.SelectedIndex > -1) txtName.Text = customerList.Single(c => c.CustomerId == (int)cboCustomerList.SelectedValue).CustomerName;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text))
            {
                bool recordExists = customerList.Any(c => string.Equals(c.CustomerName, txtName.Text, StringComparison.CurrentCultureIgnoreCase));

                if (!recordExists)
                {
                    Customer.AddCustomer(txtName.Text);
                    RefreshFields();
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
            if (cboCustomerList.SelectedIndex > -1)
            {
                if (!string.IsNullOrEmpty(txtName.Text))
                {
                    bool recordExists = customerList.Any(c => string.Equals(c.CustomerName, txtName.Text, StringComparison.CurrentCultureIgnoreCase));
                    CustomerList queryList = customerList.First(c => c.CustomerId == (int)cboCustomerList.SelectedValue);

                    if (!recordExists || (recordExists && string.Equals(queryList.CustomerName, txtName.Text, StringComparison.CurrentCultureIgnoreCase)))
                    {
                        Customer.UpdateCustomer((int)cboCustomerList.SelectedValue, txtName.Text);
                        RefreshFields();
                        MessageBox.Show("Customer updated.");
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
                if (MessageBox.Show("Deleting '" + cboCustomerList.GetItemText(cboCustomerList.SelectedItem) + "' and all associated projects and time entries. Continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    Customer.DeleteCustomer((int)cboCustomerList.SelectedValue, false);
                    RefreshFields();
                    MessageBox.Show("Customer deleted.");
                }
            }
        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Deleting all customers and all associated projects and time entries. Continue?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Customer.DeleteCustomer(-1, true);
                SQLite.PopulateDefaultTableValues("ProjectTimeTracker");
                RefreshFields();
                MessageBox.Show("All customers deleted.");
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
            PopulateCustomerList();
            txtName.Text = "";
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

        #endregion
    }
}