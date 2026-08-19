using DVLD_Business;
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
        private int? _UserID;
        private clsUser _User;

        public AddUser(int? userid)
        {
            InitializeComponent();
            _UserID = userid;
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            clsPeople Person = clsPeople.Find(ctrlFindPerson1.PersonID);
            if (Person == null)
            {
                MessageBox.Show("Person is not Exist", "Info", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // فحص هل الشخص مستخدم بالفعل فقط في حالة إضافة يوزر جديد
            else if (_UserID == null && clsUser.CheckPersonIsUser(ctrlFindPerson1.PersonID))
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
            string userName = txtUserName.Text.Trim();

            if (string.IsNullOrEmpty(userName))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "User Name is required");
                return;
            }

            bool isNewUser = (_UserID == null);
            bool isNameChangedInUpdate = (_UserID != null && _User != null && _User.UserName != userName);

            if ((isNewUser || isNameChangedInUpdate) && clsUser.IsUserExist(userName))
            {
                e.Cancel = true;
                txtUserName.Focus();
                errorProvider1.SetError(txtUserName, "User Name is already exist");
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
                txtPassword.Focus();
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
            if (txtPassword.Text != txtConfirmPassword.Text)
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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!this.ValidateChildren())
            {
                MessageBox.Show("Error has occurred! Please check validation errors.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (_UserID == null)
            {
                _User = new clsUser();
                _User.PersonID = ctrlFindPerson1.PersonID;
                _User.UserName = txtUserName.Text.Trim();
                _User.Password = clsGlobal.ComputeHashing(txtPassword.Text);
                _User.IsActive = chkIsActive.Checked;

                if (_User.Save())
                {
                    MessageBox.Show("User Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    _UserID = _User.UserID;
                    lbUserID.Text = _User.UserID.ToString();
                    lbAddorUpdate.Text = "Update User";
                }
                else
                {
                    MessageBox.Show("Failed to add user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                _User.UserName = txtUserName.Text.Trim();
                _User.Password = clsGlobal.ComputeHashing(txtPassword.Text);
                _User.IsActive = chkIsActive.Checked;

                if (_User.Save())
                    MessageBox.Show("User Updated Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Failed to update user", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void LoadUserData()
        {
            _User = clsUser.Find(_UserID);
            if (_User != null)
            {
                ctrlFindPerson1.PersonDatailsAccess.LoadPersonInfo(_User.PersonID);

                txtUserName.Text = _User.UserName;
                lbUserID.Text = _User.UserID.ToString();
                chkIsActive.Checked = Convert.ToBoolean(_User.IsActive);
                ctrlFindPerson1.SearchGroupBoxAccess.Enabled = false;
                btnNext.Enabled = false;
                btnSave.Enabled = true;
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            if (_UserID != null)
            {
                lbAddorUpdate.Text = "Update User";
                LoadUserData();
                btnAddPerson.Visible = false;
            }
        }

        private void btnAddPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePeople frm = new AddUpdatePeople(-1);
            frm.GetPersonID = GetNewPerson;
            frm.ShowDialog();
        }

        void GetNewPerson(int? PersonID)
        {
            ctrlFindPerson1.PersonDatailsAccess.LoadPersonInfo(PersonID);
            ctrlFindPerson1.TextBoxSearchAccess.Text = PersonID.ToString();
        }
    }
}