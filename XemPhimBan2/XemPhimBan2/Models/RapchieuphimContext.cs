
using Microsoft.EntityFrameworkCore;

namespace XemPhimBan2.Models;

public partial class RapchieuphimContext : DbContext
{
    public RapchieuphimContext()
    {
    }

    public RapchieuphimContext(DbContextOptions<RapchieuphimContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cachieu> Cachieus { get; set; }

    public virtual DbSet<Chitiethoadon> Chitiethoadons { get; set; }

    public virtual DbSet<Don> Dons { get; set; }

    public virtual DbSet<Ghe> Ghes { get; set; }

    public virtual DbSet<Hoadon> Hoadons { get; set; }

    public virtual DbSet<Phim> Phims { get; set; }

    public virtual DbSet<Phong> Phongs { get; set; }

    public virtual DbSet<Suatchieu> Suatchieus { get; set; }

    public virtual DbSet<Taikhoan> Taikhoans { get; set; }

    public virtual DbSet<Ve> Ves { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=rapchieuphim;uid=root;pwd=1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.39-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_unicode_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Cachieu>(entity =>
        {
            entity.HasKey(e => e.MaCa).HasName("PRIMARY");

            entity.ToTable("cachieu");

            entity.Property(e => e.GioBatDau).HasColumnType("time");
            entity.Property(e => e.GioKetThuc).HasColumnType("time");
            entity.Property(e => e.TenCa).HasMaxLength(50);
        });

        modelBuilder.Entity<Chitiethoadon>(entity =>
        {
            entity.HasKey(e => e.MaCthd).HasName("PRIMARY");

            entity.ToTable("chitiethoadon");

            entity.HasIndex(e => e.MaVe, "fk_cthd_ve");

            entity.HasIndex(e => new { e.MaHoaDon, e.MaVe }, "uq_cthd").IsUnique();

            entity.Property(e => e.MaCthd).HasColumnName("MaCTHD");
            entity.Property(e => e.DonGia).HasPrecision(10, 2);
            entity.Property(e => e.SoLuong).HasDefaultValueSql("'1'");
            entity.Property(e => e.ThanhTien).HasPrecision(12, 2);

            entity.HasOne(d => d.MaHoaDonNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.MaHoaDon)
                .HasConstraintName("fk_cthd_hoadon");

            entity.HasOne(d => d.MaVeNavigation).WithMany(p => p.Chitiethoadons)
                .HasForeignKey(d => d.MaVe)
                .HasConstraintName("fk_cthd_ve");
        });

        modelBuilder.Entity<Don>(entity =>
        {
            entity.HasKey(e => e.MaDon).HasName("PRIMARY");

            entity.ToTable("don");

            entity.HasIndex(e => e.MaNguoiDung, "MaNguoiDung");

            entity.Property(e => e.NgayDat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.TongTien).HasPrecision(12, 2);
            entity.Property(e => e.TrangThai)
                .HasDefaultValueSql("'CHO_THANH_TOAN'")
                .HasColumnType("enum('CHO_THANH_TOAN','DA_THANH_TOAN','DA_HUY')");

            entity.HasOne(d => d.MaNguoiDungNavigation).WithMany(p => p.Dons)
                .HasForeignKey(d => d.MaNguoiDung)
                .HasConstraintName("don_ibfk_1");
        });

        modelBuilder.Entity<Ghe>(entity =>
        {
            entity.HasKey(e => e.MaGhe).HasName("PRIMARY");

            entity.ToTable("ghe");

            entity.HasIndex(e => new { e.MaPhong, e.HangGhe, e.CotGhe }, "MaPhong").IsUnique();

            entity.Property(e => e.GiaGhe).HasPrecision(10, 2);
            entity.Property(e => e.HangGhe)
                .HasMaxLength(1)
                .IsFixedLength();
            entity.Property(e => e.LoaiGhe)
                .HasDefaultValueSql("'THUONG'")
                .HasColumnType("enum('THUONG','VIP')");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.Ghes)
                .HasForeignKey(d => d.MaPhong)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("ghe_ibfk_1");
        });

        modelBuilder.Entity<Hoadon>(entity =>
        {
            entity.HasKey(e => e.MaHoaDon).HasName("PRIMARY");

            entity.ToTable("hoadon");

            entity.HasIndex(e => e.MaDon, "MaDon").IsUnique();

            entity.Property(e => e.HinhThucThanhToan).HasColumnType("enum('TIEN_MAT','CHUYEN_KHOAN','ONLINE')");
            entity.Property(e => e.NgayXuat)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.ThueVat)
                .HasPrecision(5, 2)
                .HasDefaultValueSql("'8.00'")
                .HasColumnName("ThueVAT");
            entity.Property(e => e.TongTien).HasPrecision(12, 2);
            entity.Property(e => e.TrangThaiHoaDon).HasColumnType("enum('DA_XUAT','DA_HUY')");

            entity.HasOne(d => d.MaDonNavigation).WithOne(p => p.Hoadon)
                .HasForeignKey<Hoadon>(d => d.MaDon)
                .HasConstraintName("hoadon_ibfk_1");
        });

