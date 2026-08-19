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

namespace DVLD.Applications
{
    public partial class frmApplicationsList : Form
    {
        public frmApplicationsList()
        {
            InitializeComponent();
            _Refresh();
            _FillFindByComboBox();

            cbFilterApplications.SelectedIndexChanged += cbFilterApplications_SelectedIndexChanged;
            txtFilterApplications.TextChanged += txtFilterApplications_TextChanged;
            txtFilterApplications.KeyPress += txtFilterApplications_KeyPress;
        }
        private void _Refresh()
        {
            dgvApplications.DataSource = clsLocalDrivingLicenseApplications.GetAllApplications();
            lbApplicationsNumber.Text = dgvApplications.RowCount.ToString();
            dgvApplications.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void _FillFindByComboBox()
        {
            cbFilterApplications.Items.Add("None");

            foreach (DataGridViewColumn column in dgvApplications.Columns)
            {
                cbFilterApplications.Items.Add(column.Name);
            }

            cbFilterApplications.SelectedIndex = 0;
            txtFilterApplications.Visible = false;
        }

        private bool _IsSelectedColumnNumeric()
        {
            if (cbFilterApplications.SelectedItem == null ||
                cbFilterApplications.SelectedItem.ToString() == "None")
            {
                return false;
            }

            DataGridViewColumn column = dgvApplications.Columns[cbFilterApplications.SelectedItem.ToString()];
            Type columnType = column.ValueType;

            return columnType == typeof(byte) || columnType == typeof(short) ||
                   columnType == typeof(int) || columnType == typeof(long) ||
                   columnType == typeof(decimal) || columnType == typeof(float) ||
                   columnType == typeof(double);
        }

        private void cbFilterApplications_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool noFilter = cbFilterApplications.SelectedItem.ToString() == "None";
            txtFilterApplications.Visible = !noFilter;
            txtFilterApplications.Clear();

            if (noFilter)
            {
                _Refresh();
                txtFilterApplications.Visible = false;
            }
        }

        private void txtFilterApplications_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_IsSelectedColumnNumeric() && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtFilterApplications_TextChanged(object sender, EventArgs e)
        {
            if (cbFilterApplications.SelectedItem == null ||
                cbFilterApplications.SelectedItem.ToString() == "None" ||
                string.IsNullOrEmpty(txtFilterApplications.Text))
            {
                _Refresh();
                return;
            }

            string filterBy = cbFilterApplications.SelectedItem.ToString();

            if (_IsSelectedColumnNumeric())
            {
                dgvApplications.DataSource = clsLocalDrivingLicenseApplications.GetApplicationsWithIntFilter(
                    filterBy, txtFilterApplications.Text);
            }
            else
            {
                dgvApplications.DataSource = clsLocalDrivingLicenseApplications.GetApplicationsWithStringFilter(
                    filterBy, txtFilterApplications.Text);
            }

            lbApplicationsNumber.Text = dgvApplications.RowCount.ToString();
        }

        private void dgvUserList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cbFilterApplications_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void txtFilterApplications_TextChanged_1(object sender, EventArgs e)
        {

        }
    }
}
