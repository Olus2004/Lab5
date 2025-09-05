using Lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Xml.Linq;

namespace Lab5
{
    class Program
    {
        enum MenuOption
        {
            ThemHocVien = 1,
            CapNhatHocVien,
            TimKiemHocVien_MaHocVien,
            XoaHocVien_TheoID,

            ThemGiaoVien,
            CapNhatGiaoVien,
            XoaGiaoVien_TheoID,
            TimKiemGiaoVien_MaGiaoVien,

            ThemLopHoc,
            CapNhatLopHoc,
            TimKiemLopHoc_MaLop,
            XoaLopHoc,

            ThemDangKy,
            CapNhatDangKy,
            TimKiemDangKy_TheoHocVien,
            XoaDangKy,

            HienThiTatCaHocVien,
            HienThiTatCaHocVienTheoID,
            Thoat
        }

        public void CreateDatabase()
        {
            var dbContext = new AppDbContext();
            {
                string dbname = dbContext.Database.GetDbConnection().Database;
                dbContext.Database.EnsureCreated();

                var logCreate = dbContext.Database.EnsureCreated();
                //Console.WriteLine(ketqua);
                if (logCreate)
                {
                    Console.WriteLine($"Tạo Database:{dbname} thành công");
                }
                else
                {

                    Console.WriteLine($"Tạo Database:{dbname} thất bại");
                }
            }
        }
        public void DropDatabase()
        {
            var dbContext = new AppDbContext();
            {
                string dbName = dbContext.Database.GetDbConnection().Database;
                dbContext.Database.EnsureCreated();

                var logDrop = dbContext.Database.EnsureDeleted();
                if (logDrop)
                {
                    Console.WriteLine($"Xóa Database:{dbName} thành công");
                }
                else
                {
                    Console.WriteLine($"Xóa Database:{dbName} thất bại");
                }
            }
        }
        public void InsertDatatable()
        {
            var dbContext = new AppDbContext();

            // 1. Dữ liệu KhoaHoc
            var khoaHocValue = new object[]
            {
                new KhoaHoc() { MaKhoaHoc = "KH001", NgayKhaiGiang = new DateTime(2025, 1, 15), TenKhoaHoc = "Khóa học Lập trình Web", TrangThai = 2, NgayTao = DateTime.Now },
                new KhoaHoc() { MaKhoaHoc = "KH002", NgayKhaiGiang = new DateTime(2025, 2, 1), TenKhoaHoc = "Khóa học Mobile App", TrangThai = 1, NgayTao = DateTime.Now },
                new KhoaHoc() { MaKhoaHoc = "KH003", NgayKhaiGiang = new DateTime(2025, 3, 10), TenKhoaHoc = "Khóa học AI & Machine Learning", TrangThai = 1, NgayTao = DateTime.Now },
                new KhoaHoc() { MaKhoaHoc = "KH004", NgayKhaiGiang = new DateTime(2025, 4, 5), TenKhoaHoc = "Khóa học DevOps", TrangThai = 1, NgayTao = DateTime.Now },
                new KhoaHoc() { MaKhoaHoc = "KH005", NgayKhaiGiang = new DateTime(2024, 12, 1), TenKhoaHoc = "Khóa học Database", TrangThai = 3, NgayTao = DateTime.Now }
            };

            // 2. Dữ liệu MonHoc
            var monHocValue = new object[]
            {
                new MonHoc() { MaMonHoc = "MH001", TenMonHoc = "HTML & CSS Cơ bản", CapDo = 1, SoTiet = 40, HocPhi = 2500000, MoTa = "Học HTML và CSS từ cơ bản đến nâng cao" },
                new MonHoc() { MaMonHoc = "MH002", TenMonHoc = "JavaScript Programming", CapDo = 2, SoTiet = 60, HocPhi = 3500000, MoTa = "Lập trình JavaScript và ES6+" },
                new MonHoc() { MaMonHoc = "MH003", TenMonHoc = "React Framework", CapDo = 3, SoTiet = 80, HocPhi = 4500000, MoTa = "Phát triển ứng dụng web với React" },
                new MonHoc() { MaMonHoc = "MH004", TenMonHoc = "Node.js Backend", CapDo = 3, SoTiet = 70, HocPhi = 4000000, MoTa = "Phát triển backend với Node.js" },
                new MonHoc() { MaMonHoc = "MH005", TenMonHoc = "Flutter Mobile", CapDo = 3, SoTiet = 90, HocPhi = 5000000, MoTa = "Phát triển ứng dụng mobile với Flutter" },
                new MonHoc() { MaMonHoc = "MH006", TenMonHoc = "Python Cơ bản", CapDo = 1, SoTiet = 50, HocPhi = 3000000, MoTa = "Lập trình Python từ cơ bản" },
                new MonHoc() { MaMonHoc = "MH007", TenMonHoc = "Machine Learning", CapDo = 3, SoTiet = 100, HocPhi = 6000000, MoTa = "Học máy và trí tuệ nhân tạo" },
                new MonHoc() { MaMonHoc = "MH008", TenMonHoc = "MySQL Database", CapDo = 2, SoTiet = 45, HocPhi = 2800000, MoTa = "Thiết kế và quản trị cơ sở dữ liệu MySQL" },
                new MonHoc() { MaMonHoc = "MH009", TenMonHoc = "Docker & Kubernetes", CapDo = 3, SoTiet = 60, HocPhi = 4200000, MoTa = "Container hóa và triển khai ứng dụng" },
                new MonHoc() { MaMonHoc = "MH010", TenMonHoc = "Git Version Control", CapDo = 1, SoTiet = 20, HocPhi = 1500000, MoTa = "Quản lý mã nguồn với Git" }
            };

            // 3. Dữ liệu GiaoVien
            var giaoVienValue = new object[]
            {
                new GiaoVien() { MaGiaoVien = "GV001", HoTen = "Nguyễn Văn Hùng", NgaySinh = new DateTime(1985, 5, 15), GioiTinh = 1, DiaChi = "123 Đường ABC, Hà Nội", NoiCongTac = "Công ty FPT Software", DienThoai = "0901234567", Email = "hung.nv@fpt.com", ChuyenMon = "Full-stack Web Development", KinhNghiem = 3 },
                new GiaoVien() { MaGiaoVien = "GV002", HoTen = "Trần Thị Mai", NgaySinh = new DateTime(1988, 8, 22), GioiTinh = 2, DiaChi = "456 Đường XYZ, TP.HCM", NoiCongTac = "Đại học Bách Khoa", DienThoai = "0912345678", Email = "mai.tt@hcmut.edu.vn", ChuyenMon = "Mobile App Development", KinhNghiem = 4 },
                new GiaoVien() { MaGiaoVien = "GV003", HoTen = "Lê Minh Tuấn", NgaySinh = new DateTime(1982, 12, 10), GioiTinh = 1, DiaChi = "789 Đường DEF, Đà Nẵng", NoiCongTac = "Viettel Group", DienThoai = "0923456789", Email = "tuan.lm@viettel.com.vn", ChuyenMon = "AI & Machine Learning", KinhNghiem = 4 },
                new GiaoVien() { MaGiaoVien = "GV004", HoTen = "Phạm Thị Lan", NgaySinh = new DateTime(1990, 3, 8), GioiTinh = 2, DiaChi = "321 Đường GHI, Hải Phòng", NoiCongTac = "TMA Solutions", DienThoai = "0934567890", Email = "lan.pt@tmasolutions.com", ChuyenMon = "DevOps & Cloud Computing", KinhNghiem = 2 },
                new GiaoVien() { MaGiaoVien = "GV005", HoTen = "Hoàng Văn Nam", NgaySinh = new DateTime(1987, 7, 18), GioiTinh = 1, DiaChi = "654 Đường JKL, Cần Thơ", NoiCongTac = "Freelancer", DienThoai = "0945678901", Email = "nam.hv@gmail.com", ChuyenMon = "Database Management", KinhNghiem = 3 }
            };

            // 4. Dữ liệu HocVien
            var hocVienValue = new object[]
            {
                new HocVien() { MaHocVien = "HV001", HoTen = "Nguyễn Minh Hoàng", NgaySinh = new DateTime(2000, 1, 15), GioiTinh = 1, QueQuan = "Hà Nội", DiaChi = "12 Ngõ 5, Cầu Giấy, Hà Nội", TrinhDo = "Đại học", DienThoai = "0981234567", Email = "hoang.nm@gmail.com", NgayDangKy = DateTime.Now.AddMonths(-2), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV002", HoTen = "Trần Thị Hương", NgaySinh = new DateTime(1999, 5, 20), GioiTinh = 2, QueQuan = "Hải Dương", DiaChi = "45 Đường Lê Lợi, Quận 1, TP.HCM", TrinhDo = "Cao đẳng", DienThoai = "0972345678", Email = "huong.tt@yahoo.com", NgayDangKy = DateTime.Now.AddMonths(-1), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV003", HoTen = "Lê Văn Đức", NgaySinh = new DateTime(2001, 9, 12), GioiTinh = 1, QueQuan = "Nam Định", DiaChi = "78 Phố Huế, Hai Bà Trưng, Hà Nội", TrinhDo = "Trung cấp", DienThoai = "0963456789", Email = "duc.lv@hotmail.com", NgayDangKy = DateTime.Now.AddDays(-15), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV004", HoTen = "Phạm Thị Thu", NgaySinh = new DateTime(1998, 11, 5), GioiTinh = 2, QueQuan = "Thanh Hóa", DiaChi = "90 Nguyễn Trãi, Thanh Xuân, Hà Nội", TrinhDo = "Đại học", DienThoai = "0954567890", Email = "thu.pt@gmail.com", NgayDangKy = DateTime.Now.AddDays(-30), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV005", HoTen = "Vũ Minh Tâm", NgaySinh = new DateTime(2002, 4, 8), GioiTinh = 1, QueQuan = "Hà Nội", DiaChi = "23 Tôn Đức Thắng, Đống Đa, Hà Nội", TrinhDo = "Trung học phổ thông", DienThoai = "0945678901", Email = "tam.vm@student.edu.vn", NgayDangKy = DateTime.Now.AddDays(-10), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV006", HoTen = "Đỗ Thị Mai", NgaySinh = new DateTime(1997, 6, 25), GioiTinh = 2, QueQuan = "Vĩnh Phúc", DiaChi = "156 Láng Hạ, Ba Đình, Hà Nội", TrinhDo = "Đại học", DienThoai = "0936789012", Email = "mai.dt@company.com", NgayDangKy = DateTime.Now.AddDays(-45), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV007", HoTen = "Bùi Văn Long", NgaySinh = new DateTime(2000, 12, 30), GioiTinh = 1, QueQuan = "Bắc Ninh", DiaChi = "67 Giải Phóng, Hai Bà Trưng, Hà Nội", TrinhDo = "Cao đẳng", DienThoai = "0927890123", Email = "long.bv@outlook.com", NgayDangKy = DateTime.Now.AddDays(-20), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV008", HoTen = "Ngô Thị Linh", NgaySinh = new DateTime(1999, 2, 14), GioiTinh = 2, QueQuan = "Hưng Yên", DiaChi = "234 Xã Đàn, Đống Đa, Hà Nội", TrinhDo = "Trung cấp", DienThoai = "0918901234", Email = "linh.nt@gmail.com", NgayDangKy = DateTime.Now.AddDays(-25), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV009", HoTen = "Trần Minh Quân", NgaySinh = new DateTime(2001, 8, 3), GioiTinh = 1, QueQuan = "Thái Bình", DiaChi = "89 Kim Mã, Ba Đình, Hà Nội", TrinhDo = "Đại học", DienThoai = "0909012345", Email = "quan.tm@student.hust.edu.vn", NgayDangKy = DateTime.Now.AddDays(-5), TrangThai = 1 },
                new HocVien() { MaHocVien = "HV010", HoTen = "Lý Thị Hoa", NgaySinh = new DateTime(1996, 10, 18), GioiTinh = 2, QueQuan = "Hà Nam", DiaChi = "345 Thái Thịnh, Đống Đa, Hà Nội", TrinhDo = "Đại học", DienThoai = "0990123456", Email = "hoa.lt@work.com", NgayDangKy = DateTime.Now.AddDays(-35), TrangThai = 1 }
            };

            // 5. Dữ liệu LopHoc
            var lopHocValue = new object[]
            {
                new LopHoc() { MaLop = "LH001", TenLop = "Lớp HTML/CSS Sáng", SoHocVienDuKien = 25, SoHocVienThucTe = 20, NgayBatDau = new DateTime(2025, 1, 20), NgayKetThuc = new DateTime(2025, 3, 15), ThoiGianHoc = "8:00-11:00 T2,T4,T6", PhongHoc = "P101", TrangThai = 2, MaKhoaHoc = "KH001", MaMonHoc = "MH001", MaGiaoVien = "GV001" },
                new LopHoc() { MaLop = "LH002", TenLop = "Lớp JavaScript Chiều", SoHocVienDuKien = 30, SoHocVienThucTe = 28, NgayBatDau = new DateTime(2025, 2, 1), NgayKetThuc = new DateTime(2025, 4, 10), ThoiGianHoc = "14:00-17:00 T3,T5,T7", PhongHoc = "P102", TrangThai = 2, MaKhoaHoc = "KH001", MaMonHoc = "MH002", MaGiaoVien = "GV001" },
                new LopHoc() { MaLop = "LH003", TenLop = "Lớp Flutter Mobile", SoHocVienDuKien = 20, SoHocVienThucTe = 0, NgayBatDau = new DateTime(2025, 3, 1), NgayKetThuc = new DateTime(2025, 5, 20), ThoiGianHoc = "18:30-21:30 T2,T4,T6", PhongHoc = "P201", TrangThai = 1, MaKhoaHoc = "KH002", MaMonHoc = "MH005", MaGiaoVien = "GV002" },
                new LopHoc() { MaLop = "LH004", TenLop = "Lớp Machine Learning", SoHocVienDuKien = 15, SoHocVienThucTe = 0, NgayBatDau = new DateTime(2025, 4, 15), NgayKetThuc = new DateTime(2025, 7, 30), ThoiGianHoc = "19:00-21:00 T3,T5", PhongHoc = "P301", TrangThai = 1, MaKhoaHoc = "KH003", MaMonHoc = "MH007", MaGiaoVien = "GV003" },
                new LopHoc() { MaLop = "LH005", TenLop = "Lớp MySQL Database", SoHocVienDuKien = 25, SoHocVienThucTe = 22, NgayBatDau = new DateTime(2024, 12, 5), NgayKetThuc = new DateTime(2025, 2, 20), ThoiGianHoc = "8:00-11:00 T2,T4", PhongHoc = "P105", TrangThai = 3, MaKhoaHoc = "KH005", MaMonHoc = "MH008", MaGiaoVien = "GV005" }
            };

            // 6. Dữ liệu Hoc (Quan hệ HocVien - MonHoc)
            var hocValue = new object[]
            {
                new Hoc() { MaHocVien = "HV001", MaMonHoc = "MH001", NgayBatDauHoc = new DateTime(2025, 1, 20), NgayKetThucHoc = new DateTime(2025, 3, 15), TrangThai = 2 },
                new Hoc() { MaHocVien = "HV001", MaMonHoc = "MH002", NgayBatDauHoc = new DateTime(2025, 2, 1), NgayKetThucHoc = new DateTime(2025, 4, 10), TrangThai = 1 },
                new Hoc() { MaHocVien = "HV002", MaMonHoc = "MH001", NgayBatDauHoc = new DateTime(2025, 1, 20), NgayKetThucHoc = new DateTime(2025, 3, 15), TrangThai = 2 },
                new Hoc() { MaHocVien = "HV003", MaMonHoc = "MH002", NgayBatDauHoc = new DateTime(2025, 2, 1), NgayKetThucHoc = new DateTime(2025, 4, 10), TrangThai = 1 },
                new Hoc() { MaHocVien = "HV004", MaMonHoc = "MH008", NgayBatDauHoc = new DateTime(2024, 12, 5), NgayKetThucHoc = new DateTime(2025, 2, 20), TrangThai = 2 },
                new Hoc() { MaHocVien = "HV005", MaMonHoc = "MH001", NgayBatDauHoc = new DateTime(2025, 1, 20), NgayKetThucHoc = new DateTime(2025, 3, 15), TrangThai = 1 },
                new Hoc() { MaHocVien = "HV006", MaMonHoc = "MH008", NgayBatDauHoc = new DateTime(2024, 12, 5), NgayKetThucHoc = new DateTime(2025, 2, 20), TrangThai = 2 },
                new Hoc() { MaHocVien = "HV007", MaMonHoc = "MH002", NgayBatDauHoc = new DateTime(2025, 2, 1), NgayKetThucHoc = new DateTime(2025, 4, 10), TrangThai = 1 },
                new Hoc() { MaHocVien = "HV008", MaMonHoc = "MH001", NgayBatDauHoc = new DateTime(2025, 1, 20), NgayKetThucHoc = new DateTime(2025, 3, 15), TrangThai = 1 },
                new Hoc() { MaHocVien = "HV009", MaMonHoc = "MH002", NgayBatDauHoc = new DateTime(2025, 2, 1), NgayKetThucHoc = new DateTime(2025, 4, 10), TrangThai = 1 }
            };

            // 7. Dữ liệu DangKy
            var dangKyValue = new object[]
            {
                new DangKy() { MaDangKy = "DK001", MaHocVien = "HV001", MaLop = "LH001", NgayDangKy = new DateTime(2025, 1, 15), BienLai = "BL001", SoTienDong = 2500000, TrangThaiDong = 2, GhiChu = "Đã thanh toán đầy đủ" },
                new DangKy() { MaDangKy = "DK002", MaHocVien = "HV001", MaLop = "LH002", NgayDangKy = new DateTime(2025, 1, 28), BienLai = "BL002", SoTienDong = 3500000, TrangThaiDong = 2, GhiChu = "Đã thanh toán đầy đủ" },
                new DangKy() { MaDangKy = "DK003", MaHocVien = "HV002", MaLop = "LH001", NgayDangKy = new DateTime(2025, 1, 16), BienLai = "BL003", SoTienDong = 2500000, TrangThaiDong = 2, GhiChu = "Đã thanh toán đầy đủ" },
                new DangKy() { MaDangKy = "DK004", MaHocVien = "HV003", MaLop = "LH002", NgayDangKy = new DateTime(2025, 1, 30), BienLai = null, SoTienDong = 1500000, TrangThaiDong = 3, GhiChu = "Còn nợ 2,000,000 VNĐ" },
                new DangKy() { MaDangKy = "DK005", MaHocVien = "HV004", MaLop = "LH005", NgayDangKy = new DateTime(2024, 12, 1), BienLai = "BL004", SoTienDong = 2800000, TrangThaiDong = 2, GhiChu = "Đã thanh toán đầy đủ" },
                new DangKy() { MaDangKy = "DK006", MaHocVien = "HV005", MaLop = "LH001", NgayDangKy = new DateTime(2025, 1, 18), BienLai = null, SoTienDong = 0, TrangThaiDong = 1, GhiChu = "Chưa thanh toán" },
                new DangKy() { MaDangKy = "DK007", MaHocVien = "HV006", MaLop = "LH005", NgayDangKy = new DateTime(2024, 12, 2), BienLai = "BL005", SoTienDong = 2800000, TrangThaiDong = 2, GhiChu = "Đã thanh toán đầy đủ" },
                new DangKy() { MaDangKy = "DK008", MaHocVien = "HV007", MaLop = "LH002", NgayDangKy = new DateTime(2025, 1, 29), BienLai = "BL006", SoTienDong = 3500000, TrangThaiDong = 2, GhiChu = "Đã thanh toán đầy đủ" },
                new DangKy() { MaDangKy = "DK009", MaHocVien = "HV008", MaLop = "LH001", NgayDangKy = new DateTime(2025, 1, 17), BienLai = null, SoTienDong = 1000000, TrangThaiDong = 3, GhiChu = "Còn nợ 1,500,000 VNĐ" },
                new DangKy() { MaDangKy = "DK010", MaHocVien = "HV009", MaLop = "LH002", NgayDangKy = new DateTime(2025, 2, 18), BienLai = null, SoTienDong = 0, TrangThaiDong = 1, GhiChu = "Chưa thanh toán" }
            };

            // 8. Dữ liệu Day (Quan hệ GiaoVien - LopHoc)
            var dayValue = new object[]
            {
                new Day() { MaGiaoVien = "GV001", MaLop = "LH001", NgayBatDau = new DateTime(2025, 1, 20), NgayKetThuc = new DateTime(2025, 3, 15), SoTietDay = 40, GhiChu = "Giảng dạy môn HTML/CSS cơ bản" },
                new Day() { MaGiaoVien = "GV001", MaLop = "LH002", NgayBatDau = new DateTime(2025, 2, 1), NgayKetThuc = new DateTime(2025, 4, 10), SoTietDay = 60, GhiChu = "Giảng dạy môn JavaScript" },
                new Day() { MaGiaoVien = "GV002", MaLop = "LH003", NgayBatDau = new DateTime(2025, 3, 1), NgayKetThuc = new DateTime(2025, 5, 20), SoTietDay = 90, GhiChu = "Giảng dạy môn Flutter Mobile" },
                new Day() { MaGiaoVien = "GV003", MaLop = "LH004", NgayBatDau = new DateTime(2025, 4, 15), NgayKetThuc = new DateTime(2025, 7, 30), SoTietDay = 100, GhiChu = "Giảng dạy môn Machine Learning" },
                new Day() { MaGiaoVien = "GV005", MaLop = "LH005", NgayBatDau = new DateTime(2024, 12, 5), NgayKetThuc = new DateTime(2025, 2, 20), SoTietDay = 45, GhiChu = "Giảng dạy môn MySQL Database" }
            };

            // 9. Dữ liệu Diem
            var diemValue = new object[]
            {
                new Diem() { MaDiem = "D001", MaHocVien = "HV001", MaMonHoc = "MH001", DiemLyThuyet = 8.5m, DiemThucHanh = 9.0m, NgayThi = new DateTime(2025, 3, 12), LanThi = 1, GhiChu = "Làm bài tốt", NgayNhap = DateTime.Now },
                new Diem() { MaDiem = "D002", MaHocVien = "HV002", MaMonHoc = "MH001", DiemLyThuyet = 7.0m, DiemThucHanh = 8.0m, NgayThi = new DateTime(2025, 3, 12), LanThi = 1, GhiChu = "Cần cải thiện lý thuyết", NgayNhap = DateTime.Now },
                new Diem() { MaDiem = "D003", MaHocVien = "HV004", MaMonHoc = "MH008", DiemLyThuyet = 9.0m, DiemThucHanh = 8.5m, NgayThi = new DateTime(2025, 2, 18), LanThi = 1, GhiChu = "Xuất sắc", NgayNhap = DateTime.Now },
                new Diem() { MaDiem = "D004", MaHocVien = "HV006", MaMonHoc = "MH008", DiemLyThuyet = 6.5m, DiemThucHanh = 7.0m, NgayThi = new DateTime(2025, 2, 18), LanThi = 1, GhiChu = "Đạt yêu cầu", NgayNhap = DateTime.Now },
                new Diem() { MaDiem = "D005", MaHocVien = "HV001", MaMonHoc = "MH002", DiemLyThuyet = 4.5m, DiemThucHanh = 6.0m, NgayThi = new DateTime(2025, 4, 8), LanThi = 1, GhiChu = "Cần thi lại lý thuyết", NgayNhap = DateTime.Now }
            };

            // 10. Dữ liệu ChungChi
            var chungChiValue = new object[]
            {
                new ChungChi() { MaChungChi = "CC001", MaHocVien = "HV001", MaMonHoc = "MH001", NgayCap = new DateTime(2025, 3, 20), DiemTongKet = 8.8m, TrangThai = 1, SoSeri = "CC2025001", GhiChu = "Hoàn thành xuất sắc khóa HTML/CSS", NgayTao = DateTime.Now },
                new ChungChi() { MaChungChi = "CC002", MaHocVien = "HV002", MaMonHoc = "MH001", NgayCap = new DateTime(2025, 3, 20), DiemTongKet = 7.5m, TrangThai = 1, SoSeri = "CC2025002", GhiChu = "Hoàn thành khóa HTML/CSS", NgayTao = DateTime.Now },
                new ChungChi() { MaChungChi = "CC003", MaHocVien = "HV004", MaMonHoc = "MH008", NgayCap = new DateTime(2025, 2, 25), DiemTongKet = 8.75m, TrangThai = 1, SoSeri = "CC2025003", GhiChu = "Hoàn thành xuất sắc khóa MySQL Database", NgayTao = DateTime.Now },
                new ChungChi() { MaChungChi = "CC004", MaHocVien = "HV006", MaMonHoc = "MH008", NgayCap = new DateTime(2025, 2, 25), DiemTongKet = 6.75m, TrangThai = 1, SoSeri = "CC2025004", GhiChu = "Hoàn thành khóa MySQL Database", NgayTao = DateTime.Now }
            };

            dbContext.AddRange(chungChiValue);
            dbContext.AddRange(dangKyValue);
            dbContext.AddRange(dayValue);
            dbContext.AddRange(diemValue);
            dbContext.AddRange(giaoVienValue);
            dbContext.AddRange(hocValue);
            dbContext.AddRange(hocVienValue);
            dbContext.AddRange(khoaHocValue);
            dbContext.AddRange(lopHocValue);
            dbContext.AddRange(monHocValue);

            int logInsertValue = dbContext.SaveChanges();

            string dbName = dbContext.Database.GetDbConnection().Database;
            Console.WriteLine($"Đã thêm vào bảng {dbName}: {logInsertValue} dữ liệu");
        }
        public static void HienThiLoi(string errorMessage)
        {
            {
                Console.Write(errorMessage);
                for (int i = 0; i < 3; i++)
                {
                    Thread.Sleep(1000); 
                    Console.Write(".");
                }
                Console.WriteLine();
            }
        }
        public void TimKiemHocVien_MaHocVien()
        {
            var dbContext = new AppDbContext();
            Console.Write("Nhập mã học viên cần tìm: ");
            string? IDHocVien = Console.ReadLine();
            var hocVienItem = (from hv in dbContext.hocvien
                               where hv.MaHocVien == IDHocVien
                               select hv).FirstOrDefault();
            if (hocVienItem != null)
            {
                hocVienItem.HienThiThongTinHocVien();
                //Console.WriteLine($"Thông tin học viên: {hocVienItem.HoTen}, Ngày sinh: {hocVienItem.NgaySinh?.ToShortDateString() ?? "Trống (chưa cập nhật)"}, Giới tính: {(hocVienItem.GioiTinh == 1 ? "Nam" : "Nữ")}, Địa chỉ: {hocVienItem.DiaChi}, Điện thoại: {hocVienItem.DienThoai}, Email: {hocVienItem.Email}");

                /* Note lỗi:
                Console.WriteLine($"Thông tin học viên: {hocVienItem.HoTen}, Ngày sinh: {hocVienItem.NgaySinh.ToShortDateString()}, Giới tính: {(hocVienItem.GioiTinh == 1 ? "Nam" : "Nữ")}, Địa chỉ: {hocVienItem.DiaChi}, Điện thoại: {hocVienItem.DienThoai}, Email: {hocVienItem.Email}");

                CS1061: 'DateTime?' does not contain a definition for 'ToShortDateString' and no accessible extension method 'ToShortDateString' accepting 
                a first argument of type 'DateTime?' could be found (are you missing a using directive or an assembly reference?) Show potential fixes (Alt+Enter or Ctrl+.)


                Lỗi này xuất hiện vì NgaySinh trong class hocvien của bạn có kiểu DateTime? (nullable DateTime).
                Mà phương thức ToShortDateString() chỉ có trong DateTime, không áp dụng được trực tiếp cho DateTime?.

                Ở đây: 
                hocVienItem.NgaySinh?.ToShortDateString() → chỉ gọi ToShortDateString() nếu có giá trị. 
                ?? "Không có" → nếu NgaySinh = null thì in "Không có".
                */

                Console.WriteLine("\nNhấn phím bất kỳ để quay về menu...");
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"Không tìm thấy học viên với mã: {IDHocVien}.");
                Console.WriteLine("\nNhấn phím bất kỳ để quay về menu...");
                Console.ReadKey();
            }


        }
        public void ThemHocVien()
        {
            var dbContext = new AppDbContext();
            Console.Write("Thêm số lượng học viên cần thêm (tối đa 100):");
            if (!int.TryParse(Console.ReadLine(), out int soLuong) || soLuong <= 0 || soLuong > 100)
            {
                Console.WriteLine("Số lượng không hợp lệ! Vui lòng nhập số từ 1 đến 100.");
                return;
            }
            for (int i = 0; i < soLuong; i++)
            {
                Console.Clear();
                Console.WriteLine($"\nNhập thông tin học viên thứ {i + 1}:");

                Console.Write("Mã học viên (VD: HV001): ");
                string maHocVien = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(maHocVien) || maHocVien.Length > 10)
                {
                    Console.WriteLine("Mã học viên không hợp lệ!");
                    i--;
                    continue;
                }

                if (dbContext.hocvien.Any(h => h.MaHocVien == maHocVien))
                {
                    Console.WriteLine("Mã học viên đã tồn tại!");
                    i--;
                    continue;
                }

                Console.Write("Họ tên: ");
                string hoTen = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(hoTen) || hoTen.Length > 100)
                {
                    Console.WriteLine("Họ tên không hợp lệ!");
                    i--;
                    continue;
                }

