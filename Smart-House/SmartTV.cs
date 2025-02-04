using System;

namespace SmartHouseApp
{
    public class SmartTV : SmartDevice
    {
        public int Volume { get; set; }

        public SmartTV(string name, int volume = 20) : base(name)
        {
            Volume = volume;
        }

        public override void ShowStatus()
        {
            string state = IsOn ? "turned on" : "turned off";
            Console.WriteLine($"{Name} is {state} with sound on {Volume}.");
        }
    }
}

