using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels.Windows
{
    class ManualViewModel:BaseNotify
    {
        private double throttle;
        public double VM_throttle { get { return Math.Floor( throttle*10)/10; }
            set {
                throttle = value;
                NotifyPropertyChanged("VM_throttle");
                }
        }
        private double rudder;
        public double VM_rudder {
            get { return Math.Floor(rudder * 10) / 10; }
            set
            {
                rudder = value;
                NotifyPropertyChanged("VM_rudder");
            }
        }
        public int VM_aileron { get; set; }
        public int VM_elevator { get; set; }
    }
}
