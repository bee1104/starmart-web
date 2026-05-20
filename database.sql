USE StarMartDB;
GO

-- Tạo bảng (bỏ qua nếu đã tạo bằng lệnh trước)
CREATE TABLE SuKien (
  Id          INT IDENTITY(1,1) PRIMARY KEY,
  TieuDe      NVARCHAR(200) NOT NULL,
  MoTa        NVARCHAR(MAX),
  HinhAnh     NVARCHAR(500),
  NgayBatDau  DATETIME NOT NULL,
  NgayKetThuc DATETIME NOT NULL,
  LoaiTin     NVARCHAR(50) DEFAULT 'SuKien',
  TrangThai   BIT DEFAULT 1,
  NgayTao     DATETIME DEFAULT GETDATE()
);
GO

-- Dữ liệu mẫu tiếng Việt đầy đủ
INSERT INTO SuKien (TieuDe, MoTa, NgayBatDau, NgayKetThuc, LoaiTin)
VALUES
  (N'Lễ Hội Mua Sắm 30/04', N'Giảm giá đặc biệt tại nhiều gian hàng', '2025-04-30', '2025-05-01', N'SuKien'),
  (N'Summer Vibes Hè 2025',  N'Âm nhạc, ẩm thực, quà tặng hấp dẫn',   '2025-06-01', '2025-06-30', N'SuKien'),
  (N'Back to School',        N'Ưu đãi 50% học sinh sinh viên',          '2025-07-15', '2025-08-31', N'KhuyenMai'),
  (N'Ưu Đãi Cuối Tuần',     N'Sale up to 50% toàn bộ gian hàng',       '2025-05-01', '2025-12-31', N'KhuyenMai');
GO

-- Kiểm tra kết quả
SELECT * FROM SuKien;
GO