using AnnouncementsAPI.Models;
using AnnouncementsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System;
using System.IO;
using System.Text.Json;

namespace AnnouncementsAPI.Requirements
{
    public class AnnouncementRequirementHandler : AuthorizationHandler<AnnouncementRequirements>
    {
        protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, AnnouncementRequirements requirement)
        {
            var httpContext = (HttpContext)context.Resource!;
            if (httpContext.Request.Method == "DELETE")
            {
                var announcementExist = httpContext.Request.RouteValues.TryGetValue("announcementId", out object? announcementId);

                if (announcementExist)
                {
                    var userIdJwt = httpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;

                    if (string.IsNullOrEmpty(userIdJwt))
                    {
                        return;
                    }

                    var services = httpContext.RequestServices;

                    var announcementService = services.GetRequiredService<IAnnouncementService>();
                    var announcement = await announcementService.GetAnnouncementById(Int32.Parse(announcementId.ToString()));
                    if (announcement.UserId == userIdJwt)
                    {
                        context.Succeed(requirement);
                    }
                }
            }
            else if (httpContext.Request.Method == "PUT")
            {
                using (var streamReader = new StreamReader(httpContext.Request.Body))
                {
                    var bodyContent = await streamReader.ReadToEndAsync();
                    var announcementBody = JsonSerializer.Deserialize<Announcement>(bodyContent, new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    });

                    if (announcementBody != null)
                    {
                        var userIdJwt = httpContext.User.Claims.FirstOrDefault(x => x.Type == "UserId")?.Value;

                        if (string.IsNullOrEmpty(userIdJwt))
                        {
                            return;
                        }

                        var services = httpContext.RequestServices;

                        var announcementService = services.GetRequiredService<IAnnouncementService>();
                        var announcement = await announcementService.GetAnnouncementById(announcementBody.Id);
                        if (announcement.UserId == userIdJwt)
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
        }
    }
}
