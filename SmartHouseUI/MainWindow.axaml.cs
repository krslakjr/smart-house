using Avalonia.Controls;
using Avalonia.Interactivity;
using SmartHouseApp;
using System;

namespace SmartHouseUI
{
    public partial class MainWindow : Window
    {
        public SmartAC SmartACDevice { get; set; }
        public SmartTV SmartTVDevice { get; set; }
        public SmartLight SmartLightDevice { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SmartACDevice = new SmartAC("AC", 22);
            SmartTVDevice = new SmartTV("TV", 50);
            SmartLightDevice = new SmartLight("Lamp", 0);

            MainViewModel viewModel = new MainViewModel(SmartACDevice, SmartTVDevice, SmartLightDevice);
            DataContext = viewModel;

            SmartACDevice.PropertyChanged += (sender, e) => { if (e.PropertyName == nameof(SmartAC.Temperature)) UpdateStatus(); };
            SmartTVDevice.PropertyChanged += (sender, e) => { if (e.PropertyName == nameof(SmartTV.Volume)) UpdateStatus(); };
            SmartLightDevice.PropertyChanged += (sender, e) => { if (e.PropertyName == nameof(SmartLight.Brightness)) UpdateStatus(); };

            UpdateStatus();
        }



        private void UpdateStatus()
        {
            ACStatusText.Text = SmartACDevice.GetStatus();
            TVStatusText.Text = SmartTVDevice.GetStatus();
            LampStatusText.Text = SmartLightDevice.GetStatus();
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

        private void ToggleTVButton_Click(object sender, RoutedEventArgs e)
        {
            SmartTVDevice.Toggle();
            UpdateStatus();
        }

        private void VolumeSlider_ValueChanged(object sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            var newVolume = (int)e.NewValue;
            SmartTVDevice.SetSetting("volume", newVolume);
            UpdateStatus();
        }

        private void ToggleLightButton_Click(object sender, RoutedEventArgs e)
        {
            SmartLightDevice.Toggle();
            UpdateStatus();
        }

        private void BrightnessSlider_ValueChanged(object sender, Avalonia.Controls.Primitives.RangeBaseValueChangedEventArgs e)
        {
            var newBrightness = (int)e.NewValue;
            SmartLightDevice.SetSetting("brightness", newBrightness);
            UpdateStatus();
        }

        private void ToggleACModeButton_Click(object sender, RoutedEventArgs e)
        {
            SmartACDevice.ToggleMode();
            UpdateStatus();
        }

        private void ChangeChannelUpButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.ChangeChannelUp();
        }

        private void ChangeChannelDownButton_Click(object sender, RoutedEventArgs e)
        {
            (DataContext as MainViewModel)?.ChangeChannelDown(); 
        }

        private void ColorComboBox_SelectionChanged(object sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var selectedColor = (string)((ComboBox)sender).SelectedItem;
            SmartLightDevice.ChangeColor(selectedColor);
            UpdateStatus();
        }




    }
}
