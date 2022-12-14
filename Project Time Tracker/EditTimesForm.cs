using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Project_Time_Tracker
{
    public partial class EditTimesForm : Form
    {
        private List<TimeFilter> timeFilterList = new();
        private List<TimeList> timeList = new();

        public EditTimesForm()
        {
            InitializeComponent();
        }

        private void EditTimesForm_Load(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void RefreshFields()
        {
            DateTime curDateTime = DateTime.Now;
            PopulateTimeFilterList();
            lbTimeList.DataSource = null;
            PopulateProjectList();
            dtpEnd.Value = curDateTime;
            dtpStart.Value = curDateTime;
            txtNotes.Text = "";
            PopulateCustomerList();
        }

        private void PopulateTimeFilterList()
        {
            timeFilterList = Time.GenerateTimeFilterList();

            cboTimeFilter.DataSource = null;
            cboTimeFilter.DisplayMember = "CustomerAndProject";
            cboTimeFilter.ValueMember = "ProjectId";
            cboTimeFilter.DataSource = timeFilterList;
            cboTimeFilter.SelectedIndex = -1;
        }

        private void PopulateTimeList(int projectId)
        {
            timeList = Time.GenerateTimeList(projectId);

            lbTimeList.DataSource = null;
            lbTimeList.DisplayMember = "TimeSpan";
            lbTimeList.ValueMember = "TimeId";
            lbTimeList.DataSource = timeList;
            lbTimeList.SelectedIndex = -1;
        }

        private void PopulateProjectList()
        {
            cboProjectList.DataSource = null;
            cboProjectList.DisplayMember = "ProjectName";
            cboProjectList.ValueMember = "ProjectId";
            cboProjectList.DataSource = Project.GenerateProjectList(true, true);
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

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            RefreshFields();
        }

        private void cboTimeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTimeFilter.SelectedIndex > -1) PopulateTimeList((int)cboTimeFilter.SelectedValue);
        }

        private void lbTimeList_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteAll_Click(object sender, EventArgs e)
        {

        }
    }
}