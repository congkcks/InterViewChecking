namespace WebApplication12.Models
{
    public class Lop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Lop()
        {
            Id = 1;
            Name = "";
        }
        public Lop(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
