using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StorageProcedure
{
    public partial class Form1 : Form
    {
        string connectionString = "Data Source=MICROSOFT-PC; Initial Catalog=BD; Integrated Security=True";
        SqlConnection scn;

        public Form1()
        {
            InitializeComponent();
            scn = new SqlConnection(connectionString);
            scn.Open();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Select_All();
        }

        private void Select_All()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("Select * From Employes", scn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = scn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_Procedure";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Age";
            param.Direction = ParameterDirection.Input;
            param.Value = textBox1.Text;
            cmd.Parameters.Add(param);

            SqlParameter retParam = new SqlParameter();
            retParam.ParameterName = "@ReturnValue";
            retParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retParam);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if ((int)retParam.Value != 0)
            {
                MessageBox.Show("The request is empty!");
            }
            else
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            textBox2.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            textBox7.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = scn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Update_Procedure";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Name";
            param1.Direction = ParameterDirection.Input;
            param1.Value = textBox3.Text;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Surname";
            param2.Direction = ParameterDirection.Input;
            param2.Value = textBox4.Text;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@MiddleName";
            param3.Direction = ParameterDirection.Input;
            param3.Value = textBox5.Text;
            cmd.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@Age";
            param4.Direction = ParameterDirection.Input;
            param4.Value = textBox6.Text;
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@Position";
            param5.Direction = ParameterDirection.Input;
            param5.Value = textBox7.Text;
            cmd.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@Id";
            param6.Direction = ParameterDirection.Input;
            param6.Value = textBox2.Text;
            cmd.Parameters.Add(param6);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;

//            Select_All();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = scn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Select_Insert_Procedure";

            SqlParameter param1 = new SqlParameter();
            param1.ParameterName = "@Id";
            param1.Direction = ParameterDirection.Input;
            param1.Value = textBox8.Text;
            cmd.Parameters.Add(param1);

            SqlParameter param2 = new SqlParameter();
            param2.ParameterName = "@Name";
            param2.Direction = ParameterDirection.Input;
            param2.Value = textBox9.Text;
            cmd.Parameters.Add(param2);

            SqlParameter param3 = new SqlParameter();
            param3.ParameterName = "@Surname";
            param3.Direction = ParameterDirection.Input;
            param3.Value = textBox10.Text;
            cmd.Parameters.Add(param3);

            SqlParameter param4 = new SqlParameter();
            param4.ParameterName = "@MiddleName";
            param4.Direction = ParameterDirection.Input;
            param4.Value = textBox11.Text;
            cmd.Parameters.Add(param4);

            SqlParameter param5 = new SqlParameter();
            param5.ParameterName = "@Age";
            param5.Direction = ParameterDirection.Input;
            param5.Value = textBox12.Text;
            cmd.Parameters.Add(param5);

            SqlParameter param6 = new SqlParameter();
            param6.ParameterName = "@Position";
            param6.Direction = ParameterDirection.Input;
            param6.Value = textBox13.Text;
            cmd.Parameters.Add(param6);

            SqlParameter retParam = new SqlParameter();
            retParam.ParameterName = "@ReturnValue";
            retParam.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(retParam);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            if ((int)retParam.Value != 0)
            {
                MessageBox.Show("The request is empty!");
            }
            else
            {
                Select_All();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = scn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "Delete_Procedure";

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@Id";
            param.Direction = ParameterDirection.Input;
            param.Value = textBox14.Text;
            cmd.Parameters.Add(param);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);

            Select_All();
        }
    }
}
