using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KwikMedicalSystem.Business.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnChanged(string propertyChanged)
        {
            PropertyChanged(this, new PropertyChangedEventArgs(propertyChanged));
        }
    }
}
