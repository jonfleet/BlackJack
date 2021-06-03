using System;
using System.Collections.Generic;
using System.Text;
using blackjack.classes;

namespace blackjack
{
    class ConsoleService
    {
        public void Start()
        {

            bool keepPlaying;

            Console.WriteLine("Welcome to BlackJack!");

            do
            {
                //Todo start game method
                // Deck Object Returns Suffled Deck of 52 Cards
                Deck deck = new Deck();

                Hand houseHand = new Hand();
                Hand playerHand = new Hand();

                playerHand.Cards.Add(deck.Draw());
                houseHand.Cards.Add(deck.Draw());
                playerHand.Cards.Add(deck.Draw());
                
                
                Card hiddenCard = deck.Draw();
                // Flip Dealers Second Card if not Face Down already so it cannot be seen intially.
                if (!hiddenCard.FaceDown)
                {
                    hiddenCard.Flip();
                }
                houseHand.Cards.Add(hiddenCard);

                // Player's Turn
                PlayPlayerTurn(houseHand, playerHand, deck);

                // House's Turn
                PlayHouseTurn(houseHand, playerHand, deck);
                

                // Ask User if they would like to keep playing
                keepPlaying = PlayAgainMenu();

            } while (keepPlaying);
        }

        private void PlayPlayerTurn(Hand houseHand, Hand playerHand, Deck deck)
        {
            while (true)
            {
                // Display House and Player Hands

                ConsoleDisplayHand(houseHand, playerHand);

                // Check if Player's Card Total is at or above 21 points.
                if (playerHand.CardTotal > 21)
                {
                    ConsolePlayerBust();
                    break;
                }
                else if (playerHand.CardTotal == 21)
                {
                    ConsolePlayerBlackjack();
                    break;
                }

                // Hit or Stay
                Console.WriteLine("Would you like to hit [H] or stay [S]");
                string userInput = Console.ReadLine().ToLower();
                // Player Hits
                if (userInput == "h")
                {
                    playerHand.Cards.Add(deck.Draw());
                }
                // Player Stays
                else if (userInput == "s")
                {
                    break;
                }
            }
        }
        private void PlayHouseTurn(Hand houseHand, Hand playerHand, Deck deck)
        {
            if (playerHand.CardTotal < 21)
            {
                // Play Out House turn

                // Flip over House Card.
                houseHand.Cards[1].Flip();

                // Dealer Must Hit until 17
                // Dealer Must Hit on a Soft 17 (ACE & SIX)
                while (houseHand.CardTotal <= 17)
                {
                    houseHand.Cards.Add(deck.Draw());
                }

                // Print out Hands after Dealer Draws
                ConsoleDisplayHand(houseHand, playerHand);

                // Determine if Dealer or Player wins
                if (houseHand.CardTotal == 21)
                {
                    ConsoleDealerBlackjack();
                }
                else if (houseHand.CardTotal == playerHand.CardTotal)
                {
                    ConsoleDraw();
                }
                else if (houseHand.CardTotal > 21)
                {
                    ConsoleDealerBust();
                }
                else if (houseHand.CardTotal > playerHand.CardTotal)
                {
                    ConsoleDealerWin();
                }
                else
                {
                    ConsolePlayerWin();
                }
            }
        }
        private bool PlayAgainMenu()
        {
            // Menu asking user if they want to play again
            string keepPlaying; 
            while (true)
            {
                Console.WriteLine("Would you like to play again? (Y/N)");
                keepPlaying = Console.ReadLine().ToLower();

                if (keepPlaying == "n")
                {
                    return false;
                }
                else if (keepPlaying == "y")
                {
                    return true;
                }
            }
        }

        private void ConsoleDisplayHand(Hand houseHand, Hand playerHand)
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("House Hand");
            foreach (Card card in houseHand.Cards)
            {
                Console.WriteLine("---> " + card.FaceValue);
            }
            Console.WriteLine("");
            Console.WriteLine("---------------------");
            Console.WriteLine("Card Total is: " + houseHand.CardTotal);
            Console.WriteLine("---------------------");
            Console.WriteLine("");

            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("Player Hand");
            foreach (Card card in playerHand.Cards)
            {
                Console.WriteLine("---> " + card.FaceValue);
            }

            Console.WriteLine("");
            Console.WriteLine("---------------------");
            Console.WriteLine("Card Total is: " + playerHand.CardTotal);
            Console.WriteLine("---------------------");
            Console.WriteLine("");
        }
        //Todo Consider changing private
        private void ConsolePlayerBust()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("BUST!!!!! Better Luck Next Time");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        private void ConsoleDealerBust()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Dealer Bust! CONGRATULATIONS YOU WIN!!!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        private void ConsolePlayerBlackjack()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("BlackJack!!!!! Congratulations. You Win!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        private void ConsoleDealerBlackjack()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Dealer BlackJack :( Better Luck Next!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        private void ConsoleDraw()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Push.... It's a Draw!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        private void ConsoleDealerWin()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Dealer Wins :( Better Luck Next Time! ");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        private void ConsolePlayerWin()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Congratulations You Win!!!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }
    }
}
