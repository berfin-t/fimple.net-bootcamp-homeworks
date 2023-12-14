using SpaceWeatherApplication.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SpaceWeatherApplication.Data
{
    public class PlanetData 
    {
        [Key]
        public int Id { get; set; }
        public string PlanetName { get; set; }
        public int SpaceWeatherId { get; set; }
        public List<SatelliteData> SatelliteData { get; set; }
 }
}
