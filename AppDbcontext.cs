using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lab5.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Lab5
{
    internal class AppDbContext : DbContext
    {
        public static readonly ILoggerFactory loggerFactory = LoggerFactory.Create(builder =>
        {
            builder.AddFilter(DbLoggerCategory.Query.Name, LogLevel.Information);
            //builder.AddFilter(DbLoggerCategory.Database.Name, LogLevel.Information);
            builder.AddConsole();
        });
        public DbSet<ChungChi> chungchi { get; set; }
        public DbSet<DangKy> dangki { get; set; }
        public DbSet<Day> day { get; set; }
        public DbSet<Diem> diem { get; set; }
        public DbSet<GiaoVien> giaovien { get; set; }
        public DbSet<Hoc> hoc { get; set; }
        public DbSet<HocVien> hocvien { get; set; }
        public DbSet<KhoaHoc> khoahoc { get; set; }
        public DbSet<LopHoc> lophoc { get; set; }
        public DbSet<MonHoc> monhoc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = "server=localhost;database=lab6;user=root;password=21112004@Hoang";
            optionsBuilder.UseLoggerFactory(loggerFactory);
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Cấu hình composite key cho bảng Hoc
            modelBuilder.Entity<Hoc>()
                .HasKey(h => new { h.MaHocVien, h.MaMonHoc });

            // Cấu hình composite key cho bảng Day
            modelBuilder.Entity<Day>()
                .HasKey(d => new { d.MaGiaoVien, d.MaLop });

            // Cấu hình unique constraint cho HocVien
            modelBuilder.Entity<HocVien>()
                .HasIndex(h => h.Email)
                .IsUnique()
                .HasDatabaseName("uk_hocvien_email");

            modelBuilder.Entity<HocVien>()
                .HasIndex(h => h.HoTen)
                .HasDatabaseName("idx_hocvien_hoten");

            modelBuilder.Entity<HocVien>()
                .HasIndex(h => h.DienThoai)
                .HasDatabaseName("idx_hocvien_dienthoai");

            // Cấu hình unique constraint cho GiaoVien
            modelBuilder.Entity<GiaoVien>()
                .HasIndex(g => g.Email)
                .IsUnique()
                .HasDatabaseName("uk_giaovien_email");

            modelBuilder.Entity<GiaoVien>()
                .HasIndex(g => g.HoTen)
                .HasDatabaseName("idx_giaovien_hoten");

            // Cấu hình unique constraint cho ChungChi
            modelBuilder.Entity<ChungChi>()
                .HasIndex(c => new { c.MaHocVien, c.MaMonHoc })
                .IsUnique()
                .HasDatabaseName("uk_chungchi_hocvien_monhoc");

            modelBuilder.Entity<ChungChi>()
                .HasIndex(c => c.SoSeri)
                .IsUnique();

            modelBuilder.Entity<ChungChi>()
                .HasIndex(c => c.NgayCap)
                .HasDatabaseName("idx_chungchi_ngaycap");

            modelBuilder.Entity<ChungChi>()
                .HasIndex(c => c.SoSeri)
                .HasDatabaseName("idx_chungchi_soseri");

            // Cấu hình unique constraint cho DangKy
            modelBuilder.Entity<DangKy>()
                .HasIndex(d => new { d.MaHocVien, d.MaLop })
                .IsUnique()
                .HasDatabaseName("uk_dangky_hocvien_lop");

            modelBuilder.Entity<DangKy>()
                .HasIndex(d => d.MaHocVien)
                .HasDatabaseName("idx_dangky_hocvien");

            modelBuilder.Entity<DangKy>()
                .HasIndex(d => d.MaLop)
                .HasDatabaseName("idx_dangky_lop");

            // Cấu hình unique constraint cho Diem
            modelBuilder.Entity<Diem>()
                .HasIndex(d => new { d.MaHocVien, d.MaMonHoc, d.LanThi })
                .IsUnique()
                .HasDatabaseName("uk_diem_hocvien_monhoc_lanthi");

            modelBuilder.Entity<Diem>()
                .HasIndex(d => d.MaHocVien)
                .HasDatabaseName("idx_diem_hocvien");

            modelBuilder.Entity<Diem>()
                .HasIndex(d => d.MaMonHoc)
                .HasDatabaseName("idx_diem_monhoc");

            modelBuilder.Entity<Diem>()
                .HasIndex(d => d.NgayThi)
                .HasDatabaseName("idx_diem_ngaythi");

            // Cấu hình index cho LopHoc
            modelBuilder.Entity<LopHoc>()
                .HasIndex(l => l.MaKhoaHoc)
                .HasDatabaseName("idx_lophoc_khoahoc");

            modelBuilder.Entity<LopHoc>()
                .HasIndex(l => l.MaMonHoc)
                .HasDatabaseName("idx_lophoc_monhoc");

            modelBuilder.Entity<LopHoc>()
                .HasIndex(l => l.MaGiaoVien)
                .HasDatabaseName("idx_lophoc_giaovien");

            // Cấu hình foreign key relationships

            // Hoc relationships
            modelBuilder.Entity<Hoc>()
                .HasOne(h => h.HocVien)
                .WithMany(hv => hv.DanhSachHoc)
                .HasForeignKey(h => h.MaHocVien)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Hoc>()
                .HasOne(h => h.MonHoc)
                .WithMany(mh => mh.DanhSachHoc)
                .HasForeignKey(h => h.MaMonHoc)
                .OnDelete(DeleteBehavior.Cascade);

            // ChungChi relationships
            modelBuilder.Entity<ChungChi>()
                .HasOne(c => c.Hoc)
                .WithMany(h => h.DanhSachChungChi)
                .HasForeignKey(c => new { c.MaHocVien, c.MaMonHoc })
                .OnDelete(DeleteBehavior.Cascade);

            // LopHoc relationships
            modelBuilder.Entity<LopHoc>()
                .HasOne(l => l.KhoaHoc)
                .WithMany(k => k.DanhSachLopHoc)
                .HasForeignKey(l => l.MaKhoaHoc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LopHoc>()
                .HasOne(l => l.MonHoc)
                .WithMany(m => m.DanhSachLopHoc)
                .HasForeignKey(l => l.MaMonHoc)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<LopHoc>()
                .HasOne(l => l.GiaoVien)
                .WithMany(g => g.DanhSachLopHoc)
                .HasForeignKey(l => l.MaGiaoVien)
                .OnDelete(DeleteBehavior.SetNull);

            // DangKy relationships
            modelBuilder.Entity<DangKy>()
                .HasOne(d => d.HocVien)
                .WithMany(h => h.DanhSachDangKy)
                .HasForeignKey(d => d.MaHocVien)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DangKy>()
                .HasOne(d => d.LopHoc)
                .WithMany(l => l.DanhSachDangKy)
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.Cascade);

            // Day relationships
            modelBuilder.Entity<Day>()
                .HasOne(d => d.GiaoVien)
                .WithMany(g => g.DanhSachDay)
                .HasForeignKey(d => d.MaGiaoVien)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Day>()
                .HasOne(d => d.LopHoc)
                .WithMany(l => l.DanhSachDay)
                .HasForeignKey(d => d.MaLop)
                .OnDelete(DeleteBehavior.Cascade);

            // Diem relationships
            modelBuilder.Entity<Diem>()
                .HasOne(d => d.Hoc)
                .WithMany(h => h.DanhSachDiem)
                .HasForeignKey(d => new { d.MaHocVien, d.MaMonHoc })
                .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình default values
            modelBuilder.Entity<HocVien>()
                .Property(h => h.TrangThai)
                .HasDefaultValue(1);

            modelBuilder.Entity<MonHoc>()
                .Property(m => m.CapDo)
                .HasDefaultValue(1);

            modelBuilder.Entity<Hoc>()
                .Property(h => h.TrangThai)
                .HasDefaultValue(1);

            modelBuilder.Entity<ChungChi>()
                .Property(c => c.TrangThai)
                .HasDefaultValue(1);

            modelBuilder.Entity<KhoaHoc>()
                .Property(k => k.TrangThai)
                .HasDefaultValue(1);

            modelBuilder.Entity<KhoaHoc>()
                .Property(k => k.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<GiaoVien>()
                .Property(g => g.KinhNghiem)
                .HasDefaultValue(0);

            modelBuilder.Entity<LopHoc>()
                .Property(l => l.SoHocVienThucTe)
                .HasDefaultValue(0);

            modelBuilder.Entity<LopHoc>()
                .Property(l => l.TrangThai)
                .HasDefaultValue(1);

            modelBuilder.Entity<DangKy>()
                .Property(d => d.NgayDangKy)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            modelBuilder.Entity<DangKy>()
                .Property(d => d.TrangThaiDong)
                .HasDefaultValue(1);

            modelBuilder.Entity<Day>()
                .Property(d => d.SoTietDay)
                .HasDefaultValue(0);

            modelBuilder.Entity<Diem>()
                .Property(d => d.LanThi)
                .HasDefaultValue(1);

            modelBuilder.Entity<Diem>()
                .Property(d => d.NgayNhap)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }

}
