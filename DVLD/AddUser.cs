using DVLD_Bussiness;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            
            clsPeople Person = clsPeople.Find(ctrlFindPerson1.PersonID);
            if(Person == null)
            {
                MessageBox.Show("Person is not Exist","Info",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else if (clsUser.CheckPersonIsUser(ctrlFindPerson1.PersonID))
            {
                MessageBox.Show("Person is already a user", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            tabControl1.SelectedIndex = 1;
            btnSave.Enabled = true;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbLoginInfo_Click(object sender, EventArgs e)
        {

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtUserName.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "User Name is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtUserName, "");
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtPassword.Text))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtPassword, "Password is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtPassword, "");
            }
        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtPassword.Text !=txtConfirmPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Password doesn't match password confirmation");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }
    }
    
}
