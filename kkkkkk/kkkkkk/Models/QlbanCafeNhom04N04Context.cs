using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kkkkkk.Models;

public partial class QlbanCafeNhom04N04Context : DbContext
{
    public QlbanCafeNhom04N04Context()
    {
    }

    public QlbanCafeNhom04N04Context(DbContextOptions<QlbanCafeNhom04N04Context> options)
        : base(options)
    {
    }

    public virtual DbSet<TbAdmin> TbAdmins { get; set; }

    public virtual DbSet<TbChiTietHdb> TbChiTietHdbs { get; set; }

    public virtual DbSet<TbChiTietHdn> TbChiTietHdns { get; set; }

    public virtual DbSet<TbChiTietToppingHdb> TbChiTietToppingHdbs { get; set; }

    public virtual DbSet<TbCuaHang> TbCuaHangs { get; set; }

    public virtual DbSet<TbHoaDonBan> TbHoaDonBans { get; set; }

    public virtual DbSet<TbHoaDonNhap> TbHoaDonNhaps { get; set; }

    public virtual DbSet<TbKhachHang> TbKhachHangs { get; set; }

    public virtual DbSet<TbKhoVatTuCh> TbKhoVatTuChes { get; set; }

    public virtual DbSet<TbKichThuoc> TbKichThuocs { get; set; }

    public virtual DbSet<TbNhaCungCap> TbNhaCungCaps { get; set; }

    public virtual DbSet<TbNhomSanPham> TbNhomSanPhams { get; set; }

    public virtual DbSet<TbSanPham> TbSanPhams { get; set; }

    public virtual DbSet<TbTinTuc> TbTinTucs { get; set; }

    public virtual DbSet<TbTopping> TbToppings { get; set; }

