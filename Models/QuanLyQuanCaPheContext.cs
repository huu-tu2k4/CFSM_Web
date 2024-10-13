using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DemoWebQLQCF.Models;

public partial class QuanLyQuanCaPheContext : DbContext
{
    public QuanLyQuanCaPheContext()
    {
    }

    public QuanLyQuanCaPheContext(DbContextOptions<QuanLyQuanCaPheContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TBan> TBans { get; set; }

    public virtual DbSet<TChiTietHd> TChiTietHds { get; set; }

    public virtual DbSet<TDoAn> TDoAns { get; set; }

    public virtual DbSet<THoaDon> THoaDons { get; set; }

    public virtual DbSet<TMenu> TMenus { get; set; }

    public virtual DbSet<TTaiKhoan> TTaiKhoans { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-8N1GJPH;Initial Catalog=QuanLyQuanCaPhe;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TBan>(entity =>
        {
            entity.HasKey(e => e.MaBan).HasName("PK__tBan__3520ED6CC7D94D54");

            entity.ToTable("tBan");

            entity.Property(e => e.TenBan).HasMaxLength(50);
            entity.Property(e => e.TrangThai).HasMaxLength(20);
        });

        modelBuilder.Entity<TChiTietHd>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PK__tChiTiet__1E4FA771CE9A452A");

            entity.ToTable("tChiTietHD");

            entity.Property(e => e.MaCthd).HasColumnName("MaCTHD");
            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaDoAnNavigation).WithMany(p => p.TChiTietHds)
                .HasForeignKey(d => d.MaDoAn)
                .HasConstraintName("FK__tChiTietH__MaDoA__44FF419A");

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.TChiTietHds)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("FK__tChiTietH__MaHoa__440B1D61");
        });

        modelBuilder.Entity<TDoAn>(entity =>
        {
            entity.HasKey(e => e.MaDoAn).HasName("PK__tDoAn__2DCF106743253436");

            entity.ToTable("tDoAn");

            entity.Property(e => e.DonGia).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TenDoAn).HasMaxLength(100);

            entity.HasOne(d => d.MaMenuNavigation).WithMany(p => p.TDoAns)
                .HasForeignKey(d => d.MaMenu)
                .HasConstraintName("FK__tDoAn__MaMenu__3D5E1FD2");
        });

        modelBuilder.Entity<THoaDon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PK__tHoaDon__835ED13BEF166AE8");

            entity.ToTable("tHoaDon");

            entity.Property(e => e.NgayLap).HasColumnType("datetime");
            entity.Property(e => e.TongTien).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.MaBanNavigation).WithMany(p => p.THoaDons)
                .HasForeignKey(d => d.MaBan)
                .HasConstraintName("FK__tHoaDon__MaBan__403A8C7D");

            entity.HasOne(d => d.MaTaiKhoanNavigation).WithMany(p => p.THoaDons)
                .HasForeignKey(d => d.MaTaiKhoan)
                .HasConstraintName("FK__tHoaDon__MaTaiKh__412EB0B6");
        });

        modelBuilder.Entity<TMenu>(entity =>
        {
            entity.HasKey(e => e.MaMenu).HasName("PK__tMenu__0EBABE42D905EC3E");

            entity.ToTable("tMenu");

            entity.Property(e => e.TenMenu).HasMaxLength(100);
        });

        modelBuilder.Entity<TTaiKhoan>(entity =>
        {
            entity.HasKey(e => e.MaTaiKhoan).HasName("PK__tTaiKhoa__AD7C6529D76505B3");

            entity.ToTable("tTaiKhoan");

            entity.Property(e => e.LoaiTaiKhoan).HasMaxLength(20);
            entity.Property(e => e.MatKhau).HasMaxLength(100);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
