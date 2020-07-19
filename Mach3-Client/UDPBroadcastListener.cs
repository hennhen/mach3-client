using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Mach3_Client {
    class UDPBroadcastListener : IDisposable
    {
        public const int LOCAL_UDP_BROADCAST_PORT = 56189;
        UdpClient udpClient = new UdpClient();
        IPEndPoint originEndpoint = new IPEndPoint(IPAddress.Any, 0);

        public UDPBroadcastListener() {
            udpClient.Client.Bind(new IPEndPoint(IPAddress.Any, LOCAL_UDP_BROADCAST_PORT));
        }

        /// <summary>
        /// Returns if broadcast message is received (Non-blocking)
        /// </summary>
        public bool BroadcastMessageReceived() {
            if(udpClient.Available > 0) {
                // Receive usually blocks, but we made sure there is data avail
                var recvBuffer = udpClient.Receive(ref originEndpoint);
                string receivedString = (Encoding.UTF8.GetString(recvBuffer));
                Debug.WriteLine("UDPBroadcastListener Received: " + receivedString);

                if (receivedString.Contains("BROADCAST")) {
                    Debug.WriteLine("UDPBroadcastListener: Broadcast msg received!");
                    return true; 
                }
                else {
                    Debug.WriteLine("Non-Broadcast msg received: " + receivedString);
                }
            }
            return false;
        }

        /// <summary>
        /// </summary>
        /// <param name="job_name"></param>
        /// <param name="localTcpPort">The port that TCPReceiver is listening on</param>
        public void sendMachineInfo(string job_name, string customer_name, int localTcpPort) {
            string s = "$" + job_name + "$" + customer_name + "$" + localTcpPort.ToString() ;
            Byte[] sendBytes = Encoding.ASCII.GetBytes(s);   // TODO: Should be the whole package in the future

            // After a message is recevied, the originEndpoint will automatically stores the broadcast originator's endpoint
            udpClient.Send(sendBytes, sendBytes.Length, originEndpoint);
        }

        public void Dispose() {
            Debug.WriteLine("Disposing UDPBroadcastListener...");
            udpClient.Close();
            udpClient.Dispose();
        }
    }
}
