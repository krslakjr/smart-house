using System;
using System.ComponentModel;

namespace SmartHouseApp
{
    public class SmartLight : SmartDevice, INotifyPropertyChanged
    {
        private int _brightness;
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

        public int Brightness
        {
            get => _brightness;
            set
            {
                if (_brightness != value)
                {
                    _brightness = value;
                    OnPropertyChanged(nameof(Brightness));
                }
            }
        }

        public SmartLight(string name, int initialBrightness = 0) : base(name)
        {
            Brightness = initialBrightness;
            _buttonContent = "Turn On";
        }

        public override void SetSetting(string settingName, int value)
        {
            if (settingName.ToLower() == "brightness" && value >= 0 && value <= 100)
            {
                Brightness = value;
                Console.WriteLine($"{Name} brightness set to {Brightness}%.");
            }
            else
            {
                Console.WriteLine("Invalid brightness value. It should be between 0 and 100.");
            }
        }

        public void SetBrightness(int brightness)
        {
            Brightness = brightness;
            Console.WriteLine($"{Name} brightness is now {brightness}%.");
        }

        public override void Toggle()
        {
            IsOn = !IsOn;
            ButtonContent = IsOn ? "Turn Off" : "Turn On"; 
            Console.WriteLine($"{Name} is {(IsOn ? "turned on" : "turned off")}.");
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"turned on with brightness {Brightness}%" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }
        public string Status => GetStatus();

        public override string GetStatus()
        {
            return $"{Name} is {(IsOn ? "turned on" : "turned off")} with brightness {Brightness}%";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
