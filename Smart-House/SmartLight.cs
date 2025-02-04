using System;

namespace SmartHouseApp
{
    public class SmartLight : SmartDevice
    {
        public int Brightness { get; set; }

        public SmartLight(string name, int brightness = 50) : base(name)
        {
            Brightness = brightness;
        }

        public override void ShowStatus()
        {
            string state = IsOn ? "turned on" : "turned off";
            Console.WriteLine($"{Name} is {state} with strength {Brightness}%.");
        }
    }
}
