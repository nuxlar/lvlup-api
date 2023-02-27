namespace LvlUpApi.Models;

public class Habit
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public int Xp { get; set; }
  public int Multiplier { get; set; }
  public DateOnly Date { get; set; }
  public Boolean Completed { get; set; }

  public Habit()
  {
    Xp = 100;
    Multiplier = 1;
    Completed = false;
  }
}