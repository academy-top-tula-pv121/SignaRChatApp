using Microsoft.AspNetCore.SignalR;

namespace SignaRChatApp
{
    public class ChatHub : Hub
    {
        public async Task Send(User user, string message)
        {
            await this.Clients.All.SendAsync("Receive", user, message);
        }

        public override async Task OnConnectedAsync()
        {
            await Clients.Caller.SendAsync("Notify", $"{Context.ConnectionId} welcome to chat!");
            await Clients.Others.SendAsync("Notify", $"{Context.ConnectionId} enter to to chat!");
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            await Clients.All.SendAsync("Notify", $"{Context.ConnectionId} exit from chat");
            await base.OnDisconnectedAsync(exception);
        }
    }
}
