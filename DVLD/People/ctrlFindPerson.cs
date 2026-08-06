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
    public partial class ctrlFindPerson : UserControl
    {
        public ctrlFindPerson()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            ctrlPersonDetails1.LoadPersonInfo(int.Parse(txtSearch.Text));
        }
    }
}
