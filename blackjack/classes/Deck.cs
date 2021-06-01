using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack.classes
{
    public class Deck
    {
        public List<Card> deck { get; } = new List<Card>();

        public Deck()
        {
            CreateDeck();
            ShuffleDeck();
            
        }
        private void CreateDeck()
        {
            for(int i = 0; i < 4; i++)
            {
                deck.Add(new Ace());
                deck.Add(new Card("Two", 2));
                deck.Add(new Card("Three", 3));
                deck.Add(new Card("Four", 4));
                deck.Add(new Card("Five", 5));
                deck.Add(new Card("Six", 6));
                deck.Add(new Card("Seven", 7));
                deck.Add(new Card("Eight", 8));
                deck.Add(new Card("Nine", 9));
                deck.Add(new Card("Ten", 10));
                deck.Add(new Card("Jack", 10));
                deck.Add(new Card("Queen", 10));
                deck.Add(new Card("King", 10));
            }
            
        }
        
        public void PrintDeck()
        {
            Console.WriteLine($"There are {deck.Count} cards currently in the deck.");
            foreach (Card card in deck)
            {
                Console.WriteLine(card.FaceValue);
            }
        }
        public void ShuffleDeck()
        {
            Random randomNumber = new Random();

            for(int i = 0; i < 2000; i++)
            {
                int randomInt = randomNumber.Next(deck.Count);
                Card temp = deck[randomInt];
                deck.RemoveAt(randomInt);
                deck.Add(temp);
            }
        }

        public Card Draw()
        {
            // Handle Null List Values
            Card drawnCard = deck[0];
            deck.RemoveAt(0);
            deck.Add(drawnCard);

            return drawnCard;
        }

        

        
    }
}
