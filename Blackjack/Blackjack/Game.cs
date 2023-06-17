using System;

namespace Blackjack
{
    public class Game
    {
        public void Start()
        {
            Console.WriteLine("Welcome to Blackjack!");

            while (true)
            {
                string playCmd = DisplayPlayCmd();

                switch (playCmd)
                {
                    case "1":
                        PlayGame();
                        break;
                    case "2":
                        break;
                    default:
                        Console.WriteLine("You have entered an invaild option");
                        break;
                }

                Console.WriteLine("Would you like to play again? (y/n)");
                string playAgain = Console.ReadLine();
                if (playAgain.ToLower() != "y")
                {
                    break;
                }

                Console.Clear();
            }

            Console.WriteLine("Thank you for playing!");
        }

        private void PlayGame()
        {
            IDeck deck = new Deck();
            deck.Shuffle();

            IHand playerHand = new Hand();
            IHand dealerHand = new Hand();

            DealHand(deck, playerHand, dealerHand);
            DisplayHand(playerHand, dealerHand);

            // Player's turn
            while (true)
            {
                DisplayPlayCommands();
                string choice = Console.ReadLine().ToLower();

                if (choice == "3")
                {
                    DealToPlayer(deck, playerHand);

                    if (playerHand.GetTotalValue() > 21)
                    {
                        Console.WriteLine("Player busts! You lose.");
                        return;
                    }
                }
                else if (choice == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please try again.");
                }
            }

            // Dealer's turn
            Console.WriteLine("Dealer's turn: " + dealerHand);

            while (dealerHand.GetTotalValue() < 17)
            {
                DealToDealer(deck, dealerHand);
            }

            if (dealerHand.GetTotalValue() > 21)
            {
                Console.WriteLine("Dealer busts! You win.");
            }
            else if (dealerHand.GetTotalValue() > playerHand.GetTotalValue())
            {
                Console.WriteLine("Dealer wins!");
            }
            else if (dealerHand.GetTotalValue() < playerHand.GetTotalValue())
            {
                Console.WriteLine("You win!");
            }
            else
            {
                Console.WriteLine("It's a tie!");
            }

        }

        private void DealToPlayer(IDeck deck, IHand playerHand)
        {
            playerHand.AddCard(deck.DrawCard());
            Console.WriteLine("Player's hand: " + playerHand);
        }

        private void DealToDealer(IDeck deck, IHand dealerHand)
        {
            dealerHand.AddCard(deck.DrawCard());
            Console.WriteLine("Dealer's hand: " + dealerHand);
        }

        private void DisplayPlayCommands()
        {
            Console.WriteLine("Press 3 to hit");
            Console.WriteLine("Press 4 to stand");
        }

        private void DealHand(IDeck deck, IHand playerHand, IHand dealerHand)
        {
            dealerHand.AddCard(deck.DrawCard());
            playerHand.AddCard(deck.DrawCard());
            dealerHand.AddCard(deck.DrawCard());
            playerHand.AddCard(deck.DrawCard());
        }

        private void DisplayHand(IHand playerHand, IHand dealerHand)
        {
            Console.WriteLine("Player's Hand: " + playerHand);
            Console.WriteLine("Dealer's Hand: " + dealerHand.ToString().Split(',')[0] + ", [Hidden]");
            Console.WriteLine();
        }

        private string DisplayPlayCmd()
        {
            Console.WriteLine("Press 1 to deal...");
            Console.WriteLine("Press 2 to exit...");
            string playCmd = Console.ReadLine();
            Console.Clear();

            return playCmd;
        }
    }
}
