using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("hoc")]
    public class Hoc
    {
        [Key]
        [StringLength(10)]
        [Column("MaHocVien", TypeName = "varchar", Order = 0)]
        public string? MaHocVien { get; set; }

        [Key]
        [StringLength(10)]
        [Column("MaMonHoc", TypeName = "varchar", Order = 1)]
        public string? MaMonHoc { get; set; }

        [Column("NgayBatDauHoc", TypeName = "date")]
        public DateTime? NgayBatDauHoc { get; set; }

        [Column("NgayKetThucHoc", TypeName = "date")]
        public DateTime? NgayKetThucHoc { get; set; }

        [Column("TrangThai", TypeName = "smallint")]
        public short TrangThai { get; set; } = 1; // 1: Đang học, 2: Hoàn thành, 3: Bỏ học

        // Navigation properties
        [ForeignKey("MaHocVien")]
        public HocVien? HocVien { get; set; }

        [ForeignKey("MaMonHoc")]
        public MonHoc? MonHoc { get; set; }

        public List<ChungChi>? DanhSachChungChi { get; set; }
        public List<Diem>? DanhSachDiem { get; set; }
    }
}
