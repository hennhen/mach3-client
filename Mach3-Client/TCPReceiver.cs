using Mach3_Interface_Server;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mach3_Client {

    class TCPReceiver {

        TcpListener listener;
        TcpClient client;
        NetworkStream stream;

        IPAddress LOCAL_IP;

        public int LOCAL_TCP_PORT { get; private set; } = 55555;   // Temperory, should be between 49152-65535


        /// <summary>
        /// Instantiate local TcpListener Object and Bind with local IP and TCP port
        /// </summary>
        /// <param name="localIP">Should be passed in from the UDP socket (<code>socket.LocalEndPoint.Address</code></param>
        /// <param name="password">The password to authenticate the connection</code></param>
        public TCPReceiver() {
            this.LOCAL_IP = Program.MY_IP;
            try {
                listener = new TcpListener(LOCAL_IP, LOCAL_TCP_PORT);
                Debug.WriteLine("TCPListener Successfully Created. Listening on {0}:{1}", LOCAL_IP, LOCAL_TCP_PORT);
            } catch (SocketException e) {
                Debug.WriteLine("SocketException: {0}", e);
                MessageBox.Show("SocketException: " + e);
                // TODO: Throw error
            } finally {
                listener.Stop();
            }
        }

        public delegate void Del(NetworkStream stream, IncomingTCPPacket packet);

        /// <summary>
        /// Blocks until a connection request (A TCP Packet) is received
        /// </summary>
        public void ReceiveRequest(Del cb) {
            listener.Start();
            using (client = listener.AcceptTcpClient()) {
                // This was a blocking call to wait and accept requests

                stream = client.GetStream();
                // Buffers
                string receivedString = null;
                Byte[] bytes = new byte[256];
                int i;
                IncomingTCPPacket packet = null;

                // Read all bytes in the message
                while ((i = stream.Read(bytes, 0, bytes.Length)) != 0) {
                    // Translate data bytes to a ASCII string.
                    receivedString = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                    try {
                        // Try to parse the data into JSON format then break, if not, lets keep waiting
                        packet = new IncomingTCPPacket(client, receivedString);
                        break;
                    } catch(Exception e) {
                        throw (e);
                        continue;
                    }
                }

                cb(stream, packet);
                Debug.Print("Closing Client");
                client.Close();
            }
        }

        public int getLocalTcpPort() {
            if(LOCAL_TCP_PORT != null) {
                return LOCAL_TCP_PORT;
            } else {
                // Return an error code, 0 for now
                return 0;
            }
            
        }

        public bool isInitialized() {
            if (((IPEndPoint)listener.Server.LocalEndPoint).Port > 0) {
                return true;
            }
            return false;
        }
    }
}
