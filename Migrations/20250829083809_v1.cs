using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Lab5.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "giaovien",
                columns: table => new
                {
                    MaGiaoVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoTen = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<short>(type: "smallint", nullable: true),
                    DiaChi = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NoiCongTac = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DienThoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ChuyenMon = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    KinhNghiem = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)0)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_giaovien", x => x.MaGiaoVien);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hocvien",
                columns: table => new
                {
                    MaHocVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    HoTen = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgaySinh = table.Column<DateTime>(type: "date", nullable: true),
                    GioiTinh = table.Column<short>(type: "smallint", nullable: true),
                    QueQuan = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiaChi = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrinhDo = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DienThoai = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayDangKy = table.Column<DateTime>(type: "datetime", nullable: false),
                    TrangThai = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hocvien", x => x.MaHocVien);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "khoahoc",
                columns: table => new
                {
                    MaKhoaHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayKhaiGiang = table.Column<DateTime>(type: "date", nullable: false),
                    TenKhoaHoc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrangThai = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_khoahoc", x => x.MaKhoaHoc);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "monhoc",
                columns: table => new
                {
                    MaMonHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenMonHoc = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CapDo = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    SoTiet = table.Column<int>(type: "int", nullable: false),
                    HocPhi = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    MoTa = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_monhoc", x => x.MaMonHoc);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "hoc",
                columns: table => new
                {
                    MaHocVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaMonHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayBatDauHoc = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThucHoc = table.Column<DateTime>(type: "date", nullable: true),
                    TrangThai = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hoc", x => new { x.MaHocVien, x.MaMonHoc });
                    table.ForeignKey(
                        name: "FK_hoc_hocvien_MaHocVien",
                        column: x => x.MaHocVien,
                        principalTable: "hocvien",
                        principalColumn: "MaHocVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_hoc_monhoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "monhoc",
                        principalColumn: "MaMonHoc",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "lophoc",
                columns: table => new
                {
                    MaLop = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TenLop = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoHocVienDuKien = table.Column<int>(type: "int", nullable: false),
                    SoHocVienThucTe = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    ThoiGianHoc = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhongHoc = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TrangThai = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    MaKhoaHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaMonHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaGiaoVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lophoc", x => x.MaLop);
                    table.ForeignKey(
                        name: "FK_lophoc_giaovien_MaGiaoVien",
                        column: x => x.MaGiaoVien,
                        principalTable: "giaovien",
                        principalColumn: "MaGiaoVien",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_lophoc_khoahoc_MaKhoaHoc",
                        column: x => x.MaKhoaHoc,
                        principalTable: "khoahoc",
                        principalColumn: "MaKhoaHoc",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lophoc_monhoc_MaMonHoc",
                        column: x => x.MaMonHoc,
                        principalTable: "monhoc",
                        principalColumn: "MaMonHoc",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "chungchi",
                columns: table => new
                {
                    MaChungChi = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaHocVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaMonHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayCap = table.Column<DateTime>(type: "date", nullable: false),
                    DiemTongKet = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    XepLoai = table.Column<short>(type: "smallint", nullable: true),
                    TrangThai = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    SoSeri = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    GhiChu = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayTao = table.Column<DateTime>(type: "datetime", nullable: true),
                    HocVienMaHocVien = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonHocMaMonHoc = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chungchi", x => x.MaChungChi);
                    table.ForeignKey(
                        name: "FK_chungchi_hoc_MaHocVien_MaMonHoc",
                        columns: x => new { x.MaHocVien, x.MaMonHoc },
                        principalTable: "hoc",
                        principalColumns: new[] { "MaHocVien", "MaMonHoc" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_chungchi_hocvien_HocVienMaHocVien",
                        column: x => x.HocVienMaHocVien,
                        principalTable: "hocvien",
                        principalColumn: "MaHocVien");
                    table.ForeignKey(
                        name: "FK_chungchi_monhoc_MonHocMaMonHoc",
                        column: x => x.MonHocMaMonHoc,
                        principalTable: "monhoc",
                        principalColumn: "MaMonHoc");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "diem",
                columns: table => new
                {
                    MaDiem = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaHocVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaMonHoc = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DiemLyThuyet = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    DiemThucHanh = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    NgayThi = table.Column<DateTime>(type: "date", nullable: true),
                    LanThi = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    DiemTrungBinh = table.Column<decimal>(type: "decimal(3,1)", nullable: true),
                    KetQua = table.Column<short>(type: "smallint", nullable: true),
                    GhiChu = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayNhap = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    HocVienMaHocVien = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MonHocMaMonHoc = table.Column<string>(type: "varchar(10)", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_diem", x => x.MaDiem);
                    table.ForeignKey(
                        name: "FK_diem_hoc_MaHocVien_MaMonHoc",
                        columns: x => new { x.MaHocVien, x.MaMonHoc },
                        principalTable: "hoc",
                        principalColumns: new[] { "MaHocVien", "MaMonHoc" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_diem_hocvien_HocVienMaHocVien",
                        column: x => x.HocVienMaHocVien,
                        principalTable: "hocvien",
                        principalColumn: "MaHocVien");
                    table.ForeignKey(
                        name: "FK_diem_monhoc_MonHocMaMonHoc",
                        column: x => x.MonHocMaMonHoc,
                        principalTable: "monhoc",
                        principalColumn: "MaMonHoc");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "dangky",
                columns: table => new
                {
                    MaDangKy = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaHocVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaLop = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayDangKy = table.Column<DateTime>(type: "timestamp", nullable: false, defaultValueSql: "CURRENT_TIMESTAMP"),
                    BienLai = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    SoTienDong = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    TrangThaiDong = table.Column<short>(type: "smallint", nullable: false, defaultValue: (short)1),
                    GhiChu = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dangky", x => x.MaDangKy);
                    table.ForeignKey(
                        name: "FK_dangky_hocvien_MaHocVien",
                        column: x => x.MaHocVien,
                        principalTable: "hocvien",
                        principalColumn: "MaHocVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dangky_lophoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "lophoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "day",
                columns: table => new
                {
                    MaGiaoVien = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    MaLop = table.Column<string>(type: "varchar(10)", maxLength: 10, nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    NgayBatDau = table.Column<DateTime>(type: "date", nullable: true),
                    NgayKetThuc = table.Column<DateTime>(type: "date", nullable: true),
                    SoTietDay = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    GhiChu = table.Column<string>(type: "text", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_day", x => new { x.MaGiaoVien, x.MaLop });
                    table.ForeignKey(
                        name: "FK_day_giaovien_MaGiaoVien",
                        column: x => x.MaGiaoVien,
                        principalTable: "giaovien",
                        principalColumn: "MaGiaoVien",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_day_lophoc_MaLop",
                        column: x => x.MaLop,
                        principalTable: "lophoc",
                        principalColumn: "MaLop",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "idx_chungchi_ngaycap",
                table: "chungchi",
                column: "NgayCap");

            migrationBuilder.CreateIndex(
                name: "idx_chungchi_soseri",
                table: "chungchi",
                column: "SoSeri",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_chungchi_HocVienMaHocVien",
                table: "chungchi",
                column: "HocVienMaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_chungchi_MonHocMaMonHoc",
                table: "chungchi",
                column: "MonHocMaMonHoc");

            migrationBuilder.CreateIndex(
                name: "uk_chungchi_hocvien_monhoc",
                table: "chungchi",
                columns: new[] { "MaHocVien", "MaMonHoc" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_dangky_hocvien",
                table: "dangky",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "idx_dangky_lop",
                table: "dangky",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "uk_dangky_hocvien_lop",
                table: "dangky",
                columns: new[] { "MaHocVien", "MaLop" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_day_MaLop",
                table: "day",
                column: "MaLop");

            migrationBuilder.CreateIndex(
                name: "idx_diem_hocvien",
                table: "diem",
                column: "MaHocVien");

            migrationBuilder.CreateIndex(
                name: "idx_diem_monhoc",
                table: "diem",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "idx_diem_ngaythi",
                table: "diem",
                column: "NgayThi");

            migrationBuilder.CreateIndex(
                name: "IX_diem_HocVienMaHocVien",
                table: "diem",
                column: "HocVienMaHocVien");

            migrationBuilder.CreateIndex(
                name: "IX_diem_MonHocMaMonHoc",
                table: "diem",
                column: "MonHocMaMonHoc");

            migrationBuilder.CreateIndex(
                name: "uk_diem_hocvien_monhoc_lanthi",
                table: "diem",
                columns: new[] { "MaHocVien", "MaMonHoc", "LanThi" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_giaovien_hoten",
                table: "giaovien",
                column: "HoTen");

            migrationBuilder.CreateIndex(
                name: "uk_giaovien_email",
                table: "giaovien",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_hoc_MaMonHoc",
                table: "hoc",
                column: "MaMonHoc");

            migrationBuilder.CreateIndex(
                name: "idx_hocvien_dienthoai",
                table: "hocvien",
                column: "DienThoai");

            migrationBuilder.CreateIndex(
                name: "idx_hocvien_hoten",
                table: "hocvien",
                column: "HoTen");

            migrationBuilder.CreateIndex(
                name: "uk_hocvien_email",
                table: "hocvien",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "idx_lophoc_giaovien",
                table: "lophoc",
                column: "MaGiaoVien");

            migrationBuilder.CreateIndex(
                name: "idx_lophoc_khoahoc",
                table: "lophoc",
                column: "MaKhoaHoc");

            migrationBuilder.CreateIndex(
                name: "idx_lophoc_monhoc",
                table: "lophoc",
                column: "MaMonHoc");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "chungchi");

            migrationBuilder.DropTable(
                name: "dangky");

            migrationBuilder.DropTable(
                name: "day");

            migrationBuilder.DropTable(
                name: "diem");

            migrationBuilder.DropTable(
                name: "lophoc");

            migrationBuilder.DropTable(
                name: "hoc");

            migrationBuilder.DropTable(
                name: "giaovien");

            migrationBuilder.DropTable(
                name: "khoahoc");

            migrationBuilder.DropTable(
                name: "hocvien");

            migrationBuilder.DropTable(
                name: "monhoc");
        }
    }
}
