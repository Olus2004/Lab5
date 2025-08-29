using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("monhoc")]
    public class MonHoc
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaMonHoc", TypeName = "varchar")]
        public string? MaMonHoc { get; set; }

        [Required]
        [StringLength(100)]
        [Column("TenMonHoc", TypeName = "varchar")]
        public string? TenMonHoc { get; set; }

        [Column("CapDo", TypeName = "smallint")]
        public short CapDo { get; set; } = 1; // 1: Cơ bản, 2: Trung bình, 3: Nâng cao

        [Required]
        [Column("SoTiet", TypeName = "int")]
        public int SoTiet { get; set; }

        [Column("HocPhi", TypeName = "decimal(10,2)")]
        public decimal? HocPhi { get; set; }

        [Column("MoTa", TypeName = "text")]
        public string? MoTa { get; set; }

        // Navigation properties
        public List<Hoc>? DanhSachHoc { get; set; }
        public List<ChungChi>? DanhSachChungChi { get; set; }
        public List<LopHoc>? DanhSachLopHoc { get; set; }
        public List<Diem>? DanhSachDiem { get; set; }
    }
}
