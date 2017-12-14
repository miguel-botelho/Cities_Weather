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

            var pathStroke2 = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Red,
                StrokeWidth = 2,
                TextSize = 20
            };

            var pathStroke1 = new SKPaint
            {
                IsAntialias = true,
                Style = SKPaintStyle.Stroke,
                Color = SKColors.BlueViolet,
                StrokeWidth = 5
            };
            var path = new SKPath();
            int i = 80;
            int k = 7;
            for (int j = 0; j < 18; j++)
            {
                path.MoveTo(80, 450 - k * 15);
                path.LineTo(80, 450 - (k + 1) * 15);
                k++;
                canvas.DrawPath(path, pathStroke);
            }
            path = new SKPath();
            for (int j = 0; j < 24; j++)
            {
                path.MoveTo(i, 345);
                path.LineTo(i + 30, 345);
                i = i + 30;
                canvas.DrawPath(path, pathStroke);
            }

            SKPoint[] temp = new SKPoint[] { new SKPoint(40, 345), new SKPoint(50, 345)};
            canvas.DrawPositionedText("07", temp, pathStroke2);
            temp = new SKPoint[] { new SKPoint(40, 210), new SKPoint(50, 210) };
            canvas.DrawPositionedText("16", temp, pathStroke2);
            temp = new SKPoint[] { new SKPoint(40, 75), new SKPoint(50, 75) };
            canvas.DrawPositionedText("25", temp, pathStroke2);

            path = new SKPath();
            i = 80;
            if (w.Hours.Count != 0)
            {
                for (int j = 0; j < w.Hours.Count - 1; j++)
                {
                    path.MoveTo(i, 450 - w.Hours[j] * 15);
                    i = i + 30;
                    path.LineTo(i, 450 - w.Hours[j + 1] * 15);
                }
                // draw the path
                canvas.DrawPath(path, pathStroke1);
            }
        }  
    }
}