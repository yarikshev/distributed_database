using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WCFClientMEX.Service;

namespace WCFClientMEX
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        BoatClient serviceClient;

        private void Form1_Load(object sender, EventArgs e)
        {
            serviceClient = new BoatClient("BasicHttpBinding_IBoat");

            UpdateCourierGrid();
        }

        void UpdateCourierGrid()
        {
           // DataTable courierDT = serviceClient.GetCourierList();

            //dataGridView1.DataSource = courierDT;
        }

        private void button1_Click(object sender, EventArgs e)
        {
          //  serviceClient.InsertNewCourier(textBox1.Text, textBox2.Text, Convert.ToInt32(textBox3.Text));
            MessageBox.Show(serviceClient.Sinn(new Boat() { corn=90}).ToString());
          //  UpdateCourierGrid();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //serviceClient.DelCourier(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["ID"].Value));

            UpdateCourierGrid();
        }
    }
}
