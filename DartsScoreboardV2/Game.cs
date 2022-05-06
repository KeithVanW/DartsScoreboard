namespace DartsScoreboardV2
{
    internal class Game
    {
        private Player player1;
        private Player player2;
        private Statistics statistics;
        public int MaxLegs { get; set; }

        public Game(Player player1, Player player2, Statistics statistics)
        {
            this.player1 = player1;
            this.player2 = player2;

            MaxLegs = GetLegs();
            // Dit is een goede manier!
            //statistics = new Statistics(new Player[] { player1, player2 });

            // dit is een betere manier

            this.statistics = statistics;
        }

        public int GetLegs()
        {
            do
            {
                Console.WriteLine("How many legs do you want to play? (enter a uneven number)");
                MaxLegs = Convert.ToInt32(Console.ReadLine());
            } while (MaxLegs % 2 == 0 && MaxLegs > 1);
            Console.WriteLine($"{player1.Name} will play {player2.Name} in a Best of {MaxLegs}");
            MaxLegs = Convert.ToInt32(Math.Ceiling((decimal)MaxLegs / 2));
            return MaxLegs;
        }

        public string PlayerToThrowFirst()
        {
            Random generator = new Random();
            int whoBegins = generator.Next(1, 3);
            string playerToThrow;

            if (whoBegins == 0)
            {
                playerToThrow = player1.Name;
                Console.WriteLine($"{player1.Name} will throw first");
            }
            else
            {
                playerToThrow = player2.Name;
                Console.WriteLine($"{player2.Name} will throw first");
            }
            return playerToThrow;
        }

        public void ScoreboardLayout()
        {
            Console.WriteLine($"\t\t{player1.Name}\t\t\t{player2.Name}");
            Console.WriteLine($"\t\t501\t\t\t501");
        }

        public void WinCheck()
        {
            if (player1.ScoreLeft == 0)
            {
                player1.LegsWon++;
                Console.WriteLine($"Score is {player1.LegsWon} legs for {player1.Name} and {player2.LegsWon} for {player2.Name}");
                player1.ResetScore();
                player2.ResetScore();
                if (player1.LegsWon == MaxLegs)
                {
                    Console.WriteLine($"{player1.Name} wins the game with an average of {player1.Average}");
                }
            }
            else
            {
                player2.LegsWon++;
                Console.WriteLine($"Score is {player1.LegsWon} legs for {player1.Name} and {player2.LegsWon} for {player2.Name}");
                player1.ResetScore();
                player2.ResetScore();
                if (player2.LegsWon == MaxLegs)
                {
                    Console.WriteLine($"{player2.Name} wins the game with an average of {player2.Average}");
                }
            }
            Console.WriteLine(statistics.GetAveragePlayerScore());
        }
    }
}