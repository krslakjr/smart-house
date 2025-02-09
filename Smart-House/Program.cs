using System;
using System.Collections.Generic;

namespace SmartHouseApp
{
    class Program
    {
        static void Main(string[] args)
        {
            SmartTV tv = new SmartTV("Living Room TV");
            SmartAC ac = new SmartAC("Bedroom AC");
            SmartLight light = new SmartLight("Living Room Light");

            List<SmartDevice> devices = new List<SmartDevice> { tv, ac, light };

            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welcome to Smart House App!");
                Console.WriteLine("Please select a device to control:");
                Console.WriteLine("1. Smart TV");
                Console.WriteLine("2. Smart AC");
                Console.WriteLine("3. Smart Light");
                Console.WriteLine("4. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ControlSmartTV(tv);
                        break;
                    case "2":
                        ControlSmartAC(ac);
                        break;
                    case "3":
                        ControlSmartLight(light);
                        break;
                    case "4":
                        Console.WriteLine("Exiting the app.");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void ControlSmartTV(SmartTV tv)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{tv.Name} is currently {tv.Status}");
                Console.WriteLine("1. Turn On/Off");
                Console.WriteLine("2. Set Volume");
                Console.WriteLine("3. Change Channel");
                Console.WriteLine("4. Back to Main Menu");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        tv.Toggle();
                        break;
                    case "2":
                        Console.Write("Enter volume (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int volume))
                        {
                            tv.SetVolume(volume);
                        }
                        else
                        {
                            Console.WriteLine("Invalid volume input.");
                        }
                        break;
                    case "3":
                        Console.Write("Enter channel (1-30): ");
                        if (int.TryParse(Console.ReadLine(), out int channel))
                        {
                            tv.CurrentChannel = channel;
                        }
                        else
                        {
                            Console.WriteLine("Invalid channel input.");
                        }
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void ControlSmartAC(SmartAC ac)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"Bedroom {ac.Status}");
                Console.WriteLine("1. Turn On/Off");
                Console.WriteLine("2. Set Temperature");
                Console.WriteLine("3. Toggle Mode (Heating/Cooling)");
                Console.WriteLine("4. Back to Main Menu");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        ac.Toggle();
                        break;
                    case "2":
                        Console.Write("Enter temperature: ");
                        if (int.TryParse(Console.ReadLine(), out int temperature))
                        {
                            ac.SetSetting("temperature", temperature);
                        }
                        else
                        {
                            Console.WriteLine("Invalid temperature input.");
                        }
                        break;
                    case "3":
                        ac.ToggleMode();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }

        static void ControlSmartLight(SmartLight light)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"{light.Status}");
                Console.WriteLine("1. Turn On/Off");
                Console.WriteLine("2. Set Brightness");
                Console.WriteLine("3. Change Color");
                Console.WriteLine("4. Back to Main Menu");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        light.Toggle();
                        break;
                    case "2":
                        Console.Write("Enter brightness (0-100): ");
                        if (int.TryParse(Console.ReadLine(), out int brightness))
                        {
                            light.SetBrightness(brightness);
                        }
                        else
                        {
                            Console.WriteLine("Invalid brightness input.");
                        }
                        break;
                    case "3":
                        Console.WriteLine("Available colors: Yellow, Green, Blue, Red, White");
                        Console.Write("Enter color: ");
                        string color = Console.ReadLine();
                        light.ChangeColor(color);
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid option. Try again.");
                        break;
                }
                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
    }
}
