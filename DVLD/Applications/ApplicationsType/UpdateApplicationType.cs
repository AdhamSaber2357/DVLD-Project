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
    public partial class UpdateApplicationType : Form
    {
        private int _AppID;
        private clsApplicationType _AppType;
        public UpdateApplicationType(int AppID)
        {
            InitializeComponent();
            _AppID = AppID;
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void UpdateApplicationType_Load(object sender, EventArgs e)
        {
            _AppType = clsApplicationType.Find(_AppID);
            lbID.Text = _AppType.ApplicationTypeID.ToString();
            txtTitle.Text = _AppType.ApplicationTypeTitle;
            txtFees.Text = _AppType.ApplicationFees.ToString();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
                return;
            }

            if (!decimal.TryParse(txtFees.Text, out decimal fees))
            {
                MessageBox.Show("Fees must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFees.Focus();
                return;
            }

            _AppType.ApplicationTypeTitle = txtTitle.Text.Trim();
            _AppType.ApplicationFees = fees;
            if (_AppType.Save())
                MessageBox.Show("Application Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
       
            if (string.IsNullOrWhiteSpace(txtTitle.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
            }
            else
            {
                e.Cancel = false;
            }
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtFees.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Fees is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFees.Focus();
            }
            else
            {
                e.Cancel = false;
            }
        }
    }
}
