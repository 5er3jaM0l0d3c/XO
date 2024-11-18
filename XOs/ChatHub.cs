using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace XOs
{
    public class ChatHub : Hub
    {
        public static List<string> ids = new List<string>();
        public async Task SendMessage(string player, string button)
        {
            GameManager.Game(player, Convert.ToInt32(button));

            if (Data.winner != String.Empty)
            {
                await Clients.All.SendAsync("ReceiveWinner", Data.winner);
            }

            await Clients.Others.SendAsync("ReceiveMessage", player, button);
        }

        public async Task SendNotWaiting(string player)
        {
            if (!ids.Contains(player))
            {
                Data.isWaiting++;
                Console.WriteLine(Context.ConnectionId);
                ids.Add(player);

            }
            await Clients.All.SendAsync("ReceiveWaitingPlayer", Data.isWaiting);
        }

        public async Task CheckWaiting()
        {
            if (Data.isWaiting > 1)
            {
                await Clients.All.SendAsync("ReceiveWaitingPlayer", Data.isWaiting);
            }
        }
        public async Task SendLog(string log)
        {
            await Clients.All.SendAsync("ReceiveLogs", log);
        }

      
    }
}
