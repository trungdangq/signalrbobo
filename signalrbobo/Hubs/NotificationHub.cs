
using Microsoft.AspNetCore.SignalR;

namespace signalrbobo.Hubs
{
    public class NotificationHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.Group("AdminGroup").SendAsync("ReceiveMessage", user, message);
        }

        public async Task JoinGroup(string groupName)
        {
            //
            if(groupName == "Admin")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "AdminGroup");
            }
            else if (groupName == "Client")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "ClientGroup");
            }
            else if (groupName == "Driver")
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, "DriverGroup");
            }
        }
    }
}
