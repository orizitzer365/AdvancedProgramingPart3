using FlightSimulator.Model;
using FlightSimulator.Model.EventArgs;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels.Windows
{
    class ManualViewModel:BaseNotify
    {
        private static readonly ManualViewModel instance = new ManualViewModel();

        // Explicit static constructor to tell C# compiler
        // not to mark type as beforefieldinit
        static ManualViewModel()
        {
        }

        private ManualViewModel()
        {
        }

        public static ManualViewModel Instance
        {
            get
            {
                return instance;
            }
        }

        public delegate void OnScreenJoystickEventHandler(object sender, VirtualJoystickEventArgs args);
        
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
        private double aileron;
        public double VM_aileron { get
            {
                return aileron;
            }
            set {
                aileron = Math.Floor( value*10000)/10000;
                NotifyPropertyChanged("VM_aileron");
                }
        }
        private double elevator;
        public double VM_elevator { get { return elevator; }
            set {
                elevator = Math.Floor(value * 10000) / 10000;
                NotifyPropertyChanged("VM_aileron");
            }
        }
        public void update(Object sender , VirtualJoystickEventArgs e)
        {
            VM_aileron = e.Aileron;
            VM_elevator = e.Elevator;
            NotifyPropertyChanged("VM_aileron");
            NotifyPropertyChanged("VM_elevator");
        }
        public void reset(Object sender)
        {
            VM_aileron = 0;
            VM_elevator = 0;
            NotifyPropertyChanged("VM_aileron");
            NotifyPropertyChanged("VM_elevator");
        }
        private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return _okCommand ?? (_okCommand =
                new CommandHandler(() => update(this,new VirtualJoystickEventArgs())));
            }
        }
        

    }
}
