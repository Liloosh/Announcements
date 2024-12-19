namespace AnnouncementsAPI.Dtos
{
    public class AnnouncementDto
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public int Status { get; set; }
        public int Category { get; set; }
        public int SubCategory { get; set; }
        public string UserId { get; set; }
    }
}
