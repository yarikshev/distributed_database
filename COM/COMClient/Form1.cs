using System;
using System.Data;
using System.Data.SqlClient;
using System.Reflection;
using System.Windows.Forms;

namespace COMClient
{
    public partial class Form1 : Form
    {
        SqlConnection conn = new SqlConnection(@"Data Source=YAROSLAV-PC; Initial Catalog=MYDB; Integrated Security=True");
        Object ComClass;
       // Object ComClass1;
        Type type;
       // Type type1;
        

        public Form1()
        {
            InitializeComponent();

            type = Type.GetTypeFromProgID("COMServer.DeliveryWorking");

            ComClass = Activator.CreateInstance(type);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            UpdateCourierGrid();

            UpdateDeliveryListGrid();

            

           
        }

        void UpdateCourierGrid()
        {
            MethodInfo mGetCourierList = type.GetMethod("GetCourierList");

            DataTable courierDT = (DataTable)mGetCourierList.Invoke(ComClass, new object[] { conn });

            dataGridView1.DataSource = courierDT;

            comboBox1.Items.Clear();

            foreach (DataRow dr in courierDT.Rows)
            {
                comboBox1.Items.Add(dr["Name"] + " " + dr["Surname"]);
            }
        }

        void UpdateDeliveryListGrid()
        {
            MethodInfo mGetDeliveryList = type.GetMethod("GetDeliveryList");

            DataTable deliveryListDT = (DataTable)mGetDeliveryList.Invoke(ComClass, new object[] { conn });

            dataGridView2.DataSource = deliveryListDT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MethodInfo mInsertNewCourier = type.GetMethod("InsertNewCourier");

            mInsertNewCourier.Invoke(ComClass, new object[] { conn, textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text) });

            UpdateCourierGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MethodInfo mInsertNewDeliveryList = type.GetMethod("InsertNewDeliveryList");

            mInsertNewDeliveryList.Invoke(ComClass, new object[] { conn, textBox4.Text, comboBox1.SelectedIndex + 1, textBox5.Text });

            UpdateDeliveryListGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MethodInfo mDelCourier = type.GetMethod("DelCourier");

            mDelCourier.Invoke(ComClass, new object[] { conn, Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Age"].Value) });

            UpdateCourierGrid();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            MethodInfo mDelDeliveryList = type.GetMethod("DelDeliveryList");

            mDelDeliveryList.Invoke(ComClass, new object[] { conn, Convert.ToInt32(dataGridView2.SelectedRows[0].Cells["CourierID"].Value) });

            UpdateDeliveryListGrid();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Type type2 = Type.GetTypeFromProgID("COMServer.TableList");

            Object ComClass1 = Activator.CreateInstance(type2);

            MethodInfo mGetDeliveryList = type2.GetMethod("FuncTableList");

            string s1 = textBox6.Text;
            DataTable deliveryListDT = (DataTable)mGetDeliveryList.Invoke(ComClass1, new object[] { s1 });

            dataGridView2.DataSource = deliveryListDT;
        }
    }
}