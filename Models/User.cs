namespace LvlUpApi.Models;

public class User
{
  public long Id { get; set; }
  public string? Name { get; set; }
  public int Xp { get; set; }
  public int XpToLevelUp { get; set; }

  public User()
  {
    Xp = 0;
    XpToLevelUp = 100;
  }
}