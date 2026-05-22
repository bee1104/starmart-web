const API_URL = 'https://starmart-api.onrender.com/api';

// ===== TẢI SỰ KIỆN NỔI BẬT (trang chủ) =====
async function loadFeaturedEvents() {
  try {
    const res = await fetch(`${API_URL}/SuKien?limit=3&loai=SuKien`);
    if (!res.ok) return;
    const events = await res.json();
    const container = document.getElementById('eventList');
    if (!container) return;
    container.innerHTML = events.map(ev => `
      <div class="event-card">
        <div class="event-date">
          <span class="day">${new Date(ev.ngayBatDau).getDate()}</span>
          <span class="month">Th${new Date(ev.ngayBatDau).getMonth()+1}</span>
        </div>
        <div class="event-info">
          <span class="event-tag ${ev.loaiTin === 'KhuyenMai' ? 'tag-red' : 'tag-blue'}">${ev.loaiTin === 'KhuyenMai' ? 'Khuyến Mãi' : 'Sự Kiện'}</span>
          <h4>${ev.tieuDe}</h4>
          <p>${ev.moTa || ''}</p>
          <p class="date-range">
            ${formatDate(ev.ngayBatDau)} – ${formatDate(ev.ngayKetThuc)}
          </p>
        </div>
      </div>`).join('');
  } catch(e) {
    console.log('Lỗi tải sự kiện:', e);
  }
}

// ===== TẢI KHUYẾN MÃI NỔI BẬT (trang chủ) =====
async function loadFeaturedPromo() {
  try {
    const res = await fetch(`${API_URL}/SuKien?limit=4&loai=KhuyenMai`);
    if (!res.ok) return;
    const promos = await res.json();
    const container = document.getElementById('promoList');
    if (!container || promos.length === 0) return;
    const colors = ['red', 'purple', 'orange', 'dark'];
    container.innerHTML = promos.map((p, i) => `
      <div class="promo-card ${colors[i % 4]}">
        <div class="promo-label">${p.tieuDe}</div>
        <p>${p.moTa || ''}</p>
        <p class="promo-date">${formatDate(p.ngayBatDau)} – ${formatDate(p.ngayKetThuc)}</p>
        <a href="su-kien.html" class="btn-sm">XEM NGAY</a>
      </div>`).join('');
  } catch(e) {}
}

// ===== TẢI TẤT CẢ SỰ KIỆN (trang su-kien.html) =====
async function loadAllEvents(filter = 'all') {
  const container = document.getElementById('allEvents');
  if (!container) return;
  container.innerHTML = '<p style="text-align:center;padding:40px">Đang tải...</p>';
  try {
    const url = filter === 'all'
      ? `${API_URL}/SuKien`
      : `${API_URL}/SuKien?loai=${filter}`;
    const res = await fetch(url);
    const events = await res.json();
    if (events.length === 0) {
      container.innerHTML = '<p style="text-align:center;padding:40px">Chưa có tin nào.</p>';
      return;
    }
    container.innerHTML = events.map(ev => `
      <div class="event-full-card">
        ${ev.hinhAnh ? `<img src="${ev.hinhAnh}" alt="${ev.tieuDe}">` : ''}
        <div class="event-full-info">
          <span class="event-tag ${ev.loaiTin === 'KhuyenMai' ? 'tag-red' : 'tag-blue'}">
            ${ev.loaiTin === 'KhuyenMai' ? 'Khuyến Mãi' : 'Sự Kiện'}
          </span>
          <h3>${ev.tieuDe}</h3>
          <p>${ev.moTa || ''}</p>
          <p class="date-range">📅 ${formatDate(ev.ngayBatDau)} – ${formatDate(ev.ngayKetThuc)}</p>
        </div>
      </div>`).join('');
  } catch(e) {
    container.innerHTML = '<p style="color:red;text-align:center">Không thể tải dữ liệu.</p>';
  }
}

// ===== FILTER SỰ KIỆN =====
function filterEvents(type, btn) {
  document.querySelectorAll('.tab').forEach(t => t.classList.remove('active'));
  btn.classList.add('active');
  loadAllEvents(type);
}

// ===== BRAND SLIDER =====
let sliderPos = 0;
function slideBrands(dir) {
  const track = document.getElementById('brandTrack');
  if (!track) return;
  const items = track.querySelectorAll('.brand-item');
  const maxPos = Math.max(0, items.length - 6);
  sliderPos = Math.max(0, Math.min(sliderPos + dir, maxPos));
  track.style.transform = `translateX(-${sliderPos * 152}px)`;
  track.style.transition = 'transform 0.3s ease';
}

// ===== FORMAT NGÀY =====
function formatDate(dateStr) {
  return new Date(dateStr).toLocaleDateString('vi-VN', {
    day:'2-digit', month:'2-digit', year:'numeric'
  });
}

// ===== KHỞI ĐỘNG =====
document.addEventListener('DOMContentLoaded', () => {
  loadFeaturedEvents();
  loadFeaturedPromo();
  loadAllEvents();
});