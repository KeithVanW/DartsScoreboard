namespace DartsScoreboardV2
{
    internal class Statistics
    {
        private Player[] players;

        public Statistics(Player[] players)
        {
            this.players = players;
        }

        public int GetAveragePlayerScore()
        {
            double result = 0;

            foreach (Player player in players)
            {
                result += player.Average;
            }
            result /= players.Length;

            return (int)result;
        }
        public void GetHighScore(){}
    }
}