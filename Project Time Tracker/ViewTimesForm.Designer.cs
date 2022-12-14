namespace Project_Time_Tracker
{
    partial class ViewTimesForm
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
            this.dgvTimeResults = new System.Windows.Forms.DataGridView();
            this.btnClose = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.cboCustomerList = new System.Windows.Forms.ComboBox();
            this.cboProjectList = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbCustomer = new System.Windows.Forms.CheckBox();
            this.cbProject = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeResults)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTimeResults
            // 
            this.dgvTimeResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTimeResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeResults.Location = new System.Drawing.Point(12, 41);
            this.dgvTimeResults.Name = "dgvTimeResults";
            this.dgvTimeResults.RowTemplate.Height = 25;
            this.dgvTimeResults.Size = new System.Drawing.Size(860, 479);
            this.dgvTimeResults.TabIndex = 9;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(797, 526);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(79, 12);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(95, 23);
            this.dtpStart.TabIndex = 1;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(213, 12);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(95, 23);
            this.dtpEnd.TabIndex = 3;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(42, 18);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(31, 15);
            this.lblStart.TabIndex = 0;
            this.lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(180, 18);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(27, 15);
            this.lblEnd.TabIndex = 2;
            this.lblEnd.Text = "End";
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(797, 12);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 8;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // cboCustomerList
            // 
            this.cboCustomerList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerList.Enabled = false;
            this.cboCustomerList.FormattingEnabled = true;
            this.cboCustomerList.Location = new System.Drawing.Point(398, 12);
            this.cboCustomerList.Name = "cboCustomerList";
            this.cboCustomerList.Size = new System.Drawing.Size(150, 23);
            this.cboCustomerList.TabIndex = 5;
            // 
            // cboProjectList
            // 
            this.cboProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboProjectList.Enabled = false;
            this.cboProjectList.FormattingEnabled = true;
            this.cboProjectList.Location = new System.Drawing.Point(623, 12);
            this.cboProjectList.Name = "cboProjectList";
            this.cboProjectList.Size = new System.Drawing.Size(150, 23);
            this.cboProjectList.TabIndex = 7;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Project_Time_Tracker.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbCustomer
            // 
            this.cbCustomer.AutoSize = true;
            this.cbCustomer.Location = new System.Drawing.Point(314, 15);
            this.cbCustomer.Name = "cbCustomer";
            this.cbCustomer.Size = new System.Drawing.Size(78, 19);
            this.cbCustomer.TabIndex = 12;
            this.cbCustomer.Text = "Customer";
            this.cbCustomer.UseVisualStyleBackColor = true;
            this.cbCustomer.CheckedChanged += new System.EventHandler(this.cbCustomer_CheckedChanged);
            // 
            // cbProject
            // 
            this.cbProject.AutoSize = true;
            this.cbProject.Location = new System.Drawing.Point(554, 15);
            this.cbProject.Name = "cbProject";
            this.cbProject.Size = new System.Drawing.Size(63, 19);
            this.cbProject.TabIndex = 13;
            this.cbProject.Text = "Project";
            this.cbProject.UseVisualStyleBackColor = true;
            this.cbProject.CheckedChanged += new System.EventHandler(this.cbProject_CheckedChanged);
            // 
            // ViewTimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.cbProject);
            this.Controls.Add(this.cbCustomer);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboProjectList);
            this.Controls.Add(this.cboCustomerList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.dgvTimeResults);
            this.Name = "ViewTimesForm";
            this.ShowIcon = false;
            this.Text = "View Times";
            this.Load += new System.EventHandler(this.ViewTimesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DataGridView dgvTimeResults;
        private Button btnClose;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Label lblStart;
        private Label lblEnd;
        private Button btnSearch;
        private ComboBox cboCustomerList;
        private ComboBox cboProjectList;
        private Button btnRefresh;
        private CheckBox cbCustomer;
        private CheckBox cbProject;
    }
}