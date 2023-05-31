using Elements.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Project_Time_Tracker
{
    public partial class MigrateTimesForm : Form
    {
        private List<CustomerProjectList> customerProjectSourceList = new();
        private List<CustomerProjectList> customerProjectDestinationList = new();

        public MigrateTimesForm()
        {
            InitializeComponent();
        }

        private void MigrateTimesForm_Load(object sender, EventArgs e)
        {
            RefreshLists();
            RefreshFields();
        }

        #region Form Objects

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshLists();
            RefreshFields();
        }

        private void btnMigrate_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(cboSource.SelectedValue.ToString()) && !string.IsNullOrEmpty(cboDestination.SelectedValue.ToString()))
            {
                if(cboSource.SelectedValue.ToString() != cboDestination.SelectedValue.ToString())
                {
                    if (MessageBox.Show("Migrate all time entries from source to destination?", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        SQLite.spl.Add(new SQLiteParameter("@DestinationID", cboDestination.SelectedValue.ToString()));
                        SQLite.spl.Add(new SQLiteParameter("@SourceID", cboSource.SelectedValue.ToString()));
                        SQLite.ExecuteNonQuery("update Times set CustomerProjectID = @DestinationID where CustomerProjectID = @SourceID", SQLite.spl, "ProjectTimeTracker");
                        if (cbDelete.Checked)
                        {
                            SQLite.spl.Add(new SQLiteParameter("@SourceID", cboSource.SelectedValue.ToString()));
                            SQLite.ExecuteNonQuery("delete from CustomerProject where CustomerProjectID = @SourceID", SQLite.spl, "ProjectTimeTracker");
                        }
                        RefreshLists();
                        RefreshFields();
                    }
                }
                else
                {
                    MessageBox.Show("Source and destination cannot be the same.");
                }
            }
            else
            {
                MessageBox.Show("Source and destination cannot be blank.");
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
        }

        private void RefreshFields()
        {
            cbDelete.Checked = false;
        }

        private void PopulateCustomerProjectList()
        {
            customerProjectSourceList = CustomerProject.GenerateCustomerProjectList(true);

            cboSource.DataSource = null;
            cboSource.DisplayMember = "CustomerProjectName";
            cboSource.ValueMember = "CustomerProjectID";
            cboSource.DataSource = customerProjectSourceList;
            cboSource.SelectedIndex = -1;

            customerProjectDestinationList = CustomerProject.GenerateCustomerProjectList(true);

            cboDestination.DataSource = null;
            cboDestination.DisplayMember = "CustomerProjectName";
            cboDestination.ValueMember = "CustomerProjectID";
            cboDestination.DataSource = customerProjectDestinationList;
            cboDestination.SelectedIndex = -1;
        }

        #endregion

    }
}