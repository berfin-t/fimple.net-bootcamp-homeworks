// Controllers/SpaceWeatherController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpaceWeatherApplication.Data;

[ApiController]
[Route("api/v1/space-weather")]
public class SpaceWeatherController : ControllerBase
{
    private readonly SpaceWeatherDbContext _spaceWeatherDbContext;

    public SpaceWeatherController(SpaceWeatherDbContext spaceWeatherDbContext)
    {
        _spaceWeatherDbContext = spaceWeatherDbContext;
    }

    [HttpPost]
    public async Task<IActionResult> Create(SpaceWeather spaceWeather)
    {
        _spaceWeatherDbContext.SpaceWeather.Add(spaceWeather);
        await _spaceWeatherDbContext.SaveChangesAsync();

        return CreatedAtAction(nameof(GetById), new { id = spaceWeather.Id }, spaceWeather);
    }

    [HttpGet("/planetData")]
    public async Task<IActionResult> GetAll()
    {
        var spaceWeatherData = await _spaceWeatherDbContext.SpaceWeather.ToListAsync();
        var planetData = await _spaceWeatherDbContext.PlanetData.ToListAsync();

        return Ok(planetData);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var spaceWeather = _spaceWeatherDbContext.SpaceWeather.FirstOrDefault(x => x.Id == id);

        if (spaceWeather == null)
        {
            return NotFound();
        }

        return Ok(spaceWeather);
    }

    [CustomAuthorize]
    [HttpGet("{id}/planetDataList")]
    public IActionResult GetByPlanetDataList(int id, [FromQuery] string? sortOrder = null)
    {
        var spaceWeather = _spaceWeatherDbContext.SpaceWeather.FirstOrDefault(x => x.Id == id);

        if (spaceWeather == null)
        {
            return NotFound();
        }

        switch (sortOrder)
        {
            case "desc":
                return Ok(spaceWeather.PlanetData.OrderByDescending(i => i.PlanetName));
            case "asc":
                return Ok(spaceWeather.PlanetData.OrderBy(i => i.PlanetName));
            default:
                // Add a default return statement
                return BadRequest("Invalid sortOrder value. Use 'asc' or 'desc'.");
        }
    }
}
