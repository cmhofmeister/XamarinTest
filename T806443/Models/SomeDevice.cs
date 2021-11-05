using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using Xamarin.Essentials;

namespace T806443.Models
{
    public class SomeDevice
    {
        public double Temperature { get; set; }

        public BindingList<SensorValue> SensorData { get; set; }

        public BindingList<LandAreaItem> LandAreas { get; set; }

        private Random random = new Random();

        public SomeDevice()
        {
            SensorData = new BindingList<SensorValue>()
            {
                new SensorValue(DateTime.Now, random.Next(-10, 10))
            };

            Temperature = SensorData[0].Value;

            LandAreas = new BindingList<LandAreaItem>()
            {
                new LandAreaItem("Russia", 17.098),
                new LandAreaItem("Canada", 9.985),
                new LandAreaItem("People's Republic of China", 9.597),
                new LandAreaItem("United States of America", 9.834),
                new LandAreaItem("Brazil", 8.516),
                new LandAreaItem("Australia", 7.692),
                new LandAreaItem("India", 3.287),
                new LandAreaItem("Others", 81.2)
            };
        }

       
    }
}
