namespace ISU
{
    partial class ClientForm
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
            this.tbcMain = new System.Windows.Forms.TabControl();
            this.tabHome = new System.Windows.Forms.TabPage();
            this.lstThreads = new NishBox.MultiLineListBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.clstFilter = new System.Windows.Forms.CheckedListBox();
            this.tabList = new System.Windows.Forms.TabPage();
            this.pnlClubInfo = new System.Windows.Forms.Panel();
            this.btnReturnToClubList = new System.Windows.Forms.Button();
            this.lblDescription = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.lblSupervisor = new System.Windows.Forms.Label();
            this.lblLocation = new System.Windows.Forms.Label();
            this.lblClubName = new System.Windows.Forms.Label();
            this.lstClubList = new System.Windows.Forms.ListBox();
            this.tabAdmin = new System.Windows.Forms.TabPage();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.lblUsername = new System.Windows.Forms.Label();
            this.pnlEditClubInfo = new System.Windows.Forms.Panel();
            this.btnReturnFromEditClubInfo = new System.Windows.Forms.Button();
            this.btnSubmitChanges = new System.Windows.Forms.Button();
            this.txtEditDescription = new System.Windows.Forms.TextBox();
            this.txtEditSupervisor = new System.Windows.Forms.TextBox();
            this.txtEditLocation = new System.Windows.Forms.TextBox();
            this.txtEditClubName = new System.Windows.Forms.TextBox();
            this.lblEditDescription = new System.Windows.Forms.Label();
            this.lblEditSupervisor = new System.Windows.Forms.Label();
            this.lblEditLocation = new System.Windows.Forms.Label();
            this.lblEditClubName = new System.Windows.Forms.Label();
            this.pnlPublishPost = new System.Windows.Forms.Panel();
            this.lblPublishClubName = new System.Windows.Forms.Label();
            this.btnReturnToAdminClubList = new System.Windows.Forms.Button();
            this.btnEditClubInfo = new System.Windows.Forms.Button();
            this.btnPublish = new System.Windows.Forms.Button();
            this.txtNewPost = new System.Windows.Forms.TextBox();
            this.lstClubManageList = new System.Windows.Forms.ListBox();
            this.lblAdminClubList = new System.Windows.Forms.Label();
            this.btnLogout = new System.Windows.Forms.Button();
            this.btnFilter = new System.Windows.Forms.Button();
            this.tbcMain.SuspendLayout();
            this.tabHome.SuspendLayout();
            this.tabList.SuspendLayout();
            this.pnlClubInfo.SuspendLayout();
            this.tabAdmin.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.pnlEditClubInfo.SuspendLayout();
            this.pnlPublishPost.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbcMain
            // 
            this.tbcMain.Controls.Add(this.tabHome);
            this.tbcMain.Controls.Add(this.tabList);
            this.tbcMain.Controls.Add(this.tabAdmin);
            this.tbcMain.Location = new System.Drawing.Point(12, 12);
            this.tbcMain.Name = "tbcMain";
            this.tbcMain.SelectedIndex = 0;
            this.tbcMain.Size = new System.Drawing.Size(569, 396);
            this.tbcMain.TabIndex = 1;
            // 
            // tabHome
            // 
            this.tabHome.Controls.Add(this.btnFilter);
            this.tabHome.Controls.Add(this.lstThreads);
            this.tabHome.Controls.Add(this.btnRefresh);
            this.tabHome.Controls.Add(this.clstFilter);
            this.tabHome.Location = new System.Drawing.Point(4, 22);
            this.tabHome.Name = "tabHome";
            this.tabHome.Padding = new System.Windows.Forms.Padding(3);
            this.tabHome.Size = new System.Drawing.Size(561, 370);
            this.tabHome.TabIndex = 0;
            this.tabHome.Text = "Home";
            this.tabHome.UseVisualStyleBackColor = true;
            // 
            // lstThreads
            // 
            this.lstThreads.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.lstThreads.FormattingEnabled = true;
            this.lstThreads.Location = new System.Drawing.Point(3, 3);
            this.lstThreads.Name = "lstThreads";
            this.lstThreads.ScrollAlwaysVisible = true;
            this.lstThreads.Size = new System.Drawing.Size(374, 352);
            this.lstThreads.TabIndex = 2;
            // 
            // btnRefresh
            // 
            this.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRefresh.Location = new System.Drawing.Point(383, 3);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(172, 31);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // clstFilter
            // 
            this.clstFilter.FormattingEnabled = true;
            this.clstFilter.Location = new System.Drawing.Point(383, 84);
            this.clstFilter.Name = "clstFilter";
            this.clstFilter.Size = new System.Drawing.Size(172, 274);
            this.clstFilter.TabIndex = 1;
            this.clstFilter.Tag = "";
            // 
            // tabList
            // 
            this.tabList.Controls.Add(this.pnlClubInfo);
            this.tabList.Controls.Add(this.lstClubList);
            this.tabList.Location = new System.Drawing.Point(4, 22);
            this.tabList.Name = "tabList";
            this.tabList.Padding = new System.Windows.Forms.Padding(3);
            this.tabList.Size = new System.Drawing.Size(561, 370);
            this.tabList.TabIndex = 1;
            this.tabList.Text = "Club List";
            this.tabList.UseVisualStyleBackColor = true;
            // 
            // pnlClubInfo
            // 
            this.pnlClubInfo.Controls.Add(this.btnReturnToClubList);
            this.pnlClubInfo.Controls.Add(this.lblDescription);
            this.pnlClubInfo.Controls.Add(this.txtDescription);
            this.pnlClubInfo.Controls.Add(this.lblSupervisor);
            this.pnlClubInfo.Controls.Add(this.lblLocation);
            this.pnlClubInfo.Controls.Add(this.lblClubName);
            this.pnlClubInfo.Location = new System.Drawing.Point(6, 6);
            this.pnlClubInfo.Name = "pnlClubInfo";
            this.pnlClubInfo.Size = new System.Drawing.Size(549, 358);
            this.pnlClubInfo.TabIndex = 1;
            this.pnlClubInfo.Visible = false;
            // 
            // btnReturnToClubList
            // 
            this.btnReturnToClubList.Location = new System.Drawing.Point(27, 320);
            this.btnReturnToClubList.Name = "btnReturnToClubList";
            this.btnReturnToClubList.Size = new System.Drawing.Size(75, 23);
            this.btnReturnToClubList.TabIndex = 5;
            this.btnReturnToClubList.Text = "Return";
            this.btnReturnToClubList.UseVisualStyleBackColor = true;
            this.btnReturnToClubList.Click += new System.EventHandler(this.btnReturnToClubList_Click);
            // 
            // lblDescription
            // 
            this.lblDescription.AutoSize = true;
            this.lblDescription.Location = new System.Drawing.Point(24, 109);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(66, 13);
            this.lblDescription.TabIndex = 4;
            this.lblDescription.Text = "Description: ";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(27, 125);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.ReadOnly = true;
            this.txtDescription.Size = new System.Drawing.Size(482, 189);
            this.txtDescription.TabIndex = 3;
            this.txtDescription.Text = "It\'s pretty empty here";
            // 
            // lblSupervisor
            // 
            this.lblSupervisor.AutoSize = true;
            this.lblSupervisor.Location = new System.Drawing.Point(24, 70);
            this.lblSupervisor.Name = "lblSupervisor";
            this.lblSupervisor.Size = new System.Drawing.Size(63, 13);
            this.lblSupervisor.TabIndex = 2;
            this.lblSupervisor.Text = "Supervisor: ";
            // 
            // lblLocation
            // 
            this.lblLocation.AutoSize = true;
            this.lblLocation.Location = new System.Drawing.Point(24, 48);
            this.lblLocation.Name = "lblLocation";
            this.lblLocation.Size = new System.Drawing.Size(54, 13);
            this.lblLocation.TabIndex = 1;
            this.lblLocation.Text = "Location: ";
            // 
            // lblClubName
            // 
            this.lblClubName.AutoSize = true;
            this.lblClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClubName.Location = new System.Drawing.Point(11, 13);
            this.lblClubName.Name = "lblClubName";
            this.lblClubName.Size = new System.Drawing.Size(61, 24);
            this.lblClubName.TabIndex = 0;
            this.lblClubName.Text = "Name";
            // 
            // lstClubList
            // 
            this.lstClubList.FormattingEnabled = true;
            this.lstClubList.Location = new System.Drawing.Point(17, 19);
            this.lstClubList.Name = "lstClubList";
            this.lstClubList.Size = new System.Drawing.Size(485, 329);
            this.lstClubList.TabIndex = 0;
            this.lstClubList.SelectedIndexChanged += new System.EventHandler(this.lstClubList_SelectedIndexChanged);
            // 
            // tabAdmin
            // 
            this.tabAdmin.Controls.Add(this.pnlLogin);
            this.tabAdmin.Controls.Add(this.pnlEditClubInfo);
            this.tabAdmin.Controls.Add(this.pnlPublishPost);
            this.tabAdmin.Controls.Add(this.lstClubManageList);
            this.tabAdmin.Controls.Add(this.lblAdminClubList);
            this.tabAdmin.Controls.Add(this.btnLogout);
            this.tabAdmin.Location = new System.Drawing.Point(4, 22);
            this.tabAdmin.Name = "tabAdmin";
            this.tabAdmin.Size = new System.Drawing.Size(561, 370);
            this.tabAdmin.TabIndex = 2;
            this.tabAdmin.Text = "Admin";
            this.tabAdmin.UseVisualStyleBackColor = true;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtPassword);
            this.pnlLogin.Controls.Add(this.txtUsername);
            this.pnlLogin.Controls.Add(this.lblPassword);
            this.pnlLogin.Controls.Add(this.lblUsername);
            this.pnlLogin.Location = new System.Drawing.Point(3, 3);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(554, 363);
            this.pnlLogin.TabIndex = 1;
            // 
            // btnLogin
            // 
            this.btnLogin.Location = new System.Drawing.Point(239, 230);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(75, 23);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(131, 167);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(347, 20);
            this.txtPassword.TabIndex = 3;
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(131, 127);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(347, 20);
            this.txtUsername.TabIndex = 2;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(69, 170);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(53, 13);
            this.lblPassword.TabIndex = 1;
            this.lblPassword.Text = "Password";
            // 
            // lblUsername
            // 
            this.lblUsername.AutoSize = true;
            this.lblUsername.Location = new System.Drawing.Point(69, 130);
            this.lblUsername.Name = "lblUsername";
            this.lblUsername.Size = new System.Drawing.Size(55, 13);
            this.lblUsername.TabIndex = 0;
            this.lblUsername.Text = "Username";
            // 
            // pnlEditClubInfo
            // 
            this.pnlEditClubInfo.Controls.Add(this.btnReturnFromEditClubInfo);
            this.pnlEditClubInfo.Controls.Add(this.btnSubmitChanges);
            this.pnlEditClubInfo.Controls.Add(this.txtEditDescription);
            this.pnlEditClubInfo.Controls.Add(this.txtEditSupervisor);
            this.pnlEditClubInfo.Controls.Add(this.txtEditLocation);
            this.pnlEditClubInfo.Controls.Add(this.txtEditClubName);
            this.pnlEditClubInfo.Controls.Add(this.lblEditDescription);
            this.pnlEditClubInfo.Controls.Add(this.lblEditSupervisor);
            this.pnlEditClubInfo.Controls.Add(this.lblEditLocation);
            this.pnlEditClubInfo.Controls.Add(this.lblEditClubName);
            this.pnlEditClubInfo.Location = new System.Drawing.Point(6, 7);
            this.pnlEditClubInfo.Name = "pnlEditClubInfo";
            this.pnlEditClubInfo.Size = new System.Drawing.Size(555, 360);
            this.pnlEditClubInfo.TabIndex = 2;
            this.pnlEditClubInfo.Visible = false;
            // 
            // btnReturnFromEditClubInfo
            // 
            this.btnReturnFromEditClubInfo.Location = new System.Drawing.Point(87, 310);
            this.btnReturnFromEditClubInfo.Name = "btnReturnFromEditClubInfo";
            this.btnReturnFromEditClubInfo.Size = new System.Drawing.Size(75, 23);
            this.btnReturnFromEditClubInfo.TabIndex = 2;
            this.btnReturnFromEditClubInfo.Text = "Return";
            this.btnReturnFromEditClubInfo.UseVisualStyleBackColor = true;
            this.btnReturnFromEditClubInfo.Click += new System.EventHandler(this.btnReturnFromEditClubInfo_Click);
            // 
            // btnSubmitChanges
            // 
            this.btnSubmitChanges.Location = new System.Drawing.Point(399, 310);
            this.btnSubmitChanges.Name = "btnSubmitChanges";
            this.btnSubmitChanges.Size = new System.Drawing.Size(99, 23);
            this.btnSubmitChanges.TabIndex = 8;
            this.btnSubmitChanges.Text = "Submit Changes";
            this.btnSubmitChanges.UseVisualStyleBackColor = true;
            this.btnSubmitChanges.Click += new System.EventHandler(this.btnSubmitChanges_Click);
            // 
            // txtEditDescription
            // 
            this.txtEditDescription.Location = new System.Drawing.Point(87, 142);
            this.txtEditDescription.Multiline = true;
            this.txtEditDescription.Name = "txtEditDescription";
            this.txtEditDescription.Size = new System.Drawing.Size(411, 162);
            this.txtEditDescription.TabIndex = 7;
            // 
            // txtEditSupervisor
            // 
            this.txtEditSupervisor.Location = new System.Drawing.Point(87, 95);
            this.txtEditSupervisor.Name = "txtEditSupervisor";
            this.txtEditSupervisor.Size = new System.Drawing.Size(290, 20);
            this.txtEditSupervisor.TabIndex = 6;
            // 
            // txtEditLocation
            // 
            this.txtEditLocation.Location = new System.Drawing.Point(87, 53);
            this.txtEditLocation.Name = "txtEditLocation";
            this.txtEditLocation.Size = new System.Drawing.Size(290, 20);
            this.txtEditLocation.TabIndex = 5;
            // 
            // txtEditClubName
            // 
            this.txtEditClubName.Location = new System.Drawing.Point(87, 11);
            this.txtEditClubName.Name = "txtEditClubName";
            this.txtEditClubName.Size = new System.Drawing.Size(290, 20);
            this.txtEditClubName.TabIndex = 4;
            // 
            // lblEditDescription
            // 
            this.lblEditDescription.AutoSize = true;
            this.lblEditDescription.Location = new System.Drawing.Point(21, 145);
            this.lblEditDescription.Name = "lblEditDescription";
            this.lblEditDescription.Size = new System.Drawing.Size(60, 13);
            this.lblEditDescription.TabIndex = 3;
            this.lblEditDescription.Text = "Description";
            // 
            // lblEditSupervisor
            // 
            this.lblEditSupervisor.AutoSize = true;
            this.lblEditSupervisor.Location = new System.Drawing.Point(21, 98);
            this.lblEditSupervisor.Name = "lblEditSupervisor";
            this.lblEditSupervisor.Size = new System.Drawing.Size(60, 13);
            this.lblEditSupervisor.TabIndex = 2;
            this.lblEditSupervisor.Text = "Supervisor:";
            // 
            // lblEditLocation
            // 
            this.lblEditLocation.AutoSize = true;
            this.lblEditLocation.Location = new System.Drawing.Point(30, 56);
            this.lblEditLocation.Name = "lblEditLocation";
            this.lblEditLocation.Size = new System.Drawing.Size(51, 13);
            this.lblEditLocation.TabIndex = 1;
            this.lblEditLocation.Text = "Location:";
            // 
            // lblEditClubName
            // 
            this.lblEditClubName.AutoSize = true;
            this.lblEditClubName.Location = new System.Drawing.Point(40, 14);
            this.lblEditClubName.Name = "lblEditClubName";
            this.lblEditClubName.Size = new System.Drawing.Size(41, 13);
            this.lblEditClubName.TabIndex = 0;
            this.lblEditClubName.Text = "Name: ";
            // 
            // pnlPublishPost
            // 
            this.pnlPublishPost.Controls.Add(this.lblPublishClubName);
            this.pnlPublishPost.Controls.Add(this.btnReturnToAdminClubList);
            this.pnlPublishPost.Controls.Add(this.btnEditClubInfo);
            this.pnlPublishPost.Controls.Add(this.btnPublish);
            this.pnlPublishPost.Controls.Add(this.txtNewPost);
            this.pnlPublishPost.Location = new System.Drawing.Point(23, 23);
            this.pnlPublishPost.Name = "pnlPublishPost";
            this.pnlPublishPost.Size = new System.Drawing.Size(518, 340);
            this.pnlPublishPost.TabIndex = 1;
            this.pnlPublishPost.Visible = false;
            // 
            // lblPublishClubName
            // 
            this.lblPublishClubName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPublishClubName.Location = new System.Drawing.Point(35, 11);
            this.lblPublishClubName.Name = "lblPublishClubName";
            this.lblPublishClubName.Size = new System.Drawing.Size(261, 23);
            this.lblPublishClubName.TabIndex = 0;
            this.lblPublishClubName.Text = "Club Name";
            // 
            // btnReturnToAdminClubList
            // 
            this.btnReturnToAdminClubList.Location = new System.Drawing.Point(39, 301);
            this.btnReturnToAdminClubList.Name = "btnReturnToAdminClubList";
            this.btnReturnToAdminClubList.Size = new System.Drawing.Size(75, 23);
            this.btnReturnToAdminClubList.TabIndex = 3;
            this.btnReturnToAdminClubList.Text = "Return";
            this.btnReturnToAdminClubList.UseVisualStyleBackColor = true;
            this.btnReturnToAdminClubList.Click += new System.EventHandler(this.btnReturnToAdminClubList_Click);
            // 
            // btnEditClubInfo
            // 
            this.btnEditClubInfo.Location = new System.Drawing.Point(39, 241);
            this.btnEditClubInfo.Name = "btnEditClubInfo";
            this.btnEditClubInfo.Size = new System.Drawing.Size(129, 23);
            this.btnEditClubInfo.TabIndex = 2;
            this.btnEditClubInfo.Text = "Edit Club Information";
            this.btnEditClubInfo.UseVisualStyleBackColor = true;
            this.btnEditClubInfo.Click += new System.EventHandler(this.btnEditClubInfo_Click);
            // 
            // btnPublish
            // 
            this.btnPublish.Location = new System.Drawing.Point(39, 205);
            this.btnPublish.Name = "btnPublish";
            this.btnPublish.Size = new System.Drawing.Size(75, 23);
            this.btnPublish.TabIndex = 1;
            this.btnPublish.Text = "Publish";
            this.btnPublish.UseVisualStyleBackColor = true;
            this.btnPublish.Click += new System.EventHandler(this.btnPublish_Click);
            // 
            // txtNewPost
            // 
            this.txtNewPost.Location = new System.Drawing.Point(39, 37);
            this.txtNewPost.Multiline = true;
            this.txtNewPost.Name = "txtNewPost";
            this.txtNewPost.Size = new System.Drawing.Size(392, 161);
            this.txtNewPost.TabIndex = 0;
            // 
            // lstClubManageList
            // 
            this.lstClubManageList.FormattingEnabled = true;
            this.lstClubManageList.Location = new System.Drawing.Point(23, 60);
            this.lstClubManageList.Name = "lstClubManageList";
            this.lstClubManageList.Size = new System.Drawing.Size(411, 290);
            this.lstClubManageList.TabIndex = 0;
            this.lstClubManageList.SelectedIndexChanged += new System.EventHandler(this.lstClubManageList_SelectedIndexChanged);
            // 
            // lblAdminClubList
            // 
            this.lblAdminClubList.AutoSize = true;
            this.lblAdminClubList.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAdminClubList.Location = new System.Drawing.Point(19, 27);
            this.lblAdminClubList.Name = "lblAdminClubList";
            this.lblAdminClubList.Size = new System.Drawing.Size(197, 24);
            this.lblAdminClubList.TabIndex = 3;
            this.lblAdminClubList.Text = "Manage-able Club List";
            // 
            // btnLogout
            // 
            this.btnLogout.Location = new System.Drawing.Point(455, 60);
            this.btnLogout.Name = "btnLogout";
            this.btnLogout.Size = new System.Drawing.Size(75, 23);
            this.btnLogout.TabIndex = 2;
            this.btnLogout.Text = "Logout";
            this.btnLogout.UseVisualStyleBackColor = true;
            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
            // 
            // btnFilter
            // 
            this.btnFilter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFilter.Location = new System.Drawing.Point(383, 47);
            this.btnFilter.Name = "btnFilter";
            this.btnFilter.Size = new System.Drawing.Size(172, 31);
            this.btnFilter.TabIndex = 3;
            this.btnFilter.Text = "Filter";
            this.btnFilter.UseVisualStyleBackColor = true;
            this.btnFilter.Click += new System.EventHandler(this.btnFilter_Click);
            // 
            // ClientForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.tbcMain);
            this.Name = "ClientForm";
            this.Text = "Clubs Management Client";
            this.tbcMain.ResumeLayout(false);
            this.tabHome.ResumeLayout(false);
            this.tabList.ResumeLayout(false);
            this.pnlClubInfo.ResumeLayout(false);
            this.pnlClubInfo.PerformLayout();
            this.tabAdmin.ResumeLayout(false);
            this.tabAdmin.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.pnlEditClubInfo.ResumeLayout(false);
            this.pnlEditClubInfo.PerformLayout();
            this.pnlPublishPost.ResumeLayout(false);
            this.pnlPublishPost.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tbcMain;
        private System.Windows.Forms.TabPage tabHome;
        private System.Windows.Forms.TabPage tabList;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ListBox lstClubList;
        private System.Windows.Forms.TabPage tabAdmin;
        private System.Windows.Forms.ListBox lstClubManageList;
        private System.Windows.Forms.Panel pnlClubInfo;
        private System.Windows.Forms.Label lblClubName;
        private System.Windows.Forms.Label lblLocation;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label lblSupervisor;
        private System.Windows.Forms.Button btnReturnToClubList;
        private NishBox.MultiLineListBox lstThreads;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtUsername;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.Label lblUsername;
        private System.Windows.Forms.Panel pnlPublishPost;
        private System.Windows.Forms.Button btnReturnToAdminClubList;
        private System.Windows.Forms.Button btnEditClubInfo;
        private System.Windows.Forms.Button btnPublish;
        private System.Windows.Forms.TextBox txtNewPost;
        private System.Windows.Forms.Label lblPublishClubName;
        private System.Windows.Forms.Panel pnlEditClubInfo;
        private System.Windows.Forms.Label lblEditLocation;
        private System.Windows.Forms.Label lblEditClubName;
        private System.Windows.Forms.TextBox txtEditClubName;
        private System.Windows.Forms.Label lblEditDescription;
        private System.Windows.Forms.Label lblEditSupervisor;
        private System.Windows.Forms.TextBox txtEditLocation;
        private System.Windows.Forms.Button btnReturnFromEditClubInfo;
        private System.Windows.Forms.Button btnSubmitChanges;
        private System.Windows.Forms.TextBox txtEditDescription;
        private System.Windows.Forms.TextBox txtEditSupervisor;
        private System.Windows.Forms.Label lblAdminClubList;
        private System.Windows.Forms.Button btnLogout;
        private System.Windows.Forms.CheckedListBox clstFilter;
        private System.Windows.Forms.Button btnFilter;
    }
}

