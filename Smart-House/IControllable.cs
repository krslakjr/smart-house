using System;

namespace SmartHouseApp
{
    public interface IControllable
    {
        string Name { get; }
        void TurnOn();
        void TurnOff();
        void Toggle();
        void ShowStatus();
        void SetSetting(string setting, int value);
        string GetStatus();
    }
}

