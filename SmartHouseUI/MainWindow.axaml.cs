using Avalonia.Controls;
using Avalonia.Interactivity;
using SmartHouseApp;
using System;

namespace SmartHouseUI
{
    public partial class MainWindow : Window
    {
        public SmartAC SmartACDevice { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SmartACDevice = new SmartAC("AC", 22);
            this.DataContext = SmartACDevice; 
            SmartACDevice.PropertyChanged += (sender, e) =>
            {
                if (e.PropertyName == nameof(SmartAC.Temperature))
                {
                    UpdateStatus();
                }
            };

            UpdateStatus();
        }

        private void UpdateStatus()
        {
            StatusText.Text = SmartACDevice.GetStatus(); 
        }

        private void ToggleACButton_Click(object sender, RoutedEventArgs e)
        {
            SmartACDevice.Toggle();
            UpdateStatus();
        }

        private void TemperatureSlider_ValueChanged(object sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            var newTemperature = (int)e.NewValue;
            SmartACDevice.SetSetting("temperature", newTemperature);
            UpdateStatus();
        }
    }
}
