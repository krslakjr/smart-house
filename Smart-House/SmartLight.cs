using System;
using System.ComponentModel;

namespace SmartHouseApp
{
    public class SmartLight : SmartDevice, INotifyPropertyChanged
    {
        private int _brightness;
        private string _buttonContent;
        private string _currentColor="yellow";

        public string[] AvailableColors { get; } = { "yellow", "green", "blue", "red", "white" };

        public string CurrentColor
        {
            get => _currentColor;
            set
            {
                if (_currentColor != value)
                {
                    _currentColor = value;
                    OnPropertyChanged(nameof(CurrentColor));
                }
            }
        }


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
            _currentColor = AvailableColors[0];
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
            if (brightness < 0 || brightness > 100)
            {
                Console.WriteLine("Invalid brightness value. It should be between 0 and 100.");
            }
            else
            {
                Brightness = brightness;
                Console.WriteLine($"{Name} brightness is now {brightness}%.");
            }
        }


        public void ChangeColor(string color)
        {
            if (Array.Exists(AvailableColors, c => c.Equals(color, StringComparison.OrdinalIgnoreCase)))
            {
                CurrentColor = color;
                Console.WriteLine($"{Name} color changed to {CurrentColor}.");
            }
            else
            {
                Console.WriteLine("Invalid color selection.");
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
            string state = IsOn ? $"turned on with brightness {Brightness}%" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }
        public string Status => GetStatus();

        public override string GetStatus()
        {
            return $"{Name} is {(IsOn ? "on" : "off")} with a brightness of {Brightness}% and color {CurrentColor}.";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
