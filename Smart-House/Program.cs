// See https://aka.ms/new-console-template for more information
using System;

namespace SmartHouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartHouse myHouse = new SmartHouse();

            IControllable light = new SmartLight("Living room - Lamp");
            IControllable tv = new SmartTV("Samsung TV", 30);
            IControllable ac = new SmartAC("LG Klima", 24);

            myHouse.AddDevice(ac);
            myHouse.AddDevice(light);
            myHouse.AddDevice(tv);

            light.TurnOn();
            tv.TurnOn();
            tv.Volume = 50;
            ac.TurnOn();
            ac.SetTemperature(26);

            myHouse.ShowAllDevices();
        }
    }
}

