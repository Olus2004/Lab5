using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("hocvien")]
    public class HocVien
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaHocVien", TypeName = "varchar")]
        public string? MaHocVien { get; set; }

        [Required]
        [StringLength(100)]
        [Column("HoTen", TypeName = "varchar")]
        public string? HoTen { get; set; }

        [Column("NgaySinh", TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Column("GioiTinh", TypeName = "smallint")]
        public short? GioiTinh { get; set; } // 1: Nam, 2: Nữ, 3: Khác

        [StringLength(100)]
        [Column("QueQuan", TypeName = "varchar")]
        public string? QueQuan { get; set; }

        [StringLength(200)]
        [Column("DiaChi", TypeName = "varchar")]
        public string? DiaChi { get; set; }

        [StringLength(50)]
        [Column("TrinhDo", TypeName = "varchar")]
        public string? TrinhDo { get; set; }

        [StringLength(15)]
        [Column("DienThoai", TypeName = "varchar")]
        public string? DienThoai { get; set; }

        [StringLength(100)]
        [Column("Email", TypeName = "varchar")]
        public string? Email { get; set; }

        [Required]
        [Column("NgayDangKy", TypeName = "datetime")]
        public DateTime NgayDangKy { get; set; }

        [Column("TrangThai", TypeName = "smallint")]
        public short TrangThai { get; set; } = 1; // 1: Đang học, 2: Tạm nghỉ, 3: Nghỉ học

        // Navigation properties
        public List<Hoc>? DanhSachHoc { get; set; }
        public List<ChungChi>? DanhSachChungChi { get; set; }
        public List<DangKy>? DanhSachDangKy { get; set; }
        public List<Diem>? DanhSachDiem { get; set; }


        public void HienThiThongTinHocVien()
        {
            // Ánh xạ giá trị GioiTinh
            string gioiTinhText = GioiTinh.HasValue ? GioiTinh switch
            {
                1 => "Nam",
                2 => "Nữ",
                3 => "Khác",
                _ => "Không xác định"
            } : "Chưa cung cấp";

            // Ánh xạ giá trị TrangThai
            string trangThaiText = TrangThai switch
            {
                1 => "Đang học",
                2 => "Tạm nghỉ",
                3 => "Nghỉ học",
                _ => "Không xác định"
            };

            // Định dạng các cột với độ rộng cố định
            string maHocVienText = (MaHocVien ?? "Chưa cung cấp").PadRight(10);
            string hoTenText = (HoTen ?? "Chưa cung cấp").PadRight(20);
            string ngaySinhText = (NgaySinh?.ToString("dd/MM/yyyy") ?? "Chưa cung cấp").PadRight(12);
            string gioiTinhFormatted = gioiTinhText.PadRight(10);
            string queQuanText = (QueQuan ?? "Chưa cung cấp").PadRight(15);
            string diaChiText = (DiaChi ?? "Chưa cung cấp").PadRight(25);
            string trinhDoText = (TrinhDo ?? "Chưa cung cấp").PadRight(15);
            string dienThoaiText = (DienThoai ?? "Chưa cung cấp").PadRight(12);
            string emailText = (Email ?? "Chưa cung cấp").PadRight(25);
            string ngayDangKyText = NgayDangKy.ToString("dd/MM/yyyy HH:mm:ss").PadRight(20);
            string trangThaiFormatted = trangThaiText.PadRight(10);

            // Hiển thị tất cả thông tin trong 1 dòng với ký tự đặc biệt
            Console.WriteLine($"~ {maHocVienText} | {hoTenText} | {ngaySinhText} | {gioiTinhFormatted} | {queQuanText} | {diaChiText} | {trinhDoText} | {dienThoaiText} | {emailText} | {ngayDangKyText} | {trangThaiFormatted} ~");
        }

    }
    
}
