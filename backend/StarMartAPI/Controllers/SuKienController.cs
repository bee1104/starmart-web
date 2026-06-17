using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StarMartAPI.Data;
using StarMartAPI.Models;

namespace StarMartAPI.Controllers {

  [Route("api/[controller]")]
  [ApiController]
  public class SuKienController : ControllerBase {

    private readonly StarMartContext _context;

    public SuKienController(StarMartContext context) {
      _context = context;
    }

    // GET: api/SuKien
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SuKien>>> GetAll(
      [FromQuery] string? loai,
      [FromQuery] int? limit) {
      var query = _context.SuKien.Where(s => s.TrangThai);
      if (!string.IsNullOrEmpty(loai))
        query = query.Where(s => s.LoaiTin == loai);
      if (limit.HasValue)
        query = query.Take(limit.Value);
      return await query.OrderByDescending(s => s.NgayTao).ToListAsync();
    }

    // GET: api/SuKien/5
    [HttpGet("{id}")]
    public async Task<ActionResult<SuKien>> GetOne(int id) {
      var sk = await _context.SuKien.FindAsync(id);
      return sk == null ? NotFound() : sk;
    }

    // POST: api/SuKien
    [HttpPost]
    public async Task<ActionResult<SuKien>> Create(SuKien suKien) {
      _context.SuKien.Add(suKien);
      await _context.SaveChangesAsync();
      return CreatedAtAction(nameof(GetOne), new { id = suKien.Id }, suKien);
    }

    // PUT: api/SuKien/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(int id, SuKien suKien) {
      if (id != suKien.Id) return BadRequest();

    var existing = await _context.SuKien.FindAsync(id);
    if (existing == null) return NotFound();

    // Cập nhật các field cho phép sửa
    existing.TieuDe      = suKien.TieuDe;
    existing.MoTa        = suKien.MoTa;
    existing.HinhAnh     = suKien.HinhAnh;
    existing.LoaiTin     = suKien.LoaiTin;
    existing.NgayBatDau  = suKien.NgayBatDau;
    existing.NgayKetThuc = suKien.NgayKetThuc;
    existing.TrangThai   = suKien.TrangThai;
    // ← KHÔNG có existing.NguoiDang = ... → giữ nguyên người tạo gốc

    await _context.SaveChangesAsync();
    return NoContent();
    }

    // DELETE: api/SuKien/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id) {
      var sk = await _context.SuKien.FindAsync(id);
      if (sk == null) return NotFound();
      _context.SuKien.Remove(sk);
      await _context.SaveChangesAsync();
      return NoContent();
    }
    // GET: api/SuKien/ping
    [HttpGet("ping")]
    public async Task<IActionResult> Test() {
      try {
        var count = await _context.SuKien.CountAsync();
        return Ok(new { status = "OK", count, message = "Connected!" });
        } catch (Exception ex) {
          return Ok(new { status = "ERROR", message = ex.Message, inner = ex.InnerException?.Message });
          }
    }
  }
}