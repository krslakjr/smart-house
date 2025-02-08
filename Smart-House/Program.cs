using System;
using System.Collections.Generic;

namespace SmartHouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartHouse myHouse = new SmartHouse();

            SmartLight light = new SmartLight("Living Room - Lamp", 0);
            SmartTV tv = new SmartTV("Samsung TV", 0);
            SmartAC ac = new SmartAC("LG Klima", 16);

            myHouse.AddDevice(light);
            myHouse.AddDevice(tv);
            myHouse.AddDevice(ac);

            bool running = true;

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Smart House Control ===");
                Console.WriteLine("1 - Select a device");
                Console.WriteLine("2 - Show status of all devices");
                Console.WriteLine("0 - Exit");
                Console.Write("\nChoose an option: ");

                if (int.TryParse(Console.ReadLine(), out int mainChoice))
                {
                    switch (mainChoice)
                    {
                        case 0:
                            running = false;
                            break;

                        case 1:
                            Console.Clear();
                            Console.WriteLine("=== Select a Device ===");
                            myHouse.ShowAllDevices();
                            Console.Write("\nSelect a device by number (0 to go back): ");

                            if (int.TryParse(Console.ReadLine(), out int choice) && choice > 0 && choice <= myHouse.Devices.Count)
                            {
                                IControllable selectedDevice = myHouse.Devices[choice - 1];
                                ControlDevice(selectedDevice);
                            }
                            break;

                        case 2:
                            Console.Clear();
                            Console.WriteLine("=== Status of All Devices ===");
                            myHouse.ShowAllDevices();
                            Console.WriteLine("\nPress any key to go back...");
                            Console.ReadKey();
                            break;
                    }
                }
            }

            Console.WriteLine("Exiting...");
        }

        static void ControlDevice(IControllable device)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"=== {device.Name} Control ===");
                Console.WriteLine("1 - Turn On");
                Console.WriteLine("2 - Turn Off");
                Console.WriteLine("3 - Show Status");

                if (device is SmartLight)
                    Console.WriteLine("4 - Adjust Brightness (0-100%)");

                if (device is SmartTV)
                    Console.WriteLine("4 - Adjust Volume (0-100%)");

                if (device is SmartAC)
                    Console.WriteLine("4 - Adjust Temperature (16-30°C)");

                Console.WriteLine("0 - Back to Main Menu");
                Console.Write("\nChoose an option: ");

                if (int.TryParse(Console.ReadLine(), out int action))
                {
                    if (action == 0) break;

                    switch (action)
                    {
                        case 1:
                            device.TurnOn();
                            break;
                        case 2:
                            device.TurnOff();
                            break;
                        case 3:
                            Console.WriteLine("\n" + device.GetStatus());
                            Console.WriteLine("\nPress any key to continue...");
                            Console.ReadKey();
                            break;
                        case 4:
                            Console.Write("\nEnter value: ");
                            if (int.TryParse(Console.ReadLine(), out int value))
                            {
                                if (device is SmartLight lightDevice)
                                    lightDevice.SetBrightness(value);
                                else if (device is SmartTV tvDevice)
                                    tvDevice.SetVolume(value);
                                else if (device is SmartAC acDevice)
                                    acDevice.SetSetting("temperature", value);  
                            }
                            break;
                    }
                }
            }
        }
    }
}
