namespace Project_Time_Tracker
{
    partial class ViewReportsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvResults = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboCustomerList = new System.Windows.Forms.ComboBox();
            this.cboProjectList = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboReportType = new System.Windows.Forms.ComboBox();
            this.gbTimes = new System.Windows.Forms.GroupBox();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cbExactProject = new System.Windows.Forms.CheckBox();
            this.cbExactCustomer = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).BeginInit();
            this.gbTimes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvResults
            // 
            this.dgvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvResults.Location = new System.Drawing.Point(249, 12);
            this.dgvResults.Name = "dgvResults";
            this.dgvResults.RowTemplate.Height = 25;
            this.dgvResults.Size = new System.Drawing.Size(1003, 628);
            this.dgvResults.TabIndex = 3;
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.Location = new System.Drawing.Point(1177, 646);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(6, 125);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(95, 23);
            this.dtpStart.TabIndex = 7;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(130, 125);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(95, 23);
            this.dtpEnd.TabIndex = 9;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(6, 107);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(31, 15);
            this.lblStart.TabIndex = 6;
            this.lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(130, 107);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(27, 15);
            this.lblEnd.TabIndex = 8;
            this.lblEnd.Text = "End";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(168, 245);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboCustomerList
            // 
            this.cboCustomerList.Enabled = false;
            this.cboCustomerList.FormattingEnabled = true;
            this.cboCustomerList.Location = new System.Drawing.Point(6, 37);
            this.cboCustomerList.Name = "cboCustomerList";
            this.cboCustomerList.Size = new System.Drawing.Size(159, 23);
            this.cboCustomerList.TabIndex = 1;
            this.cboCustomerList.EnabledChanged += new System.EventHandler(this.cboCustomerList_EnabledChanged);
            // 
            // cboProjectList
            // 
            this.cboProjectList.Enabled = false;
            this.cboProjectList.FormattingEnabled = true;
            this.cboProjectList.Location = new System.Drawing.Point(6, 81);
            this.cboProjectList.Name = "cboProjectList";
            this.cboProjectList.Size = new System.Drawing.Size(159, 23);
            this.cboProjectList.TabIndex = 4;
            this.cboProjectList.EnabledChanged += new System.EventHandler(this.cboProjectList_EnabledChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Project_Time_Tracker.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 5;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cboReportType
            // 
            this.cboReportType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboReportType.FormattingEnabled = true;
            this.cboReportType.Items.AddRange(new object[] {
            "Times",
            "Customers",
            "Projects",
            "Customer/Project Assignments"});
            this.cboReportType.Location = new System.Drawing.Point(41, 12);
            this.cboReportType.Name = "cboReportType";
            this.cboReportType.Size = new System.Drawing.Size(202, 23);
            this.cboReportType.TabIndex = 0;
            this.cboReportType.SelectedIndexChanged += new System.EventHandler(this.cboReportType_SelectedIndexChanged);
            // 
            // gbTimes
            // 
            this.gbTimes.Controls.Add(this.lblCustomer);
            this.gbTimes.Controls.Add(this.lblProject);
            this.gbTimes.Controls.Add(this.lblNotes);
            this.gbTimes.Controls.Add(this.txtNotes);
            this.gbTimes.Controls.Add(this.cbExactProject);
            this.gbTimes.Controls.Add(this.dtpStart);
            this.gbTimes.Controls.Add(this.cbExactCustomer);
            this.gbTimes.Controls.Add(this.cboCustomerList);
            this.gbTimes.Controls.Add(this.dtpEnd);
            this.gbTimes.Controls.Add(this.cboProjectList);
            this.gbTimes.Controls.Add(this.lblEnd);
            this.gbTimes.Controls.Add(this.lblStart);
            this.gbTimes.Location = new System.Drawing.Point(12, 41);
            this.gbTimes.Name = "gbTimes";
            this.gbTimes.Size = new System.Drawing.Size(231, 198);
            this.gbTimes.TabIndex = 1;
            this.gbTimes.TabStop = false;
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(6, 19);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(59, 15);
            this.lblCustomer.TabIndex = 13;
            this.lblCustomer.Text = "Customer";
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(6, 63);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(44, 15);
            this.lblProject.TabIndex = 12;
            this.lblProject.Text = "Project";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(6, 151);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 15);
            this.lblNotes.TabIndex = 11;
            this.lblNotes.Text = "Notes";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(6, 169);
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(219, 23);
            this.txtNotes.TabIndex = 10;
            this.txtNotes.EnabledChanged += new System.EventHandler(this.txtNotes_EnabledChanged);
            // 
            // cbExactProject
            // 
            this.cbExactProject.AutoSize = true;
            this.cbExactProject.Enabled = false;
            this.cbExactProject.Location = new System.Drawing.Point(171, 83);
            this.cbExactProject.Name = "cbExactProject";
            this.cbExactProject.Size = new System.Drawing.Size(54, 19);
            this.cbExactProject.TabIndex = 5;
            this.cbExactProject.Text = "Exact";
            this.cbExactProject.UseVisualStyleBackColor = true;
            // 
            // cbExactCustomer
            // 
            this.cbExactCustomer.AutoSize = true;
            this.cbExactCustomer.Enabled = false;
            this.cbExactCustomer.Location = new System.Drawing.Point(171, 39);
            this.cbExactCustomer.Name = "cbExactCustomer";
            this.cbExactCustomer.Size = new System.Drawing.Size(54, 19);
            this.cbExactCustomer.TabIndex = 2;
            this.cbExactCustomer.Text = "Exact";
            this.cbExactCustomer.UseVisualStyleBackColor = true;
            // 
            // ViewReportsForm
            // 
            this.AcceptButton = this.btnSearch;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.gbTimes);
            this.Controls.Add(this.cboReportType);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvResults);
            this.MinimumSize = new System.Drawing.Size(960, 540);
            this.Name = "ViewReportsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reports";
            this.Load += new System.EventHandler(this.ViewTimesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvResults)).EndInit();
            this.gbTimes.ResumeLayout(false);
            this.gbTimes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DataGridView dgvResults;
        private Button btnClose;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Label lblStart;
        private Label lblEnd;
        private Button btnSearch;
        private ComboBox cboCustomerList;
        private ComboBox cboProjectList;
        private Button btnRefresh;
        private ComboBox cboReportType;
        private GroupBox gbTimes;
        private CheckBox cbExactProject;
        private CheckBox cbExactCustomer;
        private Label lblCustomer;
        private Label lblProject;
        private Label lblNotes;
        private TextBox txtNotes;
    }
}