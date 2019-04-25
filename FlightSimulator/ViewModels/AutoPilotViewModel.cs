using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    class AutoPilotViewModel:BaseNotify
    {
        private string text;
        public string VM_Text {
            get {
                return text;
            } set
            {
                text = value;
                if (value != "")
                {
                    VM_Background = "pink";
                    NotifyPropertyChanged("VM_Background");
                }
            }
        }
        private ICommand _clearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return  _clearCommand??(_clearCommand =
                new CommandHandler(() => ClickClear()));
            }
        }
        public void ClickClear()
        {
            VM_Text = "";
            VM_Background = "white";
            NotifyPropertyChanged("VM_Background");
            NotifyPropertyChanged("VM_Text");
        }
        public string VM_Background { get; set; }
        private ICommand _okCommand;
        public ICommand OKCommand
        {
            get
            {
                return _okCommand ?? (_okCommand =
                new CommandHandler(() => ClickOK()));
            }
        }
        public void ClickOK()
        {
            //model.sendCommands(VM_Text);
            //send the text to the model
            VM_Background = "white";
            NotifyPropertyChanged("VM_Background");
        }
        

    }
    
}
