using SnapProblem.Enum;
using System;
using System.Collections.Generic;

namespace SnapProblem
{
    public class Program
    {
        static void Main(string[] args)
        {           
            Console.WriteLine("With how many Deck you want to play ?");
            MatchCriteria _matchCriteria;
            string nuberOfDeckAsString = Console.ReadLine();
            if (!Int32.TryParse(nuberOfDeckAsString, out int numberOfDeck))
            {
                Console.WriteLine("Input string is not in correct format");
                return;
            }

            if (numberOfDeck == 1)
            {
                Console.WriteLine("Matching Criteria would be : Rank should be matched");
                _matchCriteria = MatchCriteria.RANK;
            }
            else
            {
                Console.WriteLine("What would be your matching criteria ?");
                Console.WriteLine($"1- {MatchCriteria.RANK}");
                Console.WriteLine($"2- {MatchCriteria.SUIT}");
                Console.WriteLine($"3- {MatchCriteria.RANKANDSUIT}");
                string matchCriteriaAsString = Console.ReadLine();
                if (!Int32.TryParse(matchCriteriaAsString, out int matchCriteria))
                {
                    Console.WriteLine("Input string is not in correct format");
                    return;
                }

                _matchCriteria = (MatchCriteria)matchCriteria;
            }

            //Cache to store card for both the players
            List<Card> playerOne = new List<Card>();
            List<Card> playerTwo = new List<Card>();


            Snap snapGame = new Snap(numberOfDeck);
            ConsoleKeyInfo consoleKey;
            Console.WriteLine("Press the Enter key to quit.");
            Console.WriteLine("Press the Space key to Play. \n");

            try
            {
                consoleKey = Play(_matchCriteria, playerOne, playerTwo, snapGame);
                DisplayResult(playerOne, playerTwo, snapGame.IsCardsRemain, consoleKey);
            }
            catch(Exception ex)
            {
                Console.WriteLine($"There is a exception in the game. Details : {ex}");
            }

            //Reset console
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine(); // Console will not close
        }

        private static void DisplayResult(List<Card> playerOne, List<Card> playerTwo, bool isCardRemain, ConsoleKeyInfo consoleKey)
        {
            if (consoleKey.Key == ConsoleKey.Enter || !isCardRemain)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("*********************************************");
                Console.WriteLine($" Player one is having total {playerOne.Count} cards");
                Console.WriteLine($" Player two is having total {playerTwo.Count} cards");
                if (playerOne.Count == playerTwo.Count)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($" Match drawn");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    string st = playerOne.Count > playerTwo.Count ? "Player One" : "Player Two";
                    Console.WriteLine($" {st} won the match");
                }
                Console.WriteLine("*********************************************");
            }
        }

        private static ConsoleKeyInfo Play(MatchCriteria _matchCriteria, List<Card> playerOne, List<Card> playerTwo, Snap snapGame)
        {
            ConsoleKeyInfo consoleKey;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                consoleKey = Console.ReadKey();
                if (!snapGame.IsCardsRemain)
                    break;

                if (consoleKey.Key == ConsoleKey.Spacebar)
                {
                    snapGame.FlipNextCard();
                    Card topCard = snapGame.TopCard;
                    if (topCard != null)
                        Console.WriteLine($"Details of Top Card is : {topCard}");

                    bool isMatch = snapGame.IsCardMatchedWithCriteria(_matchCriteria);
                    if (isMatch)
                    {
                        Random random = new Random();
                        var playerWhoWin = random.Next(1, 3); // Player who told SNAP first

                        Console.ForegroundColor = ConsoleColor.Red;

                        string message;
                        if (playerWhoWin == 1)
                        {
                            playerOne.AddRange(snapGame.GetCardCollection);
                            message = $" Player one is having {playerOne.Count} cards";
                        }
                        else
                        {
                            playerTwo.AddRange(snapGame.GetCardCollection);
                            message = $" Player two is having {playerTwo.Count} cards";
                        }

                        Console.WriteLine($" It's match.Player {playerWhoWin} told  Snap! first. {message}");
                        snapGame.ResetCardColletion();
                    }
                }

            } while (consoleKey.Key != ConsoleKey.Enter || !snapGame.IsCardsRemain);
            return consoleKey;
        }
    }
}
