using System;
namespace T806443.Models
{
    public class LandAreaItem
    {
        public string CountryName { get; }
        public double Area { get; }

        public LandAreaItem(string countryName, double area)
        {
            this.CountryName = countryName;
            this.Area = area;
        }
    }
}
