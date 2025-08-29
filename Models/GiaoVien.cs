using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("giaovien")]
    public class GiaoVien
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaGiaoVien", TypeName = "varchar")]
        public string? MaGiaoVien { get; set; }

        [Required]
        [StringLength(100)]
        [Column("HoTen", TypeName = "varchar")]
        public string? HoTen { get; set; }

        [Column("NgaySinh", TypeName = "date")]
        public DateTime? NgaySinh { get; set; }

        [Column("GioiTinh", TypeName = "smallint")]
        public short? GioiTinh { get; set; } // 1: Nam, 2: Nữ, 3: Khác

        [StringLength(200)]
        [Column("DiaChi", TypeName = "varchar")]
        public string? DiaChi { get; set; }

        [StringLength(100)]
        [Column("NoiCongTac", TypeName = "varchar")]
        public string? NoiCongTac { get; set; }

        [StringLength(15)]
        [Column("DienThoai", TypeName = "varchar")]
        public string? DienThoai { get; set; }

        [StringLength(100)]
        [Column("Email", TypeName = "varchar")]
        public string? Email { get; set; }

        [StringLength(200)]
        [Column("ChuyenMon", TypeName = "varchar")]
        public string? ChuyenMon { get; set; }

        [Required]
        [Column("KinhNghiem", TypeName = "smallint")]
        public short KinhNghiem { get; set; } = 0; // 1: Cao Đẳng, 2: Đại Học, 3: Thạc Sĩ, 4: Tiến Sĩ

        // Navigation properties
        public List<LopHoc>? DanhSachLopHoc { get; set; }
        public List<Day>? DanhSachDay { get; set; }
    }
}
