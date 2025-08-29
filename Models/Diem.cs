using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab5.Models
{
    [Table("diem")]
    public class Diem
    {
        [Key]
        [Required]
        [StringLength(10)]
        [Column("MaDiem", TypeName = "varchar")]
        public string? MaDiem { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaHocVien", TypeName = "varchar")]
        public string? MaHocVien { get; set; }

        [Required]
        [StringLength(10)]
        [Column("MaMonHoc", TypeName = "varchar")]
        public string? MaMonHoc { get; set; }

        [Column("DiemLyThuyet", TypeName = "decimal(3,1)")]
        public decimal? DiemLyThuyet { get; set; }

        [Column("DiemThucHanh", TypeName = "decimal(3,1)")]
        public decimal? DiemThucHanh { get; set; }

        [Column("NgayThi", TypeName = "date")]
        public DateTime? NgayThi { get; set; }

        [Column("LanThi", TypeName = "int")]
        public int LanThi { get; set; } = 1;

        [Column("DiemTrungBinh", TypeName = "decimal(3,1)")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public decimal? DiemTrungBinh { get; private set; }

        [Column("KetQua", TypeName = "smallint")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public short? KetQua { get; private set; } // 1: Đạt, 2: Không đạt

        [Column("GhiChu", TypeName = "text")]
        public string? GhiChu { get; set; }

        [Column("NgayNhap", TypeName = "timestamp")]
        public DateTime NgayNhap { get; set; }

        // Navigation properties
        [ForeignKey("MaHocVien,MaMonHoc")]
        public Hoc? Hoc { get; set; }

        public void CapNhatDiem()
        {
            if (DiemLyThuyet.HasValue && DiemThucHanh.HasValue)
            {
                DiemTrungBinh = Math.Round((DiemLyThuyet.Value + DiemThucHanh.Value) / 2, 1);
                KetQua = DiemTrungBinh >= 5 ? (short)1 : (short)0;
            }
            else
            {
                DiemTrungBinh = null;
                KetQua = null;
            }
        }
    }
}

