using System;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        public WeatherPage()
        {
            InitializeComponent();
            this.Title = "WeatherCities";
            getWeatherBtn.Clicked += GetWeatherBtn_Clicked;
            dateXML.MaximumDate = DateTime.Now;
            dateXML.MinimumDate = DateTime.Now.AddDays(-30);

            //Set the default binding to a default object for now
            this.BindingContext = new Weather();
        }

        private async void GetWeatherBtn_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(cityEntry.Text) && dateXML.Date.Day > 0)
            {
                Weather weather = await Core.GetWeather(cityEntry.Text, dateXML.Date);
                if (weather != null)
                {
                    this.BindingContext = weather;
                    getWeatherBtn.Text = "Search Again";
                }
                else
                {
                    this.BindingContext = weather;
                    getWeatherBtn.Text = "Error";
                }
            }
            else
            {
                getWeatherBtn.Text = "Fill in all fields";
            }
        }
    }
}