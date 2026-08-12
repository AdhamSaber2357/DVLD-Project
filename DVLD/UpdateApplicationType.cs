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
            _AppType.ApplicationTypeTitle = txtTitle.Text;
            _AppType.ApplicationFees = decimal.Parse(txtFees.Text);
            if(_AppType.Save())
                MessageBox.Show("Application Type updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
