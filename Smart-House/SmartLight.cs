using System;

namespace SmartHouseApp
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; private set; }

        public SmartLight(string name, int initialBrightness = 0) : base(name)
        {
            Brightness = initialBrightness;
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
            Console.WriteLine($"{Name} is {(IsOn ? "turned on" : "turned off")}.");
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"turned on with brightness {Brightness}%" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }
    }
}

