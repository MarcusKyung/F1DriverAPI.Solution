using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using F1DriverApi.Models;
using System.Linq;

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

    // GET: api/Drivers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Team>> GetTeam(int id)
    {
      Team team = await _db.Teams.FindAsync(id);

      if (team == null)
      {
        return NotFound();
      }

      return team;
    }
  } 
}
