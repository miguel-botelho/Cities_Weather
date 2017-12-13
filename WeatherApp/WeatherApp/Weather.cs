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
            this.Hours.Add(0);
            this.Hours.Add(1);
            this.Hours.Add(2);
            this.Hours.Add(3);
            this.Hours.Add(4);
            this.Hours.Add(5);
            this.Hours.Add(6);
            this.Hours.Add(7);
            this.Hours.Add(8);
            this.Hours.Add(9);
            this.Hours.Add(10);
            this.Hours.Add(11);
            this.Hours.Add(12);
            this.Hours.Add(13);
            this.Hours.Add(14);
            this.Hours.Add(15);
            this.Hours.Add(16);
            this.Hours.Add(17);
            this.Hours.Add(18);
            this.Hours.Add(19);
            this.Hours.Add(20);
            this.Hours.Add(21);
            this.Hours.Add(22);
        }
    }
}