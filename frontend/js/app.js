// ===== CẤU HÌNH =====
const API_URL = 'https://api.starmartmall.vn/api';  // Sau khi deploy
// const API_URL = 'http://localhost:5000/api';      // Khi test local

// ===== BRAND SLIDER =====
let sliderPos = 0;
function slideBrands(dir) {
  const track = document.getElementById('brandTrack');
  const items = track.querySelectorAll('.brand-item');
  sliderPos = Math.max(0, Math.min(sliderPos + dir, items.length - 5));
  track.style.transform = `translateX(-${sliderPos * 136}px)`;
  track.style.transition = 'transform 0.3s ease';
}

// ===== TẢI SỰ KIỆN NỔI BẬT =====
async function loadFeaturedEvents() {
  try {
    const res = await fetch(`${API_URL}/SuKien?limit=3`);
    if (!res.ok) return; // Nếu API chưa có, dùng dữ liệu tĩnh
    const events = await res.json();
    const container = document.getElementById('eventList');
    if (!container) return;
    container.innerHTML = events.map(ev => `
      <div class='event-card'>
        <div class='event-date'>
          ${new Date(ev.ngayBatDau).getDate()}/${new Date(ev.ngayBatDau).getMonth()+1}
        </div>
        <div class='event-info'>
          <h4>${ev.tieuDe}</h4>
          <p>${ev.moTa || ''}</p>
          <p>${formatDate(ev.ngayBatDau)} – ${formatDate(ev.ngayKetThuc)}</p>
        </div>
      </div>`).join('');
  } catch(e) {
    console.log('API chưa sẵn sàng, dùng dữ liệu tĩnh');
  }
}

// ===== HELPER: FORMAT NGÀY =====
function formatDate(dateStr) {
  return new Date(dateStr).toLocaleDateString('vi-VN', {
    day:'2-digit', month:'2-digit', year:'numeric'
  });
}
// ===== KHỞI ĐỘNG KHI TRANG LOAD =====
document.addEventListener('DOMContentLoaded', () => {
  loadFeaturedEvents();
});