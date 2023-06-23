using Microsoft.EntityFrameworkCore;

namespace F1DriverApi.Models
{
  public class F1DriverApiContext : DbContext
  {
    public DbSet<Driver> Drivers { get; set; }
    public DbSet<Team> Teams { get; set; }

    public F1DriverApiContext(DbContextOptions<F1DriverApiContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
      builder.Entity<Driver>()
        .HasData(
        new Driver { DriverId = 1, DriverName = "Max Verstappen", DriverNationality = "Dutch", CurrentTeam = "Red Bull Racing", DriverAge = 25, RaceWins = 41, Podiums = 85, CareerPoints = 2206, WDCChampionships = 2 },
        new Driver { DriverId = 2, DriverName = "Sergio Perez", DriverNationality = "Mexican", CurrentTeam = "Red Bull Racing", DriverAge = 33, RaceWins = 6, Podiums = 30, CareerPoints = 1327, WDCChampionships = 0 },
        new Driver { DriverId = 3, DriverName = "Fernando Alonso", DriverNationality = "Spanish", CurrentTeam = "Aston Martin", DriverAge = 41, RaceWins = 32, Podiums = 104, CareerPoints = 2178, WDCChampionships = 2 },
        new Driver { DriverId = 4, DriverName = "Lewis Hamilton", DriverNationality = "British", CurrentTeam = "Mercedes-AMG Petronas F1 Team", DriverAge = 38, RaceWins = 103, Podiums = 194, CareerPoints = 4507, WDCChampionships = 7 },
        new Driver { DriverId = 5, DriverName = "George Russel", DriverNationality = "British", CurrentTeam = "Mercedes-AMG Petronas F1 Team", DriverAge = 25, RaceWins = 1, Podiums = 10, CareerPoints = 359, WDCChampionships = 0 },
        new Driver { DriverId = 6, DriverName = "Carlos Sainz Jr", DriverNationality = "Spanish", CurrentTeam = "Scuderia Ferrari", DriverAge = 28, RaceWins = 1, Podiums = 15, CareerPoints = 850, WDCChampionships = 0 },
        new Driver { DriverId = 7, DriverName = "Charles Leclerc", DriverNationality = "Monegasque", CurrentTeam = "Scuderia Ferrari", DriverAge = 25, RaceWins = 5, Podiums = 25, CareerPoints = 922, WDCChampionships = 0 },
        new Driver { DriverId = 8, DriverName = "Lance Stroll", DriverNationality = "Canadian", CurrentTeam = "Aston Martin", DriverAge = 24, RaceWins = 0, Podiums = 3, CareerPoints = 231, WDCChampionships = 0 },
        new Driver { DriverId = 9, DriverName = "Esteban Ocon", DriverNationality = "French", CurrentTeam = "Alpine", DriverAge = 26, RaceWins = 1, Podiums = 3, CareerPoints = 393, WDCChampionships = 0 },
        new Driver { DriverId = 10, DriverName = "Pierre Gasley", DriverNationality = "French", CurrentTeam = "Alpine", DriverAge = 27, RaceWins = 1, Podiums = 3, CareerPoints = 347, WDCChampionships = 0 },
        new Driver { DriverId = 11, DriverName = "Lando Norris", DriverNationality = "British", CurrentTeam = "McLaren F1 Team", DriverAge = 23, RaceWins = 0, Podiums = 6, CareerPoints = 440, WDCChampionships = 0 },
        new Driver { DriverId = 12, DriverName = "Niko Hulkenberg", DriverNationality = "German", CurrentTeam = "MoneyGram Haas F1 Team", DriverAge = 35, RaceWins = 0, Podiums = 0, CareerPoints = 527, WDCChampionships = 0 },
        new Driver { DriverId = 13, DriverName = "Oscar Piastri", DriverNationality = "Australian", CurrentTeam = "McLaren F1 Team", DriverAge = 22, RaceWins = 0, Podiums = 0, CareerPoints = 5, WDCChampionships = 0 },
        new Driver { DriverId = 14, DriverName = "Valtteri Bottas", DriverNationality = "Finnish", CurrentTeam = "Alfa Romeo F1 Team", DriverAge = 33, RaceWins = 10, Podiums = 67, CareerPoints = 1792, WDCChampionships = 0 },
        new Driver { DriverId = 15, DriverName = "Zho Guanyu", DriverNationality = "Chinese", CurrentTeam = "Alfa Romeo F1 Team", DriverAge = 24, RaceWins = 0, Podiums = 0, CareerPoints = 10, WDCChampionships = 0 },
        new Driver { DriverId = 16, DriverName = "Yuki Tsunoda", DriverNationality = "Japanese", CurrentTeam = "Scuderia AlphaTauri", DriverAge = 23, RaceWins = 0, Podiums = 0, CareerPoints = 46, WDCChampionships = 0 },
        new Driver { DriverId = 17, DriverName = "Kevin Magnussen", DriverNationality = "Danish", CurrentTeam = "MoneyGram Haas F1 Team", DriverAge = 30, RaceWins = 0, Podiums = 1, CareerPoints = 185, WDCChampionships = 0 },
        new Driver { DriverId = 18, DriverName = "Alex Albon", DriverNationality = "Thai", CurrentTeam = "Williams Racing", DriverAge = 27, RaceWins = 0, Podiums = 2, CareerPoints = 208, WDCChampionships = 0 },
        new Driver { DriverId = 19, DriverName = "Nyck de Vries", DriverNationality = "Dutch", CurrentTeam = "Scuderia AlphaTauri", DriverAge = 28, RaceWins = 0, Podiums = 0, CareerPoints = 2, WDCChampionships = 0 },
        new Driver { DriverId = 20, DriverName = "Logan Sargeant", DriverNationality = "American", CurrentTeam = "Williams Racing", DriverAge = 22, RaceWins = 0, Podiums = 0, CareerPoints = 0, WDCChampionships = 0 }
        );

      builder.Entity<Team>()
        .HasData(
        new Team { TeamId = 1, TeamName = "Red Bull Racing", TeamNationality = "Austrian", TeamPrincipal = "Christian Horner", TeamBase = "Milton Keynes, United Kingdom", TeamChampionships = 5 },
        new Team { TeamId = 2, TeamName = "Aston Martin", TeamNationality = "British", TeamPrincipal = "Mike Krack", TeamBase = "Silverstone, United Kingdom", TeamChampionships = 0 },
        new Team { TeamId = 3, TeamName = "Mercedes-AMG Petronas F1 Team", TeamNationality = "German", TeamPrincipal = "Toto Wolff", TeamBase = "Brackley, United Kingdom", TeamChampionships = 9 },
        new Team { TeamId = 4, TeamName = "Scuderia Ferrari", TeamNationality = "Italian", TeamPrincipal = "Frederic Vasseur", TeamBase = "Maranello, Italy", TeamChampionships = 16 },
        new Team { TeamId = 5, TeamName = "Alpine", TeamNationality = "French", TeamPrincipal = "Otmar Szafnauer", TeamBase = "Enstone, United Kingdom", TeamChampionships = 0 },
        new Team { TeamId = 6, TeamName = "McLaren F1 Team", TeamNationality = "British", TeamPrincipal = "Andrea Stella", TeamBase = "Woking, United Kingdom", TeamChampionships = 8 },
        new Team { TeamId = 7, TeamName = "MoneyGram Haas F1 Team", TeamNationality = "American", TeamPrincipal = "Guenther Steiner", TeamBase = "Kannapolis, United States", TeamChampionships = 0 },
        new Team { TeamId = 8, TeamName = "Alfa Romeo F1 Team", TeamNationality = "Swiss", TeamPrincipal = "Alessandro Alunni Bravi", TeamBase = "Hinwil, Switzerland", TeamChampionships = 0 },
        new Team { TeamId = 9, TeamName = "Scuderia AlphaTauri", TeamNationality = "Italian", TeamPrincipal = "Franz Tost", TeamBase = "Faenza, Italy", TeamChampionships = 0 },
        new Team { TeamId = 10, TeamName = "Williams Racing", TeamNationality = "British", TeamPrincipal = "James Vowles", TeamBase = "Grove, United Kingdom", TeamChampionships = 9 }
        );
    }
  }
}