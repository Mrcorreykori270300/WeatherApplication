﻿using System.ComponentModel.DataAnnotations;

namespace WeatherApplication.Models
{
    public class Wind
    {
        public double speed { get; set; }
        public double deg { get; set; }
        public double gust { get; set; }

    }
}
