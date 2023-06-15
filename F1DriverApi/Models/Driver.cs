using System.ComponentModel.DataAnnotations;

namespace F1DriverApi.Models
{
  public class Driver
  {
    public int DriverId { get; set; }
    [Required]
    public string DriverName { get; set; }
    [Required]
    public string DriverNationality { get; set; }
    [Required]
    public string CurrentTeam { get; set; }
    [Required]
    public int DriverAge { get; set; }
    [Required]
    public int RaceWins { get; set; }
    [Required]
    public int Podiums { get; set; }
    [Required]
    public int CareerPoints { get; set; }
    [Required]
    public int WDCChampionships { get; set; }
  }
}
