namespace LvlUpApi.Models;

public class User
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public int Xp { get; set; }
  public int XpToLevelUp { get; set; }
  // Relationships One -> Has Many
  public List<Habit> Habits { get; set; }
  public List<HasDone> HasDones { get; set; }

  public User()
  {
    Xp = 0;
    XpToLevelUp = 100;
    Habits = new List<Habit> { };
    HasDones = new List<HasDone> { };
  }
}