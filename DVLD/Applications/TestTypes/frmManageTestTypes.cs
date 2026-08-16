using DVLD.Applications.TestTypes;
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

namespace DVLD.Applications.ApplicationsType
{
    public partial class frmManageTestTypes : Form
    {
        public frmManageTestTypes()
        {
            InitializeComponent();
            _Refresh();
        }

        void _Refresh()
        {
            dvgTestsList.DataSource = clsTestType.GetAllTestTypes();
            lbTestsNumber.Text = dvgTestsList.RowCount.ToString();
            dvgTestsList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUpdateTestType frm = new frmUpdateTestType((clsTestType.enTestType)dvgTestsList.CurrentRow.Cells[0].Value);
            frm.ShowDialog();
            _Refresh();
        }
    }
}
