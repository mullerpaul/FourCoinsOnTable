using System;

namespace _538_problem
{
    class Program
    {
        static void TestCoin()
        {
            Coin coin1 = new Coin();

            // test coin methods
            // method calls need parens.     
            coin1.Display();
            coin1.Flip();
            coin1.Display();
            Console.WriteLine("GetStatus returns: " + coin1.GetStatus());
            Console.WriteLine();
        }
        static void TestTable()
        {
            // test table methods
            Table table1 = new Table();
            table1.PrintState();

            Console.WriteLine("Rotate 1 turn clockwise");
            table1.RotateClockwise(1);
            table1.PrintState();

            Console.WriteLine("Rotate 2 turns clockwise");
            table1.RotateClockwise(2);
            table1.PrintState();

            Console.WriteLine("Rotate 3 turns clockwise");
            table1.RotateClockwise(3);
            table1.PrintState();

            Console.WriteLine("Rotate 4 turns clockwise");
            table1.RotateClockwise(4);
            table1.PrintState();

            Console.WriteLine("Flip top left coin");
            table1.Flipcoin(true, false, false, false);
            table1.PrintState();

            Console.WriteLine("Flip top right and bottom right coins");
            table1.Flipcoin(false, true, false, true);
            table1.PrintState();

            Console.WriteLine("Flip random coins");
            table1.FlipRandomCoins();
            table1.PrintState();

            Console.WriteLine("Rotate clockwise random number or times");
            //table1.RotateClockwise("test");  -- should error
            table1.RotateClockwise("random");
            table1.PrintState();

            if (table1.GetVictoryStatus())
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Not a winning position.");
            }
        }
        static void RandomGuessesAndFlips()
        {
            Console.WriteLine("test random flips and turns");

            // declare and initialize variables
            int gameLimit = 200;
            int totalRounds = 0;
            int maxRounds = 0;
            int roundID;

            for (int i = 0; i < gameLimit; i++)
            {
                // start game - init table and round counter
                var gameTable = new Table();
                roundID = 0;

                // take turns while the board is not in victory configuration
                while (!gameTable.GetVictoryStatus())
                {
                    roundID++;
                    gameTable.FlipRandomCoins();
                    gameTable.RotateClockwise("random");
                }

                //Console.WriteLine("Won after " + roundID + " turns");
                totalRounds += roundID;
                if (roundID > maxRounds)
                {
                    maxRounds = roundID;
                }

            }
            Console.WriteLine(gameLimit + " rounds completed");
            Console.WriteLine("total rounds played " + totalRounds);
            Console.WriteLine("highest number of rounds in a game " + maxRounds);
            Console.WriteLine("average number of rounds in a game " + String.Format("{0:0.00}", decimal.Divide(totalRounds, gameLimit)));
        }

        static void PatternedGuesses()
        {
            Console.WriteLine("test specific pattern of guesses with random flips");

            // declare and initialize variables
            int gameLimit = 200;
            int totalRounds = 0;
            int maxRounds = 0;
            int roundID;

            for (int i = 0; i < gameLimit; i++)
            {
                // start game - init table and round counter
                var gameTable = new Table();
                roundID = 0;

                // take turns while the board is not in victory configuration
                while (!gameTable.GetVictoryStatus())
                {
                    roundID++;
                    switch (roundID)
                    {
                        case 1:
                        case 3:
                        case 5:
                        case 7:
                        case 9:
                        case 11:
                        case 13:
                        case 15:
                            gameTable.Flipcoin(true, true, true, true);     // flip four
                            break;
                        case 2:
                        case 6:
                        case 10:
                        case 14:
                            gameTable.Flipcoin(true, false, false, true);   // flip two opposite
                            break;
                        case 4:
                        case 12:
                            gameTable.Flipcoin(true, false, true, false);   // flip two adjacent
                            break;
                        case 8:
                            gameTable.Flipcoin(true, false, false, false);  // flip one
                            break;
                        default:
                            gameTable.FlipRandomCoins();  // shouldn't happen - verify
                            break;
                    }

                    gameTable.RotateClockwise("random");
                }

                //Console.WriteLine("Won after " + roundID + " turns");
                totalRounds += roundID;
                if (roundID > maxRounds)
                {
                    maxRounds = roundID;
                }

            }
            Console.WriteLine(gameLimit + " rounds completed");
            Console.WriteLine("total rounds played " + totalRounds);
            Console.WriteLine("highest number of rounds in a game " + maxRounds);
            Console.WriteLine("average number of rounds in a game " + String.Format("{0:0.00}", decimal.Divide(totalRounds, gameLimit)));
        }

        static void Main()
        {
            // I should move these into a unit test project.
            //TestCoin();
            //TestTable();

            RandomGuessesAndFlips();
            Console.WriteLine("---");
            PatternedGuesses();
        }
    }
}
