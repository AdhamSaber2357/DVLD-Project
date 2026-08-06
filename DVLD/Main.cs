using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DVLD_Bussiness;
namespace DVLD
{
    public partial class Main : Form
    {


       public Action s;
        public Main()
        {
            InitializeComponent();
          
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void menuPeople_Click(object sender, EventArgs e)
        {
            PeopleList frm = new PeopleList();
            frm.ShowDialog();
        }

        private void signOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            s();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void menuUsers_Click(object sender, EventArgs e)
        {
            UsersList u = new UsersList();
            u.ShowDialog();
        }
    }
}
