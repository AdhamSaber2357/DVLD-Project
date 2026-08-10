namespace DVLD
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuApplications = new System.Windows.Forms.ToolStripMenuItem();
            this.menuPeople = new System.Windows.Forms.ToolStripMenuItem();
            this.menuDrivers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuUsers = new System.Windows.Forms.ToolStripMenuItem();
            this.menuAccountSettings = new System.Windows.Forms.ToolStripMenuItem();
            this.currentUserInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.signOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(50, 50);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuApplications,
            this.menuPeople,
            this.menuDrivers,
            this.menuUsers,
            this.menuAccountSettings});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1550, 58);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuApplications
            // 
            this.menuApplications.Checked = true;
            this.menuApplications.CheckState = System.Windows.Forms.CheckState.Checked;
            this.menuApplications.Image = ((System.Drawing.Image)(resources.GetObject("menuApplications.Image")));
            this.menuApplications.Name = "menuApplications";
            this.menuApplications.Size = new System.Drawing.Size(156, 54);
            this.menuApplications.Text = "Applications";
            // 
            // menuPeople
            // 
            this.menuPeople.Image = ((System.Drawing.Image)(resources.GetObject("menuPeople.Image")));
            this.menuPeople.Name = "menuPeople";
            this.menuPeople.Size = new System.Drawing.Size(118, 54);
            this.menuPeople.Text = "People";
            this.menuPeople.Click += new System.EventHandler(this.menuPeople_Click);
            // 
            // menuDrivers
            // 
            this.menuDrivers.Image = ((System.Drawing.Image)(resources.GetObject("menuDrivers.Image")));
            this.menuDrivers.Name = "menuDrivers";
            this.menuDrivers.Size = new System.Drawing.Size(119, 54);
            this.menuDrivers.Text = "Drivers";
            // 
            // menuUsers
            // 
            this.menuUsers.Image = ((System.Drawing.Image)(resources.GetObject("menuUsers.Image")));
            this.menuUsers.Name = "menuUsers";
            this.menuUsers.Size = new System.Drawing.Size(108, 54);
            this.menuUsers.Text = "Users";
            this.menuUsers.Click += new System.EventHandler(this.menuUsers_Click);
            // 
            // menuAccountSettings
            // 
            this.menuAccountSettings.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.currentUserInfoToolStripMenuItem,
            this.changePasswordToolStripMenuItem,
            this.signOutToolStripMenuItem});
            this.menuAccountSettings.Image = ((System.Drawing.Image)(resources.GetObject("menuAccountSettings.Image")));
            this.menuAccountSettings.Name = "menuAccountSettings";
            this.menuAccountSettings.Size = new System.Drawing.Size(184, 54);
            this.menuAccountSettings.Text = "Account Settings";
            // 
            // currentUserInfoToolStripMenuItem
            // 
            this.currentUserInfoToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("currentUserInfoToolStripMenuItem.Image")));
            this.currentUserInfoToolStripMenuItem.Name = "currentUserInfoToolStripMenuItem";
            this.currentUserInfoToolStripMenuItem.Size = new System.Drawing.Size(254, 56);
            this.currentUserInfoToolStripMenuItem.Text = "Current user info";
            this.currentUserInfoToolStripMenuItem.Click += new System.EventHandler(this.currentUserInfoToolStripMenuItem_Click);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("changePasswordToolStripMenuItem.Image")));
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(254, 56);
            this.changePasswordToolStripMenuItem.Text = "Change Password";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.changePasswordToolStripMenuItem_Click);
            // 
            // signOutToolStripMenuItem
            // 
            this.signOutToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("signOutToolStripMenuItem.Image")));
            this.signOutToolStripMenuItem.Name = "signOutToolStripMenuItem";
            this.signOutToolStripMenuItem.Size = new System.Drawing.Size(254, 56);
            this.signOutToolStripMenuItem.Text = "Sign out";
            this.signOutToolStripMenuItem.Click += new System.EventHandler(this.signOutToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1550, 678);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Main";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuApplications;
        private System.Windows.Forms.ToolStripMenuItem menuPeople;
        private System.Windows.Forms.ToolStripMenuItem menuDrivers;
        private System.Windows.Forms.ToolStripMenuItem menuUsers;
        private System.Windows.Forms.ToolStripMenuItem menuAccountSettings;
        private System.Windows.Forms.ToolStripMenuItem currentUserInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem signOutToolStripMenuItem;
    }
}