    public virtual DbSet<TbVatTu> TbVatTus { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=CONGKC\\SQLEXPRESS;Initial Catalog=QLBanCafe_Nhom04_N04;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TbAdmin>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("tbAdmin");

            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<TbChiTietHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDonBan, e.MaSanPham }).HasName("PK__tbChiTie__A5FCBEC8C6D3D537");

            entity.ToTable("tbChiTietHDB");

            entity.Property(e => e.MaHoaDonBan).HasMaxLength(14);
            entity.Property(e => e.MaSanPham).HasMaxLength(4);
            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(1)
                .IsFixedLength();

            entity.HasOne(d => d.MaHoaDonBanNavigation).WithMany(p => p.TbChiTietHdbs)
                .HasForeignKey(d => d.MaHoaDonBan)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaHoa__6D0D32F4");

            entity.HasOne(d => d.MaKichThuocNavigation).WithMany(p => p.TbChiTietHdbs)
                .HasForeignKey(d => d.MaKichThuoc)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaKic__6E01572D");

            entity.HasOne(d => d.MaSanPhamNavigation).WithMany(p => p.TbChiTietHdbs)
                .HasForeignKey(d => d.MaSanPham)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaSan__6EF57B66");
        });

        modelBuilder.Entity<TbChiTietHdn>(entity =>
        {
            entity.HasKey(e => new { e.MaHoaDonNhap, e.MaVatTu }).HasName("PK__tbChiTie__F4351F034B10F787");

            entity.ToTable("tbChiTietHDN");

            entity.Property(e => e.MaHoaDonNhap).HasMaxLength(14);
            entity.Property(e => e.MaVatTu).HasMaxLength(4);

            entity.HasOne(d => d.MaHoaDonNhapNavigation).WithMany(p => p.TbChiTietHdns)
                .HasForeignKey(d => d.MaHoaDonNhap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaHoa__6FE99F9F");

            entity.HasOne(d => d.MaVatTuNavigation).WithMany(p => p.TbChiTietHdns)
                .HasForeignKey(d => d.MaVatTu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaVat__70DDC3D8");
        });

        modelBuilder.Entity<TbChiTietToppingHdb>(entity =>
        {
            entity.HasKey(e => new { e.MaTopping, e.MaHoaDonBan, e.MaSanPham }).HasName("PK__tbChiTie__A99D378DDD2998B4");

            entity.ToTable("tbChiTietToppingHDB");

            entity.Property(e => e.MaTopping).HasMaxLength(2);
            entity.Property(e => e.MaHoaDonBan).HasMaxLength(14);
            entity.Property(e => e.MaSanPham).HasMaxLength(4);

            entity.HasOne(d => d.MaToppingNavigation).WithMany(p => p.TbChiTietToppingHdbs)
                .HasForeignKey(d => d.MaTopping)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTiet__MaTop__71D1E811");

            entity.HasOne(d => d.TbChiTietHdb).WithMany(p => p.TbChiTietToppingHdbs)
                .HasForeignKey(d => new { d.MaHoaDonBan, d.MaSanPham })
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbChiTietTopping__72C60C4A");
        });

        modelBuilder.Entity<TbCuaHang>(entity =>
        {
            entity.HasKey(e => e.MaCuaHang).HasName("PK__tbCuaHan__0840BCA67655D31C");

            entity.ToTable("tbCuaHang");

            entity.Property(e => e.MaCuaHang).HasMaxLength(3);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.Fanpage).HasMaxLength(256);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenCuaHang).HasMaxLength(255);

            entity.HasMany(d => d.MaSanPhams).WithMany(p => p.MaCuaHangs)
                .UsingEntity<Dictionary<string, object>>(
                    "TbCuaHangBanSp",
                    r => r.HasOne<TbSanPham>().WithMany()
                        .HasForeignKey("MaSanPham")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbCuaHang__MaSan__6A30C649"),
                    l => l.HasOne<TbCuaHang>().WithMany()
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbCuaHang__MaCua__693CA210"),
                    j =>
                    {
                        j.HasKey("MaCuaHang", "MaSanPham").HasName("PK__tbCuaHan__C7ECC8E43D182D4E");
                        j.ToTable("tbCuaHangBanSP");
                        j.IndexerProperty<string>("MaCuaHang").HasMaxLength(3);
                        j.IndexerProperty<string>("MaSanPham").HasMaxLength(4);
                    });

            entity.HasMany(d => d.MaTinTucs).WithMany(p => p.MaCuaHangs)
                .UsingEntity<Dictionary<string, object>>(
                    "TbCuaHangTinTuc",
                    r => r.HasOne<TbTinTuc>().WithMany()
                        .HasForeignKey("MaTinTuc")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbCuaHang__MaTin__6C190EBB"),
                    l => l.HasOne<TbCuaHang>().WithMany()
                        .HasForeignKey("MaCuaHang")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__tbCuaHang__MaCua__6B24EA82"),
                    j =>
                    {
                        j.HasKey("MaCuaHang", "MaTinTuc").HasName("PK__tbCuaHan__1313D82ACA3E784D");
                        j.ToTable("tbCuaHangTinTuc");
                        j.IndexerProperty<string>("MaCuaHang").HasMaxLength(3);
                        j.IndexerProperty<string>("MaTinTuc").HasMaxLength(8);
                    });
        });

        modelBuilder.Entity<TbHoaDonBan>(entity =>
        {
            entity.HasKey(e => e.MaHoaDonBan).HasName("PK__tbHoaDon__6A50CA8A2EAE83F8");

            entity.ToTable("tbHoaDonBan");

            entity.Property(e => e.MaHoaDonBan).HasMaxLength(14);
            entity.Property(e => e.MaKhachHang).HasMaxLength(6);

            entity.HasOne(d => d.MaKhachHangNavigation).WithMany(p => p.TbHoaDonBans)
                .HasForeignKey(d => d.MaKhachHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHoaDonB__MaKha__73BA3083");
        });

        modelBuilder.Entity<TbHoaDonNhap>(entity =>
        {
            entity.HasKey(e => e.MaHoaDonNhap).HasName("PK__tbHoaDon__448838B589837F0E");

            entity.ToTable("tbHoaDonNhap");

            entity.Property(e => e.MaHoaDonNhap).HasMaxLength(14);
            entity.Property(e => e.MaNhaCungCap).HasMaxLength(2);

            entity.HasOne(d => d.MaNhaCungCapNavigation).WithMany(p => p.TbHoaDonNhaps)
                .HasForeignKey(d => d.MaNhaCungCap)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbHoaDonN__MaNha__74AE54BC");
        });

        modelBuilder.Entity<TbKhachHang>(entity =>
        {
            entity.HasKey(e => e.MaKhachHang).HasName("PK__tbKhachH__88D2F0E5929E0CCC");

            entity.ToTable("tbKhachHang");

            entity.Property(e => e.MaKhachHang).HasMaxLength(6);
            entity.Property(e => e.Hang).HasMaxLength(10);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenKhachHang).HasMaxLength(55);
        });

        modelBuilder.Entity<TbKhoVatTuCh>(entity =>
        {
            entity.HasKey(e => new { e.MaCuaHang, e.MaVatTu }).HasName("PK__tbKhoVat__B8FD9B101F190A66");

            entity.ToTable("tbKhoVatTuCH");

            entity.Property(e => e.MaCuaHang).HasMaxLength(3);
            entity.Property(e => e.MaVatTu).HasMaxLength(4);

            entity.HasOne(d => d.MaCuaHangNavigation).WithMany(p => p.TbKhoVatTuChes)
                .HasForeignKey(d => d.MaCuaHang)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbKhoVatT__MaCua__75A278F5");

            entity.HasOne(d => d.MaVatTuNavigation).WithMany(p => p.TbKhoVatTuChes)
                .HasForeignKey(d => d.MaVatTu)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbKhoVatT__MaVat__76969D2E");
        });

        modelBuilder.Entity<TbKichThuoc>(entity =>
        {
            entity.HasKey(e => e.MaKichThuoc).HasName("PK__tbKichTh__22BFD66433DF6FFD");

            entity.ToTable("tbKichThuoc");

            entity.Property(e => e.MaKichThuoc)
                .HasMaxLength(1)
                .IsFixedLength();
        });

        modelBuilder.Entity<TbNhaCungCap>(entity =>
        {
            entity.HasKey(e => e.MaNhaCungCap).HasName("PK__tbNhaCun__53DA9205EA8F3543");

            entity.ToTable("tbNhaCungCap");

            entity.Property(e => e.MaNhaCungCap).HasMaxLength(2);
            entity.Property(e => e.Email).HasMaxLength(256);
            entity.Property(e => e.SoDienThoai).HasMaxLength(10);
            entity.Property(e => e.TenNhaCungCap).HasMaxLength(256);
        });

        modelBuilder.Entity<TbNhomSanPham>(entity =>
        {
            entity.HasKey(e => e.MaNhomSp).HasName("PK__tbNhomSa__5A1AD2F9328597B5");

            entity.ToTable("tbNhomSanPham");

            entity.Property(e => e.MaNhomSp)
                .HasMaxLength(2)
                .HasColumnName("MaNhomSP");
            entity.Property(e => e.TenNhomSp)
                .HasMaxLength(256)
                .HasColumnName("TenNhomSP");
        });

        modelBuilder.Entity<TbSanPham>(entity =>
        {
            entity.HasKey(e => e.MaSanPham).HasName("PK__tbSanPha__FAC7442D9EA127EE");

            entity.ToTable("tbSanPham");

            entity.Property(e => e.MaSanPham).HasMaxLength(4);
            entity.Property(e => e.Calo).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.ChatBeoBaoHoa).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Cholesterol).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Duong).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.GiaBan).HasColumnType("money");
            entity.Property(e => e.MaNhomSp)
                .HasMaxLength(2)
                .HasColumnName("MaNhomSP");
            entity.Property(e => e.Natri).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.Protein).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TenSanPham).HasMaxLength(256);
            entity.Property(e => e.TongCarbohydrate).HasColumnType("decimal(4, 2)");
            entity.Property(e => e.TongChatBeo).HasColumnType("decimal(4, 2)");

            entity.HasOne(d => d.MaNhomSpNavigation).WithMany(p => p.TbSanPhams)
                .HasForeignKey(d => d.MaNhomSp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__tbSanPham__MaNho__778AC167");
        });

        modelBuilder.Entity<TbTinTuc>(entity =>
        {
            entity.HasKey(e => e.MaTinTuc).HasName("PK__tbTinTuc__B53648C07638DF35");

            entity.ToTable("tbTinTuc");

            entity.Property(e => e.MaTinTuc).HasMaxLength(8);
            entity.Property(e => e.TieuDe).HasMaxLength(256);
        });

        modelBuilder.Entity<TbTopping>(entity =>
        {
            entity.HasKey(e => e.MaTopping).HasName("PK__tbToppin__33C2FC6157B8E23D");

            entity.ToTable("tbTopping");

            entity.Property(e => e.MaTopping).HasMaxLength(2);
            entity.Property(e => e.TenTopping).HasMaxLength(256);
        });

        modelBuilder.Entity<TbVatTu>(entity =>
        {
            entity.HasKey(e => e.MaVatTu).HasName("PK__tbVatTu__0BD27B6A8C1AEDB0");

            entity.ToTable("tbVatTu");

            entity.Property(e => e.MaVatTu).HasMaxLength(4);
            entity.Property(e => e.DonViTinh).HasMaxLength(5);
            entity.Property(e => e.TenVatTu).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
