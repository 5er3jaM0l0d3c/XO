using Microsoft.AspNetCore.SignalR;
using System.Numerics;

namespace XOs
{
    public class ChatHub:Hub
    {
        
        public async Task SendMessage(string player, string button)
        {
            GameManager.Game(player, Convert.ToInt32(button));

            if (Data.winner != String.Empty)
            {
                await Clients.All.SendAsync("ReceiveWinner", Data.winner);
            }

            await Clients.Others.SendAsync("ReceiveMessage", player, button);
        }
    }
}
