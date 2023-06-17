using System.ComponentModel.DataAnnotations;

namespace F1DriverApi.Models
{
  public class Team
  {
    public int TeamId { get; set; }
    [Required]
    public string TeamName { get; set; }
    [Required]
    public string TeamNationality { get; set; }
    [Required]
    public string TeamPrincipal { get; set; }
    [Required]
    public string TeamBase { get; set; }
    [Required]
    public int TeamChampionships { get; set; }
  }
}
