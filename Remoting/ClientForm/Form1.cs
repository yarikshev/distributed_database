using RemotingObject;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection conn = new SqlConnection(@"Data Source=YAROSLAV-PC; Initial Catalog=MYDB; Integrated Security=True");
        TableSelecter tableSelector;
        CourierWorker courierInserter;

        private void button1_Click(object sender, EventArgs e)
        {
            DataTable dt = new DataTable("Table1");
            dt =tableSelector.GetTableFromDB();
            dataGridView1.DataSource = dt;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpChannel());

            //tableSelector = (TableSelecter)Activator.GetObject(typeof(TableSelecter), "tcp://localhost:8080//TSServ");

            RemotingConfiguration.RegisterWellKnownClientType(
                                                               typeof(TableSelecter),
                                                               "tcp://localhost:8080/TSServ"
                                                             );

            tableSelector = new TableSelecter();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            courierInserter.SetTableToDB(textBox2.Text, textBox4.Text, Convert.ToInt32(textBox3.Text));

            dataGridView1.DataSource = tableSelector.GetTableFromDB();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new HttpChannel());

            RemotingConfiguration.RegisterActivatedClientType(typeof(CourierWorker),
                                                       "http://localhost:8081");

            courierInserter = new CourierWorker();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            courierInserter.DeleteRow(Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["Age"].Value));

            dataGridView1.DataSource = tableSelector.GetTableFromDB();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            //ChannelServices.RegisterChannel(new TcpChannel());

            tableSelector = (TableSelecter)Activator.GetObject(typeof(TableSelecter), "tcp://localhost:8080/TSServ");

        }

        private void button7_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new HttpChannel());

            courierInserter = (CourierWorker)Activator.GetObject(typeof(CourierWorker), "http://localhost:8081");

        }
    }
}
