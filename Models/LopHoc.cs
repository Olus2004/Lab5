using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("lophoc")]
    public class LopHoc
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaLop", TypeName = "varchar")]
        public string? MaLop { get; set; }

        [Required]
        [StringLength(100)]
        [Column("TenLop", TypeName = "varchar")]
        public string? TenLop { get; set; }

        [Required]
        [Column("SoHocVienDuKien", TypeName = "int")]
        public int SoHocVienDuKien { get; set; }

        [Column("SoHocVienThucTe", TypeName = "int")]
        public int SoHocVienThucTe { get; set; } = 0;

        [Column("NgayBatDau", TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column("NgayKetThuc", TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [StringLength(50)]
        [Column("ThoiGianHoc", TypeName = "varchar")]
        public string? ThoiGianHoc { get; set; }

        [StringLength(20)]
        [Column("PhongHoc", TypeName = "varchar")]
        public string? PhongHoc { get; set; }

        [Column("TrangThai", TypeName = "smallint")]
        public short TrangThai { get; set; } = 1; // 1: Chưa khai giảng, 2: Đang học, 3: Kết thúc

        [Required]
        [StringLength(10)]
        [Column("MaKhoaHoc", TypeName = "varchar")]
        public string? MaKhoaHoc { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaMonHoc", TypeName = "varchar")]
        public string? MaMonHoc { get; set; }

        [StringLength(10)]
        [Column("MaGiaoVien", TypeName = "varchar")]
        public string? MaGiaoVien { get; set; }

        // Navigation properties
        [ForeignKey("MaKhoaHoc")]
        public KhoaHoc? KhoaHoc { get; set; }

        [ForeignKey("MaMonHoc")]
        public MonHoc? MonHoc { get; set; }

        [ForeignKey("MaGiaoVien")]
        public GiaoVien? GiaoVien { get; set; }

        public List<DangKy>? DanhSachDangKy { get; set; }
        public List<Day>? DanhSachDay { get; set; }
    }
}
