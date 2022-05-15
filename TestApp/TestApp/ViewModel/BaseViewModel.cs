using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TestApp.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
