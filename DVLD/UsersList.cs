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
using DVLD_Bussiness;
namespace DVLD
{
    public partial class UsersList : Form
    {
        public UsersList()
        {
            InitializeComponent();
            _Refresh();
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
    }
}
