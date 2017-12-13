using SkiaSharp;
using SkiaSharp.Views.Forms;
using System;
using System.Diagnostics;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class WeatherPage : ContentPage
    {
        Weather w = new Weather();
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
                    w = weather;
                    canvas.InvalidateSurface();
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
        
        void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKCanvas canvas = args.Surface.Canvas;
            canvas.Clear(Color.Black.ToSKColor());  //paint it black

            var pathStroke = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 5
            };
            var path = new SKPath();
            int i = 140;
            if (w.Hours.Count != 0)
            {
                canvas.Clear(Color.Green.ToSKColor());
                for (int j = 0; j < w.Hours.Count - 1; j++)
                {
                    path.MoveTo(i, w.Hours[j] * 15);
                    path.LineTo(i, w.Hours[j + 1] * 15);
                    canvas.DrawPath(path, pathStroke);
                }
            }else
            {
                for (int j = 0; j < w.Hours.Count - 1; j++)
                {
                    path.MoveTo(i, w.Hours[j] * 15);
                    i = i + 30;
                    path.LineTo(i, w.Hours[j + 1] * 15);
                }

                // draw the path
                canvas.DrawPath(path, pathStroke);
            }
        }  
    }
}