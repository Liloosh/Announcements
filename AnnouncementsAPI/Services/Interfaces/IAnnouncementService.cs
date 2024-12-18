using AnnouncementsAPI.Dtos;
using AnnouncementsAPI.Enums;
using AnnouncementsAPI.Models;

namespace AnnouncementsAPI.Services.Interfaces
{
    public interface IAnnouncementService
    {
        Task<Announcement> GetAnnouncementById(int id);
        Task<IEnumerable<Announcement>> GetAnnouncements(int? CategotyId, int? SubcategoryId);
        Task<ResultEnum> CreateAnnouncement(AnnouncementDto announcementDto);
        Task<ResultEnum> UpdateAnnouncement(AnnouncementUpdateDto announcement);
        Task<ResultEnum> DeleteAnnouncement(int announcementId);
    }
}
