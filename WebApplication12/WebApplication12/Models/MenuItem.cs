namespace WebApplication12.Models
{
    public class MenuItem
    {
        public int Id { get; set; }//Item id
        public string Name { get; set; } //Item name
        public string Link { get; set; } //Item label
        public MenuItem()
        {
            Id = 0;
            Name = string.Empty;
            Link = string.Empty;
        }
    }
}
