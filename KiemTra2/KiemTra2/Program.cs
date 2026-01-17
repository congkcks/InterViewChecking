using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
namespace DependencyInjection_ViDu;


public interface INhatKy
{
    void GhiLog(string thongDiep);
}


public interface IKhoLuuTru
{
    void Luu(DonHang donHang);
    DonHang LayDonHang(int id);
}

public interface IDichVuEmail
{
    void GuiEmail(string nguoiNhan, string tieuDe, string noiDung);
}


public interface IDinhDangDuLieu
{
    string DinhDang(string duLieu);
}

/// <summary>
/// Lớp đại diện cho một đơn hàng
/// </summary>
public class DonHang
{
    public int Id { get; set; }
    public string TenKhachHang { get; set; }
    public decimal TongTien { get; set; }
    public DateTime NgayDatHang { get; set; }

    public override string ToString()
    {
        return $"Đơn hàng #{Id}: {TenKhachHang}, {TongTien:C}, Ngày: {NgayDatHang:dd/MM/yyyy}";
    }
}

// Các lớp triển khai

/// <summary>
/// Ghi log ra console
/// </summary>
public class NhatKyConsole : INhatKy
{
    public void GhiLog(string thongDiep)
    {
        Console.WriteLine($"[{DateTime.Now:HH:mm:ss}] LOG: {thongDiep}");
    }
}

/// <summary>
/// Kho lưu trữ dữ liệu giả lập
/// </summary>
public class KhoLuuTruCSDL : IKhoLuuTru
{
    private readonly INhatKy _nhatKy;

    // Tiêm phụ thuộc qua constructor
    public KhoLuuTruCSDL(INhatKy nhatKy)
    {
        _nhatKy = nhatKy ?? throw new ArgumentNullException(nameof(nhatKy));
    }

    public void Luu(DonHang donHang)
    {
        // Mô phỏng lưu vào CSDL
        _nhatKy.GhiLog($"Đã lưu {donHang} vào cơ sở dữ liệu");
    }

    public DonHang LayDonHang(int id)
    {
        _nhatKy.GhiLog($"Đang truy xuất đơn hàng có ID: {id}");
        // Mô phỏng truy vấn CSDL
        return new DonHang
        {
            Id = id,
            TenKhachHang = "Nguyễn Văn A",
            TongTien = 1500000,
            NgayDatHang = DateTime.Now.AddDays(-3)
        };
    }
}

/// <summary>
/// Dịch vụ email SMTP giả lập
/// </summary>
public class DichVuEmailSMTP : IDichVuEmail
{
    private readonly INhatKy _nhatKy;

    // Tiêm phụ thuộc qua constructor
    public DichVuEmailSMTP(INhatKy nhatKy)
    {
        _nhatKy = nhatKy ?? throw new ArgumentNullException(nameof(nhatKy));
    }

    public void GuiEmail(string nguoiNhan, string tieuDe, string noiDung)
    {
        _nhatKy.GhiLog($"Gửi email đến {nguoiNhan}, Tiêu đề: {tieuDe}");
        // Mô phỏng gửi email
    }
}

/// <summary>
/// Định dạng dữ liệu theo chuẩn JSON
/// </summary>
public class DinhDangJSON : IDinhDangDuLieu
{
    public string DinhDang(string duLieu)
    {
        return $"{{\"DuLieu\": \"{duLieu}\"}}";
    }
}

/// <summary>
/// Định dạng dữ liệu theo chuẩn XML
/// </summary>
public class DinhDangXML : IDinhDangDuLieu
{
    public string DinhDang(string duLieu)
    {
        return $"<DuLieu>{duLieu}</DuLieu>";
    }
}

/// <summary>
/// Dịch vụ quản lý đơn hàng - ví dụ cho Constructor Injection
/// </summary>
public class DichVuQuanLyDonHang
{
    private readonly IKhoLuuTru _khoLuuTru;
    private readonly INhatKy _nhatKy;
    private readonly IDichVuEmail _dichVuEmail;

    // Constructor Injection với nhiều dependency
    public DichVuQuanLyDonHang(
        IKhoLuuTru khoLuuTru,
        INhatKy nhatKy,
        IDichVuEmail dichVuEmail)
    {
        _khoLuuTru = khoLuuTru ?? throw new ArgumentNullException(nameof(khoLuuTru));
        _nhatKy = nhatKy ?? throw new ArgumentNullException(nameof(nhatKy));
        _dichVuEmail = dichVuEmail ?? throw new ArgumentNullException(nameof(dichVuEmail));
    }

