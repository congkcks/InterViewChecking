using System.ComponentModel.DataAnnotations;

namespace ssdf.Models
{
    public class Test
    {
        [Required(ErrorMessage ="ID khong duoc de trong ")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Ten khong duoc de trong ")]
        public string Name { get; set; }

       
       public Test()
        {
            Id = 0;
            Name = "";
        }
    }
}
