using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach3_Client {
    class TCPResponses {
        public static byte[] SUCCESS { get; private set; } = Encoding.ASCII.GetBytes("{\"status\":200}");
        public static byte[] AUTH_FAILURE_INCORRECT_PASSWORD { get; private set; } = Encoding.ASCII.GetBytes("{\"status\":401}");
        public static byte[] DISCON_FAILURE_NOT_CONNECTED { get; private set; } = Encoding.ASCII.GetBytes("401: Disconnect Failure. Not already connected");
    }
}
