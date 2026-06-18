using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace StarMartAPI.Models {
  [Table("SuKien")]
  public class SuKien {
    [Column("Id")]
    public int Id { get; set; }

    [Required]
    [Column("TieuDe")]
    public string TieuDe { get; set; } = string.Empty;

    [Column("MoTa")]
    public string? MoTa { get; set; }

    [Column("HinhAnh")]
    public string? HinhAnh { get; set; }

    [Column("NgayBatDau")]
    public DateTime NgayBatDau { get; set; }

    [Column("NgayKetThuc")]
    public DateTime NgayKetThuc { get; set; }

    [Column("LoaiTin")]
    public string? LoaiTin { get; set; }

    [Column("TrangThai")]
    public bool TrangThai { get; set; } = true;

    [Column("NgayTao")]
    public DateTime NgayTao { get; set; } = DateTime.UtcNow;

    [Column("NguoiDang")]
    public string? NguoiDang { get; set; }
  }
}