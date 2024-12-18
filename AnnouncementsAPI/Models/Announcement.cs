namespace AnnouncementsAPI.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime CreatedDate { get; set; }
        public required int Status { get; set; }
        public required int Category { get; set; }
        public int SubCategory { get; set; }
    }
}
