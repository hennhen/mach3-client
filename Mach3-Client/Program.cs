using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Mach3_Client;
using System.Threading;
using System.Net;
using System.Runtime.CompilerServices;
using System.Diagnostics.Eventing.Reader;
using System.Security.AccessControl;
using System.Net.Sockets;
using System.Text;

namespace Mach3_Interface_Server {
    static class Program {
        public static IPAddress MY_IP;
        private static string AUTHORIZED_IP;
        public static string AUTH_PASSWORD = "123";

        //public static volatile bool DISCOVERY_MODE_FLAG = true;
        //private static volatile bool UDP_STREAMING_FLAG = false;
        //private static volatile bool UDP_STREAMING_IS_RUNNING = false;   //We can change to a dict or array that stores active threads if needed

        // Dictionary to store the flag for each condition
        public static readonly object flagsLocker = new object();
        public static volatile Dictionary<string, bool> flags = new Dictionary<string, bool>();

        public static Mach3Client mach3;
        private static TCPReceiver tcpPacketReceiver;
        //private static UDP_SHOULD_STREAM;

        public static Form1 form;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]

        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            lock (flagsLocker) {
                flags.Add("discovery_mode", false);
                flags.Add("udp_stream", false);
                flags.Add("udp_stream_thread_running", false);
            }

            MY_IP = GetLocalIPAddress();

            Thread t_Form = new Thread(() => {
                Application.Run(form = new Form1());
            });
            t_Form.Start();

            // Wait for the form to load properly
            while(Application.OpenForms.Count == 0) { }

            // Block until Mach3Client is successfully created
            while (true) {
                try {
                    mach3 = new Mach3Client();
                    //Mach3Mill connected and successfully created mach3 obj
                    form.updateMach3MillFound("Clevis Mount", "Henry Wu");
                    break;
                }
                catch (Exception e) {
                    if (e.Message == "Mach3NotFoundException") {
                        continue;
                    }
                }
            }

            // Now we start the TCP Receiver Object and Thread to Listen
            tcpPacketReceiver = new TCPReceiver();

            Thread t_TCPReceive = new Thread(() => {
                Thread.CurrentThread.Name = "t_TCPRecieve";
                while (true) {
                    tcpPacketReceiver.ReceiveRequest((stream, packet) => {
                        byte[] response = null;
                        // TODO: Packet is null: Should catch this error before, or store the error code in here and have it display: Bad request
                        switch (packet.data.type) {
                            case "mach3_command":
                                if (IsAuthorized(packet)) {
                                    // An authorized command request
                                    Debug.Print("t_TCPRecieve: Received Authorized TCP Command");
                                    mach3.executeCommand(packet.data.command);
                                    response = TCPResponses.SUCCESS;
                                }
                                else {
                                    Debug.Print("t_TCPRecieve: Received Unauthorized TCP Command");
                                }
                                break;
                            case "auth_request":
                                Debug.Print("t_TCPRecieve: Received Auth Request");
                                Debug.Print(packet.data.auth_password);

                                if (packet.data.auth_password == AUTH_PASSWORD) {
                                    Debug.Print("t_TCPRecieve: Correct Password");
                                    // Check if we are already streaming and stop it
                                    lock (flagsLocker) {
                                        if (flags["udp_stream"]) {
                                            Debug.Print("t_TCPRecieve: Already streaming, stream to the new request now");
                                            flags["udp_stream"] = false;
                                        }
                                        while (flags["udp_stream_thread_running"]) {/*Wait for thread to stop*/ }

                                        AUTHORIZED_IP = packet.info.ip;
                                        // Kills t_UDPDiscovery and start streaming data
                                        flags["discovery_mode"] = false;
                                    }
                                    tStart_UDPStream(packet.info.ip, packet.data.auth_udp_port);
                                    response = TCPResponses.SUCCESS;

                                    form.updateGeneralConnectionStatus(true, "Connected!", AUTHORIZED_IP);
                                    form.updatePanelBroadcastStatus(true);   // Hides the broadcast info pannel
                                    form.updateTCPUDPGroupdBoxes(true, packet.info.port, tcpPacketReceiver.LOCAL_TCP_PORT, packet.data.auth_udp_port, UDPSender.LOCAL_PORT); // Show the TCP & UDP Info Group Boxes
                                }
                                else {
                                    Debug.Print("Incorrect Password");
                                    response = TCPResponses.AUTH_FAILURE_INCORRECT_PASSWORD;
                                }
                                break;
                            case "disconnect_request":
                                if (IsAuthorized(packet)) {
                                    AUTHORIZED_IP = null;

                                    // Stop UDP Streaming and Start listening for broadcasting
                                    lock (flagsLocker) {
                                        flags["udp_stream"] = false;
                                    }
                                    tStart_UDPDiscovery();
                                    response = TCPResponses.SUCCESS;
                                    form.updateDisconnect();
                                }
                                else {
                                    Debug.Print("Unauthorized Disconnect Request");
                                    response = TCPResponses.DISCON_FAILURE_NOT_CONNECTED;
                                }
                                break;
                            // TODO: Case connection keep alive
                            default:
                                Debug.Print("Unknown packet type: {0}", packet.data.command);
                                break;
                        }
                        stream.Write(response, 0, response.Length);
                    });
                }
            });

