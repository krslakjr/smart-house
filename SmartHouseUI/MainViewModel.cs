using System;
using System.ComponentModel;
using SmartHouseApp;

namespace SmartHouseUI
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public SmartAC SmartACDevice { get; set; }
        public SmartTV SmartTVDevice { get; set; }
        public SmartLight SmartLightDevice { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        // Konstruktor sa parametrima
        public MainViewModel(SmartAC acDevice, SmartTV tvDevice, SmartLight lightDevice)
        {
            SmartACDevice = acDevice;
            SmartTVDevice = tvDevice;
            SmartLightDevice = lightDevice;
        }

        // Konstruktor bez parametara koji se koristi za Avalonia
        public MainViewModel()
        {
            // Podrazumevane vrednosti za inicijalizaciju
            SmartACDevice = new SmartAC("AC", 22);
            SmartTVDevice = new SmartTV("TV", 50);
            SmartLightDevice = new SmartLight("Lamp", 0);
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public string SmartACStatus => SmartACDevice.GetStatus();
        public string SmartTVStatus => SmartTVDevice.GetStatus();
        public string SmartLightStatus => SmartLightDevice.GetStatus();
    }
}
