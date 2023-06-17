using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1DriverApi.Models;
using Microsoft.AspNetCore.Cors;


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
    [EnableCors("Policy1")]
    public async Task<List<Driver>> Get(int pageNumber, int pageSize, string driverName, string driverNationality, string currentTeam, int driverAge, int raceWins, int podiums, int careerPoints, int wDCChampionships, string sortBy, bool isWDCChampion, int minPoints)
    {
      IQueryable<Driver> query = _db.Drivers.AsQueryable();

      if (pageNumber > 0)
      {
        query = query.Skip((pageNumber - 1) * pageSize);
      }

      if(pageSize > 0)
      {
        query = query.Take(pageSize);
      }

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
      query = query.OrderBy(entry => entry.DriverName);    
      }

      if (minPoints > 0)
      {
        query = query.Where(entry => entry.CareerPoints >= minPoints);
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
        query = query.Where(entry => entry.CurrentTeam.Contains(currentTeam)); //allows for search of partial matches
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

    // GET: api/Drivers/Statistics
    [HttpGet("statistics")]
    [EnableCors("Policy1")]
    public ActionResult<DriverStatistics> GetDriverStatistics()
    {
      int driverCount = _db.Drivers.Count();
      double averageAge = _db.Drivers.Average(entry => entry.DriverAge);
      int totalRaceWins = _db.Drivers.Sum(entry => entry.RaceWins);
      int totalPodiums = _db.Drivers.Sum(entry => entry.Podiums);
      int totalCareerPoints = _db.Drivers.Sum(entry => entry.CareerPoints);
      int totalWDCChampionships = _db.Drivers.Sum(entry => entry.WDCChampionships);

      DriverStatistics statistics = new DriverStatistics
      {
          DriverCount = driverCount,
          AverageAge = averageAge,
          TotalRaceWins = totalRaceWins,
          TotalPodiums = totalPodiums,
          TotalCareerPoints = totalCareerPoints,
          TotalWDCChampionships = totalWDCChampionships
      };

      return statistics;
    }

    // GET: api/Drivers/5
    [HttpGet("{id}")]
    [EnableCors("Policy1")]
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
    [EnableCors("Policy1")]
    public async Task<ActionResult<Driver>> GetRandomDriver()
    {
      List<Driver> drivers = await _db.Drivers.ToListAsync();
      int random = new Random().Next(drivers.Count);
      return drivers[random];
    }

    // POST: api/drivers
    [HttpPost]
    [EnableCors("Policy1")]
    public async Task<ActionResult<Driver>> Post(Driver driver)
    {
      _db.Drivers.Add(driver);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetDriver), new { id = driver.DriverId }, driver);
    }

    // PUT: api/Driver/5
    [HttpPut("{id}")]
    [EnableCors("Policy1")]
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
    [EnableCors("Policy1")]
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
