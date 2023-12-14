using SpaceWeatherApplication.Entity;
using System.ComponentModel.DataAnnotations;

namespace SpaceWeatherApplication.Data
{
    public class TemperatureData 
    {
        [Key]
        public int Id { get; set; }
        public float DailyTemperature { get; set; }
        public float WeeklyTemperature { get; set; }
        public float MonthlyTemperature { get; set; }
        public int SatelliteDataId { get; set; }
    }
}
