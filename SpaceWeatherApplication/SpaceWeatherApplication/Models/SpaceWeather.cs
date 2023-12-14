using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SpaceWeatherApplication.Entity;

namespace SpaceWeatherApplication.Data
{
    public class SpaceWeather 
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public List<PlanetData> PlanetData { get; set; } 

    }
}