        modelBuilder.Entity<Phim>(entity =>
        {
            entity.HasKey(e => e.MaPhim).HasName("PRIMARY");

            entity.ToTable("phim");

            entity.Property(e => e.MoTa).HasColumnType("text");
            entity.Property(e => e.NgonNgu).HasMaxLength(50);
            entity.Property(e => e.QuocGia).HasMaxLength(50);
            entity.Property(e => e.TenPhim).HasMaxLength(100);
            entity.Property(e => e.TheLoai).HasMaxLength(100);
        });

        modelBuilder.Entity<Phong>(entity =>
        {
            entity.HasKey(e => e.MaPhong).HasName("PRIMARY");

            entity.ToTable("phong");

            entity.HasIndex(e => e.TenPhong, "TenPhong").IsUnique();

            entity.Property(e => e.TenPhong).HasMaxLength(50);
        });

        modelBuilder.Entity<Suatchieu>(entity =>
        {
            entity.HasKey(e => e.MaSuat).HasName("PRIMARY");

            entity.ToTable("suatchieu");

            entity.HasIndex(e => e.MaCa, "MaCa");

            entity.HasIndex(e => e.MaPhim, "MaPhim");

            entity.HasIndex(e => new { e.MaPhong, e.MaCa, e.NgayChieu }, "MaPhong").IsUnique();

            entity.Property(e => e.GiaSuat).HasPrecision(10, 2);

            entity.HasOne(d => d.MaCaNavigation).WithMany(p => p.Suatchieus)
                .HasForeignKey(d => d.MaCa)
                .HasConstraintName("suatchieu_ibfk_3");

            entity.HasOne(d => d.MaPhimNavigation).WithMany(p => p.Suatchieus)
                .HasForeignKey(d => d.MaPhim)
                .HasConstraintName("suatchieu_ibfk_1");

            entity.HasOne(d => d.MaPhongNavigation).WithMany(p => p.Suatchieus)
                .HasForeignKey(d => d.MaPhong)
                .HasConstraintName("suatchieu_ibfk_2");
        });

        modelBuilder.Entity<Taikhoan>(entity =>
        {
            entity.HasKey(e => e.MaNguoiDung).HasName("PRIMARY");

            entity.ToTable("taikhoan");

            entity.HasIndex(e => e.TenDangNhap, "TenDangNhap").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.HoTen).HasMaxLength(100);
            entity.Property(e => e.MatKhau).HasMaxLength(255);
            entity.Property(e => e.NgayTao)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("timestamp");
            entity.Property(e => e.SoDienThoai).HasMaxLength(20);
            entity.Property(e => e.TenDangNhap).HasMaxLength(50);
            entity.Property(e => e.TrangThai)
                .HasDefaultValueSql("'HOAT_DONG'")
                .HasColumnType("enum('HOAT_DONG','KHOA')");
        });

        modelBuilder.Entity<Ve>(entity =>
        {
            entity.HasKey(e => e.MaVe).HasName("PRIMARY");

            entity.ToTable("ve");

            entity.HasIndex(e => e.MaDon, "MaDon");

            entity.HasIndex(e => e.MaGhe, "MaGhe");

            entity.HasIndex(e => new { e.MaSuat, e.MaGhe }, "MaSuat").IsUnique();

            entity.Property(e => e.GiaVe).HasPrecision(10, 2);

            entity.HasOne(d => d.MaDonNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.MaDon)
                .HasConstraintName("ve_ibfk_1");

            entity.HasOne(d => d.MaGheNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.MaGhe)
                .HasConstraintName("ve_ibfk_3");

            entity.HasOne(d => d.MaSuatNavigation).WithMany(p => p.Ves)
                .HasForeignKey(d => d.MaSuat)
                .HasConstraintName("ve_ibfk_2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
