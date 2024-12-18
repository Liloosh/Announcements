namespace BlazorApp1.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }

        public Announcement()
        {
            CreatedDate = DateTime.Now;
            Status = 0;
            Category = 0;
            SubCategory = 0;
        }
    }
}