                Console.Write("Ngày sinh (YYYY-MM-DD): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime ngaySinh))
                {
                    Console.WriteLine("Ngày sinh không hợp lệ!");
                    i--;
                    continue;
                }

                Console.Write("Giới tính (0-Nam, 1-Nữ): ");
                if (!short.TryParse(Console.ReadLine(), out short gioiTinh) || (gioiTinh != 0 && gioiTinh != 1))
                {
                    Console.WriteLine("Giới tính không hợp lệ!");
                    i--;
                    continue;
                }

                Console.Write("Quê quán: ");
                string queQuan = Console.ReadLine()?.Trim();
                if (queQuan?.Length > 100)
                {
                    Console.WriteLine("Quê quán không hợp lệ!");
                    i--;
                    continue;
                }

                Console.Write("Địa chỉ: ");
                string diaChi = Console.ReadLine()?.Trim();
                if (diaChi?.Length > 200)
                {
                    Console.WriteLine("Địa chỉ không hợp lệ!");
                    i--;
                    continue;
                }

                Console.Write("Trình độ: ");
                string trinhDo = Console.ReadLine()?.Trim();
                if (trinhDo?.Length > 50)
                {
                    Console.WriteLine("Trình độ không hợp lệ!");
                    i--;
                    continue;
                }

                Console.Write("Điện thoại: ");
                string dienThoai = Console.ReadLine()?.Trim();
                if (dienThoai?.Length > 15 || dbContext.hocvien.Any(h => h.DienThoai == dienThoai))
                {
                    Console.WriteLine("Số điện thoại không hợp lệ hoặc đã tồn tại!");
                    i--;
                    continue;
                }

               
                Console.Write("Email: ");
                string email = Console.ReadLine()?.Trim();
                if (email?.Length > 100 || dbContext.hocvien.Any(h => h.Email == email))
                {
                    Console.WriteLine("Email không hợp lệ hoặc đã tồn tại!");
                    i--;
                    continue;
                }

                
                var hocVien = new HocVien
                {
                    MaHocVien = maHocVien,
                    HoTen = hoTen,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    QueQuan = queQuan,
                    DiaChi = diaChi,
                    TrinhDo = trinhDo,
                    DienThoai = dienThoai,
                    Email = email,
                    NgayDangKy = DateTime.Now,
                    TrangThai = 1
                };

                // Thêm vào database
                dbContext.hocvien.Add(hocVien);
                dbContext.SaveChanges();
                Console.WriteLine($"Đã thêm học viên {hoTen} thành công!");
            }
        }
        public void CapNhatHocVien()
        {
            using var dbContext = new AppDbContext();
            int skipValue = 0;
            int takeValue = 5;
            bool view = true;
            while ( view)
            {
                Console.Clear();
                var viewHocVien = (from hv in dbContext.hocvien
                                   orderby hv.MaHocVien
                                   select hv).Skip(skipValue).Take(takeValue);
                Console.WriteLine("------------------------------------------------------------------------");
                viewHocVien.ToList().ForEach(hv => Console.WriteLine($"|Mã học viên: {hv.MaHocVien, 6}|Họ tên: {hv.HoTen, 20}|Ngày sinh: {hv.NgaySinh, 10}|Quê quán: {hv.QueQuan, 10}"));
                Console.WriteLine("------------------------------------------------------------------------");
                Console.WriteLine("\nNhập [1] để hiển thị thêm 5 học viên\nNhập [2] để quay lại 5 học viên\nNhập [0] để thoát\nHoặc Nhập mã học viên để cập nhật: ");
                string userInput = Console.ReadLine()?.Trim();
                if (userInput == "0")
                {
                    view = false;
                    Console.WriteLine("Quay lại Menu.");
                }
                else if (userInput == "1")
                {
                    skipValue += 5;
                    takeValue += 5;
                }
                else if (userInput == "2")
                {
                    skipValue -= 5;
                    takeValue -= 5;
                    if (skipValue < 0)
                    {
                        //Console.WriteLine("Không có dữ liệu trước đó để hiển thị.");
                        skipValue = 0;
                        takeValue = 5;
                    }
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(userInput))
                    {
                        var hocVien = (from hv in dbContext.hocvien
                                       where hv.MaHocVien == userInput
                                       select hv).FirstOrDefault();
                        if (hocVien != null)
                        {
                            Console.WriteLine("Thông tin học viên cũ:");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Mã học viên: {hocVien.MaHocVien}");
                            Console.WriteLine($"Họ tên: {hocVien.HoTen}");
                            Console.WriteLine($"Ngày sinh: {(hocVien.NgaySinh.HasValue ? hocVien.NgaySinh.Value.ToString("dd/MM/yyyy") : "Chưa cung cấp")}");
                            Console.WriteLine($"Giới tính: {(hocVien.GioiTinh switch
                            {
                                1 => "Nam",
                                2 => "Nữ",
                                3 => "Khác",
                                _ => "Chưa cung cấp"
                            })}");
                            Console.WriteLine($"Quê quán: {hocVien.QueQuan ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Địa chỉ: {hocVien.DiaChi ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Trình độ: {hocVien.TrinhDo ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Điện thoại: {hocVien.DienThoai ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Email: {hocVien.Email ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Ngày đăng ký: {hocVien.NgayDangKy:dd/MM/yyyy}");
                            Console.WriteLine($"Trạng thái: {(hocVien.TrangThai switch
                            {
                                1 => "Đang học",
                                2 => "Tạm nghỉ",
                                3 => "Nghỉ học",
                                _ => "Không xác định"
                            })}");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("\nNhập thông tin học viên mới:");
                            Console.WriteLine("Nhập Họ tên học viên mới:");
                            string newHoTen = Console.ReadLine()?.Trim();
                            if (string.IsNullOrEmpty(newHoTen) || newHoTen.Length > 100)
                            {
                                Console.WriteLine("Họ tên không hợp lệ! Phải từ 1 đến 100 ký tự.");
                                return;
                            }
                            hocVien.HoTen = newHoTen;
                            Console.WriteLine("Nhập Ngày sinh (dd/MM/yyyy):");
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out DateTime ngaySinh))
                            {
                                hocVien.NgaySinh = ngaySinh;
                            }
                            else
                            {
                                Console.WriteLine("Ngày sinh không hợp lệ! Định dạng phải là dd/MM/yyyy.");
                                hocVien.NgaySinh = null;
                            }
                            Console.WriteLine("Nhập Giới tính (1: Nam, 2: Nữ, 3: Khác):");
                            if (short.TryParse(Console.ReadLine(), out short gioiTinh) && gioiTinh >= 1 && gioiTinh <= 3)
                            {
                                hocVien.GioiTinh = gioiTinh;
                            }
                            else
                            {
                                Console.WriteLine("Giới tính không hợp lệ! Chỉ nhập 1, 2 hoặc 3.");
                                hocVien.GioiTinh = null;
                            }
                            Console.WriteLine("Nhập Quê quán:");
                            string newQueQuan = Console.ReadLine()?.Trim();
                            if (newQueQuan?.Length > 100)
                            {
                                Console.WriteLine("Quê quán không được vượt quá 100 ký tự!");
                                newQueQuan = null;
                            }
                            hocVien.QueQuan = newQueQuan;
                            Console.WriteLine("Nhập Địa chỉ:");
                            string newDiaChi = Console.ReadLine()?.Trim();
                            if (newDiaChi?.Length > 200)
                            {
                                Console.WriteLine("Địa chỉ không được vượt quá 200 ký tự!");
                                newDiaChi = null;
                            }
                            hocVien.DiaChi = newDiaChi;
                            Console.WriteLine("Nhập Trình độ:");
                            string newTrinhDo = Console.ReadLine()?.Trim();
                            if (newTrinhDo?.Length > 50)
                            {
                                Console.WriteLine("Trình độ không được vượt quá 50 ký tự!");
                                newTrinhDo = null;
                            }
                            hocVien.TrinhDo = newTrinhDo;
                            Console.WriteLine("Nhập Số điện thoại:");
                            string newDienThoai = Console.ReadLine()?.Trim();
                            if (newDienThoai?.Length > 15)
                            {
                                Console.WriteLine("Số điện thoại không được vượt quá 15 ký tự!");
                                newDienThoai = null;
                            }
                            hocVien.DienThoai = newDienThoai;

                            Console.WriteLine("Nhập Email:");
                            string newEmail = Console.ReadLine()?.Trim();
                            if (newEmail?.Length > 100)
                            {
                                Console.WriteLine("Email không được vượt quá 100 ký tự!");
                                newEmail = null;
                            }
                            hocVien.Email = newEmail;
                            Console.WriteLine("Nhập Ngày đăng ký (dd/MM/yyyy HH:mm:ss):");
                            if (DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime ngayDangKy))
                            {
                                hocVien.NgayDangKy = ngayDangKy;
                            }
                            else
                            {
                                Console.WriteLine("Ngày đăng ký không hợp lệ! Định dạng phải là dd/MM/yyyy HH:mm:ss.");
                                hocVien.NgayDangKy = DateTime.Now; // Gán mặc định là thời điểm hiện tại nếu nhập sai
                            }

                            // Nhập Trạng thái
                            Console.WriteLine("Nhập Trạng thái (1: Đang học, 2: Tạm nghỉ, 3: Nghỉ học):");
                            if (short.TryParse(Console.ReadLine(), out short trangThai) && trangThai >= 1 && trangThai <= 3)
                            {
                                hocVien.TrangThai = trangThai;
                            }
                            else
                            {
                                Console.WriteLine("Trạng thái không hợp lệ! Mặc định đặt là 1 (Đang học).");
                                hocVien.TrangThai = 1;
                            }

                            Console.WriteLine("Đã nhập thông tin học viên thành công!");


                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy học viên với mã {userInput}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập 0, 1 hoặc mã học viên.");

                    }
                    Console.WriteLine("Bạn có muốn tiếp tục không? Vui lòng nhập 0 (Không), 1(Có): ");
                    if (Console.ReadLine()?.ToLower() != "1")
                    {
                        view = false;
                    }
                }
            }
            
        }
        public bool XoaHocVien_TheoID()
        {
            var dbContext = new AppDbContext();
            try
            {
                Console.Write("Nhập mã học viên cần xóa: ");
                string maHocVien = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(maHocVien))
                {
                    Console.WriteLine("Mã học viên không được để trống.");
                    return false;
                }

                var hocVien = dbContext.hocvien.FirstOrDefault(hv => hv.MaHocVien == maHocVien);
                if (hocVien == null)
                {
                    Console.WriteLine($"Không tìm thấy học viên với mã {maHocVien}.");
                    return false;
                }

                Console.WriteLine($"Bạn có chắc chắn muốn xóa học viên {hocVien.HoTen} (Mã: {maHocVien})? (Y/N): ");
                string confirm = Console.ReadLine()?.Trim().ToUpper();
                if (confirm != "Y")
                {
                    Console.WriteLine("Hủy thao tác xóa học viên.");
                    return false;
                }

                dbContext.hocvien.Remove(hocVien);
                dbContext.SaveChanges();
                Console.WriteLine($"Xóa học viên {hocVien.HoTen} thành công.");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi xóa học viên: {ex.Message}");
                return false;
            }
        }
        public void TimKiemGiaoVien_MaGiaoVien()
        {
            var dbContext = new AppDbContext();
            Console.Write("Nhập mã giáo viên cần tìm: ");
            string? idGiaoVien = Console.ReadLine();

            var gvItem = dbContext.giaovien.FirstOrDefault(gv => gv.MaGiaoVien == idGiaoVien);
            if (gvItem != null)
            {
                Console.WriteLine($"Thông tin giáo viên: {gvItem.HoTen}, " +
                                  $"Ngày sinh: {gvItem.NgaySinh?.ToShortDateString() ?? "Chưa cập nhật"}, " +
                                  $"Giới tính: {(gvItem.GioiTinh == 1 ? "Nữ" : "Nam")}, " +
                                  $"Địa chỉ: {gvItem.DiaChi}, " +
                                  $"Nơi công tác: {gvItem.NoiCongTac}, " +
                                  $"Chuyên môn: {gvItem.ChuyenMon}, " +
                                  $"Kinh nghiệm: {gvItem.KinhNghiem} năm, " +
                                  $"Điện thoại: {gvItem.DienThoai}, " +
                                  $"Email: {gvItem.Email}");
            }
            else
            {
                Console.WriteLine($"Không tìm thấy giáo viên với mã {idGiaoVien}");
            }
            Console.WriteLine("\nNhấn phím bất kỳ để quay về menu...");
            Console.ReadKey();
        }

        public void ThemGiaoVien()
        {
            var dbContext = new AppDbContext();
            Console.Write("Nhập số lượng giáo viên cần thêm (tối đa 50): ");
            if (!int.TryParse(Console.ReadLine(), out int soLuong) || soLuong <= 0 || soLuong > 50)
            {
                Console.WriteLine("Số lượng không hợp lệ!");
                return;
            }

            for (int i = 0; i < soLuong; i++)
            {
                Console.Clear();
                Console.WriteLine($"Nhập thông tin giáo viên thứ {i + 1}:");

                Console.Write("Mã giáo viên (VD: GV001): ");
                string maGV = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(maGV) || maGV.Length > 10 || dbContext.giaovien.Any(g => g.MaGiaoVien == maGV))
                {
                    Console.WriteLine("Mã giáo viên không hợp lệ hoặc đã tồn tại!");
                    i--; continue;
                }

                Console.Write("Họ tên: ");
                string hoTen = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(hoTen) || hoTen.Length > 100)
                {
                    Console.WriteLine("Họ tên không hợp lệ!");
                    i--; continue;
                }

                Console.Write("Ngày sinh (yyyy-MM-dd): ");
                if (!DateTime.TryParse(Console.ReadLine(), out DateTime ngaySinh))
                {
                    Console.WriteLine("Ngày sinh không hợp lệ!");
                    i--; continue;
                }

                Console.Write("Giới tính (0-Nam, 1-Nữ): ");
                if (!short.TryParse(Console.ReadLine(), out short gioiTinh) || (gioiTinh != 0 && gioiTinh != 1))
                {
                    Console.WriteLine("Giới tính không hợp lệ!");
                    i--; continue;
                }

                Console.Write("Địa chỉ: ");
                string diaChi = Console.ReadLine()?.Trim();

                Console.Write("Nơi công tác: ");
                string noiCongTac = Console.ReadLine()?.Trim();

                Console.Write("Điện thoại: ");
                string dienThoai = Console.ReadLine()?.Trim();
                if (dienThoai?.Length > 15 || dbContext.giaovien.Any(g => g.DienThoai == dienThoai))
                {
                    Console.WriteLine("Số điện thoại không hợp lệ hoặc đã tồn tại!");
                    i--; continue;
                }

                Console.Write("Email: ");
                string email = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(email) || email.Length > 100 || dbContext.giaovien.Any(g => g.Email == email))
                {
                    Console.WriteLine("Email không hợp lệ hoặc đã tồn tại!");
                    i--; continue;
                }

                Console.Write("Chuyên môn: ");
                string chuyenMon = Console.ReadLine()?.Trim();

                Console.Write("Kinh nghiệm (số năm): ");
                if (!short.TryParse(Console.ReadLine(), out short kinhNghiem) || kinhNghiem < 0)
                {
                    Console.WriteLine("Kinh nghiệm không hợp lệ!");
                    i--; continue;
                }

                var gv = new GiaoVien
                {
                    MaGiaoVien = maGV,
                    HoTen = hoTen,
                    NgaySinh = ngaySinh,
                    GioiTinh = gioiTinh,
                    DiaChi = diaChi,
                    NoiCongTac = noiCongTac,
                    DienThoai = dienThoai,
                    Email = email,
                    ChuyenMon = chuyenMon,
                    KinhNghiem = kinhNghiem
                };

                dbContext.giaovien.Add(gv);
                dbContext.SaveChanges();
                Console.WriteLine($"Đã thêm giáo viên {hoTen} thành công!");
            }
        }

        public bool CapNhatGiaoVien()
        {
            var dbContext = new AppDbContext();
            Console.Write("Nhập mã giáo viên cần cập nhật: ");
            string maGV = Console.ReadLine()?.Trim();
            var gv = dbContext.giaovien.FirstOrDefault(g => g.MaGiaoVien == maGV);
            if (gv == null)
            {
                Console.WriteLine("Không tìm thấy giáo viên!");
                return false;
            }

            Console.WriteLine($"Họ tên (hiện tại: {gv.HoTen}): ");
            string hoTen = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(hoTen)) gv.HoTen = hoTen;

            Console.WriteLine($"Ngày sinh (hiện tại: {gv.NgaySinh:yyyy-MM-dd}): ");
            string nsInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(nsInput) && DateTime.TryParse(nsInput, out DateTime ns)) gv.NgaySinh = ns;

            Console.WriteLine($"Giới tính (0-Nam,1-Nữ, hiện tại: {gv.GioiTinh}): ");
            string gtInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(gtInput) && short.TryParse(gtInput, out short gt)) gv.GioiTinh = gt;

            Console.WriteLine($"Địa chỉ (hiện tại: {gv.DiaChi}): ");
            string diaChi = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(diaChi)) gv.DiaChi = diaChi;

            Console.WriteLine($"Nơi công tác (hiện tại: {gv.NoiCongTac}): ");
            string noiCT = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(noiCT)) gv.NoiCongTac = noiCT;

            Console.WriteLine($"Điện thoại (hiện tại: {gv.DienThoai}): ");
            string dt = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(dt)) gv.DienThoai = dt;

            Console.WriteLine($"Email (hiện tại: {gv.Email}): ");
            string email = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(email) && email != gv.Email)
            {
                if (dbContext.giaovien.Any(g => g.Email == email && g.MaGiaoVien != maGV))
                {
                    Console.WriteLine("Email đã tồn tại!");
                    return false;
                }
                gv.Email = email;
            }

            Console.WriteLine($"Chuyên môn (hiện tại: {gv.ChuyenMon}): ");
            string cm = Console.ReadLine()?.Trim();
            if (!string.IsNullOrEmpty(cm)) gv.ChuyenMon = cm;

            Console.WriteLine($"Kinh nghiệm (hiện tại: {gv.KinhNghiem}): ");
            string knInput = Console.ReadLine();
            if (!string.IsNullOrEmpty(knInput) && short.TryParse(knInput, out short kn)) gv.KinhNghiem = kn;

            dbContext.SaveChanges();
            Console.WriteLine("Cập nhật thông tin giáo viên thành công!");
            return true;
        }

        public bool XoaGiaoVien_TheoID()
        {
            var dbContext = new AppDbContext();
            Console.Write("Nhập mã giáo viên cần xóa: ");
            string maGV = Console.ReadLine()?.Trim();
            var gv = dbContext.giaovien.FirstOrDefault(g => g.MaGiaoVien == maGV);
            if (gv == null)
            {
                Console.WriteLine("Không tìm thấy giáo viên!");
                return false;
            }

            Console.WriteLine($"Bạn có chắc chắn muốn xóa giáo viên {gv.HoTen} (Mã: {maGV})? (Y/N): ");
            string confirm = Console.ReadLine()?.Trim().ToUpper();
            if (confirm != "Y")
            {
                Console.WriteLine("Hủy thao tác xóa.");
                return false;
            }

            dbContext.giaovien.Remove(gv);
            dbContext.SaveChanges();
            Console.WriteLine("Xóa giáo viên thành công!");
            return true;
        }
        public void TimKiemLopHoc_MaLop()
        {
            using var db = new AppDbContext();
            Console.Write("Nhập mã lớp cần tìm: ");
            string? maLop = Console.ReadLine();

            var lop = db.lophoc
                        .FirstOrDefault(l => l.MaLop == maLop);

            if (lop != null)
            {
                Console.WriteLine($"Mã lớp: {lop.MaLop}, Tên lớp: {lop.TenLop}, " +
                                  $"Dự kiến: {lop.SoHocVienDuKien}, Thực tế: {lop.SoHocVienThucTe}, " +
                                  $"Thời gian: {lop.ThoiGianHoc}, Phòng: {lop.PhongHoc}, " +
                                  $"Trạng thái: {lop.TrangThai}, " +
                                  $"Ngày BD: {lop.NgayBatDau?.ToString("dd/MM/yyyy")}, Ngày KT: {lop.NgayKetThuc?.ToString("dd/MM/yyyy")}, " +
                                  $"Mã KH: {lop.MaKhoaHoc}, Mã MH: {lop.MaMonHoc}, GV: {lop.MaGiaoVien}");
            }
            else
            {
                Console.WriteLine("Không tìm thấy lớp học!");
            }
        }
        public void ThemLopHoc()
        {
            using var db = new AppDbContext();
            Console.Write("Nhập số lượng lớp muốn thêm (tối đa 20): ");
            if (!int.TryParse(Console.ReadLine(), out int soLuong) || soLuong <= 0 || soLuong > 20)
            {
                Console.WriteLine("Số lượng không hợp lệ!");
                return;
            }

            for (int i = 0; i < soLuong; i++)
            {
                Console.WriteLine($"\n--- Nhập thông tin lớp học thứ {i + 1} ---");

                Console.Write("Mã lớp: ");
                string maLop = Console.ReadLine()?.Trim();
                if (string.IsNullOrEmpty(maLop) || db.lophoc.Any(l => l.MaLop == maLop))
                {
                    Console.WriteLine("Mã lớp rỗng hoặc đã tồn tại!");
                    i--; continue;
                }

                Console.Write("Tên lớp: ");
                string tenLop = Console.ReadLine()?.Trim();
                Console.Write("Số học viên dự kiến: ");
                int soDuKien = int.TryParse(Console.ReadLine(), out int dk) ? dk : 0;
                Console.Write("Ngày bắt đầu (yyyy-MM-dd): ");
                DateTime? ngayBD = DateTime.TryParse(Console.ReadLine(), out DateTime nbd) ? nbd : null;
                Console.Write("Ngày kết thúc (yyyy-MM-dd): ");
                DateTime? ngayKT = DateTime.TryParse(Console.ReadLine(), out DateTime nkt) ? nkt : null;
                Console.Write("Thời gian học: ");
                string tgHoc = Console.ReadLine();
                Console.Write("Phòng học: ");
                string phongHoc = Console.ReadLine();
                Console.Write("Mã khóa học: ");
                string maKH = Console.ReadLine();
                Console.Write("Mã môn học: ");
                string maMH = Console.ReadLine();
                Console.Write("Mã giáo viên (có thể bỏ trống): ");
                string maGV = Console.ReadLine();

                var lop = new LopHoc
                {
                    MaLop = maLop,
                    TenLop = tenLop,
                    SoHocVienDuKien = soDuKien,
                    SoHocVienThucTe = 0,
                    NgayBatDau = ngayBD,
                    NgayKetThuc = ngayKT,
                    ThoiGianHoc = tgHoc,
                    PhongHoc = phongHoc,
                    TrangThai = 1,
                    MaKhoaHoc = maKH,
                    MaMonHoc = maMH,
                    MaGiaoVien = string.IsNullOrWhiteSpace(maGV) ? null : maGV
                };

                db.lophoc.Add(lop);
                db.SaveChanges();
                Console.WriteLine($"✅ Đã thêm lớp {lop.TenLop} thành công!");
            }
        }
        public void CapNhatLopHoc()
        {
            using var db = new AppDbContext();
            Console.Write("Nhập mã lớp cần cập nhật: ");
            string maLop = Console.ReadLine()?.Trim();

            var lop = db.lophoc.FirstOrDefault(l => l.MaLop == maLop);
            if (lop == null)
            {
                Console.WriteLine("Không tìm thấy lớp học!");
                return;
            }

            Console.WriteLine($"Tên lớp ({lop.TenLop}): ");
            string tenLop = Console.ReadLine();
            if (!string.IsNullOrEmpty(tenLop)) lop.TenLop = tenLop;

            Console.WriteLine($"Số học viên dự kiến ({lop.SoHocVienDuKien}): ");
            if (int.TryParse(Console.ReadLine(), out int soDK)) lop.SoHocVienDuKien = soDK;

            Console.WriteLine($"Số học viên thực tế ({lop.SoHocVienThucTe}): ");
            if (int.TryParse(Console.ReadLine(), out int soTT)) lop.SoHocVienThucTe = soTT;

            Console.WriteLine($"Ngày bắt đầu ({lop.NgayBatDau?.ToString("yyyy-MM-dd")}): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime nbd)) lop.NgayBatDau = nbd;

            Console.WriteLine($"Ngày kết thúc ({lop.NgayKetThuc?.ToString("yyyy-MM-dd")}): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime nkt)) lop.NgayKetThuc = nkt;

            Console.WriteLine($"Thời gian học ({lop.ThoiGianHoc}): ");
            string tgHoc = Console.ReadLine();
            if (!string.IsNullOrEmpty(tgHoc)) lop.ThoiGianHoc = tgHoc;

            Console.WriteLine($"Phòng học ({lop.PhongHoc}): ");
            string phong = Console.ReadLine();
            if (!string.IsNullOrEmpty(phong)) lop.PhongHoc = phong;

            Console.WriteLine($"Trạng thái ({lop.TrangThai}): ");
            if (short.TryParse(Console.ReadLine(), out short tt)) lop.TrangThai = tt;

            Console.WriteLine($"Mã khóa học ({lop.MaKhoaHoc}): ");
            string maKH = Console.ReadLine();
            if (!string.IsNullOrEmpty(maKH)) lop.MaKhoaHoc = maKH;

            Console.WriteLine($"Mã môn học ({lop.MaMonHoc}): ");
            string maMH = Console.ReadLine();
            if (!string.IsNullOrEmpty(maMH)) lop.MaMonHoc = maMH;

            Console.WriteLine($"Mã giáo viên ({lop.MaGiaoVien}): ");
            string maGV = Console.ReadLine();
            if (!string.IsNullOrEmpty(maGV)) lop.MaGiaoVien = maGV;

            db.SaveChanges();
            Console.WriteLine(" Cập nhật lớp học thành công!");
        }
        public void XoaLopHoc()
        {
            using var db = new AppDbContext();
            Console.Write("Nhập mã lớp cần xóa: ");
            string maLop = Console.ReadLine()?.Trim();

            var lop = db.lophoc.FirstOrDefault(l => l.MaLop == maLop);
            if (lop == null)
            {
                Console.WriteLine("Không tìm thấy lớp học!");
                return;
            }

            Console.WriteLine($"Bạn có chắc chắn muốn xóa lớp {lop.TenLop}? (Y/N): ");
            string confirm = Console.ReadLine()?.Trim().ToUpper();
            if (confirm != "Y") return;

            db.lophoc.Remove(lop);
            db.SaveChanges();
            Console.WriteLine("Xóa lớp học thành công!");
        }
        public void ThemDangKy(string maDangKy, string maHocVien, string maLop, decimal soTien, string bienLai = null)
        {
            using var db = new AppDbContext();

            var hocVien = db.hocvien.Find(maHocVien);
            if (hocVien == null)
            {
                Console.WriteLine("Học viên không tồn tại.");
                return;
            }

            var lop = db.lophoc.Find(maLop);
            if (lop == null)
            {
                Console.WriteLine("Lớp học không tồn tại.");
                return;
            }

            var tonTai = db.dangki.FirstOrDefault(d => d.MaHocVien == maHocVien && d.MaLop == maLop);
            if (tonTai != null)
            {
                Console.WriteLine("Học viên đã đăng ký lớp này rồi.");
                return;
            }


            if (lop.SoHocVienThucTe >= lop.SoHocVienDuKien)
            {
                Console.WriteLine("Lớp đã đủ sĩ số.");
                return;
            }

      
            var dangKy = new DangKy
            {
                MaDangKy = maDangKy,
                MaHocVien = maHocVien,
                MaLop = maLop,
                NgayDangKy = DateTime.Now,
                SoTienDong = soTien,
                BienLai = bienLai,
                TrangThaiDong = 1
            };

            db.dangki.Add(dangKy);
            lop.SoHocVienThucTe += 1; // tăng sĩ số
            db.SaveChanges();

            Console.WriteLine("Đăng ký thành công!");
        }
        public void input_ThemDangKi()
        {
            Console.Write("Nhập mã đăng ký: ");
            string maDangKy = Console.ReadLine();

            Console.Write("Nhập mã học viên: ");
            string maHocVien = Console.ReadLine();

            Console.Write("Nhập mã lớp: ");
            string maLop = Console.ReadLine();

            Console.Write("Nhập số tiền: ");
            decimal soTien;
            while (!decimal.TryParse(Console.ReadLine(), out soTien))
            {
                Console.Write("Vui lòng nhập đúng định dạng số tiền: ");
            }

            Console.Write("Nhập số biên lai (có thể bỏ trống): ");
            string bienLai = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bienLai))
            {
                bienLai = null;
            }

            ThemDangKy(maDangKy, maHocVien, maLop, soTien, bienLai);
   
        }
        public void CapNhatDangKy(string maDangKy, decimal? soTien = null, string bienLai = null, short? trangThai = null, string ghiChu = null)
        {
            using var db = new AppDbContext();
            var dangKy = db.dangki.Find(maDangKy);

            if (dangKy == null)
            {
                Console.WriteLine("Không tìm thấy đăng ký.");
                return;
            }

            if (soTien != null) dangKy.SoTienDong = soTien;
            if (bienLai != null) dangKy.BienLai = bienLai;
            if (trangThai != null) dangKy.TrangThaiDong = trangThai.Value;
            if (ghiChu != null) dangKy.GhiChu = ghiChu;

            db.SaveChanges();
            Console.WriteLine("Cập nhật đăng ký thành công.");
        }
        public void input_CapNhatDangKy()
        {
            Console.Write("Nhập mã đăng ký cần cập nhật: ");
            string maDangKy = Console.ReadLine();

            Console.Write("Nhập số tiền mới (bỏ trống nếu không đổi): ");
            string inputSoTien = Console.ReadLine();
            decimal? soTien = null;
            if (!string.IsNullOrWhiteSpace(inputSoTien))
            {
                if (decimal.TryParse(inputSoTien, out decimal parsedSoTien))
                    soTien = parsedSoTien;
            }

            Console.Write("Nhập số biên lai mới (bỏ trống nếu không đổi): ");
            string bienLai = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(bienLai)) bienLai = null;

            Console.Write("Nhập trạng thái mới (0: chưa đóng, 1: đã đóng, bỏ trống nếu không đổi): ");
            string inputTrangThai = Console.ReadLine();
            short? trangThai = null;
            if (!string.IsNullOrWhiteSpace(inputTrangThai))
            {
                if (short.TryParse(inputTrangThai, out short parsedTrangThai))
                    trangThai = parsedTrangThai;
            }

            Console.Write("Nhập ghi chú mới (bỏ trống nếu không đổi): ");
            string ghiChu = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(ghiChu)) ghiChu = null;

            CapNhatDangKy(maDangKy, soTien, bienLai, trangThai, ghiChu);
        }
        public void XoaDangKy(string maDangKy)
        {
            using var db = new AppDbContext();
            var dangKy = db.dangki.Find(maDangKy);

            if (dangKy == null)
            {
                Console.WriteLine("Không tìm thấy đăng ký.");
                return;
            }

            var lop = db.lophoc.Find(dangKy.MaLop);
            if (lop != null && lop.SoHocVienThucTe > 0)
            {
                lop.SoHocVienThucTe -= 1;
            }

            db.dangki.Remove(dangKy);
            db.SaveChanges();

            Console.WriteLine("Hủy đăng ký thành công.");
        }
        public void input_XoaDangKy()
        {
            Console.Write("Nhập mã đăng ký cần xóa: ");
            string maDangKy = Console.ReadLine();

            XoaDangKy(maDangKy);
        }
        public void TimKiemDangKy_TheoHocVien(string maHocVien)
        {
            using var db = new AppDbContext();

            var danhSach = db.dangki
                .Include(d => d.LopHoc)
                .Where(d => d.MaHocVien == maHocVien)
                .ToList();

            if (danhSach.Count == 0)
            {
                Console.WriteLine("Học viên chưa đăng ký lớp nào.");
                return;
            }

            Console.WriteLine($"Danh sách lớp của học viên {maHocVien}:");
            foreach (var dk in danhSach)
            {
                Console.WriteLine($"- Mã đăng ký: {dk.MaDangKy}, Lớp: {dk.MaLop} - {dk.LopHoc.TenLop}, Ngày ĐK: {dk.NgayDangKy:dd/MM/yyyy}");
            }
        }
        public void input_TimKiemDangKy_TheoHocVien()
        {
            Console.Write("Nhập mã học viên cần tra cứu: ");
            string maHocVien = Console.ReadLine();
            TimKiemDangKy_TheoHocVien(maHocVien);
        }
        public void ThemDiem(string maDiem, string maHocVien, string maMonHoc, decimal diemLT, decimal diemTH, DateTime ngayThi, int lanThi = 1, string ghiChu = null)
        {
            using var dbContext = new AppDbContext();
            var diemTonTai = dbContext.diem
                .FirstOrDefault(d => d.MaHocVien == maHocVien
                                  && d.MaMonHoc == maMonHoc
                                  && d.LanThi == lanThi);

            if (diemTonTai != null)
            {
                throw new Exception("Học viên này đã có điểm cho môn học và lần thi này!");
            }

            var diem = new Diem
            {
                MaDiem = maDiem,
                MaHocVien = maHocVien,
                MaMonHoc = maMonHoc,
                DiemLyThuyet = diemLT,
                DiemThucHanh = diemTH,
                NgayThi = ngayThi,
                LanThi = lanThi,
                GhiChu = ghiChu
            };

            diem.CapNhatDiem();

            dbContext.diem.Add(diem);
            dbContext.SaveChanges();
        }
        public void SapXepHocVienTheoHo()
        {
            using var dbContext = new AppDbContext();
            var danhsach = from hv in dbContext.hocvien
                           orderby hv.HoTen 
                           select hv;
            danhsach.ToList().ForEach(hv => Console.WriteLine(hv.HoTen));
        }
        public void HienThiTatCaHocVien()
        {
            using var dbContext = new AppDbContext();
            int skipValue = 0;
            int takeValue = 5;
            bool view = true;
            while (view)
            {
                Console.Clear();
                var viewHV = from hv in dbContext.hocvien
                             orderby hv.MaHocVien
                             select hv;
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                viewHV.ToList().ForEach(hv => Console.WriteLine($"|Mã học viên: {hv.MaHocVien,6}|Họ tên: {hv.HoTen,20}|Ngày sinh: {hv.NgaySinh,10}|Quê quán: {hv.QueQuan,10}|"));
                Console.WriteLine("---------------------------------------------------------------------------------------------------------");
                Console.Write("\nNhập [0] để thoát\nHoặc Nhập mã học viên để xem chi tiết: ");
                string userInput = Console.ReadLine()?.Trim();
                if (userInput == "0")
                {
                    view = false;
                    Console.WriteLine("Quay lại Menu.");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(userInput))
                    {
                        var hocVien = (from hv in dbContext.hocvien
                                       where hv.MaHocVien == userInput
                                       select hv).FirstOrDefault();
                        if (hocVien != null)
                        {
                            Console.WriteLine("\n----------------------------------------");
                            Console.WriteLine($"Thông tin học viên: {hocVien.HoTen}");
                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine($"Mã học viên: {hocVien.MaHocVien}");
                            Console.WriteLine($"Họ tên: {hocVien.HoTen}");
                            Console.WriteLine($"Ngày sinh: {(hocVien.NgaySinh.HasValue ? hocVien.NgaySinh.Value.ToString("dd/MM/yyyy") : "Chưa cung cấp")}");
                            Console.WriteLine($"Giới tính: {(hocVien.GioiTinh switch
                            {
                                1 => "Nam",
                                2 => "Nữ",
                                3 => "Khác",
                                _ => "Chưa cung cấp"
                            })}");
                            Console.WriteLine($"Quê quán: {hocVien.QueQuan ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Địa chỉ: {hocVien.DiaChi ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Trình độ: {hocVien.TrinhDo ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Điện thoại: {hocVien.DienThoai ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Email: {hocVien.Email ?? "Chưa cung cấp"}");
                            Console.WriteLine($"Ngày đăng ký: {hocVien.NgayDangKy:dd/MM/yyyy}");
                            Console.WriteLine($"Trạng thái: {(hocVien.TrangThai switch
                            {
                                1 => "Đang học",
                                2 => "Tạm nghỉ",
                                3 => "Nghỉ học",
                                _ => "Không xác định"
                            })}");
                            Console.WriteLine("----------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy học viên với mã {userInput}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập 0, 1 hoặc mã học viên.");

                    }
                    Console.WriteLine("Bạn có muốn tiếp tục không? Vui lòng nhập 0 (Không), 1(Có): ");
                    if (Console.ReadLine()?.ToLower() != "1")
                    {
                        view = false;
                    }
                }
            }
        }
        public void HienThiTatCaHocVienTheoID()
        {
            using var dbContext = new AppDbContext();
            int skipValue = 0;
            int takeValue = 5;
            bool view = true;
            while (view)
            {
                Console.Clear();
                var viewHVLop = from idlop in dbContext.lophoc
                                select idlop;
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                viewHVLop.ToList().ForEach(hvl => Console.WriteLine($"|Mã lớp: {hvl.MaLop, 5}|Tên lớp: {hvl.TenLop, 25}|Số học viên dự kiến:{hvl.SoHocVienDuKien, 3}|Số học viên thực tế:{hvl.SoHocVienThucTe, 3}|"));
                Console.WriteLine("--------------------------------------------------------------------------------------------------");
                Console.Write("\nNhập [0] để thoát\nHoặc Nhập mã lớp học để xem chi tiết: ");
                string userInput = Console.ReadLine()?.Trim();
                if (userInput == "0")
                {
                    view = false;
                    Console.WriteLine("Quay lại Menu.");
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(userInput))
                    {
                        var dangki = from hv in dbContext.hocvien
                                     join dk in dbContext.dangki on hv.MaHocVien equals dk.MaHocVien
                                     where dk.MaLop == userInput
                                     select new
                                     {
                                         MaHocVien = hv.MaHocVien,
                                         TenHocVien = hv.HoTen,
                                         NgaySinh = hv.NgaySinh, 
                                         GioiTinh = hv.GioiTinh == 1 ? "Nam" : 
                                                    hv.GioiTinh == 2 ? "Nữ" : "Khác",
                                         QueQuan = hv.QueQuan ?? "Chưa cung cấp", 
                                         DiaChi = hv.DiaChi ?? "Chưa cung cấp", 
                                         DienThoai = hv.DienThoai ?? "Chưa cung cấp",
                                         Email = hv.Email ?? "Chưa cung cấp",
                                         NgayDangKy = dk.NgayDangKy, 
                                         TrangThai = hv.TrangThai == 1 ? "Đang học" :
                                                     hv.TrangThai == 2 ? "Tạm nghỉ" :
                                                     hv.TrangThai == 3 ? "Nghỉ học" : "Không xác định"
                                     };
                        var dshv = dangki.ToList();
                        if (dshv.Any())
                        {
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                            dshv.ToList().ForEach(hv => Console.WriteLine($"|Mã học viên: {hv.MaHocVien,6}|Họ tên: {hv.TenHocVien,20}|Ngày sinh: {hv.NgaySinh,10}|Quê quán: {hv.QueQuan,10}|Trạng thái: {hv.TrangThai}"));
                            Console.WriteLine("--------------------------------------------------------------------------------------------------");
                        }
                        else
                        {
                            Console.WriteLine($"Không tìm thấy học viên với mã lớp: {userInput}.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Đầu vào không hợp lệ. Vui lòng nhập 0, 1 hoặc mã lớp.");

                    }
                    Console.WriteLine("Bạn có muốn tiếp tục không? Vui lòng nhập 0 (Không), 1(Có): ");
                    if (Console.ReadLine()?.ToLower() != "1")
                    {
                        view = false;
                    }
                }

            }
        }
        public void DisplayMenu()
        {
            Console.Clear();
            Console.WriteLine("===================================");
            Console.WriteLine("             QUẢN LÝ               ");
            Console.WriteLine("===================================");
            Console.WriteLine("  1. Quản lý học viên");
            Console.WriteLine("     1. Thêm học viên");
            Console.WriteLine("     2. Cập nhật học viên");
            Console.WriteLine("     3. Tìm kiếm học viên theo mã");
            Console.WriteLine("     4. Xóa học viên theo mã");
            Console.WriteLine("  2. Quản lý giáo viên");
            Console.WriteLine("     5. Thêm giáo viên");
            Console.WriteLine("     6. Cập nhật giáo viên");
            Console.WriteLine("     7. Tìm kiếm giáo viên theo mã");
            Console.WriteLine("     8. Xóa giáo viên theo mã");
            Console.WriteLine("  3. Quản lý lớp học");
            Console.WriteLine("     9. Thêm lớp học");
            Console.WriteLine("     10. Cập nhật lớp học");
            Console.WriteLine("     11. Tìm kiếm lớp học theo mã");
            Console.WriteLine("     12. Xóa lớp học");
            Console.WriteLine("  4. Quản lý đăng ký");
            Console.WriteLine("     13. Thêm đăng ký");
            Console.WriteLine("     14. Cập nhật đăng ký");
            Console.WriteLine("     15. Tìm kiếm đăng ký theo học viên");
            Console.WriteLine("     16. Xóa đăng ký");
            Console.WriteLine("  5. Hiển thị");
            Console.WriteLine("     17. Hiển thị tất cả học viên");
            Console.WriteLine("     18. Hiển thị tất cả học viên theo mã lớp");
            Console.WriteLine("     19. Thoát");
            Console.WriteLine("===================================");
            Console.Write("Nhập lựa chọn (1-18): ");
        }
        public void Run()
        {
            bool tiepTuc = true;
            while (tiepTuc)
            {
                DisplayMenu();
                if (int.TryParse(Console.ReadLine(), out int luaChon) &&
                    Enum.IsDefined(typeof(MenuOption), luaChon))
                {
                    MenuOption option = (MenuOption)luaChon;
                    Console.Clear();

                    switch (option)
                    {
                        case MenuOption.ThemHocVien:
                            ThemHocVien();
                            break;
                        case MenuOption.CapNhatHocVien:
                            CapNhatHocVien();
                            break;
                        case MenuOption.TimKiemHocVien_MaHocVien:
                            TimKiemHocVien_MaHocVien();
                            break;
                        case MenuOption.XoaHocVien_TheoID:
                            XoaHocVien_TheoID();
                            break;
                        case MenuOption.ThemGiaoVien:
                            ThemGiaoVien();
                            break;
                        case MenuOption.CapNhatGiaoVien:
                            CapNhatGiaoVien();
                            break;
                        case MenuOption.TimKiemGiaoVien_MaGiaoVien:
                            TimKiemGiaoVien_MaGiaoVien();
                            break;
                        case MenuOption.XoaGiaoVien_TheoID:
                            XoaGiaoVien_TheoID();
                            break;
                        case MenuOption.ThemLopHoc:
                            ThemLopHoc();
                            break;
                        case MenuOption.CapNhatLopHoc:
                            CapNhatLopHoc();
                            break;
                        case MenuOption.TimKiemLopHoc_MaLop:
                            TimKiemLopHoc_MaLop();
                            break;
                        case MenuOption.XoaLopHoc:
                            XoaLopHoc();
                            break;
                        case MenuOption.ThemDangKy:
                            input_ThemDangKi();
                            break;
                        case MenuOption.CapNhatDangKy:
                            input_CapNhatDangKy();
                            break;
                        case MenuOption.TimKiemDangKy_TheoHocVien:
                            input_TimKiemDangKy_TheoHocVien();
                            break;
                        case MenuOption.XoaDangKy:
                            input_XoaDangKy();
                            break;
                        case MenuOption.HienThiTatCaHocVien:
                            HienThiTatCaHocVien();
                            break;
                        case MenuOption.HienThiTatCaHocVienTheoID:
                            HienThiTatCaHocVienTheoID();
                            break;
                        case MenuOption.Thoat:
                            tiepTuc = false;
                            Console.WriteLine("Đã thoát chương trình. Nhấn phím bất kỳ để đóng.");
                            Console.ReadKey();
                            break;
                    }
                    if (option != MenuOption.Thoat)
                    {
                        Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
                        Console.ReadKey();
                    }
                }
                else
                {
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng chọn từ 1 đến 18.");
                    Console.WriteLine("Nhấn phím bất kỳ để thử lại...");
                    Console.ReadKey();
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            var program = new Program();

            //program.ThemHocVien();
            //program.CapNhatHocVien();
            //program.TimKiemHocVien_MaHocVien();
            //program.XoaHocVien_TheoID();

            //program.ThemGiaoVien();
            //program.CapNhatGiaoVien();
            //program.XoaGiaoVien_TheoID();
            //program.TimKiemGiaoVien_MaGiaoVien();

            //program.ThemLopHoc();
            //program.CapNhatLopHoc();
            //program.TimKiemLopHoc_MaLop();
            //program.XoaLopHoc();

            //program.input_ThemDangKi();
            //program.input_CapNhatDangKy();
            //program.input_TimKiemDangKy_TheoHocVien();
            //program.input_XoaDangKy();

            //program.SapXepHocVienTheoHo();
            //program.HienThiHocVienTheoMaLop()

            program.Run();
        }
    }
}