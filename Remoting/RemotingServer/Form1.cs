using RemotingObject;
using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;
using System.Windows.Forms;

namespace RemotingServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new TcpServerChannel(8080),false);

            RemotingConfiguration.RegisterWellKnownServiceType(typeof(TableSelecter),
                                                                "TSServ",
                                                                WellKnownObjectMode.Singleton
                                                              );
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ChannelServices.RegisterChannel(new HttpChannel(8081));

            RemotingConfiguration.RegisterActivatedServiceType(typeof(CourierWorker));
        }
    }
}
