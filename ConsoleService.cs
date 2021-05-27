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

            string keepPlaying;

            Console.WriteLine("Welcome to BlackJack!");

            do
            {
                // Deck Object Returns Suffled Deck of 52 Cards
                Deck newDeck = new Deck();

                Hand houseHand = new Hand();
                Hand playerHand = new Hand();

                playerHand.Cards.Add(newDeck.Draw());
                houseHand.Cards.Add(newDeck.Draw());
                playerHand.Cards.Add(newDeck.Draw());
                
                // Flip Dealers Second Card so it cannot be seen intially.
                Card hiddenCard = newDeck.Draw();
                hiddenCard.Flip();
                houseHand.Cards.Add(hiddenCard);

                while (true)
                {
                    // Display House and Player Hands

                    ConsoleDisplayHand(houseHand, playerHand);

                    // Check if Player's Card Total is at or above 21 points.
                    if(playerHand.CardTotal > 21)
                    {
                        ConsolePlayerBust();
                        break;
                    } else if(playerHand.CardTotal == 21)
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
                        playerHand.Cards.Add(newDeck.Draw());
                    }
                    // Player Stays
                    else if (userInput == "s")
                    {
                        break;
                    }
                }

                if (playerHand.CardTotal < 21)
                {
                    // Play Out House turn

                    // Flip over House Card.
                    houseHand.Cards[1].Flip();

                    // Dealer Must Hit until 17
                    // Dealer Must Hit on a Soft 17 (ACE & SIX)
                    while (houseHand.CardTotal <= 17)
                    {
                        houseHand.Cards.Add(newDeck.Draw());
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
               
                // Menu asking user if they want to play again
                while (true)
                {
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    keepPlaying = Console.ReadLine().ToLower();

                    if (keepPlaying == "n")
                    {
                        return;
                    }
                    else if (keepPlaying == "y")
                    {
                        break;
                    }
                }

            } while (keepPlaying == "y");
        }

        public void ConsoleDisplayHand(Hand houseHand, Hand playerHand)
        {
            Console.WriteLine("House Hand");
            foreach (Card card in houseHand.Cards)
            {
                Console.WriteLine("---> " + card.FaceValue);
            }

            Console.WriteLine("____________");
            Console.WriteLine("Card Total is: " + houseHand.CardTotal);
            Console.WriteLine("____________");

            Console.WriteLine("Player Hand");
            foreach (Card card in playerHand.Cards)
            {
                Console.WriteLine("---> " + card.FaceValue);
            }

            Console.WriteLine("____________");
            Console.WriteLine("Card Total is: " + playerHand.CardTotal);
            Console.WriteLine("____________");
        }

        public void ConsolePlayerBust()
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("BUST!!!!! Better Luck Next Time");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
        }

        public void ConsoleDealerBust()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Dealer Bust! CONGRATULATIONS YOU WIN!!!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        public void ConsolePlayerBlackjack()
        {
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("BlackJack!!!!! Congratulations. You Win!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXX");
        }

        public void ConsoleDealerBlackjack()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Dealer BlackJack :( Better Luck Next!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        public void ConsoleDraw()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Push.... It's a Draw!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        public void ConsoleDealerWin()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Dealer Wins :( Better Luck Next Time! ");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }

        public void ConsolePlayerWin()
        {
            Console.WriteLine("");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("Congratulations You Win!!!");
            Console.WriteLine("XXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXXX");
            Console.WriteLine("");
        }
    }
}
