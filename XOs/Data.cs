namespace XOs
{
    public class Data
    {
        public static List<string> players = new List<string>();
        public static int[,] field = { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 } };
        public static bool isFirstPlayer = true;
        public static string winner = String.Empty;
        public static int settedButtons = 0;
        public static int isWaiting = 0;
        public static void ResetAll()
        {
            if (players.Count == 2)
            {
                isWaiting = 0;
                ChatHub.ids.Clear();
                players = new List<string>();

            }

            int[,] newField = { { 1, 0 }, { 2, 0 }, { 3, 0 }, { 4, 0 }, { 5, 0 }, { 6, 0 }, { 7, 0 }, { 8, 0 }, { 9, 0 } };
            field = newField;
            isFirstPlayer = true;
            winner = String.Empty;
            settedButtons = 0;
        }
    }
}
