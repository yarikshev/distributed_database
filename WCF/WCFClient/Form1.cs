using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFService;

namespace WCFClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        IServTP serviceClient;

        private void Form1_Load(object sender, EventArgs e)
        {
            //BasicHttpBinding binding = new BasicHttpBinding();
            NetTcpBinding binding = new NetTcpBinding();

            EndpointAddress address = new EndpointAddress("net.tcp://localhost:1523");

            var cf = new ChannelFactory<IServTP>(binding, address);//<IService>(binding, address);
            serviceClient = cf.CreateChannel();
            

            UpdateCourierGrid();
        }

        void UpdateCourierGrid()
        {
            DataTable courierDT = serviceClient.GetSystemInfo("U"); //serviceClient.GetCourierList();

            dataGridView1.DataSource = courierDT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //serviceClient.InsertNewCourier(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));

            UpdateCourierGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           // serviceClient.DelCourier(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value));

            UpdateCourierGrid();
        }
    }
}
