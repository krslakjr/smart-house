using System;
using System.ComponentModel;

namespace SmartHouseApp
{
    public class SmartAC : SmartDevice, INotifyPropertyChanged
    {
        private int _temperature;
        private string _buttonContent;

        public string ButtonContent
        {
            get => _buttonContent;
            set
            {
                if (_buttonContent != value)
                {
                    _buttonContent = value;
                    OnPropertyChanged(nameof(ButtonContent));
                }
            }
        }

        public int Temperature
        {
            get => _temperature;
            set
            {
                if (_temperature != value)
                {
                    _temperature = value;
                    OnPropertyChanged(nameof(Temperature));
                }
            }
        }

        public string Status => IsOn ? $"AC is on with temperature {Temperature}°C" : "AC is off";

        public SmartAC() : base("Smart AC")
        {
            _temperature = 22;
            _buttonContent = "Turn On";
        }

        public SmartAC(string name, int initialTemperature = 22) : base(name)
        {
            _temperature = initialTemperature;
            _buttonContent = "Turn On";
        }

        public override void SetSetting(string settingName, int value)
        {
            if (settingName.ToLower() == "temperature" && value >= 16 && value <= 30)
            {
                Temperature = value;
                Console.WriteLine($"{Name} temperature set to {Temperature}°C.");
            }
            else
            {
                Console.WriteLine("Invalid temperature value. It should be between 16°C and 30°C.");
            }
        }

        public void SetTemperature(int newTemperature)
        {
            if (newTemperature >= 16 && newTemperature <= 30)
            {
                Temperature = newTemperature;
            }
        }

        public override void Toggle()
        {
            IsOn = !IsOn;
            ButtonContent = IsOn ? "Turn Off" : "Turn On";
            Console.WriteLine($"{Name} is {(IsOn ? "turned on" : "turned off")}.");
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"turned on with temperature {Temperature}°C" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }

        public override string GetStatus()
        {
            return $"{Name} is {(IsOn ? "turned on" : "turned off")} with temperature {Temperature}°C";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
