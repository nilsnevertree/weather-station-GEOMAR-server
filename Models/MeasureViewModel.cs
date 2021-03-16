using System;
using System.Globalization;
using WeatherLogger.Data;

namespace WeatherLogger.Models
{
    public class MeasureViewModel
    {
        //public string MeasuredAt { get; set; }
        public string Temperature { get; set; }
        public string Humidity { get; set; }
        public string WindSpeed { get; set; }
        public string WindDirection { get; set; }

        public Measure ToMeasure()
        {
            var nfi = new NumberFormatInfo();
            nfi.NumberDecimalSeparator = ".";
            return new Measure
            {
                //Id = ,
                MeasuredAt = DateTime.Now,
                Temperature = Decimal.Parse(Temperature, nfi),
                Humidity = Decimal.Parse(Humidity, nfi),
                WindSpeed = Decimal.Parse(WindSpeed, nfi),
                WindDirection = Decimal.Parse(WindDirection, nfi)
            };
        }
    }
}