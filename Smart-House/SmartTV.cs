using System;
using System.ComponentModel;

namespace SmartHouseApp
{
    public class SmartTV : SmartDevice, INotifyPropertyChanged
    {
        private int _volume;
        private string _buttonContent;
        private int _currentChannel;
        private const int MaxChannel = 30;

        public int CurrentChannel
        {
            get => _currentChannel;
            set
            {
                if (_currentChannel != value && value >= 1 && value <= MaxChannel)
                {
                    _currentChannel = value;
                    OnPropertyChanged(nameof(CurrentChannel));
                    OnPropertyChanged(nameof(Status));  
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

        public void ChangeChannelUp()
        {
            if (_currentChannel < MaxChannel)
            {
                CurrentChannel++;
            }
            else
            {
                Console.WriteLine("Already on the highest channel.");
            }
        }

        public void ChangeChannelDown()
        {
            if (_currentChannel > 1)
            {
                CurrentChannel--;
            }
            else
            {
                Console.WriteLine("Already on the lowest channel.");
            }
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
