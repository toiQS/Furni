using Furni.API.Models;
using Furni.Entities;
using Furni.Services.member;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Furni.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly IMemberServices _memberService;

        public MemberController(IMemberServices memberService)
        {
            _memberService = memberService;
        }

        // Chỉ cho phép Admin hoặc Manager xem danh sách các thành viên
        [HttpGet]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetMembersAsync()
        {
            var members = await _memberService.GetMembersAsync();
            if (members == null || !members.Any())
                return NotFound(ServiceResult<string>.FailureResult("No members found"));

            var result = members.Select(x => new MemberModel
            {
                FullName = x.FullName,
                IsDeleted = x.IsDeleted,
                MemberId = x.MemberId,
                Position = x.Position,
                Summary = x.Summary,
                URLImage = x.URLImage
            });

            return Ok(ServiceResult<IEnumerable<MemberModel>>.SuccessResult(result));
        }

        // Tìm kiếm thành viên theo text (Admin hoặc Manager)
        [HttpGet("search")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetMembersByTextAsync([FromQuery] string text)
        {
            if (string.IsNullOrEmpty(text))
                return BadRequest(ServiceResult<string>.FailureResult("Search text is required"));

            var data = await _memberService.GetMembersByTextAsync(text);
            if (data == null || !data.Any())
                return NotFound(ServiceResult<string>.FailureResult("No members found for the given text"));

            var result = data.Select(x => new MemberModel
            {
                FullName = x.FullName,
                IsDeleted = x.IsDeleted,
                MemberId = x.MemberId,
                Position = x.Position,
                Summary = x.Summary,
                URLImage = x.URLImage
            }).ToList();

            return Ok(ServiceResult<IEnumerable<MemberModel>>.SuccessResult(result));
        }

        // Lấy thành viên theo ID (Admin hoặc Manager)
        [HttpGet("{memberId}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> GetMemberById(string memberId)
        {
            if (string.IsNullOrEmpty(memberId))
                return BadRequest(ServiceResult<string>.FailureResult("Member ID is required"));

            var data = await _memberService.GetMemberById(memberId);
            if (data == null)
                return NotFound(ServiceResult<string>.FailureResult("Member not found"));

            var result = new MemberModel
            {
                FullName = data.FullName,
                IsDeleted = data.IsDeleted,
                MemberId = data.MemberId,
                Position = data.Position,
                Summary = data.Summary,
                URLImage = data.URLImage
            };

            return Ok(ServiceResult<MemberModel>.SuccessResult(result));
        }

        // Tạo thành viên mới (Chỉ dành cho Admin)
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateAsync(string firstName, string? middleName, string lastName, string position, string summary, string urlImage)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(urlImage) || string.IsNullOrEmpty(summary))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input"));

            var result = await _memberService.CreateAsync(firstName, middleName, lastName, position, summary, urlImage);
            if (result)
                return StatusCode(StatusCodes.Status201Created, ServiceResult<string>.SuccessResult("Member created successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Failed to create member"));
        }

        // Cập nhật thông tin thành viên (Admin hoặc Manager)
        [HttpPut("{memberId}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> UpdateAsync(string memberId, string firstName, string? middleName, string lastName, string position, string summary, string urlImage)
        {
            if (string.IsNullOrEmpty(memberId) || string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName) || string.IsNullOrEmpty(position) || string.IsNullOrEmpty(urlImage) || string.IsNullOrEmpty(summary))
                return BadRequest(ServiceResult<string>.FailureResult("Invalid input"));

            var result = await _memberService.UpdateAsync(memberId, firstName, middleName, lastName, position, summary, urlImage);
            if (result)
                return NoContent(); // 204 No Content

            return BadRequest(ServiceResult<string>.FailureResult("Failed to update member"));
        }

        // Đánh dấu thành viên đã bị xóa (Admin hoặc Manager)
        [HttpPut("markDeleted/{memberId}")]
        [Authorize(Roles = "Admin, Manager")]
        public async Task<IActionResult> MarkMemberAsDeletedAsync(string memberId)
        {
            if (string.IsNullOrEmpty(memberId))
                return BadRequest(ServiceResult<string>.FailureResult("Member ID is required"));

            var result = await _memberService.UpdateAsync(memberId);
            if (result)
                return Ok(ServiceResult<string>.SuccessResult("Member marked as deleted successfully"));

            return BadRequest(ServiceResult<string>.FailureResult("Failed to update member"));
        }

        // Xóa thành viên (Chỉ dành cho Admin)
        [HttpDelete("{memberId}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteAsync(string memberId)
        {
            if (string.IsNullOrEmpty(memberId))
                return BadRequest(ServiceResult<string>.FailureResult("Member ID is required"));

            var result = await _memberService.DeleteAsync(memberId);
            if (result)
                return NoContent(); // 204 No Content

            return BadRequest(ServiceResult<string>.FailureResult("Failed to delete member"));
        }
    }
}
