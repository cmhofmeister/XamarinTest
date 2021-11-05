using System;

namespace T806443.Models
{
    public class SensorValue
    {
        public DateTime Timestamp { get; set; }
        public double Value { get; set; }

        public SensorValue(DateTime timestamp, double value)
        {
            Timestamp = timestamp;
            Value = value;
        }
    }
}
