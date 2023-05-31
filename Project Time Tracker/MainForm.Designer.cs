namespace Project_Time_Tracker
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.msMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.projectsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.assignmentsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrMain = new System.Windows.Forms.Timer(this.components);
            this.cboProjectList = new System.Windows.Forms.ComboBox();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.btnToggleTimer = new System.Windows.Forms.Button();
            this.txtTimerStart = new System.Windows.Forms.TextBox();
            this.txtTimerDuration = new System.Windows.Forms.TextBox();
            this.lblProject = new System.Windows.Forms.Label();
            this.lblNotes = new System.Windows.Forms.Label();
            this.lblTimerStart = new System.Windows.Forms.Label();
            this.lblTimerDuration = new System.Windows.Forms.Label();
            this.lblCustomer = new System.Windows.Forms.Label();
            this.cboCustomerList = new System.Windows.Forms.ComboBox();
            this.cboCustomerProjectList = new System.Windows.Forms.ComboBox();
            this.btnPause = new System.Windows.Forms.Button();
            this.msMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // msMain
            // 
            this.msMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.msMain.Location = new System.Drawing.Point(0, 0);
            this.msMain.Name = "msMain";
            this.msMain.Size = new System.Drawing.Size(413, 24);
            this.msMain.TabIndex = 0;
            this.msMain.Text = "msMain";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newToolStripMenuItem.Text = "&New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(95, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customerToolStripMenuItem,
            this.projectsToolStripMenuItem,
            this.assignmentsToolStripMenuItem,
            this.editTimesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.customerToolStripMenuItem.Text = "&Customers";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.projectsToolStripMenuItem.Text = "&Projects";
            this.projectsToolStripMenuItem.Click += new System.EventHandler(this.projectsToolStripMenuItem_Click);
            // 
            // assignmentsToolStripMenuItem
            // 
            this.assignmentsToolStripMenuItem.Name = "assignmentsToolStripMenuItem";
            this.assignmentsToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.assignmentsToolStripMenuItem.Text = "&Assignments";
            this.assignmentsToolStripMenuItem.Click += new System.EventHandler(this.assignmentsToolStripMenuItem_Click);
            // 
            // editTimesToolStripMenuItem
            // 
            this.editTimesToolStripMenuItem.Name = "editTimesToolStripMenuItem";
            this.editTimesToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.editTimesToolStripMenuItem.Text = "&Times";
            this.editTimesToolStripMenuItem.Click += new System.EventHandler(this.editTimesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.reportsToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.reportsToolStripMenuItem.Text = "&Reports";
            this.reportsToolStripMenuItem.Click += new System.EventHandler(this.reportsToolStripMenuItem_Click);
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // cboProjectList
            // 
            this.cboProjectList.FormattingEnabled = true;
            this.cboProjectList.Location = new System.Drawing.Point(76, 85);
            this.cboProjectList.MaxLength = 100;
            this.cboProjectList.Name = "cboProjectList";
            this.cboProjectList.Size = new System.Drawing.Size(325, 23);
            this.cboProjectList.TabIndex = 5;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(76, 114);
            this.txtNotes.MaxLength = 1000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(325, 93);
            this.txtNotes.TabIndex = 7;
            // 
            // btnToggleTimer
            // 
            this.btnToggleTimer.Location = new System.Drawing.Point(326, 241);
            this.btnToggleTimer.Name = "btnToggleTimer";
            this.btnToggleTimer.Size = new System.Drawing.Size(75, 23);
            this.btnToggleTimer.TabIndex = 12;
            this.btnToggleTimer.Text = "Start";
            this.btnToggleTimer.UseVisualStyleBackColor = true;
            this.btnToggleTimer.Click += new System.EventHandler(this.btnToggleTimer_Click);
            // 
            // txtTimerStart
            // 
            this.txtTimerStart.Location = new System.Drawing.Point(76, 213);
            this.txtTimerStart.Name = "txtTimerStart";
            this.txtTimerStart.ReadOnly = true;
            this.txtTimerStart.Size = new System.Drawing.Size(139, 23);
            this.txtTimerStart.TabIndex = 9;
            // 
            // txtTimerDuration
            // 
            this.txtTimerDuration.Location = new System.Drawing.Point(76, 242);
            this.txtTimerDuration.Name = "txtTimerDuration";
            this.txtTimerDuration.ReadOnly = true;
            this.txtTimerDuration.Size = new System.Drawing.Size(139, 23);
            this.txtTimerDuration.TabIndex = 11;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(11, 88);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(44, 15);
            this.lblProject.TabIndex = 4;
            this.lblProject.Text = "Project";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(11, 117);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 15);
            this.lblNotes.TabIndex = 6;
            this.lblNotes.Text = "Notes";
            // 
            // lblTimerStart
            // 
            this.lblTimerStart.AutoSize = true;
            this.lblTimerStart.Location = new System.Drawing.Point(11, 216);
            this.lblTimerStart.Name = "lblTimerStart";
            this.lblTimerStart.Size = new System.Drawing.Size(31, 15);
            this.lblTimerStart.TabIndex = 8;
            this.lblTimerStart.Text = "Start";
            // 
            // lblTimerDuration
            // 
            this.lblTimerDuration.AutoSize = true;
            this.lblTimerDuration.Location = new System.Drawing.Point(11, 245);
            this.lblTimerDuration.Name = "lblTimerDuration";
            this.lblTimerDuration.Size = new System.Drawing.Size(53, 15);
            this.lblTimerDuration.TabIndex = 10;
            this.lblTimerDuration.Text = "Duration";
            // 
            // lblCustomer
            // 
            this.lblCustomer.AutoSize = true;
            this.lblCustomer.Location = new System.Drawing.Point(11, 59);
            this.lblCustomer.Name = "lblCustomer";
            this.lblCustomer.Size = new System.Drawing.Size(59, 15);
            this.lblCustomer.TabIndex = 2;
            this.lblCustomer.Text = "Customer";
            // 
            // cboCustomerList
            // 
            this.cboCustomerList.FormattingEnabled = true;
            this.cboCustomerList.Location = new System.Drawing.Point(76, 56);
            this.cboCustomerList.MaxLength = 100;
            this.cboCustomerList.Name = "cboCustomerList";
            this.cboCustomerList.Size = new System.Drawing.Size(325, 23);
            this.cboCustomerList.TabIndex = 3;
            // 
            // cboCustomerProjectList
            // 
            this.cboCustomerProjectList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboCustomerProjectList.FormattingEnabled = true;
            this.cboCustomerProjectList.Location = new System.Drawing.Point(76, 27);
            this.cboCustomerProjectList.MaxLength = 100;
            this.cboCustomerProjectList.Name = "cboCustomerProjectList";
            this.cboCustomerProjectList.Size = new System.Drawing.Size(325, 23);
            this.cboCustomerProjectList.TabIndex = 1;
            this.cboCustomerProjectList.SelectedIndexChanged += new System.EventHandler(this.cboCustomerProject_SelectedIndexChanged);
            // 
            // btnPause
            // 
            this.btnPause.Enabled = false;
            this.btnPause.Location = new System.Drawing.Point(245, 241);
            this.btnPause.Name = "btnPause";
            this.btnPause.Size = new System.Drawing.Size(75, 23);
            this.btnPause.TabIndex = 13;
            this.btnPause.Text = "Pause";
            this.btnPause.UseVisualStyleBackColor = true;
            this.btnPause.Click += new System.EventHandler(this.btnPause_Click);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnToggleTimer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(413, 276);
            this.Controls.Add(this.btnPause);
            this.Controls.Add(this.cboCustomerProjectList);
            this.Controls.Add(this.lblCustomer);
            this.Controls.Add(this.cboCustomerList);
            this.Controls.Add(this.lblTimerDuration);
            this.Controls.Add(this.lblTimerStart);
            this.Controls.Add(this.lblNotes);
            this.Controls.Add(this.lblProject);
            this.Controls.Add(this.txtTimerDuration);
            this.Controls.Add(this.txtTimerStart);
            this.Controls.Add(this.btnToggleTimer);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.cboProjectList);
            this.Controls.Add(this.msMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.msMain;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Time Tracker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.msMain.ResumeLayout(false);
            this.msMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MenuStrip msMain;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem editToolStripMenuItem;
        private ToolStripMenuItem projectsToolStripMenuItem;
        private ToolStripMenuItem editTimesToolStripMenuItem;
        private ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.Timer tmrMain;
        private ComboBox cboProjectList;
        private TextBox txtNotes;
        private Button btnToggleTimer;
        private TextBox txtTimerStart;
        private TextBox txtTimerDuration;
        private Label lblProject;
        private Label lblNotes;
        private Label lblTimerStart;
        private Label lblTimerDuration;
        private ToolStripMenuItem newToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem customerToolStripMenuItem;
        private Label lblCustomer;
        private ComboBox cboCustomerList;
        private ToolStripMenuItem reportsToolStripMenuItem;
        private ComboBox cboCustomerProjectList;
        private ToolStripMenuItem assignmentsToolStripMenuItem;
        private Button btnPause;
    }
}