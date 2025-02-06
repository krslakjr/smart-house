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
            SmartAC ac = new SmartAC("LG AC", 16);

            myHouse.AddDevice(light);
            myHouse.AddDevice(tv);
            myHouse.AddDevice(ac);

            bool running = true;
            SmartDevice selectedDevice = null; 

            while (running)
            {
                Console.Clear();
                Console.WriteLine("=== Smart House ===");
                Console.WriteLine("Select a device to control:");

                
                Console.WriteLine("1 - Living Room - Lamp (Smart Light)");
                Console.WriteLine("2 - Samsung TV (Smart TV)");
                Console.WriteLine("3 - LG AC (Smart AC)");
                Console.WriteLine("0 - Exit");

                
                if (int.TryParse(Console.ReadLine(), out int deviceChoice))
                {
                    switch (deviceChoice)
                    {
                        case 1:
                            selectedDevice = light;
                            break;
                        case 2:
                            selectedDevice = tv;
                            break;
                        case 3:
                            selectedDevice = ac;
                            break;
                        case 0:
                            running = false;
                            continue;
                        default:
                            Console.WriteLine("Invalid choice, please try again.");
                            continue;
                    }

                    
                    while (selectedDevice != null)
                    {
                        Console.Clear();
                        Console.WriteLine($"=== {selectedDevice.Name} Control ===");
                        Console.WriteLine("1 - Turn On");
                        Console.WriteLine("2 - Turn Off");

                        if (selectedDevice is SmartLight)
                        {
                            Console.WriteLine("3 - Adjust Brightness (0-100%)");
                        }
                        else if (selectedDevice is SmartTV)
                        {
                            Console.WriteLine("3 - Adjust Volume (0-100%)");
                        }
                        else if (selectedDevice is SmartAC)
                        {
                            Console.WriteLine("3 - Adjust Temperature (16-30°C)");
                        }

                        Console.WriteLine("0 - Back to Main Menu");

                        if (int.TryParse(Console.ReadLine(), out int action))
                        {
                            if (action == 0) break;

                            switch (action)
                            {
                                case 1:
                                    selectedDevice.TurnOn();
                                    break;
                                case 2:
                                    selectedDevice.TurnOff();
                                    break;
                                case 3:
                                    Console.Write("Enter value: ");
                                    if (int.TryParse(Console.ReadLine(), out int value))
                                    {
                                        if (selectedDevice is SmartLight lightDevice)
                                        {
                                            lightDevice.SetSetting("brightness", value); 
                                        }
                                        else if (selectedDevice is SmartTV tvDevice)
                                        {
                                            tvDevice.SetSetting("volume", value); 
                                        }
                                        else if (selectedDevice is SmartAC acDevice)
                                        {
                                            acDevice.SetSetting("temperature", value);  
                                        }
                                    }
                                    break;
                            }
                        }
                    }
                }
            }
        }
    }
}
