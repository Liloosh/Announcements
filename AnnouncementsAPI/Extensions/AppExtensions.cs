using AnnouncementsAPI.Repositories;
using AnnouncementsAPI.Repositories.Interfaces;
using AnnouncementsAPI.Services;
using AnnouncementsAPI.Services.Interfaces;

namespace AnnouncementsAPI.Extensions
{
    public static class AppExtensions
    {
        public static void ConfigureRepositories(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAnnouncementRepository, AnnouncementRepository>();
            serviceCollection.AddScoped<IUserRepository, UserRepository>();
        }

        public static void ConfigureServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IAnnouncementService, AnnouncementService>();
            serviceCollection.AddScoped<IUserService, UserService>();
        }
    }
}
