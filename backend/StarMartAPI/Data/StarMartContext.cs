using Microsoft.EntityFrameworkCore;
using StarMartAPI.Models;

namespace StarMartAPI.Data {
  public class StarMartContext : DbContext {
    public StarMartContext(DbContextOptions<StarMartContext> options)
      : base(options) { }

    public DbSet<SuKien> SuKien { get; set; }
  }
}