    public void XuLyDonHang(DonHang donHang)
    {
        _nhatKy.GhiLog($"Bắt đầu xử lý {donHang}");

        // Xử lý đơn hàng
        _khoLuuTru.Luu(donHang);

        // Gửi email xác nhận
        _dichVuEmail.GuiEmail(
            donHang.TenKhachHang,
            $"Xác nhận đơn hàng #{donHang.Id}",
            $"Cảm ơn bạn đã đặt hàng. Tổng tiền: {donHang.TongTien:C}");

        _nhatKy.GhiLog($"Hoàn thành xử lý đơn hàng #{donHang.Id}");
    }
}

/// <summary>
/// Dịch vụ tạo báo cáo - ví dụ cho Property Injection
/// </summary>
public class DichVuBaoCao
{
    // Property Injection
    public INhatKy NhatKy { get; set; }

    public void TaoBaoCao(string loaiBaoCao)
    {
        if (NhatKy != null)
        {
            NhatKy.GhiLog($"Bắt đầu tạo báo cáo loại: {loaiBaoCao}");
        }

        // Logic tạo báo cáo ở đây...

        if (NhatKy != null)
        {
            NhatKy.GhiLog($"Hoàn thành báo cáo loại: {loaiBaoCao}");
        }
    }
}

/// <summary>
/// Dịch vụ xử lý dữ liệu - ví dụ cho Method Injection
/// </summary>
public class DichVuXuLyDuLieu
{
    // Method Injection - dependency được truyền vào như tham số
    public string XuLyDuLieu(string duLieu, IDinhDangDuLieu dinhDang)
    {
        if (dinhDang == null)
            throw new ArgumentNullException(nameof(dinhDang));

        string ketQua = dinhDang.DinhDang(duLieu);
        // Xử lý thêm nếu cần...

        return ketQua;
    }
}

/// <summary>
/// Lớp cấu hình ứng dụng
/// </summary>
public class CauHinhUngDung
{
    public string ChuoiKetNoi { get; set; } = "Server=localhost;Database=QuanLyDonHang;";
}

/// <summary>
/// Lớp chương trình chính
/// </summary>
public class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("DEMO DEPENDENCY INJECTION TRONG C#");
        Console.WriteLine("===================================");

        // Thiết lập DI container
        var dichVu = new ServiceCollection()
            // Đăng ký các dịch vụ
            .AddSingleton<CauHinhUngDung>()
            .AddSingleton<INhatKy, NhatKyConsole>()
            .AddScoped<IKhoLuuTru, KhoLuuTruCSDL>()
            .AddTransient<IDichVuEmail, DichVuEmailSMTP>()
            .AddTransient<DichVuQuanLyDonHang>()
            .AddTransient<DichVuXuLyDuLieu>()
            .AddTransient<IDinhDangDuLieu, DinhDangJSON>() // Mặc định sử dụng JSON
            .BuildServiceProvider();

        Console.WriteLine("\n1. CONSTRUCTOR INJECTION DEMO");
        Console.WriteLine("-----------------------------");
        // Lấy dịch vụ quản lý đơn hàng từ container
        var dichVuQuanLyDonHang = dichVu.GetRequiredService<DichVuQuanLyDonHang>();

        // Tạo đơn hàng mẫu
        var donHang = new DonHang
        {
            Id = 1001,
            TenKhachHang = "Trần Thị B",
            TongTien = 2500000,
            NgayDatHang = DateTime.Now
        };

        // Xử lý đơn hàng - constructor injection được sử dụng bên trong
        dichVuQuanLyDonHang.XuLyDonHang(donHang);

        Console.WriteLine("\n2. PROPERTY INJECTION DEMO");
        Console.WriteLine("-------------------------");
        // Tạo dịch vụ báo cáo và thiết lập property
        var dichVuBaoCao = new DichVuBaoCao();
        dichVuBaoCao.NhatKy = dichVu.GetRequiredService<INhatKy>();
        dichVuBaoCao.TaoBaoCao("Báo cáo doanh thu tháng");

        Console.WriteLine("\n3. METHOD INJECTION DEMO");
        Console.WriteLine("------------------------");
        // Sử dụng method injection
        var xuLyDuLieu = dichVu.GetRequiredService<DichVuXuLyDuLieu>();

        // Lấy định dạng từ container
        var dinhDangJSON = dichVu.GetRequiredService<IDinhDangDuLieu>();
        string ketQuaJSON = xuLyDuLieu.XuLyDuLieu("Dữ liệu mẫu", dinhDangJSON);
        Console.WriteLine($"Kết quả định dạng JSON: {ketQuaJSON}");

        // Sử dụng định dạng khác không qua container
        var dinhDangXML = new DinhDangXML();
        string ketQuaXML = xuLyDuLieu.XuLyDuLieu("Dữ liệu mẫu", dinhDangXML);
        Console.WriteLine($"Kết quả định dạng XML: {ketQuaXML}");

        Console.WriteLine("\nHoàn thành demo!");
    }
}
