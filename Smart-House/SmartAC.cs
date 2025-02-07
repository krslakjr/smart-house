using System;

namespace SmartHouseApp
{
    public class SmartAC : SmartDevice
    {
        public int Temperature { get; private set; }

        public SmartAC(string name, int initialTemperature = 22) : base(name)
        {
            Temperature = initialTemperature;
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
        public void SetTemperature(int temperature)
        {
            Temperature = temperature;
            Console.WriteLine($"{Name} temperature is now {temperature}°C.");
        }

        public override void Toggle()
        {
            IsOn = !IsOn;
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

    }
}

