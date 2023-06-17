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
  } 
}
