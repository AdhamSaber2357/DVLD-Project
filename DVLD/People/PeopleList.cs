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
    public partial class PeopleList : Form
    {
        void _Refresh()
        {
            dataGridView1.DataSource = clsPeople.GetPeople();
            lbPeopleNumber.Text = dataGridView1.RowCount.ToString();

        }

        void _FillComboBoxFilter()
        {
            cbFilter.Items.Add("None");
            foreach (DataGridViewColumn col in dataGridView1.Columns)

            {
                cbFilter.Items.Add(col.Name);
            }
            cbFilter.SelectedIndex = 0;
        }
        public PeopleList()
        {
            InitializeComponent();
            _Refresh();
            _FillComboBoxFilter();
            txtFilter.KeyPress += txtFilter_KeyPress;
        }

        private void PeopleList_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None" ||
                string.IsNullOrEmpty(txtFilter.Text))
            {
                _Refresh();
                return;
            }

            string filterBy = cbFilter.SelectedItem.ToString();
            DataGridViewColumn column = dataGridView1.Columns[filterBy];

            if (column.ValueType == typeof(DateTime))
                dataGridView1.DataSource = clsPeople.GetPeopleWithDateFilter(filterBy, txtFilter.Text);
            else if (_IsSelectedColumnNumeric())
                dataGridView1.DataSource = clsPeople.GetPeopleWithIntFilter(filterBy, txtFilter.Text);
            else
                dataGridView1.DataSource = clsPeople.GetPeopleWithStringFilter(filterBy, txtFilter.Text);

            lbPeopleNumber.Text = dataGridView1.RowCount.ToString();
        }

        private bool _IsSelectedColumnNumeric()
        {
            if (cbFilter.SelectedItem == null || cbFilter.SelectedItem.ToString() == "None")
                return false;

            Type columnType = dataGridView1.Columns[cbFilter.SelectedItem.ToString()].ValueType;
            return columnType == typeof(byte) || columnType == typeof(short) ||
                   columnType == typeof(int) || columnType == typeof(long) ||
                   columnType == typeof(decimal);
        }

        private void txtFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (_IsSelectedColumnNumeric() && !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUpdatePeople frm = new AddUpdatePeople(-1);
            frm.ShowDialog();
            _Refresh();
        }

        private void cmAddNewPerson_Click(object sender, EventArgs e)
        {
            AddUpdatePeople frm = new AddUpdatePeople(-1);
            frm.ShowDialog();
            _Refresh();
        }

        private void cmEdit_Click(object sender, EventArgs e)
        {
            AddUpdatePeople frm = new AddUpdatePeople(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            frm.ShowDialog();
            _Refresh();
            
        }

        private void lbPeopleNumber_Click(object sender, EventArgs e)
        {
            
        }

        private void cmEdit_Click_1(object sender, EventArgs e)
        {
            AddUpdatePeople frm = new AddUpdatePeople(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            
            frm.ShowDialog();
            _Refresh();
        }

        private void cmDelete_Click(object sender, EventArgs e)
        {
            if (clsPeople.DeletePerson(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value)))
                MessageBox.Show("Person was deleted successfully","Success",MessageBoxButtons.OK,MessageBoxIcon.Information);
            else
                MessageBox.Show("Person was not deleted", "Falure", MessageBoxButtons.OK, MessageBoxIcon.Error);
            _Refresh();
        }

        private void cmShowDetails_Click(object sender, EventArgs e)
        {
          PersonDetails p = new PersonDetails(Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
           p.ShowDialog();
            _Refresh();
        }

     

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool noFilter = cbFilter.SelectedItem.ToString() == "None";
            txtFilter.Visible = !noFilter;
            txtFilter.Clear();

            if (noFilter)
                _Refresh();
        }
    }
}
