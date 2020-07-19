using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Mach4;
using System.Diagnostics;
using System.Threading;
using Mach3_Interface_Server;

namespace Mach3_Client
{
    public partial class Form1 : Form
    {
        private SynchronizationContext _synchronizationContext;

        public Form1()
        {
            InitializeComponent();
            _synchronizationContext = SynchronizationContext.Current;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label_myIP.Text = Program.MY_IP.ToString();
        }

        public void updateMach3Data(string job_name) {
            _synchronizationContext.Post(new SendOrPostCallback(o => {
                textbox_job_name.Text = job_name;
            }), null);
        }

        public void updateUDPData(string data) {
            _synchronizationContext.Post(new SendOrPostCallback(o => {
    
            }), null);
        }

        public async void updateMach3MillFound(string job_name, string customer_name) {
            await Task.Run(() => {
                _synchronizationContext.Post(new SendOrPostCallback(o => {
                    groupBox_udpBroadcast.Enabled = true;
                    pictureBox_Loading_Mach3Mill.Visible = false;
                    label_mach3mill_status.Text = "Connected to Mach3Mill!";
                    label_mach3mill_status.ForeColor = Color.ForestGreen;

                    textbox_customer_name.Text = customer_name;
                    textbox_job_name.Text = job_name;
                    textbox_password.Text = Program.AUTH_PASSWORD;
                }), null);
            });
        }

        public async void updateGeneralConnectionStatus(bool connected, string message, string remote_ip = null) {
            await Task.Run(() => {
                _synchronizationContext.Post(new SendOrPostCallback(o => {
                    label_connect_status.Text = message;
                    label_connect_status.ForeColor = connected ? Color.ForestGreen : Color.DarkRed;
                    label_server_ip.Text = connected ? remote_ip : "Not Available";
                    label_server_ip.ForeColor = connected ? Color.ForestGreen : Color.FromName("ButtonShadow");
                    button_disconFromServer.Enabled = connected;
                }), null);
            });
        }

        public async void updatePanelBroadcastStatus(bool broadcastOn, int tcp_receive_port, int udp_broadcast_port = UDPBroadcastListener.LOCAL_UDP_BROADCAST_PORT
            ,  string message = null) {
            await Task.Run(() => {
                _synchronizationContext.Post(new SendOrPostCallback(o => {
                    label_udpBroadcastGroupBox_message.Text = message;
                    label_broadcast_listen_port.Text = udp_broadcast_port.ToString();
                    label_tcp_receive_port.Text = tcp_receive_port.ToString();

                    button_discovery_mode_OnOff.Text = broadcastOn? "On" : "Off";
                    button_discovery_mode_OnOff.ForeColor = broadcastOn ? Color.ForestGreen : Color.DarkRed;

                    table_broadcast_port_info.Visible = broadcastOn;
                    picture_discovery_mode_spinner.Visible = broadcastOn;
                }), null);
            });
        }

        public async void updatePanelBroadcastStatus(bool hide) {
            await Task.Run(() => {
                _synchronizationContext.Post(new SendOrPostCallback(o => {
                    groupBox_udpBroadcast.Visible = !hide;
                }), null);
            });
        }

        /// <summary>
        /// Update the General Connection Status Table and show the broadcast listening panel again
        /// </summary>
        public async void updateDisconnect() {
            await Task.Run(() => {
                _synchronizationContext.Post(new SendOrPostCallback(o => {
                    updateGeneralConnectionStatus(false, "Disconnected");
                    // We must have had connected before we can disconnect, so we just use the data from before
                    groupBox_udpBroadcast.Visible = true;
                    updatePanelBroadcastStatus(false);  // Don't hide: SHow
                    updateTCPUDPGroupdBoxes(false);
                    button_disconFromServer.Enabled = false;
                }), null);
            });
        }

        public async void updateTCPUDPGroupdBoxes(bool wantsToShow, int tcp_target_port = 0, int tcp_local_port = 0, int udp_target_port = 0, int udp_local_port = 0) {
            await Task.Run(() => {
                _synchronizationContext.Post(new SendOrPostCallback(o => {
                    groupBox_tcp.Visible = wantsToShow;
                    groupBox_udp.Visible = wantsToShow;

                    if (wantsToShow) {
                        label_tcp_target_port.Text = tcp_target_port.ToString();
                        label_tcp_local_port.Text = tcp_local_port.ToString();
                        label_udp_target_port.Text = udp_target_port.ToString();
                        label_udp_local_port.Text = udp_local_port.ToString();
                        
                    }
                }), null);
            });
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e) {

        }

        private void label1_Click(object sender, EventArgs e) {

        }

        

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e) {

        }

        private void label2_Click(object sender, EventArgs e) {

        }

        private void groupBox1_Enter(object sender, EventArgs e) {

        }

        private void panel1_Paint(object sender, PaintEventArgs e) {

        }

        private void label14_Click(object sender, EventArgs e) {

        }

        private void label13_Click(object sender, EventArgs e) {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e) {

        }

        private void groupBox2_Enter(object sender, EventArgs e) {

        }

        private void label18_Click(object sender, EventArgs e) {

        }

        private void label5_Click(object sender, EventArgs e) {

        }

        private void label8_Click(object sender, EventArgs e) {

        }
        
        private void button__Click(object sender, EventArgs e) {

        }

        private void button_discovery_mode_OnOff_Click_1(object sender, EventArgs e) {
            // TODO: Also make TCP not accept new connections
            bool status;
            lock (Program.flagsLocker) {
                status = Program.flags["discovery_mode"];
                Program.flags["discovery_mode"] = !status;
            }

            if (!status) {
                // If previously not running
                Program.tStart_UDPDiscovery();
            }
            // Do opposite of status
            button_discovery_mode_OnOff.Text = status ? "Off" : "On";
            button_discovery_mode_OnOff.ForeColor = status ? Color.DarkRed : Color.ForestGreen;

            picture_discovery_mode_spinner.Visible = !status;
            label_udpBroadcastGroupBox_message.Text = status ? "Not Listening for Broadcasts" : "Listening for Broadcast...";
        }

		private void button_disconFromServer_Click(object sender, EventArgs e)
		{
            lock (Program.flagsLocker)
            {
                Program.flags["udp_stream"] = false;
                Program.tStart_UDPDiscovery();
                updateDisconnect();
            }
        }

        private void textbox_job_name_TextChanged(object sender, EventArgs e)
        {

        }

        // Set new data and password
        private void label_PASSWORD_TEXT_Click(object sender, EventArgs e)
        {
            textbox_customer_name.Enabled = !textbox_customer_name.Enabled;
            textbox_job_name.Enabled = !textbox_job_name.Enabled;
            textbox_password.Enabled = !textbox_password.Enabled;

            Program.mach3.customer_name = textbox_customer_name.Text;
            Program.mach3.job_name = textbox_job_name.Text;
            Program.AUTH_PASSWORD = textbox_password.Text;
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e) {
            lock (Program.flagsLocker) {
                Program.flags["udp_stream"] = false;
                Program.flags["discovery_mode"] = false;
            }
            Debug.Print("Form Closed, Exiting");
            Application.Exit();
            Environment.Exit(0);
        }
    }
}
