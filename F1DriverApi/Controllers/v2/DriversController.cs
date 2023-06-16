using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1DriverApi.Models;
using System.Linq;

namespace F1DriverApi.Controllers.v2
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("2.0")]
  public class DriversController : ControllerBase
  {
    private readonly F1DriverApiContext _db;

    public DriversController(F1DriverApiContext db)
    {
      _db = db;
    }

    // GET api/drivers
    [HttpGet]
    public async Task<List<Driver>> Get(string driverName, string driverNationality, string currentTeam, int driverAge, int raceWins, int podiums, int careerPoints, int wDCChampionships, string sortBy, bool isWDCChampion)
    {
      IQueryable<Driver> query = _db.Drivers.AsQueryable();

      if (sortBy == "Points" || sortBy == "points")
      {
        query = query.OrderByDescending(entry => entry.CareerPoints);
      } 
      else if (sortBy == "age" || sortBy == "Age")
      {
      query = query.OrderByDescending(entry => entry.DriverAge);    
      } 
      else if (sortBy == "podiums" || sortBy == "Podiums")
      {
      query = query.OrderByDescending(entry => entry.Podiums);    
      }
      else if (sortBy == "wins" || sortBy == "Wins")
      {
      query = query.OrderByDescending(entry => entry.RaceWins);    
      }
      else if (sortBy == "championships" || sortBy == "Championships")
      {
      query = query.OrderByDescending(entry => entry.WDCChampionships);    
      }
      else if (sortBy == "name" || sortBy == "Name")
      {
      query = query.OrderByDescending(entry => entry.DriverName);    
      }


      if (isWDCChampion == true)
      {
        query = query.Where(entry => entry.WDCChampionships > 0);
      }

      if (driverName != null)
      {
        query = query.Where(entry => entry.DriverName == driverName);
      }

      if (driverNationality != null)
      {
        query = query.Where(entry => entry.DriverNationality == driverNationality);
      }

      if (currentTeam != null)
      {
        query = query.Where(entry => entry.CurrentTeam == currentTeam);
      }

      if (driverAge > 0)
      {
        query = query.Where(entry => entry.DriverAge == driverAge);
      }

      if (raceWins > 0)
      {
        query = query.Where(entry => entry.RaceWins == raceWins);
      }

      if (podiums > 0)
      {
        query = query.Where(entry => entry.Podiums == podiums);
      }

      if (careerPoints > 0)
      {
        query = query.Where(entry => entry.CareerPoints == careerPoints);
      }

      if (wDCChampionships > 0)
      {
        query = query.Where(entry => entry.WDCChampionships == wDCChampionships);
      }

      return await query.ToListAsync();
    }

    // GET: api/Drivers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Driver>> GetDriver(int id)
    {
      Driver driver = await _db.Drivers.FindAsync(id);

      if (driver == null)
      {
        return NotFound();
      }

      return driver;
    }

    [HttpGet("random")]
    public async Task<ActionResult<Driver>> GetRandomDriver()
    {
      List<Driver> drivers = await _db.Drivers.ToListAsync();
      int random = new Random().Next(drivers.Count);
      return drivers[random];
    }

    // POST: api/drivers
    [HttpPost]
    public async Task<ActionResult<Driver>> Post(Driver driver)
    {
      _db.Drivers.Add(driver);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetDriver), new { id = driver.DriverId }, driver);
    }

    // PUT: api/Driver/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Driver driver)
    {
      if (id != driver.DriverId)
      {
        return BadRequest();
      }

      _db.Drivers.Update(driver);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!DriverExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

    private bool DriverExists(int id)
    {
      return _db.Drivers.Any(e => e.DriverId == id);
    }

    // DELETE: api/Drivers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult>DeleteDriver(int id)
    {
      Driver driver = await _db.Drivers.FindAsync(id);
      if (driver == null)
      {
        return NotFound();
      }
      _db.Drivers.Remove(driver);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  } 
}
