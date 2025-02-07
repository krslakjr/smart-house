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
