using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mach3_Client {
    public class Mach3OutgoingJSON {

        // Construcotr: We need to instantiate any sub-classes
        public Mach3OutgoingJSON() { 
            this.coors = new Coors();
        }

        public Coors coors { get; set; }

        public double line_num { get; set; }
        public double set_rpm { get; set; }

        public double true_rpm { get; set; }

        public double feedrate { get; set; }

        public double tool_num { get; set; }

        public double elapsed_time { get; set; }

        public class Coors {
            public double x { get; set; }
            public double y { get; set; }
            public double z { get; set; }
            public double a { get; set; }
            public double c { get; set; }
        }

        
    }
}
