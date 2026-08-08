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
        public int? PersonID
        {
            get { return ctrlPersonDetails1.PersonID; }
        }
        public ctrlPersonDetails PersonDatailsAccess
        {
            get { return ctrlPersonDetails1; }
        }
        public GroupBox SearchGroupBoxAccess
        {
            get { return gbSearch; }
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            ctrlPersonDetails1.LoadPersonInfo(int.Parse(txtSearch.Text));
        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }

        private void ctrlFindPerson_Load(object sender, EventArgs e)
        {

        }
    }
}
