using System.ComponentModel.DataAnnotations;

namespace ssdf.Models
{
    public class Mau
    {
        [Required(ErrorMessage = "Ten Khong Duoc De Trong")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SDT Khong Duoc De Trong")]
        public string Phone { get; set; }

        public Mau()
        {
            Name = "Mau";
            Phone = "";
        }
    }
}
