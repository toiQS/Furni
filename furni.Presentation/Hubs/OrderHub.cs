using Microsoft.AspNetCore.SignalR;

namespace furni.Presentation.Hubs
{
    public class OrderHub : Hub
    {
        public async Task SendOrder()
		{
			await Clients.All.SendAsync("ReceiveOrder");
		}
    }
}
