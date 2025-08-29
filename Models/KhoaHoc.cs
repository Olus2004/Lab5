using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("khoahoc")]
    public class KhoaHoc
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaKhoaHoc", TypeName = "varchar")]
        public string? MaKhoaHoc { get; set; }

        [Required]
        [Column("NgayKhaiGiang", TypeName = "date")]
        public DateTime NgayKhaiGiang { get; set; }

        [StringLength(100)]
        [Column("TenKhoaHoc", TypeName = "varchar")]
        public string? TenKhoaHoc { get; set; }

        [Required]
        [Column("TrangThai", TypeName = "smallint")]
        public short TrangThai { get; set; } = 1; // 1: Sắp khai giảng, 2: Đang học, 3: Kết thúc

        [Column("NgayTao", TypeName = "datetime")]
        public DateTime NgayTao { get; set; }

        // Navigation properties
        public List<LopHoc>? DanhSachLopHoc { get; set; }
    }
}
