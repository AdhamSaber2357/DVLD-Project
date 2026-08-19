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
using DVLD_Business;
namespace DVLD
{
    public partial class UsersList : Form
    {
        public UsersList()
        {
            InitializeComponent();
            _Refresh();
            _FillFindByComboBox();
        }

        void _Refresh()
        {
            dgvUserList.DataSource = clsUser.GetUsers();
            lbUsersNumber.Text = dgvUserList.RowCount.ToString();
            dgvUserList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }

        private void lbPeopleNumber_Click(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            AddUser u = new AddUser(null);
            u.ShowDialog();
            _Refresh();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int? x = dgvUserList.CurrentRow.Cells[0].Value as int?;
            AddUser u = new AddUser(x);
            u.ShowDialog();
            _Refresh();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (clsUser.DeleteUser((int)dgvUserList.CurrentRow.Cells[0].Value))
                MessageBox.Show("User Deleted successfully");
            _Refresh();
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserInfo u = new frmUserInfo((int)dgvUserList.CurrentRow.Cells[0].Value);
            u.ShowDialog();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePassword cp = new frmChangePassword((int)dgvUserList.CurrentRow.Cells[0].Value);
            cp.ShowDialog();
        }

        private void _FillFindByComboBox()
        {
            cbFilterUsers.Items.Add("None");
            foreach (DataGridViewColumn Column in dgvUserList.Columns)
            {
                cbFilterUsers.Items.Add(Column.Name);
            }

            cbFilterUsers.SelectedIndex = 0;


            cbForIsActive.Items.Add("All");
            cbForIsActive.Items.Add("Yes");
            cbForIsActive.Items.Add("No");

            cbForIsActive.SelectedIndex = 0;

        }
        private void UsersList_Load(object sender, EventArgs e)
        {

        }

        private void txtFilterUsers_KeyPress(object sender, KeyPressEventArgs e)
        {
           if(cbFilterUsers.SelectedItem.ToString() == "PersonID" || cbFilterUsers.SelectedItem.ToString() == "UserID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
            }
        }

        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbFilterUsers.SelectedItem.ToString() == "None")
            {
                txtFilterUsers.Visible = false;
                dgvUserList.DataSource = clsUser.GetUsers();
                txtFilterUsers.Visible = false;
                cbForIsActive.Visible = false;
            }
            else if (cbFilterUsers.SelectedItem.ToString() == "IsActive")
            {
                txtFilterUsers.Visible = false;
                cbForIsActive.Visible = true;
            }
            else
            {
                txtFilterUsers.Visible = true;
                cbForIsActive.Visible = false;
            }
        }

        private void txtFilterUsers_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterUsers.SelectedItem.ToString() == "None" || string.IsNullOrEmpty(txtFilterUsers.Text))
                dgvUserList.DataSource = clsUser.GetUsers();

            else if (cbFilterUsers.SelectedItem.ToString() == "PersonID" || cbFilterUsers.SelectedItem.ToString() == "UserID")
                dgvUserList.DataSource = clsUser.GetUsersWithIntFilter(cbFilterUsers.SelectedItem.ToString(), txtFilterUsers.Text);


            else
                dgvUserList.DataSource = clsUser.GetUsersWithStringFilter(cbFilterUsers.SelectedItem.ToString(), txtFilterUsers.Text);

             lbUsersNumber.Text = dgvUserList.RowCount.ToString();
        }

        private void cbForIsActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbFilterUsers.SelectedItem.ToString() == "IsActive")
            {
                if (cbForIsActive.SelectedItem.ToString() == "All")
                    dgvUserList.DataSource = clsUser.GetUsers();
                else if (cbForIsActive.SelectedItem.ToString() == "Yes")
                    dgvUserList.DataSource = clsUser.GetUsersWithIntFilter(cbFilterUsers.SelectedItem.ToString(), "1");
                else
                    dgvUserList.DataSource = clsUser.GetUsersWithIntFilter(cbFilterUsers.SelectedItem.ToString(), "0");
                lbUsersNumber.Text = dgvUserList.RowCount.ToString();

            }
        }
    }
}
