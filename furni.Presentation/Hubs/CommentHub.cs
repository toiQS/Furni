using System.Text.RegularExpressions;
using System;
using Microsoft.AspNetCore.SignalR;
using furni.Infrastructure.Data;

namespace furni.Presentation.Hubs
{
    public class CommentHub : Hub
    {
        private readonly ApplicationDbContext _context;

        public CommentHub(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task SendComment(string productId)
        {
            if (int.TryParse(productId, out int productIdInt))
            {
                var latestComment = _context.Review
                    .Where(re => re.ProductId == productIdInt)
                    .OrderByDescending(re => re.CreatedAt)
                    .Select(re => new
                    {
                        CommentId = re.Id,
                        CommentName = re.AppUser.FullName,
                        CommentText = re.Description,
                        CommentRating = re.Rating,
                        CommentCreatedAt = re.CreatedAt
                    })
                    .FirstOrDefault();

                if (latestComment != null)
                {
                    await Clients.Group(productId.ToString()).SendAsync("ReceiveComment", latestComment);
                }
            }
        }

        public async Task JoinGroup(string productId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, productId);
        }

        public async Task LeaveGroup(string productId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, productId);
        }
    }
}
