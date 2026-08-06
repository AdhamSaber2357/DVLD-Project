using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_Bussiness;

namespace DVLD
{
    public partial class LoginForUser : Form
    {
        public LoginForUser()
        {
            InitializeComponent();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void RememberUser()
        {
            if(chkRememberMe.Checked)
            {
                Properties.Settings.Default.UserName = txtUserName.Text;
                Properties.Settings.Default.Password = txtPassword.Text;
                Properties.Settings.Default.Remember = true;
            }
            else
            {
                Properties.Settings.Default.UserName = "";
                Properties.Settings.Default.Password = "";
                Properties.Settings.Default.Remember = false;
            }
            Properties.Settings.Default.Save();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int Check = clsUser.CheckUser(txtUserName.Text, txtPassword.Text);
           
            if (Check == 1)
            {
                this.Hide();
                RememberUser();
               Main m = new Main();
               m.s = ShowLoginAgain;
               m.Show();
               
            }
            else if (Check == 2)
                MessageBox.Show($"User : {txtUserName.Text} is not active, please contact the adminstrator","infomation",MessageBoxButtons.OK,MessageBoxIcon.Error);
            else
                MessageBox.Show("Username or password is not exist", "infomation", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        void ShowLoginAgain()
        {
            this.Show();
        }

        private void chkShowPassword_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPassword.Checked)
                txtPassword.PasswordChar = '\0';
            else
                txtPassword.PasswordChar = '*';
        }

        private void LoginForUser_Load(object sender, EventArgs e)
        {
            if(Properties.Settings.Default.Remember)
            {
                txtUserName.Text = Properties.Settings.Default.UserName;
                txtPassword.Text = Properties.Settings.Default.Password;
                chkRememberMe.Checked = true;
            }
        }
    }
}
