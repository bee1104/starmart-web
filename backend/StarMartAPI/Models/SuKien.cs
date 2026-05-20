using System.ComponentModel.DataAnnotations;

namespace StarMartAPI.Models {
  public class SuKien {
    public int Id { get; set; }

    [Required]
    public string TieuDe { get; set; } = string.Empty;

    public string? MoTa { get; set; }
    public string? HinhAnh { get; set; }
    public DateTime NgayBatDau { get; set; }
    public DateTime NgayKetThuc { get; set; }
    public string? LoaiTin { get; set; }
    public bool TrangThai { get; set; } = true;
    public DateTime NgayTao { get; set; } = DateTime.Now;
  }
}