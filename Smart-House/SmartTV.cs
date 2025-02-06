using System;

namespace SmartHouseApp
{
    public class SmartTV : SmartDevice
    {
        public int Volume { get; set; }

        public SmartTV(string name, int volume = 0) : base(name)
        {
            Volume = volume;
        }

        public override void SetSetting(string settingName, int value)
        {
            if (settingName.ToLower() == "volume" && value >= 0 && value <= 100)
            {
                Volume = value;
                Console.WriteLine($"{Name} volume set to {Volume}.");
            }
            else
            {
                Console.WriteLine("Invalid volume value. It should be between 0 and 100.");
            }
        }

        public void SetVolume(int volume)
        {
            Volume = volume;
            Console.WriteLine($"{Name} volume is now {volume}%.");
        }

        public override void Toggle()
        {
            IsOn = !IsOn;
            Console.WriteLine($"{Name} is {(IsOn ? "turned on" : "turned off")}.");
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"turned on with volume {Volume}" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }
    }
}



