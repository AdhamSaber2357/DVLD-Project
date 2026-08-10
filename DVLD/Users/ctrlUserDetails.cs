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
    public partial class ctrlUserDetails : UserControl
    {
        private int _UserID;
        private clsUser _User;
        public ctrlUserDetails()
        {
            InitializeComponent();
        }

        private void UserDetails_Load(object sender, EventArgs e)
        {

        }
        public void LoadInfo(int? UserID)
        {
           if(UserID!=null)
            {
                _User = clsUser.Find(UserID);
                ctrlPersonDetails1.LoadPersonInfo(_User.PersonID);
                lbUserID.Text = UserID.ToString();
                lbUserName.Text = _User.UserName;
                if (_User.IsActive == true)
                    lbIsActive.Text = "Yes";
                else
                    lbIsActive.Text = "No";
            }

        }

        private void ctrlPersonDetails1_Load(object sender, EventArgs e)
        {

        }
    }
}
