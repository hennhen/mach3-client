
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using Mach4;
using Mach3_Client;
using System.Threading;

namespace Mach3_Interface_Server {

    /// <summary>Class <c>Mach3Client</c> has the handle of Mach3Mill and uses Mach3 
    /// macro VBA functions for getting and setting data</summary>
    class Mach3Client {

        // The JSON Object for storing outgoing data
        public Mach3OutgoingJSON outgoingJson = new Mach3OutgoingJSON();

        //Mach3 Windows Handles
        private Mach4.IMach4 Mach3App = null;
        private Mach4.IMyScriptObject Mach3 = null;

        //Basic Datas
        public string customer_name;
        public string job_name;

        //DRO Codes
        private const short DRO_X = 800;
        private const short DRO_Y = 801;
        private const short DRO_Z = 802;
        private const short DRO_A = 803;
        private const short DRO_C = 805;

        private const short DRO_CURRENT_LINE_NUM = 800;

        private SynchronizationContext _synchronizationContext;

        // Constructor
        public Mach3Client() {
            this._synchronizationContext = SynchronizationContext.Current;
            try {
                Mach3App = (Mach4.IMach4)Marshal.GetActiveObject("Mach4.Document");
                Mach3 = (Mach4.IMyScriptObject)Mach3App.GetScriptDispatch();
            } catch(COMException e) {
                throw (new Exception("Mach3NotFoundException"));
            }
        }

        public async void executeCommand(string command) {

            switch (command) {
                case "start":
                    Mach3.DoOEMButton(1000);
                    break;
                case "pause":
                    Mach3.DoOEMButton(1001);
                    break;
                case "zero-all":
                    Mach3.DoOEMButton(1007);
                    break;
                default:
                    Debug.Print("Received unknown command: " + command);
                    break;
            }
            // TODO: This blocks??? when we do open GCode Window
        }

        private void getCoors() {
            outgoingJson.coors.x = Mach3.GetOEMDRO(DRO_X);
            outgoingJson.coors.y = Mach3.GetOEMDRO(DRO_Y);
            outgoingJson.coors.z = Mach3.GetOEMDRO(DRO_Z);
            outgoingJson.coors.a = Mach3.GetOEMDRO(DRO_A);
            outgoingJson.coors.c = Mach3.GetOEMDRO(DRO_C);
        }

        /// <summary>
        /// Update the internal <code>outgoingJson</code> with each getter functions.
        /// </summary>
        public void updateData() {
            // TODO: Catch InvalidCastexception for when Mach3 closes suddenly
            getCoors();

            outgoingJson.line_num = Mach3.GetOEMDRO(816);

            outgoingJson.set_rpm = Mach3.GetOEMDRO(817);
            outgoingJson.true_rpm = Mach3.GetOEMDRO(39);

            outgoingJson.feedrate = Mach3.GetOEMDRO(818);

            outgoingJson.tool_num = Mach3.GetOEMDRO(824);

            outgoingJson.elapsed_time = Mach3.GetOEMDRO(814);
        }

        /// 
        /// <summary>Returns stringified <code>outgoingJson</code></summary>
        /// 
        public string getJsonData() {
            return JsonConvert.SerializeObject(outgoingJson);
        }
    }
}