using Microsoft.EntityFrameworkCore;
using StarMartAPI.Models;

namespace StarMartAPI.Data {
  public class StarMartContext : DbContext {
    public StarMartContext(DbContextOptions<StarMartContext> options)
      : base(options) { }

    public DbSet<SuKien> SuKien { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder) {
      modelBuilder.Entity<SuKien>().ToTable("SuKien");
      modelBuilder.Entity<SuKien>().Property(e => e.Id).HasColumnName("Id");
      modelBuilder.Entity<SuKien>().Property(e => e.TieuDe).HasColumnName("TieuDe");
      modelBuilder.Entity<SuKien>().Property(e => e.MoTa).HasColumnName("MoTa");
      modelBuilder.Entity<SuKien>().Property(e => e.HinhAnh).HasColumnName("HinhAnh");
      modelBuilder.Entity<SuKien>().Property(e => e.NgayBatDau).HasColumnName("NgayBatDau");
      modelBuilder.Entity<SuKien>().Property(e => e.NgayKetThuc).HasColumnName("NgayKetThuc");
      modelBuilder.Entity<SuKien>().Property(e => e.LoaiTin).HasColumnName("LoaiTin");
      modelBuilder.Entity<SuKien>().Property(e => e.TrangThai).HasColumnName("TrangThai");
      modelBuilder.Entity<SuKien>().Property(e => e.NgayTao).HasColumnName("NgayTao");
    }
  }
}