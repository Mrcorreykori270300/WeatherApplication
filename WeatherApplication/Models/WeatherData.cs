namespace WeatherApplication.Models
{
    public class WeatherData
    {
        public string name { get; set; }
        public Main main { get; set; }
        public Weather[] weather { get; set; }

        public Wind wind { get; set; }
        public Sys sys { get; set; }


    }
}
