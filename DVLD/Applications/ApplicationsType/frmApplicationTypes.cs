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
    public partial class frmApplicationTypes : Form
    {
        public frmApplicationTypes()
        {
            InitializeComponent();
            _Refresh();
           
        }
        
        void _Refresh()
        {
            dgvApplicationList.DataSource = clsApplicationType.GetAllApplicationTypes();
            lbApplicationsNumber.Text = dgvApplicationList.RowCount.ToString();
            dgvApplicationList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateApplicationType app = new UpdateApplicationType(Convert.ToInt32(dgvApplicationList.CurrentRow.Cells[0].Value));
            app.ShowDialog();
            _Refresh();
        }

        private void frmApplicationTypes_Load(object sender, EventArgs e)
        {

        }
    }
}
