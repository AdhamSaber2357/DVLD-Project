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

namespace DVLD.Applications.TestTypes
{
   
    public partial class frmUpdateTestType : Form
    {
        private clsTestType.enTestType _TestID;
        private clsTestType _TestType;
        public frmUpdateTestType(clsTestType.enTestType TestType)
        {
            InitializeComponent();
            _TestID = TestType;
        }

        private void frmUpdateTestType_Load(object sender, EventArgs e)
        {
            _TestType = clsTestType.Find(_TestID);
            lbID.Text = ((int)_TestType.ID).ToString();
            txtTitle.Text = _TestType.TestTypeTitle;
            txtDescription.Text = _TestType.TestTypeDescription;
            txtFees.Text = _TestType.TestTypeFees.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtTitle_Validating(object sender, CancelEventArgs e)
        {
            if(string.IsNullOrEmpty(txtTitle.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Title is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtTitle.Focus();
            }
            else
                e.Cancel = false;
        }

        private void txtFees_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtFees.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Fees is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFees.Focus();
            }
            else
                e.Cancel = false;

            if(decimal.TryParse(txtFees.Text, out decimal fees))
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
                MessageBox.Show("Fees must be a valid number.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFees.Focus();
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDescription.Text))
            {
                e.Cancel = true;
                MessageBox.Show("Description is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
            }
            else
                e.Cancel = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _TestType.TestTypeTitle = txtTitle.Text.Trim();
            _TestType.TestTypeFees =  decimal.Parse(txtFees.Text);
            _TestType.TestTypeDescription = txtDescription.Text.Trim();
            if(_TestType.Save())
                MessageBox.Show("Test Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
