using Microsoft.AspNetCore.SignalR;

namespace Employee_SignalR
{
    public class EntryPoint : Hub
    {
        public void BroadcastToGroupName(string groupName, string information)
        {
            Clients.Group(groupName).InvokeAsync("ClientMethod", $"{information} - {groupName}");
        }


        public void RegisterConnectionOnGroup(string groupName)
        {
            Groups.AddAsync(Context.ConnectionId, groupName);
        }
    }
}
