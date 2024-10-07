﻿using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using eCommerce.Core.Domain.Entities;
namespace Entities;

public partial class ShopQuanAoContext : DbContext
{
    public ShopQuanAoContext()
    {
    }

    public ShopQuanAoContext(DbContextOptions<ShopQuanAoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BanBe> BanBes { get; set; }

    public virtual DbSet<ChiTietHd> ChiTietHds { get; set; }

    public virtual DbSet<ChuDe> ChuDes { get; set; }

    public virtual DbSet<GopY> Gopies { get; set; }

    public virtual DbSet<HangHoa> HangHoas { get; set; }

    public virtual DbSet<HinhAnhHangHoa> HinhAnhHangHoas { get; set; }

    public virtual DbSet<HoaDon> HoaDons { get; set; }

    public virtual DbSet<HoiDap> HoiDaps { get; set; }

    public virtual DbSet<KhachHang> KhachHangs { get; set; }

    public virtual DbSet<LoaiHangHoa> LoaiHangHoas { get; set; }

    public virtual DbSet<NhaCungCap> NhaCungCaps { get; set; }

    public virtual DbSet<NhanVien> NhanViens { get; set; }

    public virtual DbSet<PhanCong> PhanCongs { get; set; }

    public virtual DbSet<PhanQuyen> PhanQuyens { get; set; }

    public virtual DbSet<PhongBan> PhongBans { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<TrangThai> TrangThais { get; set; }

    public virtual DbSet<TrangWeb> TrangWebs { get; set; }

    public virtual DbSet<VChiTietHoaDon> VChiTietHoaDons { get; set; }

    public virtual DbSet<YeuThich> YeuThiches { get; set; }

    

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BanBe>(entity =>
        {
            entity.HasKey(e => e.MaBb).HasName("PK_Promotions");

            entity.ToTable("BanBe");

            entity.Property(e => e.MaBb).HasColumnName("MaBB");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaHh).HasColumnName("MaHH");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.NgayGui)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.BanBes)
                .HasForeignKey(d => d.MaHh)
                .HasConstraintName("FK_QuangBa_HangHoa");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.BanBes)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_BanBe_KhachHang");
        });

        modelBuilder.Entity<ChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaCt).HasName("PK_OrderDetails");

            entity.ToTable("ChiTietHD");

            entity.Property(e => e.MaCt).HasColumnName("MaCT");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaHh).HasColumnName("MaHH");
            entity.Property(e => e.SoLuong).HasDefaultValue(1);

            entity.HasOne(d => d.MaHdNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHd)
                .HasConstraintName("FK_OrderDetails_Orders");

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.ChiTietHds)
                .HasForeignKey(d => d.MaHh)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Products");
        });

        modelBuilder.Entity<ChuDe>(entity =>
        {
            entity.HasKey(e => e.MaCd);

            entity.ToTable("ChuDe");

            entity.Property(e => e.MaCd).HasColumnName("MaCD");
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.TenCd)
                .HasMaxLength(50)
                .HasColumnName("TenCD");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.ChuDes)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ChuDe_NhanVien");
        });

        modelBuilder.Entity<GopY>(entity =>
        {
            entity.HasKey(e => e.MaGy);

            entity.ToTable("GopY");

            entity.Property(e => e.MaGy)
                .HasMaxLength(50)
                .HasColumnName("MaGY");
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaCd).HasColumnName("MaCD");
            entity.Property(e => e.NgayGy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("NgayGY");
            entity.Property(e => e.NgayTl).HasColumnName("NgayTL");
            entity.Property(e => e.TraLoi).HasMaxLength(50);

            entity.HasOne(d => d.MaCdNavigation).WithMany(p => p.Gopies)
                .HasForeignKey(d => d.MaCd)
                .HasConstraintName("FK_GopY_ChuDe");
        });

        modelBuilder.Entity<HangHoa>(entity =>
        {
            entity.HasKey(e => e.MaHh).HasName("PK_Products");

            entity.ToTable("HangHoa");

            entity.Property(e => e.MaHh).HasColumnName("MaHH");
            entity.Property(e => e.DonGia).HasDefaultValue(0.0);
            entity.Property(e => e.MaNcc)
                .HasMaxLength(50)
                .HasColumnName("MaNCC");
            entity.Property(e => e.MoTaDonVi).HasMaxLength(50);
            entity.Property(e => e.NgaySx)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("NgaySX");
            entity.Property(e => e.TenAlias).HasMaxLength(50);
            entity.Property(e => e.TenHh)
                .HasMaxLength(50)
                .HasColumnName("TenHH");

            entity.HasOne(d => d.MaNccNavigation).WithMany(p => p.HangHoas)
                .HasForeignKey(d => d.MaNcc)
                .HasConstraintName("FK_Products_Suppliers");

            entity.HasMany(d => d.MaLoais).WithMany(p => p.MaHhs)
                .UsingEntity<Dictionary<string, object>>(
                    "HangHoaLoaiHangHoa",
                    r => r.HasOne<LoaiHangHoa>().WithMany()
                        .HasForeignKey("MaLoai")
                        .HasConstraintName("FK__HangHoaLo__MaLoa__30C33EC3"),
                    l => l.HasOne<HangHoa>().WithMany()
                        .HasForeignKey("MaHh")
                        .HasConstraintName("FK__HangHoaLoa__MaHh__2FCF1A8A"),
                    j =>
                    {
                        j.HasKey("MaHh", "MaLoai").HasName("PK__HangHoaL__A01503B185BFF2D5");
                        j.ToTable("HangHoaLoaiHangHoa");
                    });

            entity.HasMany(d => d.MaTags).WithMany(p => p.MaHhs)
                .UsingEntity<Dictionary<string, object>>(
                    "HangHoaTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("MaTag")
                        .HasConstraintName("FK__HangHoaTa__MaTag__2CF2ADDF"),
                    l => l.HasOne<HangHoa>().WithMany()
                        .HasForeignKey("MaHh")
                        .HasConstraintName("FK__HangHoaTag__MaHH__2BFE89A6"),
                    j =>
                    {
                        j.HasKey("MaHh", "MaTag").HasName("PK__HangHoaT__74314AC5AF3379F5");
                        j.ToTable("HangHoaTag");
                        j.IndexerProperty<int>("MaHh").HasColumnName("MaHH");
                    });
        });

        modelBuilder.Entity<HinhAnhHangHoa>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PK__HinhAnhH__7516F4EC10E5FD7F");

            entity.ToTable("HinhAnhHangHoa");

            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.ImagePath)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.MaHh).HasColumnName("MaHH");
        });

        modelBuilder.Entity<HoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHd).HasName("PK_Orders");

            entity.ToTable("HoaDon");

            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.CachThanhToan)
                .HasMaxLength(50)
                .HasDefaultValue("Cash");
            entity.Property(e => e.CachVanChuyen)
                .HasMaxLength(50)
                .HasDefaultValue("Airline");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.GhiChu).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayCan)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayDat)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.NgayGiao)
                .HasDefaultValueSql("(((1)/(1))/(1900))")
                .HasColumnType("datetime");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaKh)
                .HasConstraintName("FK_Orders_Customers");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_HoaDon_NhanVien");

            entity.HasOne(d => d.MaTrangThaiNavigation).WithMany(p => p.HoaDons)
                .HasForeignKey(d => d.MaTrangThai)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_HoaDon_TrangThai");
        });

        modelBuilder.Entity<HoiDap>(entity =>
        {
            entity.HasKey(e => e.MaHd);

            entity.ToTable("HoiDap");

            entity.Property(e => e.MaHd)
                .ValueGeneratedNever()
                .HasColumnName("MaHD");
            entity.Property(e => e.CauHoi).HasMaxLength(50);
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.NgayDua).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.TraLoi).HasMaxLength(50);

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.HoiDaps)
                .HasForeignKey(d => d.MaNv)
                .HasConstraintName("FK_HoiDap_NhanVien");
        });

        modelBuilder.Entity<KhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKh).HasName("PK_Customers");

            entity.ToTable("KhachHang");

            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.DiaChi).HasMaxLength(60);
            entity.Property(e => e.DienThoai).HasMaxLength(24);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Hinh)
                .HasMaxLength(50)
                .HasDefaultValue("Photo.gif");
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
            entity.Property(e => e.NgaySinh)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.RandomKey)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoaiHangHoa>(entity =>
        {
            entity.HasKey(e => e.MaLoai).HasName("PK_Categories");

            entity.ToTable("LoaiHangHoa");

            entity.Property(e => e.TenLoai).HasMaxLength(50);
            entity.Property(e => e.TenLoaiAlias).HasMaxLength(50);
        });

        modelBuilder.Entity<NhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNcc).HasName("PK_Suppliers");

            entity.ToTable("NhaCungCap");

            entity.Property(e => e.MaNcc)
                .HasMaxLength(50)
                .HasColumnName("MaNCC");
            entity.Property(e => e.DiaChi).HasMaxLength(50);
            entity.Property(e => e.DienThoai).HasMaxLength(50);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Logo).HasMaxLength(50);
            entity.Property(e => e.NguoiLienLac).HasMaxLength(50);
            entity.Property(e => e.TenCongTy).HasMaxLength(50);
        });

        modelBuilder.Entity<NhanVien>(entity =>
        {
            entity.HasKey(e => e.MaNv);

            entity.ToTable("NhanVien");

            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.HoTen).HasMaxLength(50);
            entity.Property(e => e.MatKhau).HasMaxLength(50);
        });

        modelBuilder.Entity<PhanCong>(entity =>
        {
            entity.HasKey(e => e.MaPc);

            entity.ToTable("PhanCong");

            entity.Property(e => e.MaPc).HasColumnName("MaPC");
            entity.Property(e => e.MaNv)
                .HasMaxLength(50)
                .HasColumnName("MaNV");
            entity.Property(e => e.MaPb)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("MaPB");
            entity.Property(e => e.NgayPc)
                .HasColumnType("datetime")
                .HasColumnName("NgayPC");

            entity.HasOne(d => d.MaNvNavigation).WithMany(p => p.PhanCongs)
                .HasForeignKey(d => d.MaNv)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCong_NhanVien");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.PhanCongs)
                .HasForeignKey(d => d.MaPb)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PhanCong_PhongBan");
        });

        modelBuilder.Entity<PhanQuyen>(entity =>
        {
            entity.HasKey(e => e.MaPq);

            entity.ToTable("PhanQuyen");

            entity.Property(e => e.MaPq).HasColumnName("MaPQ");
            entity.Property(e => e.MaPb)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("MaPB");

            entity.HasOne(d => d.MaPbNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.MaPb)
                .HasConstraintName("FK_PhanQuyen_PhongBan");

            entity.HasOne(d => d.MaTrangNavigation).WithMany(p => p.PhanQuyens)
                .HasForeignKey(d => d.MaTrang)
                .HasConstraintName("FK_PhanQuyen_TrangWeb");
        });

        modelBuilder.Entity<PhongBan>(entity =>
        {
            entity.HasKey(e => e.MaPb);

            entity.ToTable("PhongBan");

            entity.Property(e => e.MaPb)
                .HasMaxLength(7)
                .IsUnicode(false)
                .HasColumnName("MaPB");
            entity.Property(e => e.TenPb)
                .HasMaxLength(50)
                .HasColumnName("TenPB");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.MaTag).HasName("PK__Tag__314EC214E8B25673");

            entity.ToTable("Tag");

            entity.HasIndex(e => e.TenTag, "UQ__Tag__CD4F893EF5775F5D").IsUnique();

            entity.Property(e => e.TenTag).HasMaxLength(100);
        });

        modelBuilder.Entity<TrangThai>(entity =>
        {
            entity.HasKey(e => e.MaTrangThai);

            entity.ToTable("TrangThai");

            entity.Property(e => e.MaTrangThai).ValueGeneratedNever();
            entity.Property(e => e.MoTa).HasMaxLength(500);
            entity.Property(e => e.TenTrangThai).HasMaxLength(50);
        });

        modelBuilder.Entity<TrangWeb>(entity =>
        {
            entity.HasKey(e => e.MaTrang);

            entity.ToTable("TrangWeb");

            entity.Property(e => e.TenTrang).HasMaxLength(50);
            entity.Property(e => e.Url)
                .HasMaxLength(250)
                .HasColumnName("URL");
        });

        modelBuilder.Entity<VChiTietHoaDon>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("vChiTietHoaDon");

            entity.Property(e => e.MaCt).HasColumnName("MaCT");
            entity.Property(e => e.MaHd).HasColumnName("MaHD");
            entity.Property(e => e.MaHh).HasColumnName("MaHH");
            entity.Property(e => e.TenHh)
                .HasMaxLength(50)
                .HasColumnName("TenHH");
        });

        modelBuilder.Entity<YeuThich>(entity =>
        {
            entity.HasKey(e => e.MaYt).HasName("PK_Favorites");

            entity.ToTable("YeuThich");

            entity.Property(e => e.MaYt).HasColumnName("MaYT");
            entity.Property(e => e.MaHh).HasColumnName("MaHH");
            entity.Property(e => e.MaKh)
                .HasMaxLength(20)
                .HasColumnName("MaKH");
            entity.Property(e => e.MoTa).HasMaxLength(255);
            entity.Property(e => e.NgayChon).HasColumnType("datetime");

            entity.HasOne(d => d.MaHhNavigation).WithMany(p => p.YeuThiches)
                .HasForeignKey(d => d.MaHh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_YeuThich_HangHoa");

            entity.HasOne(d => d.MaKhNavigation).WithMany(p => p.YeuThiches)
                .HasForeignKey(d => d.MaKh)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_Favorites_Customers");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
