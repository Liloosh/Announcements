using AnnouncementsAPI.Dtos;
using AnnouncementsAPI.Enums;
using AnnouncementsAPI.Models;
using AnnouncementsAPI.Repositories.Interfaces;
using AnnouncementsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsAPI.Services
{
    public class AnnouncementService(IAnnouncementRepository _announcementRepository): IAnnouncementService
    {
        public async Task<Announcement> GetAnnouncementById(int id)
        {
            return await _announcementRepository.GetAnnouncementById(id);
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncements(int? CategotyId,int? SubcategoryId) 
        {
            return await _announcementRepository.GetAnnouncements(CategotyId, SubcategoryId);
        }

        public async Task<ResultEnum> CreateAnnouncement(AnnouncementDto announcementDto)
        {
            return await _announcementRepository.CreateAnnouncement(announcementDto);
        }

        public async Task<ResultEnum> UpdateAnnouncement(AnnouncementUpdateDto announcement)
        {
            return await _announcementRepository.UpdateAnnouncement(announcement);
        }

        public async Task<ResultEnum> DeleteAnnouncement(int announcementId)
        {
            return await _announcementRepository.DeleteAnnouncement(announcementId);
        }
    }
}
