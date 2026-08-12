using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_Business;
namespace DVLD
{
    public partial class Main : Form
    {


       public Action s;
        public Main()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuPeople_Click(object sender, EventArgs e)
        {
            PeopleList frm = new PeopleList();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            s();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser currentUser = clsUser.Find(Properties.Settings.Default.UserName);
            frmChangePassword cp = new frmChangePassword(currentUser.UserID);
            cp.ShowDialog();
        }

        private void menuUsers_Click(object sender, EventArgs e)
        {
            UsersList u = new UsersList();
            u.ShowDialog();
        }

        private void currentUserInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clsUser currentUser = clsUser.Find(Properties.Settings.Default.UserName);
            frmUserInfo fi = new frmUserInfo(currentUser.UserID);
            fi.ShowDialog();
        }

        private void manageApplicationTypesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmApplicationTypes at = new frmApplicationTypes();
            at.ShowDialog();
        }
    }
}
