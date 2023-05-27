namespace Project_Time_Tracker
{
    partial class EditAssignmentsForm
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
            this.btnDeleteAll = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomerProjectList = new System.Windows.Forms.ComboBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.btnAdd = new System.Windows.Forms.Button();
            this.cboCustomerList = new System.Windows.Forms.ComboBox();
            this.cboProjectList = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(12, 74);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(44, 15);
            this.lblProject.TabIndex = 14;
            this.lblProject.Text = "Project";
            // 
            // btnDeleteAll
            // 
            this.btnDeleteAll.Location = new System.Drawing.Point(317, 70);
            this.btnDeleteAll.Name = "btnDeleteAll";
            this.btnDeleteAll.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAll.TabIndex = 20;
            this.btnDeleteAll.Text = "Delete All";
            this.btnDeleteAll.UseVisualStyleBackColor = true;
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(317, 99);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 18;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackgroundImage = global::Project_Time_Tracker.Properties.Resources.refresh;
            this.btnRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefresh.Location = new System.Drawing.Point(12, 12);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(23, 23);
            this.btnRefresh.TabIndex = 21;
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(12, 44);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(59, 15);
            this.lblCustomer.TabIndex = 12;
            this.lblCustomer.Text = "Customer";
            // 
            // cboCustomerProjectList
            // 
            this.cboCustomerProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerProjectList.FormattingEnabled = true;
            this.cboCustomerProjectList.Location = new System.Drawing.Point(77, 12);
            this.cboCustomerProjectList.Name = "cboCustomerProjectList";
            this.cboCustomerProjectList.Size = new System.Drawing.Size(315, 23);
            this.cboCustomerProjectList.TabIndex = 11;
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(317, 41);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 23);
            this.btnDelete.TabIndex = 19;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(236, 99);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnUpdate.TabIndex = 17;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(155, 99);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 16;
            this.btnAdd.Text = "Add";
            this.btnAdd.UseVisualStyleBackColor = true;
            // 
            // cboCustomerList
            // 
            this.cboCustomerList.FormattingEnabled = true;
            this.cboCustomerList.Location = new System.Drawing.Point(77, 41);
            this.cboCustomerList.Name = "cboCustomerList";
            this.cboCustomerList.Size = new System.Drawing.Size(234, 23);
            this.cboCustomerList.TabIndex = 22;
            // 
            // cboProjectList
            // 
            this.cboProjectList.FormattingEnabled = true;
            this.cboProjectList.Location = new System.Drawing.Point(77, 70);
            this.cboProjectList.Name = "cboProjectList";
            this.cboProjectList.Size = new System.Drawing.Size(234, 23);
            this.cboProjectList.TabIndex = 23;
            // 
            // EditAssignmentsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 134);
            this.Controls.Add(this.cboProjectList);
            this.Controls.Add(this.cboCustomerList);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.btnDeleteAll);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cboCustomerProjectList);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.btnAdd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "EditAssignmentsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Edit Assignments";
            this.Load += new System.EventHandler(this.EditAssignmentsForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Label lblProject;
        private Button btnDeleteAll;
        private Button btnClose;
        private Button btnRefresh;
        private Label lblCustomer;
        private ComboBox cboCustomerProjectList;
        private Button btnDelete;
        private Button btnUpdate;
        private Button btnAdd;
        private ComboBox cboCustomerList;
        private ComboBox cboProjectList;
    }
}