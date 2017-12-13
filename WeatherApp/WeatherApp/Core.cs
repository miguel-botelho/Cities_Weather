using System;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WeatherApp
{
    public class Core
    {
        public static async Task<Weather> GetWeather(string country, DateTime d)
        {
            string key = "5071ff4d395a43f095c144741170612";
            int days;

            if (System.DateTime.Now.Month != d.Month)
            {
                days = 31 - Convert.ToInt32(d.Day) + Convert.ToInt32(System.DateTime.Now.Day);
            } else
            {
                days = Convert.ToInt32(System.DateTime.Now.Day) - Convert.ToInt32(d.Day);
            }
            
            String finalDay = d.Year + "-" + d.Month + "-" + d.Day;
            string queryString = "http://api.apixu.com/v1/history.json?key="
                + key + "&q=" + country + "&dt=" + finalDay;

            Debug.WriteLine(queryString);

            var results = await DataService.getDataFromService(queryString).ConfigureAwait(false);
            
            Debug.WriteLine(results);
            if (results["location"] != null)
            {
                Weather weather = new Weather();
                weather.Title = (string)results["location"]["country"];
                weather.Temperature = (string)results["forecast"]["forecastday"][0]["day"]["avgtemp_c"] + " ºC";
                weather.MinimumTemperature = (string)results["forecast"]["forecastday"][0]["day"]["maxtemp_c"] + " ºC";
                weather.MaximumTemperature = (string)results["forecast"]["forecastday"][0]["day"]["mintemp_c"] + " ºC";
                weather.Wind = (string)results["forecast"]["forecastday"][0]["day"]["maxwind_kph"] + " kph";
                weather.Humidity = (string)results["forecast"]["forecastday"][0]["day"]["avghumidity"] + " %";
                weather.Visibility = (string)results["forecast"]["forecastday"][0]["day"]["avgvis_km"] + " km";
                weather.Precipitation = (string)results["forecast"]["forecastday"][0]["day"]["totalprecip_mm"] + " mm";
                weather.LastUpdated = (string)results["forecast"]["forecastday"][0]["date"];
                weather.Sunset = (string)results["forecast"]["forecastday"][0]["astro"]["sunset"];
                weather.Sunrise = (string)results["forecast"]["forecastday"][0]["astro"]["sunrise"];

                foreach (var obj in results["forecast"]["forecastday"][0]["hour"])
                {
                    weather.Hours.Add((int)obj["temp_c"]);
                }

                return weather;
            }
            else
            {
                return null;
            }
        }
    }
}