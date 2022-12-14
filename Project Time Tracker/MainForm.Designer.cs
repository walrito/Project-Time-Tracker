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
            this.editTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTimesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.msMain.Size = new System.Drawing.Size(384, 24);
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
            this.editTimesToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.customerToolStripMenuItem.Text = "&Customers";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // projectsToolStripMenuItem
            // 
            this.projectsToolStripMenuItem.Name = "projectsToolStripMenuItem";
            this.projectsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.projectsToolStripMenuItem.Text = "&Projects";
            this.projectsToolStripMenuItem.Click += new System.EventHandler(this.projectsToolStripMenuItem_Click);
            // 
            // editTimesToolStripMenuItem
            // 
            this.editTimesToolStripMenuItem.Name = "editTimesToolStripMenuItem";
            this.editTimesToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.editTimesToolStripMenuItem.Text = "&Times";
            this.editTimesToolStripMenuItem.Click += new System.EventHandler(this.editTimesToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTimesToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "&View";
            // 
            // viewTimesToolStripMenuItem
            // 
            this.viewTimesToolStripMenuItem.Name = "viewTimesToolStripMenuItem";
            this.viewTimesToolStripMenuItem.Size = new System.Drawing.Size(105, 22);
            this.viewTimesToolStripMenuItem.Text = "&Times";
            this.viewTimesToolStripMenuItem.Click += new System.EventHandler(this.viewTimesToolStripMenuItem_Click);
            // 
            // tmrMain
            // 
            this.tmrMain.Interval = 1000;
            this.tmrMain.Tick += new System.EventHandler(this.tmrMain_Tick);
            // 
            // cboProjectList
            // 
            this.cboProjectList.FormattingEnabled = true;
            this.cboProjectList.Location = new System.Drawing.Point(76, 27);
            this.cboProjectList.MaxLength = 100;
            this.cboProjectList.Name = "cboProjectList";
            this.cboProjectList.Size = new System.Drawing.Size(262, 23);
            this.cboProjectList.TabIndex = 2;
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(76, 56);
            this.txtNotes.MaxLength = 1000;
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.Size = new System.Drawing.Size(296, 93);
            this.txtNotes.TabIndex = 4;
            // 
            // btnToggleTimer
            // 
            this.btnToggleTimer.Location = new System.Drawing.Point(297, 184);
            this.btnToggleTimer.Name = "btnToggleTimer";
            this.btnToggleTimer.Size = new System.Drawing.Size(75, 23);
            this.btnToggleTimer.TabIndex = 9;
            this.btnToggleTimer.Text = "Start";
            this.btnToggleTimer.UseVisualStyleBackColor = true;
            this.btnToggleTimer.Click += new System.EventHandler(this.btnToggleTimer_Click);
            // 
            // txtTimerStart
            // 
            this.txtTimerStart.Location = new System.Drawing.Point(76, 155);
            this.txtTimerStart.Name = "txtTimerStart";
            this.txtTimerStart.ReadOnly = true;
            this.txtTimerStart.Size = new System.Drawing.Size(139, 23);
            this.txtTimerStart.TabIndex = 6;
            // 
            // txtTimerDuration
            // 
            this.txtTimerDuration.Location = new System.Drawing.Point(76, 184);
            this.txtTimerDuration.Name = "txtTimerDuration";
            this.txtTimerDuration.ReadOnly = true;
            this.txtTimerDuration.Size = new System.Drawing.Size(139, 23);
            this.txtTimerDuration.TabIndex = 8;
            // 
            // lblProject
            // 
            this.lblProject.AutoSize = true;
            this.lblProject.Location = new System.Drawing.Point(12, 30);
            this.lblProject.Name = "lblProject";
            this.lblProject.Size = new System.Drawing.Size(44, 15);
            this.lblProject.TabIndex = 1;
            this.lblProject.Text = "Project";
            // 
            // lblNotes
            // 
            this.lblNotes.AutoSize = true;
            this.lblNotes.Location = new System.Drawing.Point(12, 59);
            this.lblNotes.Name = "lblNotes";
            this.lblNotes.Size = new System.Drawing.Size(38, 15);
            this.lblNotes.TabIndex = 3;
            this.lblNotes.Text = "Notes";
            // 
            // lblTimerStart
            // 
            this.lblTimerStart.AutoSize = true;
            this.lblTimerStart.Location = new System.Drawing.Point(12, 158);
            this.lblTimerStart.Name = "lblTimerStart";
            this.lblTimerStart.Size = new System.Drawing.Size(31, 15);
            this.lblTimerStart.TabIndex = 5;
            this.lblTimerStart.Text = "Start";
            // 
            // lblTimerDuration
            // 
            this.lblTimerDuration.AutoSize = true;
            this.lblTimerDuration.Location = new System.Drawing.Point(12, 187);
            this.lblTimerDuration.Name = "lblTimerDuration";
            this.lblTimerDuration.Size = new System.Drawing.Size(53, 15);
            this.lblTimerDuration.TabIndex = 7;
            this.lblTimerDuration.Text = "Duration";
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnToggleTimer;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 219);
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
        private ToolStripMenuItem viewTimesToolStripMenuItem;
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
    }
}