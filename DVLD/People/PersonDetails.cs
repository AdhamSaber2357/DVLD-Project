using DVLD.Properties;
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

namespace DVLD
{
    public partial class PersonDetails : Form
    {

        public delegate void DataBack(object sender, int PersonID);
        public event DataBack Data;

        private int _PersonID;
        public PersonDetails(int prsID)
        {
            InitializeComponent();

            _PersonID = prsID;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
       

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
        }

        private void PersonDetails_Load(object sender, EventArgs e)
        {
            ctrlPersonDetails1.LoadPersonInfo(_PersonID);
        }

        private void llEdit_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            
        }
    }
}
