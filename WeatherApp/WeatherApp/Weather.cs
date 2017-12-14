using System;
using System.Collections.Generic;

namespace WeatherApp
{
    public class Weather
    {
        public string Title { get; set; }
        public string Temperature { get; set; }
        public string MinimumTemperature { get; set; }
        public string MaximumTemperature { get; set; }
        public string Wind { get; set; }
        public string Humidity { get; set; }
        public string Visibility { get; set; }
        public string Precipitation { get; set; }
        public string LastUpdated { get; set; }
        public string Sunset { get; set; }
        public string Sunrise { get; set; }
        public IList<int> Hours { get; set; } 

        public Weather()
        {
            //Because labels bind to these values, set them to an empty string to
            //ensure that the label appears on all platforms by default.
            this.Title = " ";
            this.Temperature = " ";
            this.MinimumTemperature = " ";
            this.MaximumTemperature = " ";
            this.Wind = " ";
            this.Humidity = " ";
            this.Visibility = " ";
            this.Precipitation = " ";
            this.LastUpdated = " ";
            this.Hours = new List<int>();
        }
    }
}