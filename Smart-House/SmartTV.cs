using System;
using System.ComponentModel;

namespace SmartHouseApp
{
    public class SmartTV : SmartDevice, INotifyPropertyChanged
    {
        private int _volume;
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

        public event PropertyChangedEventHandler? PropertyChanged;

        public int Volume
        {
            get => _volume;
            set
            {
                if (_volume != value)
                {
                    _volume = value;
                    OnPropertyChanged(nameof(Volume));
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public string Status => GetStatus();

        public SmartTV(string name, int volume = 0) : base(name)
        {
            Volume = volume;
            _buttonContent = "Turn On";
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public override void SetSetting(string settingName, int value)
        {
            if (settingName.ToLower() == "volume" && value >= 0 && value <= 100)
            {
                Volume = value;
                Console.WriteLine($"{Name}: Volume set to {Volume}%.");
            }
            else
            {
                Console.WriteLine($"{Name}: Invalid volume value. It should be between 0 and 100.");
            }
        }

        public void SetVolume(int volume)
        {
            if (volume >= 0 && volume <= 100)
            {
                Volume = volume;
                Console.WriteLine($"{Name}: Volume is now {Volume}%.");
            }
            else
            {
                Console.WriteLine($"{Name}: Invalid volume value.");
            }
        }

        public override void Toggle()
        {
            IsOn = !IsOn;
            ButtonContent = IsOn ? "Turn Off" : "Turn On";
            Console.WriteLine($"{Name} is now {(IsOn ? "ON" : "OFF")}.");
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"ON, Volume: {Volume}%" : "OFF";
            Console.WriteLine($"{Name} status: {state}");
        }

        public override string GetStatus()
        {
            return $"{Name} is {(IsOn ? "ON" : "OFF")}, Volume: {Volume}%";
        }
    }
}
