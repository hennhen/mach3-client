using Mach3_Interface_Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mach3_Client {
    class UDPSender : IDisposable{

        private Mach3Client mach3;
        private UdpClient udpClient;
        private byte[] outgoingData;
        public const int LOCAL_PORT = 12000;

        public UDPSender(in Mach3Client mach3, string target_ip, int target_port) {
            // in means it cant be modified, which makes sense cuz we are just reading & sending data
            this.mach3 = mach3;

            udpClient = new UdpClient(LOCAL_PORT);   // Local port number
            udpClient.Connect(IPAddress.Parse(target_ip), target_port); // Target address
        }

        /// <summary>
        /// Calls <code>Mach3Client.updateData()</code> then send to port
        /// </summary>
        public void sendMach3Data() {
            mach3.updateData();
            outgoingData = Encoding.ASCII.GetBytes(mach3.getJsonData());
            udpClient.Send(outgoingData, outgoingData.Length);
        }

        public void Dispose() {
            Debug.WriteLine("Disposing UDPSender...");
            udpClient.Close();
            udpClient.Dispose();
        }
    }
}

