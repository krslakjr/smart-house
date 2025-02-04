using System;

namespace SmartHouseApp
{
    public interface IControllable
    {
        void TurnOn();
        void TurnOff();
        void ShowStatus();
    }
}

