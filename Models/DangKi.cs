using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("dangky")]
    public class DangKy
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaDangKy", TypeName = "varchar")]
        public string? MaDangKy { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaHocVien", TypeName = "varchar")]
        public string? MaHocVien { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaLop", TypeName = "varchar")]
        public string? MaLop { get; set; }

        [Column("NgayDangKy", TypeName = "timestamp")]
        public DateTime NgayDangKy { get; set; }

        [StringLength(50)]
        [Column("BienLai", TypeName = "varchar")]
        public string? BienLai { get; set; }

        [Column("SoTienDong", TypeName = "decimal(10,2)")]
        public decimal? SoTienDong { get; set; }

        [Column("TrangThaiDong", TypeName = "smallint")]
        public short TrangThaiDong { get; set; } = 1; // 1: Chưa đóng, 2: Đã đóng, 3: Đóng một phần

        [Column("GhiChu", TypeName = "text")]
        public string? GhiChu { get; set; }

        // Navigation properties
        [ForeignKey("MaHocVien")]
        public HocVien? HocVien { get; set; }

        [ForeignKey("MaLop")]
        public LopHoc? LopHoc { get; set; }
    }
}