            tStart_UDPDiscovery();
            t_TCPReceive.Start();
        }

        /// <summary>
        /// Start t_UDPStream: Create UDPSender and send mach3 data as long as UDP_STREAMING_FLAG
        /// </summary>
        /// <param name="targetEndpoint">Destination of the stream. "IP:PORT" casted to an object</param>
        private static void tStart_UDPStream(string target_ip, int target_port) {

            lock (flagsLocker) {
                flags["udp_stream"] = true;
            }
            Debug.WriteLine("Starting UDPStream thread to {0}:{1}", target_ip, target_port);
            UDPSender udpSender = new UDPSender(in mach3, target_ip, target_port);
            Thread t_UDPStream = new Thread(() => {
                lock (flagsLocker) {
                    flags["udp_stream_thread_running"] = true;
                }
                Thread.CurrentThread.Name = "t_UDPStream";

                try {
                    // This makes sure that this thread stops when program stops
                    Thread.CurrentThread.IsBackground = true;

                    while (flags["udp_stream"]) {
                        udpSender.sendMach3Data();
                        form.updateUDPData(mach3.getJsonData());
                        Thread.Sleep(100);
                    }
                } catch (ThreadAbortException e) {
                    Debug.WriteLine("UDPStream Thread Aborted...");
                }
                finally {
                    udpSender.Dispose();
                    flags["udp_stream_thread_running"] = false;
                    Debug.WriteLine("UDPStream Thread Exiting 2...");
                }
            });
            t_UDPStream.Start();
        }

        /// <summary>
        /// Start t_UDPDiscovery: Create UDPBroadcastListener then receives broadcast messages then respond with machine data.
        /// Thread is to be reused, rebound, and restarted
        /// </summary>
        public static void tStart_UDPDiscovery() {
            lock (flagsLocker) {
                flags["discovery_mode"] = true;
            }
            UDPBroadcastListener broadcastListener = new UDPBroadcastListener();
            Thread t_UDPDiscovery = new Thread(() => {
                try {
                    Thread.CurrentThread.IsBackground = true;

                    // We keep listening and sending back machine data until a connection is made and kills the thread
                    Debug.WriteLine("tStart_UDPDiscovery: Started listening...");
                    form.updatePanelBroadcastStatus(true, tcpPacketReceiver.LOCAL_TCP_PORT, UDPBroadcastListener.LOCAL_UDP_BROADCAST_PORT,  "Waiting for Connection...");
                    
                    while (flags["discovery_mode"]) {
                        if (broadcastListener.BroadcastMessageReceived())
                        {
                            broadcastListener.sendMachineInfo(mach3.job_name, mach3.customer_name ,tcpPacketReceiver.getLocalTcpPort());
                        }
                    }
                }
                catch (ThreadAbortException e) {
                    
                    Debug.WriteLine("tStart_UDPDiscovery: Thread Aborted...");
                }
                finally {
                    broadcastListener.Dispose();
                    Debug.WriteLine("tStart_UDPDiscovery: Thread Exiting...");

                }
            });
            t_UDPDiscovery.Start();
        }

        private static bool IsAuthorized(IncomingTCPPacket incomingPacket) {
            if (incomingPacket.info.ip == AUTHORIZED_IP) {
                return true;
            }
            return false;
        }

        public static IPAddress GetLocalIPAddress() {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList) {
                if (ip.AddressFamily == AddressFamily.InterNetwork) {
                    return ip;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}