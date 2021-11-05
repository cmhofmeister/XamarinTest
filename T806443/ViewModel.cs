using System;
using System.ComponentModel;
using T806443.Models;
using Xamarin.Essentials;

namespace T806443
{
    class ViewModel
    {
        public BindingList<SomeDevice> Devices { get; set; }

        private System.Timers.Timer SomeTimer;
        private const int SAMPLE_TIME_MS = 10000;

        public ViewModel()
        {
            SomeTimer = new System.Timers.Timer(SAMPLE_TIME_MS);
            SomeTimer.AutoReset = true;
            SomeTimer.Elapsed += TempPollTimer_Elapsed;
            SomeTimer.Start();

            Devices = new BindingList<SomeDevice>();
            Devices.Add(new SomeDevice());
        }

        private void TempPollTimer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                double randomTemp = new Random().Next(-30, 30);
                Devices[0].Temperature = randomTemp;
                Devices[0].LandAreas.Add(new LandAreaItem("Test", 123));
                Devices[0].SensorData.Add(new SensorValue(DateTime.Now, randomTemp));
            });
        }
    }
}
