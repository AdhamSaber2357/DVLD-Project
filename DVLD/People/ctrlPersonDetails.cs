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


    public partial class ctrlPersonDetails : UserControl
    {
        private clsPeople _Person;

        private int? _PersonID = -1;

        public int? PersonID
        {
            get { return _PersonID; }
        }

        public clsPeople SelectedPersonInfo
        {
            get { return _Person; }
        }

        public ctrlPersonDetails()
        {
            InitializeComponent();

        }
        public void ResetPersonInfo()
        {
            _PersonID = -1;
            lbPersonID.Text = "[????]";
            lbNationalNo.Text = "[????]";
            lbName.Text = "[????]";
            pictureBox1.Image = Resources.Male_512;
            lbGender.Text = "[????]";
            lbEmail.Text = "[????]";
            lbPhone.Text = "[????]";
            lbDateOfBirth.Text = "[????]";
            lbCountry.Text = "[????]";
            lbAddress.Text = "[????]";

        }

        private void _FillPersonInfo()
        {
            clsPeople p = _Person;
            _PersonID = p.PersonID;
            lbPersonID.Text = p.PersonID.ToString();
            lbName.Text = p.FirstName.ToString() + " " + p.SecondName.ToString() + " "
                + p.ThirdName.ToString() + " " + p.LastName.ToString() + " ";
            lbNationalNo.Text = p.NationalNo.ToString();
            if (p.Gender == 0)
                lbGender.Text = "Male";
            else
                lbGender.Text = "Female";

            lbEmail.Text = p.Email;
            lbPhone.Text = p.Phone;
            lbAddress.Text = p.Address;
            lbDateOfBirth.Text = p.DateOfBirth.ToShortDateString();
            lbCountry.Text = clsCountry.Find(p.NationalityID);
            if (p.ImagePath != null)
                pictureBox1.Load(p.ImagePath);
            else
            {
                if (p.Gender == 0)
                    pictureBox1.BackgroundImage = Resources.Male_512;
                else
                    pictureBox1.BackgroundImage = Resources.Female_512;
            }

            

        }

        public void LoadPersonInfo(int? PersonID)
        {
            _Person = clsPeople.Find(PersonID);
            if (_Person == null)
            {
                ResetPersonInfo();
                MessageBox.Show("No Person with PersonID = " + PersonID.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            _FillPersonInfo();
        }




        private void btnClose_Click(object sender, EventArgs e)
        {
          
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    

        private void ctrlPersonDetails_Load(object sender, EventArgs e)
        {

        }

        private void llEdit_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddUpdatePeople frm = new AddUpdatePeople(Convert.ToInt32(_PersonID));
            frm.ShowDialog();
            LoadPersonInfo(_PersonID);


        }
    }
}
