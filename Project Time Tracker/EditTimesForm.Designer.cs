namespace Project_Time_Tracker
{
    partial class EditTimesForm
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
            this.lblProject = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.cboProjectList = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.cboCustomerProjectList = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.dtpStart = new System.Windows.Forms.DateTimePicker();
            this.dtpEnd = new System.Windows.Forms.DateTimePicker();
            this.lblStart = new System.Windows.Forms.Label();
            this.lblEnd = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomerList = new System.Windows.Forms.ComboBox();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.lblTimeList = new System.Windows.Forms.Label();
            this.clbTimeList = new System.Windows.Forms.CheckedListBox();
            this.cbSelectAll = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(12, 317);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(44, 15);
            this.lblProject.TabIndex = 11;
            this.lblProject.Text = "Project";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 202);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 15);
            this.lblNotes.TabIndex = 7;
            this.lblNotes.Text = "Notes";
            // 
            // cboProjectList
            // 
            this.cboProjectList.FormattingEnabled = true;
            this.cboProjectList.Location = new System.Drawing.Point(77, 314);
            this.cboProjectList.MaxLength = 100;
            this.cboProjectList.Name = "cboProjectList";
            this.cboProjectList.Size = new System.Drawing.Size(244, 23);
            this.cboProjectList.TabIndex = 12;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(77, 199);
            this.txtNotes.MaxLength = 1000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(244, 80);
            this.txtNotes.TabIndex = 8;
            // 
            // cboCustomerProjectList
            // 
            this.cboCustomerProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerProjectList.FormattingEnabled = true;
            this.cboCustomerProjectList.Location = new System.Drawing.Point(77, 12);
            this.cboCustomerProjectList.Name = "cboCustomerProjectList";
            this.cboCustomerProjectList.Size = new System.Drawing.Size(325, 23);
            this.cboCustomerProjectList.TabIndex = 0;
            this.cboCustomerProjectList.SelectedIndexChanged += new System.EventHandler(this.cboCustomerProjectList_SelectedIndexChanged);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(327, 66);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 16;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(246, 343);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(165, 343);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 13;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Project_Time_Tracker.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 18;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // dtpStart
            // 
            this.dtpStart.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpStart.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStart.Location = new System.Drawing.Point(77, 141);
            this.dtpStart.Name = "dtpStart";
            this.dtpStart.Size = new System.Drawing.Size(140, 23);
            this.dtpStart.TabIndex = 4;
            // 
            // dtpEnd
            // 
            this.dtpEnd.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            this.dtpEnd.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEnd.Location = new System.Drawing.Point(77, 170);
            this.dtpEnd.Name = "dtpEnd";
            this.dtpEnd.Size = new System.Drawing.Size(140, 23);
            this.dtpEnd.TabIndex = 6;
            // 
            // lblStart
            // 
            this.lblStart.AutoSize = true;
            this.lblStart.Location = new System.Drawing.Point(12, 147);
            this.lblStart.Name = "lblStart";
            this.lblStart.Size = new System.Drawing.Size(31, 15);
            this.lblStart.TabIndex = 3;
            this.lblStart.Text = "Start";
            // 
            // lblEnd
            // 
            this.lblEnd.AutoSize = true;
            this.lblEnd.Location = new System.Drawing.Point(12, 176);
            this.lblEnd.Name = "lblEnd";
            this.lblEnd.Size = new System.Drawing.Size(27, 15);
            this.lblEnd.TabIndex = 5;
            this.lblEnd.Text = "End";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 288);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(59, 15);
            this.lblCustomer.TabIndex = 9;
            this.lblCustomer.Text = "Customer";
            // 
            // cboCustomerList
            // 
            this.cboCustomerList.FormattingEnabled = true;
            this.cboCustomerList.Location = new System.Drawing.Point(77, 285);
            this.cboCustomerList.MaxLength = 100;
            this.cboCustomerList.Name = "cboCustomerList";
            this.cboCustomerList.Size = new System.Drawing.Size(244, 23);
            this.cboCustomerList.TabIndex = 10;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(327, 343);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 15;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(327, 95);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 17;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            this.btnDeleteAll.Click += new System.EventHandler(this.btnDeleteAll_Click);
            // 
            // lblTimeList
            // 
            this.lblTimeList.AutoSize = true;
            this.lblTimeList.Location = new System.Drawing.Point(12, 41);
            this.lblTimeList.Name = "lblTimeList";
            this.lblTimeList.Size = new System.Drawing.Size(54, 15);
            this.lblTimeList.TabIndex = 1;
            this.lblTimeList.Text = "Time List";
            // 
            // clbTimeList
            // 
            this.clbTimeList.FormattingEnabled = true;
            this.clbTimeList.Location = new System.Drawing.Point(77, 41);
            this.clbTimeList.Name = "clbTimeList";
            this.clbTimeList.Size = new System.Drawing.Size(244, 94);
            this.clbTimeList.TabIndex = 2;
            this.clbTimeList.SelectedIndexChanged += new System.EventHandler(this.clbTimeList_SelectedIndexChanged);
            // 
            // cbSelectAll
            // 
            this.cbSelectAll.AutoSize = true;
            this.cbSelectAll.Location = new System.Drawing.Point(327, 41);
            this.cbSelectAll.Name = "cbSelectAll";
            this.cbSelectAll.Size = new System.Drawing.Size(74, 19);
            this.cbSelectAll.TabIndex = 19;
            this.cbSelectAll.Text = "Select All";
            this.cbSelectAll.UseVisualStyleBackColor = true;
            this.cbSelectAll.CheckedChanged += new System.EventHandler(this.cbSelectAll_CheckedChanged);
            // 
            // EditTimesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(414, 378);
            this.Controls.Add(this.cbSelectAll);
            this.Controls.Add(this.clbTimeList);
            this.Controls.Add(this.lblTimeList);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cboCustomerList);
            this.Controls.Add(this.lblEnd);
            this.Controls.Add(this.lblStart);
            this.Controls.Add(this.dtpEnd);
            this.Controls.Add(this.dtpStart);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.cboProjectList);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cboCustomerProjectList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditTimesForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Times";
            this.Load += new System.EventHandler(this.EditTimesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblProject;
        private Label lblNotes;
        private ComboBox cboProjectList;
        private TextBox txtNotes;
        private ComboBox cboCustomerProjectList;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private Button btnRefresh;
        private DateTimePicker dtpStart;
        private DateTimePicker dtpEnd;
        private Label lblStart;
        private Label lblEnd;
        private Label lblCustomer;
        private ComboBox cboCustomerList;
        private Button btnClose;
        private Button btnDeleteAll;
        private Label lblTimeList;
        private CheckedListBox clbTimeList;
        private CheckBox cbSelectAll;
    }
}