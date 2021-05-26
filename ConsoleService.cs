﻿using System;
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
                Deck newDeck = new Deck();

                Hand houseHand = new Hand();
                Hand playerHand = new Hand();

                playerHand.Cards.Add(newDeck.Draw());
                houseHand.Cards.Add(newDeck.Draw());
                playerHand.Cards.Add(newDeck.Draw());
                houseHand.Cards.Add(newDeck.Draw());

                while (true)
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

                    Console.WriteLine("Would you like to hit [H] or stay [S]");
                    string userInput = Console.ReadLine().ToLower();
                    if (userInput == "h")
                    {
                        playerHand.Cards.Add(newDeck.Draw());
                    }
                    else if (userInput == "s")
                    {
                        break;
                    }

                }
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
    }
}
