using AnnouncementsAPI.Dtos;
using AnnouncementsAPI.Enums;
using AnnouncementsAPI.Models;

namespace AnnouncementsAPI.Repositories.Interfaces
{
    public interface IAnnouncementRepository
    {
        Task<Announcement?> GetAnnouncementById(int id);
        Task<IEnumerable<Announcement>> GetAnnouncements(int? CategotyId, int? SubcategoryId);
        Task<ResultEnum> CreateAnnouncement(AnnouncementDto announcement);
        Task<ResultEnum> UpdateAnnouncement(AnnouncementUpdateDto announcement);
        Task<ResultEnum> DeleteAnnouncement(int announcementId);
    }
}
