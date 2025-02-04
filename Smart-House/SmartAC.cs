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

        public void SetTemperature(int temp)
        {
            if (temp < 16 || temp > 30)
            {
                Console.WriteLine("Invalid temperature! Set between 16 and 30°C.");
            }
            else
            {
                Temperature = temp;
                Console.WriteLine($"{Name} is set on {Temperature}°C.");
            }
        }

        public override void ShowStatus()
        {
            string state = IsOn ? $"turned on {Temperature}°C" : "turned off";
            Console.WriteLine($"{Name} is {state}.");
        }
    }
}