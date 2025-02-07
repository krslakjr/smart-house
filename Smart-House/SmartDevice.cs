using System;
using System.Collections.Generic;

namespace SmartHouseApp
{
    public abstract class SmartDevice : IControllable
    {
        public string Name { get; set; }
        public bool IsOn { get; protected set; }

        public SmartDevice(string name)
        {
            Name = name;
            IsOn = false;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{Name} is turned on.");
        }

        public void TurnOff()
        {
            IsOn = false;
            Console.WriteLine($"{Name} is turned off.");
        }

        public abstract void Toggle();
        public abstract void SetSetting(string setting, int value);

        public abstract string GetStatus();
        public abstract void ShowStatus();
    }
}
