using DartsScoreboardV2;

Player player1 = new Player("Keith");
Player player2 = new Player("Michiel");
Statistics statistics = new Statistics(new Player[] { player1, player2 });
Game game = new Game(player1, player2, statistics);
// Statistics statistics = new Statistics(player1, player2);

string playerToThrow = game.PlayerToThrowFirst();

do
{
    game.ScoreboardLayout();
    CalculateScores();
    game.WinCheck();

} while (player1.LegsWon < game.MaxLegs && player2.LegsWon < game.MaxLegs);

Console.ReadLine();



void CalculateScores()
    {
    while (player1.ScoreLeft != 0 && player2.ScoreLeft != 0)
    {
        if (playerToThrow == player1.Name)
        {
            Console.WriteLine($"{player1.Name}, enter your score");
            player1.Score = Convert.ToInt32(Console.ReadLine());
            player1.ScoreLeft -= player1.Score;
            player1.DartsThrown += 3;
            player1.Average = player1.CalculateAvg(player1.Score, player1.DartsThrown);
            Console.WriteLine($"\t{player1.Score}\t{player1.ScoreLeft}\t\t{player2.Score}\t{player2.ScoreLeft}");
            playerToThrow = player2.Name;
        }
        else
        {
            Console.WriteLine($"{player2.Name}, enter your score");
            player2.Score = Convert.ToInt32(Console.ReadLine());
            player2.ScoreLeft -= player2.Score;
            player2.DartsThrown += 3;
            player2.Average = player2.CalculateAvg(player2.Score, player2.DartsThrown);
            Console.WriteLine($"\t{player1.Score}\t{player1.ScoreLeft}\t\t{player2.Score}\t{player2.ScoreLeft}");
            playerToThrow = player1.Name;
        }
    }
}