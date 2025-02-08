using System;
using System.ComponentModel;

namespace SmartHouseApp
{
    public class SmartAC : SmartDevice, INotifyPropertyChanged
    {
        private int _temperature;
        private string _buttonContent;
        private string _modeButtonContent="Heating";
        private bool _isHeating;
        private int _sliderMinimum;
        private int _sliderMaximum;

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

        public string ModeButtonContent
        {
            get => _modeButtonContent;
            set
            {
                if (_modeButtonContent != value)
                {
                    _modeButtonContent = value;
                    OnPropertyChanged(nameof(ModeButtonContent));
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

        public bool IsHeating
        {
            get => _isHeating;
            set
            {
                if (_isHeating != value)
                {
                    _isHeating = value;
                    OnPropertyChanged(nameof(IsHeating));
                    UpdateSliderRange();
                }
            }
        }

        public int SliderMinimum
        {
            get => _sliderMinimum;
            private set
            {
                if (_sliderMinimum != value)
                {
                    _sliderMinimum = value;
                    OnPropertyChanged(nameof(SliderMinimum));
                }
            }
        }

        public int SliderMaximum
        {
            get => _sliderMaximum;
            private set
            {
                if (_sliderMaximum != value)
                {
                    _sliderMaximum = value;
                    OnPropertyChanged(nameof(SliderMaximum));
                }
            }
        }

        public string Status => IsOn
            ? (_isHeating
                ? $"AC is heating to {Temperature}°C"
                : $"AC is cooling to {Temperature}°C")
            : "AC is off";

        public SmartAC() : base("Smart AC")
        {
            _temperature = 22;
            _isHeating = false;
            _buttonContent = "Turn On";
            _modeButtonContent = "Cooling";
            UpdateSliderRange();
        }

        private void UpdateSliderRange()
        {
            if (_isHeating)
            {
                SliderMinimum = 25;
                SliderMaximum = 40;
            }
            else
            {
                SliderMinimum = 16;
                SliderMaximum = 25;
            }
        }


        public SmartAC(string name, int initialTemperature = 22, bool isHeating = false) : base(name)
        {
            _temperature = initialTemperature;
            _isHeating = isHeating;
            _buttonContent = "Turn On";
        }

        private void SetHeatingTemperature(int value)
        {
            if (value >= 25 && value <= 40)
            {
                Temperature = value;
                Console.WriteLine($"{Name} set to heating at {Temperature}°C.");
            }
            else
            {
                Console.WriteLine("Invalid heating temperature. Must be between 25°C and 40°C.");
            }
        }

        private void SetCoolingTemperature(int value)
        {
            if (value >= 16 && value <= 25)
            {
                Temperature = value;
                Console.WriteLine($"{Name} set to cooling at {Temperature}°C.");
            }
            else
            {
                Console.WriteLine("Invalid cooling temperature. Must be between 16°C and 25°C.");
            }
        }

        public override void SetSetting(string settingName, int value)
        {
            if (settingName.ToLower() == "temperature")
            {
                if (_isHeating)
                {
                    SetHeatingTemperature(value);
                }
                else
                {
                    SetCoolingTemperature(value);
                }
            }
            else
            {
                Console.WriteLine("Invalid setting.");
            }
        }

        public void ToggleMode()
        {
            _isHeating = !_isHeating;
            ModeButtonContent = _isHeating ? "Cooling" : "Heating";
            Console.WriteLine($"{Name} mode set to {(_isHeating ? "Heating" : "Cooling")}");
            UpdateSliderRange();
        }

        public override void Toggle()
        {
            IsOn = !IsOn;
            ButtonContent = IsOn ? "Turn Off" : "Turn On";
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"{(_isHeating ? "heating" : "cooling")} to {Temperature}°C" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }

        public override string GetStatus()
        {
            return $"{Name} is {(IsOn ? (_isHeating ? $"heating to {Temperature}°C" : $"cooling to {Temperature}°C") : "turned off")}";
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
