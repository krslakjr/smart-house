using System;
namespace SmartHouseApp
{
    public class SmartHouse
    {
        private List<SmartDevice> devices = new List<SmartDevice>();

        public void AddDevice(SmartDevice device)
        {
            devices.Add(device);
            Console.WriteLine($"{device.Name} is added in Smart House.");
        }

        public void ShowAllDevices()
        {
            Console.WriteLine("\n Status of all devices:");
            foreach (var device in devices)
            {
                device.ShowStatus();
            }
        }
    }
}
