using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("day")]
    public class Day
    {
        [Key]
        [StringLength(10)]
        [Column("MaGiaoVien", TypeName = "varchar", Order = 0)]
        public string? MaGiaoVien { get; set; }

        [Key]
        [StringLength(10)]
        [Column("MaLop", TypeName = "varchar" , Order = 1)]
        public string? MaLop { get; set; }

        [Column("NgayBatDau", TypeName = "date")]
        public DateTime? NgayBatDau { get; set; }

        [Column("NgayKetThuc", TypeName = "date")]
        public DateTime? NgayKetThuc { get; set; }

        [Column("SoTietDay", TypeName = "int")]
        public int SoTietDay { get; set; } = 0;

        [Column("GhiChu", TypeName = "text")]
        public string? GhiChu { get; set; }

        // Navigation properties
        [ForeignKey("MaGiaoVien")]
        public GiaoVien? GiaoVien { get; set; }

        [ForeignKey("MaLop")]
        public LopHoc? LopHoc { get; set; }
    }
}
