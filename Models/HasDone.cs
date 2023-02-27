namespace LvlUpApi.Models;

public class HasDone
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public DateOnly Date { get; set; }
  public int Xp { get; set; }

  public HasDone()
  {
    Xp = 100;
  }
}