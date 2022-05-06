namespace DartsScoreboardV2
{
    public class Player
    {
        public string Name { get; set; }
        public int Score { get; set; }
        public int ScoreLeft { get; set; } = 501;
        public double Average { get; set; }
        public int LegsWon { get; set; }
        public int DartsThrown { get; set; }
        public int TotalScore { get; set; }

        public Player(string PlayerName)
        {
            Name = PlayerName;
        }
        public double CalculateAvg(int Score, int DartsThrown)
        {
            if (TotalScore == 0)
            {
                TotalScore = Score;
            }
            else 
            {
                TotalScore += Score;
            }
            double Average = TotalScore / (DartsThrown/3);
            return Average;
        }
        public void ResetScore()
        {
            ScoreLeft = 501;
        }
    }
}
