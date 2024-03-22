﻿using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Models
{
    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }

        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public double pressure { get; set; }
        public double sea_level { get; set; }

        public double grnd_level { get; set; }

    }


}
