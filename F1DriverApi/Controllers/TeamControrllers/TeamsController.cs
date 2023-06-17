using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1DriverApi.Models;
using Microsoft.AspNetCore.Cors;


namespace F1DriverApi.Controllers.v2
{
  [ApiController]
  [Route("api/v{version:apiVersion}/[controller]")]
  [ApiVersion("2.0")]
  public class TeamsController : ControllerBase
  {
    private readonly F1DriverApiContext _db;

    public TeamsController(F1DriverApiContext db)
    {
      _db = db;
    }

    // GET api/teams
    [HttpGet]
    [EnableCors("Policy1")]
    public async Task<List<Team>> Get(int pageNumber, int pageSize, string teamName, string teamNationality, string teamPrincipal, string teamBase, int teamChampionships, string sortBy)
    {
      IQueryable<Team> query = _db.Teams.AsQueryable();

      if (pageNumber > 0)
      {
        query = query.Skip((pageNumber - 1) * pageSize);
      }

      if(pageSize > 0)
      {
        query = query.Take(pageSize);
      }

      if (sortBy == "TeamChampionships" || sortBy == "teamChampionships")
      {
        query = query.OrderByDescending(entry => entry.TeamChampionships);
      } 
      else if (sortBy == "TeamName" || sortBy == "teamName" || sortBy == "name" || sortBy == "Name")
      {
        query = query.OrderBy(entry => entry.TeamName);
      }

      if (teamName != null)
      {
        query = query.Where(entry => entry.TeamName == teamName);
      }

      if (teamNationality != null)
      {
        query = query.Where(entry => entry.TeamNationality == teamNationality);
      }

      if (teamPrincipal != null)
      {
        query = query.Where(entry => entry.TeamPrincipal.Contains(teamPrincipal)); //allows for query of partial matches
      }

      if (teamBase != null)
      {
        query = query.Where(entry => entry.TeamBase.Contains(teamBase)); //allows for query of partial matches
      }

      if (teamChampionships > 0)
      {
        query = query.Where(entry => entry.TeamChampionships == teamChampionships);
      }

      return await query.ToListAsync();
    }

    // POST: api/teams
    [HttpPost]
    [EnableCors("Policy1")]
    public async Task<ActionResult<Team>> Post(Team team)
    {
      _db.Teams.Add(team);
      await _db.SaveChangesAsync();
      return CreatedAtAction(nameof(GetTeam), new { id = team.TeamId }, team);
    }

    // GET: api/teams/5
    [HttpGet("{id}")]
    [EnableCors("Policy1")]
    public async Task<ActionResult<Team>> GetTeam(int id)
    {
      Team team = await _db.Teams.FindAsync(id);

      if (team == null)
      {
        return NotFound();
      }

      return team;
    }

    [HttpGet("random")]
    [EnableCors("Policy1")]
    public async Task<ActionResult<Team>> GetRandomTeam()
    {
      List<Team> teams = await _db.Teams.ToListAsync();
      int random = new Random().Next(teams.Count);
      return teams[random];
    }

    // PUT: api/Teams/5
    [HttpPut("{id}")]
    [EnableCors("Policy1")]
    public async Task<IActionResult> Put(int id, Team team)
    {
      if (id != team.TeamId)
      {
        return BadRequest();
      }

      _db.Teams.Update(team);

      try
      {
        await _db.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!TeamExists(id))
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

    private bool TeamExists(int id)
    {
      return _db.Teams.Any(e => e.TeamId == id);
    }

    // DELETE: api/Teams/5
    [HttpDelete("{id}")]
    [EnableCors("Policy1")]
    public async Task<IActionResult>DeleteTeam(int id)
    {
      Team team = await _db.Teams.FindAsync(id);
      if (team == null)
      {
        return NotFound();
      }
      _db.Teams.Remove(team);
      await _db.SaveChangesAsync();

      return NoContent();
    }
  } 
}
