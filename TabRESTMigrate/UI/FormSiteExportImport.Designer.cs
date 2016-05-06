namespace TabRESTMigrate.UI
{
    partial class FormSiteExportImport
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
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.splitContainerStatus = new System.Windows.Forms.SplitContainer();
            this.btnAbortRun = new System.Windows.Forms.Button();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.chkVerboseLog = new System.Windows.Forms.CheckBox();
            this.textBoxErrors = new System.Windows.Forms.TextBox();
            this.panelImportSite = new System.Windows.Forms.Panel();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.txtDBCredentialsImport = new System.Windows.Forms.TextBox();
            this.chkRemapWorkbookDataserverReferences = new System.Windows.Forms.CheckBox();
            this.btnLinkImportCommandLine = new System.Windows.Forms.LinkLabel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSiteImportCommandLineExample = new System.Windows.Forms.TextBox();
            this.txtUrlImportTo = new System.Windows.Forms.TextBox();
            this.txtIdImportTo = new System.Windows.Forms.TextBox();
            this.txtPasswordImportTo = new System.Windows.Forms.TextBox();
            this.buttonRunAsyncImport = new System.Windows.Forms.Button();
            this.txtSiteImportContentPath = new System.Windows.Forms.TextBox();
            this.chkImportIsSystemAdmin = new System.Windows.Forms.CheckBox();
            this.textSiteExportCommandLine = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chkExportUserIsAdmin = new System.Windows.Forms.CheckBox();
            this.btnRunAsync = new System.Windows.Forms.Button();
            this.txtPasswordExportFrom = new System.Windows.Forms.TextBox();
            this.txtIdExportFrom = new System.Windows.Forms.TextBox();
            this.txtUrlExportFrom = new System.Windows.Forms.TextBox();
            this.panelExportSite = new System.Windows.Forms.Panel();
            this.chkExportRemoveExportTag = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtExportOnlyTagged = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtExportSingleProject = new System.Windows.Forms.TextBox();
            this.btnLinkExportSiteCommandLine = new System.Windows.Forms.LinkLabel();
            this.panelInventorySite = new System.Windows.Forms.Panel();
            this.chkGenerateInventoryTwb = new System.Windows.Forms.CheckBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtInventoryExampleCommandLine = new System.Windows.Forms.TextBox();
            this.btnLinkInventoryCommandLine = new System.Windows.Forms.LinkLabel();
            this.chkInventoryUserIsSystemAdmin = new System.Windows.Forms.CheckBox();
            this.txtUrlInventoryFrom = new System.Windows.Forms.TextBox();
            this.txtIdInventoryFromUserId = new System.Windows.Forms.TextBox();
            this.txtPasswordInventoryFrom = new System.Windows.Forms.TextBox();
            this.buttonRunInventorySite = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panelRunCommandLine = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxChooseAction = new System.Windows.Forms.ComboBox();
            this.panelTopSplitter = new System.Windows.Forms.Panel();
            this.checkBoxRememberPassword = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).BeginInit();
            this.splitContainerStatus.Panel1.SuspendLayout();
            this.splitContainerStatus.Panel2.SuspendLayout();
            this.splitContainerStatus.SuspendLayout();
            this.panelImportSite.SuspendLayout();
            this.panelExportSite.SuspendLayout();
            this.panelInventorySite.SuspendLayout();
            this.panelRunCommandLine.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // splitContainerStatus
            // 
            this.splitContainerStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainerStatus.Location = new System.Drawing.Point(8, 695);
            this.splitContainerStatus.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.splitContainerStatus.Name = "splitContainerStatus";
            // 
            // splitContainerStatus.Panel1
            // 
            this.splitContainerStatus.Panel1.Controls.Add(this.btnAbortRun);
            this.splitContainerStatus.Panel1.Controls.Add(this.textBoxStatus);
            // 
            // splitContainerStatus.Panel2
            // 
            this.splitContainerStatus.Panel2.Controls.Add(this.chkVerboseLog);
            this.splitContainerStatus.Panel2.Controls.Add(this.textBoxErrors);
            this.splitContainerStatus.Size = new System.Drawing.Size(1886, 247);
            this.splitContainerStatus.SplitterDistance = 1203;
            this.splitContainerStatus.SplitterWidth = 6;
            this.splitContainerStatus.TabIndex = 18;
            // 
            // btnAbortRun
            // 
            this.btnAbortRun.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAbortRun.BackColor = System.Drawing.Color.Red;
            this.btnAbortRun.FlatAppearance.BorderSize = 0;
            this.btnAbortRun.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAbortRun.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAbortRun.ForeColor = System.Drawing.Color.White;
            this.btnAbortRun.Location = new System.Drawing.Point(936, 166);
            this.btnAbortRun.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAbortRun.Name = "btnAbortRun";
            this.btnAbortRun.Size = new System.Drawing.Size(225, 75);
            this.btnAbortRun.TabIndex = 35;
            this.btnAbortRun.Text = "Abort";
            this.btnAbortRun.UseVisualStyleBackColor = false;
            this.btnAbortRun.Visible = false;
            this.btnAbortRun.Click += new System.EventHandler(this.btnAbortRun_Click);
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.BackColor = System.Drawing.Color.White;
            this.textBoxStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.textBoxStatus.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ReadOnly = true;
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxStatus.Size = new System.Drawing.Size(1196, 238);
            this.textBoxStatus.TabIndex = 5;
            this.textBoxStatus.Text = "not yet started...";
            // 
            // chkVerboseLog
            // 
            this.chkVerboseLog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkVerboseLog.AutoSize = true;
            this.chkVerboseLog.Checked = true;
            this.chkVerboseLog.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkVerboseLog.Location = new System.Drawing.Point(423, 199);
            this.chkVerboseLog.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkVerboseLog.Name = "chkVerboseLog";
            this.chkVerboseLog.Size = new System.Drawing.Size(200, 29);
            this.chkVerboseLog.TabIndex = 11;
            this.chkVerboseLog.Text = "Verbose logging";
            this.chkVerboseLog.UseVisualStyleBackColor = true;
            // 
            // textBoxErrors
            // 
            this.textBoxErrors.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxErrors.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.textBoxErrors.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxErrors.Location = new System.Drawing.Point(0, 0);
            this.textBoxErrors.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textBoxErrors.Multiline = true;
            this.textBoxErrors.Name = "textBoxErrors";
            this.textBoxErrors.ReadOnly = true;
            this.textBoxErrors.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxErrors.Size = new System.Drawing.Size(662, 238);
            this.textBoxErrors.TabIndex = 8;
            this.textBoxErrors.Text = "no errors yet...";
            // 
            // panelImportSite
            // 
            this.panelImportSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelImportSite.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.panelImportSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelImportSite.Controls.Add(this.label17);
            this.panelImportSite.Controls.Add(this.label16);
            this.panelImportSite.Controls.Add(this.label13);
            this.panelImportSite.Controls.Add(this.label14);
            this.panelImportSite.Controls.Add(this.label15);
            this.panelImportSite.Controls.Add(this.txtDBCredentialsImport);
            this.panelImportSite.Controls.Add(this.chkRemapWorkbookDataserverReferences);
            this.panelImportSite.Controls.Add(this.btnLinkImportCommandLine);
            this.panelImportSite.Controls.Add(this.label2);
            this.panelImportSite.Controls.Add(this.txtSiteImportCommandLineExample);
            this.panelImportSite.Controls.Add(this.txtUrlImportTo);
            this.panelImportSite.Controls.Add(this.txtIdImportTo);
            this.panelImportSite.Controls.Add(this.txtPasswordImportTo);
            this.panelImportSite.Controls.Add(this.buttonRunAsyncImport);
            this.panelImportSite.Controls.Add(this.txtSiteImportContentPath);
            this.panelImportSite.Controls.Add(this.chkImportIsSystemAdmin);
            this.panelImportSite.Location = new System.Drawing.Point(18, 164);
            this.panelImportSite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelImportSite.Name = "panelImportSite";
            this.panelImportSite.Size = new System.Drawing.Size(1754, 686);
            this.panelImportSite.TabIndex = 52;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.ForeColor = System.Drawing.Color.DarkGray;
            this.label17.Location = new System.Drawing.Point(15, 203);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(604, 25);
            this.label17.TabIndex = 97;
            this.label17.Text = "xml file with database credentials for upload content (optional)";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.ForeColor = System.Drawing.Color.DarkGray;
            this.label16.Location = new System.Drawing.Point(15, 47);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(427, 25);
            this.label16.TabIndex = 96;
            this.label16.Text = "local file system path to import content from";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.DarkGray;
            this.label13.Location = new System.Drawing.Point(570, 125);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(241, 25);
            this.label13.TabIndex = 95;
            this.label13.Text = "url to any content in site";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.ForeColor = System.Drawing.Color.DarkGray;
            this.label14.Location = new System.Drawing.Point(322, 125);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(174, 25);
            this.label14.TabIndex = 94;
            this.label14.Text = "sign-in password";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.DarkGray;
            this.label15.Location = new System.Drawing.Point(15, 125);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 25);
            this.label15.TabIndex = 93;
            this.label15.Text = "sign-in id";
            // 
            // txtDBCredentialsImport
            // 
            this.txtDBCredentialsImport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDBCredentialsImport.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtDBCredentialsImport.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtDBCredentialsImport.Location = new System.Drawing.Point(15, 234);
            this.txtDBCredentialsImport.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtDBCredentialsImport.Name = "txtDBCredentialsImport";
            this.txtDBCredentialsImport.Size = new System.Drawing.Size(1481, 31);
            this.txtDBCredentialsImport.TabIndex = 5;
            this.txtDBCredentialsImport.Text = "db credentials file path here";
            // 
            // chkRemapWorkbookDataserverReferences
            // 
            this.chkRemapWorkbookDataserverReferences.AutoSize = true;
            this.chkRemapWorkbookDataserverReferences.Checked = true;
            this.chkRemapWorkbookDataserverReferences.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkRemapWorkbookDataserverReferences.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkRemapWorkbookDataserverReferences.Location = new System.Drawing.Point(622, 281);
            this.chkRemapWorkbookDataserverReferences.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRemapWorkbookDataserverReferences.Name = "chkRemapWorkbookDataserverReferences";
            this.chkRemapWorkbookDataserverReferences.Size = new System.Drawing.Size(421, 29);
            this.chkRemapWorkbookDataserverReferences.TabIndex = 7;
            this.chkRemapWorkbookDataserverReferences.Text = "Remap workbook dataserver references";
            this.chkRemapWorkbookDataserverReferences.UseVisualStyleBackColor = true;
            // 
            // btnLinkImportCommandLine
            // 
            this.btnLinkImportCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkImportCommandLine.AutoSize = true;
            this.btnLinkImportCommandLine.Location = new System.Drawing.Point(1328, 297);
            this.btnLinkImportCommandLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnLinkImportCommandLine.Name = "btnLinkImportCommandLine";
            this.btnLinkImportCommandLine.Size = new System.Drawing.Size(423, 25);
            this.btnLinkImportCommandLine.TabIndex = 9;
            this.btnLinkImportCommandLine.TabStop = true;
            this.btnLinkImportCommandLine.Text = "Generate command line showing password";
            this.btnLinkImportCommandLine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLinkImportCommandLine_LinkClicked);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(503, 37);
            this.label2.TabIndex = 50;
            this.label2.Text = "Upload from file system into site";
            // 
            // txtSiteImportCommandLineExample
            // 
            this.txtSiteImportCommandLineExample.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteImportCommandLineExample.BackColor = System.Drawing.Color.Black;
            this.txtSiteImportCommandLineExample.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSiteImportCommandLineExample.ForeColor = System.Drawing.Color.White;
            this.txtSiteImportCommandLineExample.Location = new System.Drawing.Point(15, 328);
            this.txtSiteImportCommandLineExample.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSiteImportCommandLineExample.Multiline = true;
            this.txtSiteImportCommandLineExample.Name = "txtSiteImportCommandLineExample";
            this.txtSiteImportCommandLineExample.ReadOnly = true;
            this.txtSiteImportCommandLineExample.Size = new System.Drawing.Size(1723, 209);
            this.txtSiteImportCommandLineExample.TabIndex = 51;
            this.txtSiteImportCommandLineExample.Text = "example command line generated here...";
            // 
            // txtUrlImportTo
            // 
            this.txtUrlImportTo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtUrlImportTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtUrlImportTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlImportTo.Location = new System.Drawing.Point(570, 156);
            this.txtUrlImportTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUrlImportTo.Name = "txtUrlImportTo";
            this.txtUrlImportTo.Size = new System.Drawing.Size(916, 31);
            this.txtUrlImportTo.TabIndex = 4;
            this.txtUrlImportTo.Text = "http://my-tableau-server/#/site/MySite/";
            // 
            // txtIdImportTo
            // 
            this.txtIdImportTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtIdImportTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdImportTo.Location = new System.Drawing.Point(15, 156);
            this.txtIdImportTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdImportTo.Name = "txtIdImportTo";
            this.txtIdImportTo.Size = new System.Drawing.Size(299, 31);
            this.txtIdImportTo.TabIndex = 2;
            this.txtIdImportTo.Text = "TestUserId";
            // 
            // txtPasswordImportTo
            // 
            this.txtPasswordImportTo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtPasswordImportTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordImportTo.Location = new System.Drawing.Point(322, 156);
            this.txtPasswordImportTo.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPasswordImportTo.Name = "txtPasswordImportTo";
            this.txtPasswordImportTo.PasswordChar = '*';
            this.txtPasswordImportTo.Size = new System.Drawing.Size(239, 31);
            this.txtPasswordImportTo.TabIndex = 3;
            this.txtPasswordImportTo.Text = "pw";
            // 
            // buttonRunAsyncImport
            // 
            this.buttonRunAsyncImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunAsyncImport.BackColor = System.Drawing.Color.Purple;
            this.buttonRunAsyncImport.FlatAppearance.BorderSize = 0;
            this.buttonRunAsyncImport.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRunAsyncImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRunAsyncImport.ForeColor = System.Drawing.Color.White;
            this.buttonRunAsyncImport.Location = new System.Drawing.Point(1515, 8);
            this.buttonRunAsyncImport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRunAsyncImport.Name = "buttonRunAsyncImport";
            this.buttonRunAsyncImport.Size = new System.Drawing.Size(225, 78);
            this.buttonRunAsyncImport.TabIndex = 8;
            this.buttonRunAsyncImport.Text = "Publish";
            this.buttonRunAsyncImport.UseVisualStyleBackColor = false;
            this.buttonRunAsyncImport.Click += new System.EventHandler(this.buttonRunAsyncImport_Click);
            // 
            // txtSiteImportContentPath
            // 
            this.txtSiteImportContentPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSiteImportContentPath.BackColor = System.Drawing.Color.White;
            this.txtSiteImportContentPath.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtSiteImportContentPath.Location = new System.Drawing.Point(15, 78);
            this.txtSiteImportContentPath.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSiteImportContentPath.Name = "txtSiteImportContentPath";
            this.txtSiteImportContentPath.Size = new System.Drawing.Size(990, 31);
            this.txtSiteImportContentPath.TabIndex = 1;
            this.txtSiteImportContentPath.Text = "C:\\ivosa_work\\_SoftwareProjects\\ServerMigrateSite_REST_003\\tests\\upload001";
            // 
            // chkImportIsSystemAdmin
            // 
            this.chkImportIsSystemAdmin.AutoSize = true;
            this.chkImportIsSystemAdmin.Checked = true;
            this.chkImportIsSystemAdmin.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkImportIsSystemAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkImportIsSystemAdmin.Location = new System.Drawing.Point(15, 281);
            this.chkImportIsSystemAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkImportIsSystemAdmin.Name = "chkImportIsSystemAdmin";
            this.chkImportIsSystemAdmin.Size = new System.Drawing.Size(571, 29);
            this.chkImportIsSystemAdmin.TabIndex = 6;
            this.chkImportIsSystemAdmin.Text = "User is system admin (needed to create projects in site)";
            this.chkImportIsSystemAdmin.UseVisualStyleBackColor = true;
            // 
            // textSiteExportCommandLine
            // 
            this.textSiteExportCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textSiteExportCommandLine.BackColor = System.Drawing.Color.Black;
            this.textSiteExportCommandLine.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textSiteExportCommandLine.ForeColor = System.Drawing.Color.White;
            this.textSiteExportCommandLine.Location = new System.Drawing.Point(15, 281);
            this.textSiteExportCommandLine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.textSiteExportCommandLine.Multiline = true;
            this.textSiteExportCommandLine.Name = "textSiteExportCommandLine";
            this.textSiteExportCommandLine.ReadOnly = true;
            this.textSiteExportCommandLine.Size = new System.Drawing.Size(1806, 209);
            this.textSiteExportCommandLine.TabIndex = 37;
            this.textSiteExportCommandLine.Text = "example command line generated here...";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(8, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(561, 37);
            this.label1.TabIndex = 43;
            this.label1.Text = "Export site content to local directory";
            // 
            // chkExportUserIsAdmin
            // 
            this.chkExportUserIsAdmin.AutoSize = true;
            this.chkExportUserIsAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportUserIsAdmin.Location = new System.Drawing.Point(15, 125);
            this.chkExportUserIsAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkExportUserIsAdmin.Name = "chkExportUserIsAdmin";
            this.chkExportUserIsAdmin.Size = new System.Drawing.Size(674, 29);
            this.chkExportUserIsAdmin.TabIndex = 33;
            this.chkExportUserIsAdmin.Text = "User is system admin (site users, and site info will be downloaded)";
            this.chkExportUserIsAdmin.UseVisualStyleBackColor = true;
            // 
            // btnRunAsync
            // 
            this.btnRunAsync.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRunAsync.BackColor = System.Drawing.Color.Purple;
            this.btnRunAsync.FlatAppearance.BorderSize = 0;
            this.btnRunAsync.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRunAsync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRunAsync.ForeColor = System.Drawing.Color.White;
            this.btnRunAsync.Location = new System.Drawing.Point(1598, 8);
            this.btnRunAsync.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnRunAsync.Name = "btnRunAsync";
            this.btnRunAsync.Size = new System.Drawing.Size(225, 78);
            this.btnRunAsync.TabIndex = 35;
            this.btnRunAsync.Text = "Export site";
            this.btnRunAsync.UseVisualStyleBackColor = false;
            this.btnRunAsync.Click += new System.EventHandler(this.btnRunExportAsync_Click);
            // 
            // txtPasswordExportFrom
            // 
            this.txtPasswordExportFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtPasswordExportFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordExportFrom.Location = new System.Drawing.Point(330, 78);
            this.txtPasswordExportFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPasswordExportFrom.Name = "txtPasswordExportFrom";
            this.txtPasswordExportFrom.PasswordChar = '*';
            this.txtPasswordExportFrom.Size = new System.Drawing.Size(239, 31);
            this.txtPasswordExportFrom.TabIndex = 31;
            this.txtPasswordExportFrom.Text = "pw";
            // 
            // txtIdExportFrom
            // 
            this.txtIdExportFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtIdExportFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdExportFrom.Location = new System.Drawing.Point(15, 78);
            this.txtIdExportFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdExportFrom.Name = "txtIdExportFrom";
            this.txtIdExportFrom.Size = new System.Drawing.Size(302, 31);
            this.txtIdExportFrom.TabIndex = 30;
            this.txtIdExportFrom.Text = "testuser@example.com";
            // 
            // txtUrlExportFrom
            // 
            this.txtUrlExportFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtUrlExportFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlExportFrom.Location = new System.Drawing.Point(578, 78);
            this.txtUrlExportFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUrlExportFrom.Name = "txtUrlExportFrom";
            this.txtUrlExportFrom.Size = new System.Drawing.Size(677, 31);
            this.txtUrlExportFrom.TabIndex = 32;
            this.txtUrlExportFrom.Text = "https://10az.online.tableau.com/#/site/my-test-site/projects";
            // 
            // panelExportSite
            // 
            this.panelExportSite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelExportSite.BackColor = System.Drawing.Color.Bisque;
            this.panelExportSite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelExportSite.Controls.Add(this.chkExportRemoveExportTag);
            this.panelExportSite.Controls.Add(this.label5);
            this.panelExportSite.Controls.Add(this.txtExportOnlyTagged);
            this.panelExportSite.Controls.Add(this.label12);
            this.panelExportSite.Controls.Add(this.label9);
            this.panelExportSite.Controls.Add(this.label10);
            this.panelExportSite.Controls.Add(this.label11);
            this.panelExportSite.Controls.Add(this.txtExportSingleProject);
            this.panelExportSite.Controls.Add(this.btnLinkExportSiteCommandLine);
            this.panelExportSite.Controls.Add(this.label1);
            this.panelExportSite.Controls.Add(this.txtUrlExportFrom);
            this.panelExportSite.Controls.Add(this.textSiteExportCommandLine);
            this.panelExportSite.Controls.Add(this.txtIdExportFrom);
            this.panelExportSite.Controls.Add(this.txtPasswordExportFrom);
            this.panelExportSite.Controls.Add(this.chkExportUserIsAdmin);
            this.panelExportSite.Controls.Add(this.btnRunAsync);
            this.panelExportSite.Location = new System.Drawing.Point(396, 88);
            this.panelExportSite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelExportSite.Name = "panelExportSite";
            this.panelExportSite.Size = new System.Drawing.Size(1836, 549);
            this.panelExportSite.TabIndex = 53;
            // 
            // chkExportRemoveExportTag
            // 
            this.chkExportRemoveExportTag.AutoSize = true;
            this.chkExportRemoveExportTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkExportRemoveExportTag.Location = new System.Drawing.Point(532, 242);
            this.chkExportRemoveExportTag.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkExportRemoveExportTag.Name = "chkExportRemoveExportTag";
            this.chkExportRemoveExportTag.Size = new System.Drawing.Size(369, 29);
            this.chkExportRemoveExportTag.TabIndex = 96;
            this.chkExportRemoveExportTag.Text = "Remove tag from exported content";
            this.chkExportRemoveExportTag.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.DarkGray;
            this.label5.Location = new System.Drawing.Point(525, 164);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(309, 25);
            this.label5.TabIndex = 95;
            this.label5.Text = "export only if tagged (optional) ";
            // 
            // txtExportOnlyTagged
            // 
            this.txtExportOnlyTagged.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtExportOnlyTagged.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExportOnlyTagged.Location = new System.Drawing.Point(532, 195);
            this.txtExportOnlyTagged.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtExportOnlyTagged.Name = "txtExportOnlyTagged";
            this.txtExportOnlyTagged.Size = new System.Drawing.Size(299, 31);
            this.txtExportOnlyTagged.TabIndex = 94;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.DarkGray;
            this.label12.Location = new System.Drawing.Point(15, 164);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(497, 25);
            this.label12.TabIndex = 93;
            this.label12.Text = "export content from only a single project (optional) ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.DarkGray;
            this.label9.Location = new System.Drawing.Point(572, 45);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(241, 25);
            this.label9.TabIndex = 92;
            this.label9.Text = "url to any content in site";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.ForeColor = System.Drawing.Color.DarkGray;
            this.label10.Location = new System.Drawing.Point(322, 47);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(174, 25);
            this.label10.TabIndex = 91;
            this.label10.Text = "sign-in password";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.ForeColor = System.Drawing.Color.DarkGray;
            this.label11.Location = new System.Drawing.Point(15, 47);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(99, 25);
            this.label11.TabIndex = 90;
            this.label11.Text = "sign-in id";
            // 
            // txtExportSingleProject
            // 
            this.txtExportSingleProject.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtExportSingleProject.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtExportSingleProject.Location = new System.Drawing.Point(15, 195);
            this.txtExportSingleProject.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtExportSingleProject.Name = "txtExportSingleProject";
            this.txtExportSingleProject.Size = new System.Drawing.Size(479, 31);
            this.txtExportSingleProject.TabIndex = 34;
            // 
            // btnLinkExportSiteCommandLine
            // 
            this.btnLinkExportSiteCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkExportSiteCommandLine.AutoSize = true;
            this.btnLinkExportSiteCommandLine.Location = new System.Drawing.Point(1410, 250);
            this.btnLinkExportSiteCommandLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnLinkExportSiteCommandLine.Name = "btnLinkExportSiteCommandLine";
            this.btnLinkExportSiteCommandLine.Size = new System.Drawing.Size(423, 25);
            this.btnLinkExportSiteCommandLine.TabIndex = 36;
            this.btnLinkExportSiteCommandLine.TabStop = true;
            this.btnLinkExportSiteCommandLine.Text = "Generate command line showing password";
            this.btnLinkExportSiteCommandLine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLinkExportSiteCommandLine_LinkClicked);
            // 
            // panelInventorySite
            // 
            this.panelInventorySite.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInventorySite.BackColor = System.Drawing.Color.DarkSalmon;
            this.panelInventorySite.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelInventorySite.Controls.Add(this.checkBoxRememberPassword);
            this.panelInventorySite.Controls.Add(this.chkGenerateInventoryTwb);
            this.panelInventorySite.Controls.Add(this.label8);
            this.panelInventorySite.Controls.Add(this.label7);
            this.panelInventorySite.Controls.Add(this.label6);
            this.panelInventorySite.Controls.Add(this.txtInventoryExampleCommandLine);
            this.panelInventorySite.Controls.Add(this.btnLinkInventoryCommandLine);
            this.panelInventorySite.Controls.Add(this.chkInventoryUserIsSystemAdmin);
            this.panelInventorySite.Controls.Add(this.txtUrlInventoryFrom);
            this.panelInventorySite.Controls.Add(this.txtIdInventoryFromUserId);
            this.panelInventorySite.Controls.Add(this.txtPasswordInventoryFrom);
            this.panelInventorySite.Controls.Add(this.buttonRunInventorySite);
            this.panelInventorySite.Controls.Add(this.label3);
            this.panelInventorySite.Location = new System.Drawing.Point(48, 145);
            this.panelInventorySite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelInventorySite.Name = "panelInventorySite";
            this.panelInventorySite.Size = new System.Drawing.Size(1724, 447);
            this.panelInventorySite.TabIndex = 57;
            // 
            // chkGenerateInventoryTwb
            // 
            this.chkGenerateInventoryTwb.AutoSize = true;
            this.chkGenerateInventoryTwb.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkGenerateInventoryTwb.Location = new System.Drawing.Point(788, 133);
            this.chkGenerateInventoryTwb.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGenerateInventoryTwb.Name = "chkGenerateInventoryTwb";
            this.chkGenerateInventoryTwb.Size = new System.Drawing.Size(315, 29);
            this.chkGenerateInventoryTwb.TabIndex = 90;
            this.chkGenerateInventoryTwb.Text = "Generate Tableau Workbook";
            this.chkGenerateInventoryTwb.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkGray;
            this.label8.Location = new System.Drawing.Point(570, 47);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(241, 25);
            this.label8.TabIndex = 89;
            this.label8.Text = "url to any content in site";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.DarkGray;
            this.label7.Location = new System.Drawing.Point(322, 47);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(174, 25);
            this.label7.TabIndex = 88;
            this.label7.Text = "sign-in password";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.DarkGray;
            this.label6.Location = new System.Drawing.Point(15, 47);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 25);
            this.label6.TabIndex = 87;
            this.label6.Text = "sign-in id";
            // 
            // txtInventoryExampleCommandLine
            // 
            this.txtInventoryExampleCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInventoryExampleCommandLine.BackColor = System.Drawing.Color.Black;
            this.txtInventoryExampleCommandLine.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtInventoryExampleCommandLine.Font = new System.Drawing.Font("Consolas", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInventoryExampleCommandLine.ForeColor = System.Drawing.Color.White;
            this.txtInventoryExampleCommandLine.Location = new System.Drawing.Point(15, 172);
            this.txtInventoryExampleCommandLine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInventoryExampleCommandLine.Multiline = true;
            this.txtInventoryExampleCommandLine.Name = "txtInventoryExampleCommandLine";
            this.txtInventoryExampleCommandLine.ReadOnly = true;
            this.txtInventoryExampleCommandLine.Size = new System.Drawing.Size(1692, 210);
            this.txtInventoryExampleCommandLine.TabIndex = 86;
            this.txtInventoryExampleCommandLine.Text = "example command line generated here...";
            // 
            // btnLinkInventoryCommandLine
            // 
            this.btnLinkInventoryCommandLine.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLinkInventoryCommandLine.AutoSize = true;
            this.btnLinkInventoryCommandLine.Location = new System.Drawing.Point(1296, 141);
            this.btnLinkInventoryCommandLine.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.btnLinkInventoryCommandLine.Name = "btnLinkInventoryCommandLine";
            this.btnLinkInventoryCommandLine.Size = new System.Drawing.Size(423, 25);
            this.btnLinkInventoryCommandLine.TabIndex = 85;
            this.btnLinkInventoryCommandLine.TabStop = true;
            this.btnLinkInventoryCommandLine.Text = "Generate command line showing password";
            this.btnLinkInventoryCommandLine.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btnLinkInventoryCommandLine_LinkClicked);
            // 
            // chkInventoryUserIsSystemAdmin
            // 
            this.chkInventoryUserIsSystemAdmin.AutoSize = true;
            this.chkInventoryUserIsSystemAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.chkInventoryUserIsSystemAdmin.Location = new System.Drawing.Point(16, 133);
            this.chkInventoryUserIsSystemAdmin.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkInventoryUserIsSystemAdmin.Name = "chkInventoryUserIsSystemAdmin";
            this.chkInventoryUserIsSystemAdmin.Size = new System.Drawing.Size(756, 29);
            this.chkInventoryUserIsSystemAdmin.TabIndex = 83;
            this.chkInventoryUserIsSystemAdmin.Text = "User is system admin (site users, and site info will be included in inventory)";
            this.chkInventoryUserIsSystemAdmin.UseVisualStyleBackColor = true;
            // 
            // txtUrlInventoryFrom
            // 
            this.txtUrlInventoryFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtUrlInventoryFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUrlInventoryFrom.Location = new System.Drawing.Point(570, 78);
            this.txtUrlInventoryFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtUrlInventoryFrom.Name = "txtUrlInventoryFrom";
            this.txtUrlInventoryFrom.Size = new System.Drawing.Size(674, 31);
            this.txtUrlInventoryFrom.TabIndex = 82;
            this.txtUrlInventoryFrom.Text = "https://10az.online.tableau.com/#/site/my-test-site";
            // 
            // txtIdInventoryFromUserId
            // 
            this.txtIdInventoryFromUserId.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtIdInventoryFromUserId.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtIdInventoryFromUserId.Location = new System.Drawing.Point(15, 78);
            this.txtIdInventoryFromUserId.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtIdInventoryFromUserId.Name = "txtIdInventoryFromUserId";
            this.txtIdInventoryFromUserId.Size = new System.Drawing.Size(299, 31);
            this.txtIdInventoryFromUserId.TabIndex = 80;
            this.txtIdInventoryFromUserId.Text = "test@example.com";
            // 
            // txtPasswordInventoryFrom
            // 
            this.txtPasswordInventoryFrom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(250)))), ((int)(((byte)(250)))), ((int)(((byte)(255)))));
            this.txtPasswordInventoryFrom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtPasswordInventoryFrom.Location = new System.Drawing.Point(322, 78);
            this.txtPasswordInventoryFrom.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPasswordInventoryFrom.Name = "txtPasswordInventoryFrom";
            this.txtPasswordInventoryFrom.PasswordChar = '*';
            this.txtPasswordInventoryFrom.Size = new System.Drawing.Size(239, 31);
            this.txtPasswordInventoryFrom.TabIndex = 81;
            this.txtPasswordInventoryFrom.Text = "pw";
            // 
            // buttonRunInventorySite
            // 
            this.buttonRunInventorySite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonRunInventorySite.BackColor = System.Drawing.Color.Purple;
            this.buttonRunInventorySite.FlatAppearance.BorderSize = 0;
            this.buttonRunInventorySite.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRunInventorySite.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRunInventorySite.ForeColor = System.Drawing.Color.White;
            this.buttonRunInventorySite.Location = new System.Drawing.Point(1485, 8);
            this.buttonRunInventorySite.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonRunInventorySite.Name = "buttonRunInventorySite";
            this.buttonRunInventorySite.Size = new System.Drawing.Size(225, 75);
            this.buttonRunInventorySite.TabIndex = 84;
            this.buttonRunInventorySite.Text = "Run now";
            this.buttonRunInventorySite.UseVisualStyleBackColor = false;
            this.buttonRunInventorySite.Click += new System.EventHandler(this.buttonRunInventorySite_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(8, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(564, 37);
            this.label3.TabIndex = 44;
            this.label3.Text = "Generate CSV file of site\'s inventory";
            // 
            // panelRunCommandLine
            // 
            this.panelRunCommandLine.Controls.Add(this.label4);
            this.panelRunCommandLine.Location = new System.Drawing.Point(1782, 336);
            this.panelRunCommandLine.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelRunCommandLine.Name = "panelRunCommandLine";
            this.panelRunCommandLine.Size = new System.Drawing.Size(1852, 98);
            this.panelRunCommandLine.TabIndex = 58;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(395, 37);
            this.label4.TabIndex = 45;
            this.label4.Text = "Running command line...";
            // 
            // comboBoxChooseAction
            // 
            this.comboBoxChooseAction.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxChooseAction.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBoxChooseAction.FormattingEnabled = true;
            this.comboBoxChooseAction.Location = new System.Drawing.Point(0, 0);
            this.comboBoxChooseAction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxChooseAction.Name = "comboBoxChooseAction";
            this.comboBoxChooseAction.Size = new System.Drawing.Size(772, 50);
            this.comboBoxChooseAction.TabIndex = 60;
            this.comboBoxChooseAction.SelectedIndexChanged += new System.EventHandler(this.comboBoxChooseAction_SelectedIndexChanged);
            // 
            // panelTopSplitter
            // 
            this.panelTopSplitter.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelTopSplitter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.panelTopSplitter.Location = new System.Drawing.Point(-1254, 77);
            this.panelTopSplitter.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panelTopSplitter.Name = "panelTopSplitter";
            this.panelTopSplitter.Size = new System.Drawing.Size(3753, 2);
            this.panelTopSplitter.TabIndex = 59;
            this.panelTopSplitter.Visible = false;
            // 
            // checkBoxRememberPassword
            // 
            this.checkBoxRememberPassword.AutoSize = true;
            this.checkBoxRememberPassword.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.checkBoxRememberPassword.Location = new System.Drawing.Point(1262, 78);
            this.checkBoxRememberPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.checkBoxRememberPassword.Name = "checkBoxRememberPassword";
            this.checkBoxRememberPassword.Size = new System.Drawing.Size(243, 29);
            this.checkBoxRememberPassword.TabIndex = 91;
            this.checkBoxRememberPassword.Text = "Remember Password";
            this.checkBoxRememberPassword.UseVisualStyleBackColor = true;
            // 
            // FormSiteExportImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1911, 961);
            this.Controls.Add(this.panelInventorySite);
            this.Controls.Add(this.panelExportSite);
            this.Controls.Add(this.panelTopSplitter);
            this.Controls.Add(this.comboBoxChooseAction);
            this.Controls.Add(this.panelRunCommandLine);
            this.Controls.Add(this.splitContainerStatus);
            this.Controls.Add(this.panelImportSite);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MinimumSize = new System.Drawing.Size(1637, 898);
            this.Name = "FormSiteExportImport";
            this.Text = "Online - Site export/import";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.splitContainerStatus.Panel1.ResumeLayout(false);
            this.splitContainerStatus.Panel1.PerformLayout();
            this.splitContainerStatus.Panel2.ResumeLayout(false);
            this.splitContainerStatus.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerStatus)).EndInit();
            this.splitContainerStatus.ResumeLayout(false);
            this.panelImportSite.ResumeLayout(false);
            this.panelImportSite.PerformLayout();
            this.panelExportSite.ResumeLayout(false);
            this.panelExportSite.PerformLayout();
            this.panelInventorySite.ResumeLayout(false);
            this.panelInventorySite.PerformLayout();
            this.panelRunCommandLine.ResumeLayout(false);
            this.panelRunCommandLine.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.SplitContainer splitContainerStatus;
        private System.Windows.Forms.TextBox textSiteExportCommandLine;
        private System.Windows.Forms.TextBox textBoxErrors;
        private System.Windows.Forms.CheckBox chkVerboseLog;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chkExportUserIsAdmin;
        private System.Windows.Forms.Button btnRunAsync;
        private System.Windows.Forms.TextBox txtPasswordExportFrom;
        private System.Windows.Forms.TextBox txtIdExportFrom;
        private System.Windows.Forms.TextBox txtUrlExportFrom;
        private System.Windows.Forms.CheckBox chkImportIsSystemAdmin;
        private System.Windows.Forms.TextBox txtSiteImportContentPath;
        private System.Windows.Forms.Button buttonRunAsyncImport;
        private System.Windows.Forms.TextBox txtPasswordImportTo;
        private System.Windows.Forms.TextBox txtIdImportTo;
        private System.Windows.Forms.TextBox txtUrlImportTo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSiteImportCommandLineExample;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.Panel panelImportSite;
        private System.Windows.Forms.Panel panelExportSite;
        private System.Windows.Forms.Panel panelInventorySite;
        private System.Windows.Forms.TextBox txtUrlInventoryFrom;
        private System.Windows.Forms.TextBox txtIdInventoryFromUserId;
        private System.Windows.Forms.TextBox txtPasswordInventoryFrom;
        private System.Windows.Forms.Button buttonRunInventorySite;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkInventoryUserIsSystemAdmin;
        private System.Windows.Forms.TextBox txtInventoryExampleCommandLine;
        private System.Windows.Forms.Panel panelRunCommandLine;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.LinkLabel btnLinkInventoryCommandLine;
        private System.Windows.Forms.LinkLabel btnLinkExportSiteCommandLine;
        private System.Windows.Forms.ComboBox comboBoxChooseAction;
        private System.Windows.Forms.Button btnAbortRun;
        private System.Windows.Forms.LinkLabel btnLinkImportCommandLine;
        private System.Windows.Forms.TextBox txtExportSingleProject;
        private System.Windows.Forms.CheckBox chkRemapWorkbookDataserverReferences;
        private System.Windows.Forms.TextBox txtDBCredentialsImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panelTopSplitter;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtExportOnlyTagged;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chkExportRemoveExportTag;
        private System.Windows.Forms.CheckBox chkGenerateInventoryTwb;
        private System.Windows.Forms.CheckBox checkBoxRememberPassword;
    }
}

