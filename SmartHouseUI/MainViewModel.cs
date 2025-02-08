using System;
using System.ComponentModel;
using SmartHouseApp;

namespace SmartHouseUI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public SmartAC SmartACDevice { get; set; }
        public SmartTV SmartTVDevice { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Konstruktor sa parametrima
        public MainViewModel(SmartAC acDevice, SmartTV tvDevice)
        {
            SmartACDevice = acDevice;
            SmartTVDevice = tvDevice;
        }

        // Konstruktor bez parametara koji se koristi za Avalonia
        public MainViewModel()
        {
            // Podrazumevane vrednosti za inicijalizaciju
            SmartACDevice = new SmartAC("AC", 22);
            SmartTVDevice = new SmartTV("TV", 50);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SmartACStatus => SmartACDevice.GetStatus();
        public string SmartTVStatus => SmartTVDevice.GetStatus();
    }
}
