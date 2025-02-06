using System;
using System.Collections.Generic;

namespace SmartHouseApp
{
    public class SmartHouse
    {
        private List<IControllable> devices = new List<IControllable>();

        public List<IControllable> Devices => devices;

        public void AddDevice(IControllable device)
        {
            devices.Add(device);
            Console.WriteLine($"{device.Name} is added to Smart House.");
        }

        public void ShowAllDevices()
        {
            Console.WriteLine("\nStatus of all devices:");
            foreach (var device in devices)
            {
                device.ShowStatus();
            }
        }
    }
}
