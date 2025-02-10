using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace WebApplication3.Models
{
    public class Student
    {
        public int Id { get; set; } // Mã sinh viên

        [Required(ErrorMessage = "Họ tên là bắt buộc.")]
        [StringLength(100, MinimumLength = 4, ErrorMessage = "Họ tên phải có độ dài từ 4 đến 100 ký tự.")]
        public string Name { get; set; } // Họ tên

        [Required(ErrorMessage = "Email là bắt buộc.")]
        [RegularExpression(@"^[\w-\.]+@gmail\.com$", ErrorMessage = "Email phải có đuôi gmail.com.")]
        public string Email { get; set; } // Email

        [Required(ErrorMessage = "Mật khẩu là bắt buộc.")]
        [StringLength(100, MinimumLength = 8, ErrorMessage = "Mật khẩu phải có độ dài từ 8.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$", ErrorMessage = "Mật khẩu phải có ký tự viết hoa, viết thường, chữ số và ký tự đặc biệt.")]
        public string Password { get; set; } // Mật khẩu

        [Required(ErrorMessage = "Ngành học là bắt buộc.")]
        public Branch Branch { get; set; } // Ngành học

        [Required(ErrorMessage = "Giới tính là bắt buộc.")]
        public Gender Gender { get; set; } // Giới tính
        [Required]
        public bool IsRegular { get; set; } // Hệ: true-chính qui, false-phi cq

        [Required(ErrorMessage = "Địa chỉ là bắt buộc.")]
        public string? Address { get; set; } // Địa chỉ

        [Required(ErrorMessage = "Ngày sinh là bắt buộc.")]
        [DataType(DataType.Date)]
        [Range(typeof(DateTime), "1/1/1900", "12/05/2005", ErrorMessage = "Ngày sinh phải nằm trong khoảng từ 01/01/1900 đến 12/12/2005")]
        public DateTime DateOfBorth { get; set; } // Ngày sinh

        [Required(ErrorMessage = "Điểm là bắt buộc.")]
        [Range(0.0, 10.0, ErrorMessage = "Điểm phải nằm trong khoảng từ 0.0 đến 10.0.")]
        public double Score { get; set; } // Điểm
    }
}

