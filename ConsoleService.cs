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
            Deck newDeck = new Deck();

            Console.WriteLine("Welcome to BlackJack!");

            do
            {
                Card firstPlayerCard = newDeck.Draw();
                Card firstHouseCard = newDeck.Draw();
                Card secondPlayerCard = newDeck.Draw();
                Card secondHouseCard = newDeck.Draw();

                int houseTotal = firstHouseCard.CardValue + secondHouseCard.CardValue;
                int playerTotal = firstPlayerCard.CardValue + secondPlayerCard.CardValue;

                Console.WriteLine($"House: {firstHouseCard.FaceValue}, {secondHouseCard.FaceValue} ------ Total: {houseTotal}");
                Console.WriteLine($"Player: {firstPlayerCard.FaceValue}, {secondPlayerCard.FaceValue} ------ Total: {playerTotal}");
                
                do
                {
                    Console.WriteLine("Would you like to play again? (Y/N)");
                    keepPlaying = Console.ReadLine().ToLower();
                    Console.WriteLine(keepPlaying);
                } while (keepPlaying != "y" && keepPlaying != "n");
                
            } while (keepPlaying.Equals("y"));
            

        }
    }
}
