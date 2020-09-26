using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mach3_Client {
    class IncomingTCPPacket {

        #region
        // Json infos
        public class Info { 
            public string ip { get; set; }
            public int port { get; set; }
            public string timestamp { get; set; }
        }

        public class Data {
            public string type { get; set; }
            public string command { get; set; }
            //public string auth_password { get; set; }
            public int auth_udp_port { get; set; }
        }

        public class JsonPacket {
            public Info info { get; set; }
            public Data data { get; set; }
        }
        #endregion

        public Info info;
        public Data data;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client">The TcpClient after connected</param>
        /// <param name="data">Parsed datd</param>
        public IncomingTCPPacket(in TcpClient client, string data) {
            Data receivedData = JsonConvert.DeserializeObject<Data>(data);
            info = new Info();
 
            this.data = receivedData;

            this.info.ip = ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString();
            this.info.port = ((IPEndPoint)client.Client.RemoteEndPoint).Port;
        }
    }
}
