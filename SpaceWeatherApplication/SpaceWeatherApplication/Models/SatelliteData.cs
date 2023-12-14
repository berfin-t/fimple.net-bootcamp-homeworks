using SpaceWeatherApplication.Entity;
using System.ComponentModel.DataAnnotations;

namespace SpaceWeatherApplication.Data
{
    public class SatelliteData 
    {
        [Key]
        public int Id { get; set; }
        public string SatelliteName { get; set; }
        public int PlanetDataId { get; set; }
        public List<TemperatureData> TemperatureData { get; set; } 


    }
}
