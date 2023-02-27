using Microsoft.EntityFrameworkCore;

namespace LvlUpApi.Models;

public class HasDoneContext : DbContext
{
  public HasDoneContext(DbContextOptions<HasDoneContext> options)
      : base(options)
  {
  }

  public DbSet<HasDone> HasDones { get; set; } = null!;
}