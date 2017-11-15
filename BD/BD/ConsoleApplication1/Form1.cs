using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApplication1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        string dir = " ASC";

        private void accountingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.employesBindingSource.EndEdit();
            this.employesTableAdapter.Update(bDDataSet.Accounting.DataSet as BDDataSet);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.employesTableAdapter.Fill(this.bDDataSet.Employes);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            this.employesBindingSource.EndEdit();
            this.employesTableAdapter.Update(bDDataSet.Employes.DataSet as BDDataSet);
        }

        private void button1_Click(object sender, EventArgs e)
        {
                employesBindingSource.EndEdit();
            employesTableAdapter.Update(bDDataSet.Employes.DataSet as BDDataSet);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            employesBindingSource.MovePrevious();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            employesBindingSource.MoveNext();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            employesBindingSource.MoveFirst();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            employesBindingSource.MoveLast();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                employesBindingSource.AddNew();
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                employesBindingSource.RemoveCurrent();
                int index = employesDataGridView.CurrentRow.Index;
                employesDataGridView.Rows[index].Selected = true;
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox1.Text == "") employesBindingSource.Filter = null;
                else employesBindingSource.Filter = comboBox1.SelectedItem + " = '" + textBox1.Text + "'";
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
                employesBindingSource.Filter = null;
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            dir = (dir == " ASC") ? " DESC" : " ASC";
            employesBindingSource.Sort = comboBox1.Text + dir;
        }

        private void employesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            textBox2.Text = employesDataGridView.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = employesDataGridView.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = employesDataGridView.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = employesDataGridView.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = employesDataGridView.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = employesDataGridView.CurrentRow.Cells[5].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            employesDataGridView.CurrentRow.Cells[0].Value = textBox2.Text;
            employesDataGridView.CurrentRow.Cells[1].Value = textBox3.Text;
            employesDataGridView.CurrentRow.Cells[2].Value = textBox4.Text;
            employesDataGridView.CurrentRow.Cells[3].Value = textBox5.Text;
            employesDataGridView.CurrentRow.Cells[4].Value = textBox6.Text;
            employesDataGridView.CurrentRow.Cells[5].Value = textBox7.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
