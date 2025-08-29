using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("chungchi")]
    public class ChungChi
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaChungChi", TypeName = "varchar")]
        public string? MaChungChi { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaHocVien", TypeName = "varchar")]
        public string? MaHocVien { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaMonHoc", TypeName = "varchar")]
        public string? MaMonHoc { get; set; }

        [Required]
        [Column("NgayCap", TypeName = "date")]
        public DateTime NgayCap { get; set; }

        [Column("DiemTongKet", TypeName = "decimal(3,1)")]
        public decimal? DiemTongKet { get; set; }

        [Column("XepLoai", TypeName = "smallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short? XepLoai { get; private set; } // 1: Xuất sắc, 2: Giỏi, 3: Khá, 4: Trung bình

        [Column("TrangThai", TypeName = "smallint")]
        public short TrangThai { get; set; } = 1; // 1: Đã nhận chứng chỉ, 2: Chưa nhận chứng chỉ

        [StringLength(20)]
        [Column("SoSeri", TypeName = "varchar")]
        public string? SoSeri { get; set; }

        [Column("GhiChu", TypeName = "text")]
        public string? GhiChu { get; set; }

        [Column("NgayTao", TypeName = "datetime")]
        public DateTime? NgayTao { get; set; }

        // Navigation properties
        [ForeignKey("MaHocVien,MaMonHoc")]
        public Hoc? Hoc { get; set; }
    }
}
