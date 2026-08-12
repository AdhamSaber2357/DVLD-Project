using DVLD.Properties;
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

 
    public partial class AddUpdatePeople : Form
    {
        public Action<int?> GetPersonID;

        public int PersonID;
        clsPeople Person;
        
        private void _FillCountries()
        {
            DataTable dt = new DataTable();
            dt = clsCountry.GetCountries();
            foreach (DataRow row in dt.Rows)
            {
                cbCountry.Items.Add(row["CountryName"].ToString());
            }
            cbCountry.SelectedIndex= 89;
        }
      

        public AddUpdatePeople(int PersonId)
        {
            
            InitializeComponent();
            _FillCountries();
            if(PersonId==-1)
            {
                PersonID = -1;
                Person = new clsPeople();
            }
            else
            {
                PersonID = PersonId;
                PutData();
            }
        }
        
        private void AddUpdatePeople_Load(object sender, EventArgs e)
        {
           
            
        }

        private void rbMale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMale.Checked)
            {
                pbImage.Image = Resources.Male_512;
               
            }
        }

        private void rbFemale_CheckedChanged(object sender, EventArgs e)
        {
            if (rbFemale.Checked)
            {
                pbImage.Image = Resources.Female_512;
                
            }
        }

        private void _Add()
        {
            Person = new clsPeople();

            StoreData();

            if (Person.Save())
            {
                MessageBox.Show("Person added successfully");
                GetPersonID(Person.PersonID);
            }
        }

        public void PutData()
        {
            Person = clsPeople.Find(PersonID);
            lbAddOrUpdate.Text = "Update Person";
            lbPersonID.Text = PersonID.ToString();
            txtNationalNo.Text = Person.NationalNo;
            txtFirst.Text = Person.FirstName;
            txtSecond.Text = Person.SecondName;
            txtThird.Text = Person.ThirdName;
            txtLast.Text = Person.LastName;
            dtpDateOfBirth.Value = Person.DateOfBirth;
            txtEmail.Text = Person.Email;
            txtPhone.Text = Person.Phone;
            txtAddress.Text = Person.Address;
            cbCountry.SelectedIndex = Person.NationalityID - 1;
            cbCountry.Enabled = false;
            pbImage.ImageLocation = Person.ImagePath;

            if(Person.Gender == 0)
            {
                rbMale.Checked = true;
            }
            else
                rbFemale.Checked = true;
        }
       

        void StoreData()
        {
            Person.NationalNo = txtNationalNo.Text.ToString();
            Person.FirstName = txtFirst.Text.ToString();
            Person.SecondName = txtSecond.Text.ToString();
            Person.ThirdName = txtThird.Text.ToString();
            Person.LastName = txtLast.Text.ToString();
            Person.DateOfBirth = dtpDateOfBirth.Value;
            Person.Email = txtEmail.Text.ToString();
            Person.Phone = txtPhone.Text.ToString();
            Person.Address = txtAddress.Text.ToString();
            Person.NationalityID = cbCountry.SelectedIndex + 1;
            Person.ImagePath = pbImage.ImageLocation;
            if (rbMale.Checked)
                Person.Gender = 0;
            else { Person.Gender = 1; }
        }
        private void _Update()
        {
            StoreData();

            if (Person.Save())
                MessageBox.Show("Person Updated successfully");
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (PersonID == - 1)
            {
                _Add();
            }

            else
            {
               _Update();
            }
        }

        private void llChangeImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Filter = "Image Files (*.jpg;*.jpeg;*.png)|*.jpg;*.jpeg;*.png|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = false;

            if(openFileDialog1.ShowDialog()==DialogResult.OK)
                pbImage.ImageLocation = openFileDialog1.FileName;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNationalNo_Validating(object sender, CancelEventArgs e)
        {
            DataTable dt = new DataTable();
            dt = clsPeople.GetPeople();
            bool isError = false;
            foreach (DataRow row in  dt.Rows)
            {

                if (string.IsNullOrEmpty(txtNationalNo.Text) ||( (row["NationalNo"].ToString() == txtNationalNo.Text)&& (txtNationalNo.Text != Person.NationalNo)))
                {
                    isError = true;
                    break;
                }
            }
            if(isError)
            {
                e.Cancel = true;
                txtNationalNo.Focus();
                errorProvider1.SetError(txtNationalNo, "National Number is empty or already exist");
            }

            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtNationalNo, "");
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(txtEmail.Text))
                return;
            if(!txtEmail.Text.Contains("@gmail.com"))
            {
                e.Cancel = true;
                txtEmail.Focus();
                errorProvider1.SetError(txtEmail, "Invalid email format");
            } 
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(txtEmail, "");
            }
        }
    }
}
