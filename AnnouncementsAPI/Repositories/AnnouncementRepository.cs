using AnnouncementsAPI.Dtos;
using AnnouncementsAPI.Enums;
using AnnouncementsAPI.Models;
using AnnouncementsAPI.Repositories.Interfaces;
using Dapper;
using System.Data.SqlClient;

namespace AnnouncementsAPI.Repositories
{
    public class AnnouncementRepository : IAnnouncementRepository
    {
        private readonly string connectionString;

        public AnnouncementRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<Announcement?> GetAnnouncementById(int id)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var announcement = await connection.QueryFirstAsync<Announcement>("SelectAnnouncementById", new { Id = id }, commandType: System.Data.CommandType.StoredProcedure);
                return announcement;
            }
        }

        public async Task<IEnumerable<Announcement>> GetAnnouncements(int? CategoryId, int? SubcategoryId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var announcements = await connection.QueryAsync<Announcement>("SelectAnnouncements", new { CategoryId, SubcategoryId }, commandType: System.Data.CommandType.StoredProcedure);
                return announcements;
            }
        }

        public async Task<ResultEnum> CreateAnnouncement(AnnouncementDto announcement)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync("InsertAnnouncement", announcement, commandType: System.Data.CommandType.StoredProcedure);
                if(result == 1)
                {
                    return ResultEnum.Success;
                }
            }

            return ResultEnum.Failer;
        }

        public async Task<ResultEnum> UpdateAnnouncement(AnnouncementUpdateDto announcement)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync("UpdateAnnouncement", announcement, commandType: System.Data.CommandType.StoredProcedure);
                if (result == 1)
                {
                    return ResultEnum.Success;
                }
            }

            return ResultEnum.Failer;
        }

        public async Task<ResultEnum> DeleteAnnouncement(int announcementId)
        {
            using (var connection = new SqlConnection(connectionString))
            {
                var result = await connection.ExecuteAsync("DeleteAnnouncement", new { id = announcementId }, commandType: System.Data.CommandType.StoredProcedure);
                if (result == 1)
                {
                    return ResultEnum.Success;
                }
            }

            return ResultEnum.Failer;
        }
    }
}
