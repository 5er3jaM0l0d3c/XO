using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace XOs
{
    public static class GameManager
    {
        private static int[,] combines = new int[8, 3] { { 1, 2, 3 }, { 4, 5, 6 }, { 7, 8, 9 }, { 1, 4, 7 }, { 2, 5, 8 }, { 3, 6, 9 }, { 1, 5, 9 }, { 3, 5, 7 } };

        public static async void Game(string player, int btn)
        {
            if (Data.players[0] == player && Data.isFirstPlayer)
            {
                SetButton(btn, 0);
            }
            try
            {
                if (Data.players[1] == player && !Data.isFirstPlayer)
                {
                    SetButton(btn, 1);
                }
            }
            catch { }

            int winner = await CheckGame();

            if (winner == 3)
            {
                Data.winner = "nobody";
            }
            else if(winner != -1)
            {
                Data.winner = Data.players[winner];
            }
        }
        private static void SetButton(int btn, int playerId)
        {
            //проверка на то, не занята ли клетка выполняется на клиенте
            if (playerId == 0)
            {
                Data.field[btn - 1, 1] = 1;
            }
            else
            {
                Data.field[btn - 1, 1] = 2;
            }
            Data.isFirstPlayer = !Data.isFirstPlayer;
            Data.settedButtons++;
        }

        public static Task<int> CheckGame()
        {
            bool isWin = false;
            for (int id = 0; id < 2; id++)
            {
                for (int i = 0; i < 8; i++)
                {
                    isWin = true;
                    for (int j = 0; j < 3; j++)
                    {
                        if (Data.field[combines[i, j] - 1, 1] != 1 + id)
                        {
                            isWin = false;
                        }
                    }
                    if (isWin)
                        break;
                }
                if (isWin)
                    return Task.FromResult(id);
            }
            if (Data.settedButtons == 9)
            {
                return Task.FromResult(3);
            }
            return Task.FromResult(-1);
        }
    }
}
