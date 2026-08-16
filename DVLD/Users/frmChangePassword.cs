using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Business;
namespace DVLD
{
    
    public partial class frmChangePassword : Form
    {
        private clsUser _User;
        private int? _UserID;
        public frmChangePassword(int? UserID)
        {
            InitializeComponent();
            _UserID = UserID;
            _User = clsUser.Find(_UserID);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtUserName_Validating(object sender, CancelEventArgs e)
        {

            if (clsGlobal.ComputeHashing(txtOldPssword.Text) != _User.Password || string.IsNullOrEmpty(txtOldPssword.Text))
            {
                e.Cancel = true;
                txtOldPssword.Focus();
                errorProvider1.SetError(txtOldPssword, "Password is False");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtOldPssword, "");
            }
        }

        private void txtNewPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewPassword.Text))
            {
                e.Cancel = true;
                txtOldPssword.Focus();
                errorProvider1.SetError(txtNewPassword, "Password is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNewPassword, "");
            }
        }

        private void txtConfirmPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtConfirmPassword_Validating(object sender, CancelEventArgs e)
        {
            if (txtConfirmPassword.Text != txtNewPassword.Text)
            {
                e.Cancel = true;
                txtConfirmPassword.Focus();
                errorProvider1.SetError(txtConfirmPassword, "Confirm Password is not match New Password");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtConfirmPassword, "");
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
                return;
            _User.Password =clsGlobal.ComputeHashing(txtNewPassword.Text);
            if (_User.Save())
                MessageBox.Show("Password changed successfully");
        }

        private void frmChangePassword_Load(object sender, EventArgs e)
        {
            ctrlUserDetails1.LoadInfo(_UserID);
        }
    }
}
