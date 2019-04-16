using FlightSimulator.Model.EventArgs;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels.Windows
{
    class ManualViewModel:BaseNotify
    {
        public delegate void OnScreenJoystickEventHandler(object sender, VirtualJoystickEventArgs args);
        public ManualViewModel(Joystick e)
        {
            e.Moved+=update;
            e.Released += reset;
        }
        private double throttle;
        public double VM_throttle { get { return Math.Floor( throttle*10)/10; }
            set {
                throttle = value;
                //model.moveThrottle(throttle);
                NotifyPropertyChanged("VM_throttle");
                }
        }
        private double rudder;
        public double VM_rudder {
            get { return Math.Floor(rudder * 10) / 10; }
            set
            {
                rudder = value;
                //model.moveRudder(rudder);
                NotifyPropertyChanged("VM_rudder");
            }
        }
        public double VM_aileron { get; set; }
        public double VM_elevator { get; set; }
        private void update(Object sender , VirtualJoystickEventArgs e)
        {
            VM_aileron = e.Aileron;
            VM_elevator = e.Elevator;
            NotifyPropertyChanged("VM_aileron");
            NotifyPropertyChanged("VM_elevator");
        }
        private void reset(Object sender)
        {
            VM_aileron = 0;
            VM_elevator = 0;
            NotifyPropertyChanged("VM_aileron");
            NotifyPropertyChanged("VM_elevator");
        }
    }
}
