using AnnouncementsAPI.Dtos;
using AnnouncementsAPI.Enums;
using AnnouncementsAPI.Models;
using AnnouncementsAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AnnouncementsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementController(IAnnouncementService _announcementService) : ControllerBase
    {
        [HttpGet]
        [Route("{id:int}")]
        [ProducesResponseType(typeof(Announcement), StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAnnouncementById(int id)
        {
            var announcement = await _announcementService.GetAnnouncementById(id);
            return Ok(announcement);
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Announcement>) ,StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAnnouncemnts([FromQuery] int? CategotyId, [FromQuery] int? SubcategoryId)
        {
            var announcements = await _announcementService.GetAnnouncements(CategotyId, SubcategoryId);
            return Ok(announcements);
        }

        [HttpPost]
        [Authorize(AuthenticationSchemes = "Bearer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateAnnouncement([FromBody]AnnouncementDto announcementDto)
        {
            ResultEnum result = await _announcementService.CreateAnnouncement(announcementDto);
            if (result == ResultEnum.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpPut]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "AnnouncementRequirements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateAnnouncement([FromBody] AnnouncementUpdateDto announcement)
        {
            ResultEnum result = await _announcementService.UpdateAnnouncement(announcement);
            if (result == ResultEnum.Success)
            {
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        [Route("{announcementId:int}")]
        [Authorize(AuthenticationSchemes = "Bearer", Policy = "AnnouncementRequirements")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> DeleteAnnouncement([FromRoute] int announcementId)
        {
            ResultEnum result = await _announcementService.DeleteAnnouncement(announcementId);
            if (result == ResultEnum.Success)
            {
                return Ok();
            }
            return BadRequest();
        }
    }
}
