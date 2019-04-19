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
        public string VM_Text {get;set;}
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
            VM_Background = "Red";
            NotifyPropertyChanged("VM_Background");
        }
        

    }
    
}
