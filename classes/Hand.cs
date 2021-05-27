using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack.classes
{
    class Hand 
    {
        public List<Card> Cards { get; set; } = new List<Card>();
        public int CardTotal 
        {
            get
            {
                return FindTotal(Cards);
            }
        }

        // Determine if list has any Ace objects with a CardValue of 11 and return their index.
        private List<int> FindAces(List<Card> Cards)
        {
            List<int> aceIndexs = new List<int>();

            for(int i = 0; i < Cards.Count; i++)
            {
                if(Cards[i] is Ace && Cards[i].CardValue == 1)
                {
                    aceIndexs.Add(i);
                }
            }

            return aceIndexs;
        }

        // FindTotal Value of the Play Cards
            // Determines if Ace CardValue should be 11 or 1

        private int FindTotal(List<Card> Cards)
        {
            int total = 0;

            foreach (Card card in Cards)
            {
                if (!card.FaceDown)
                {
                    if (total + card.CardValue > 21 && card is Ace)
                    {
                        ((Ace)card).ChangeAceValue((Ace)card);
                    }
                    else if (total + card.CardValue > 21)
                    {
                        List<int> aceIndexs = FindAces(Cards);
                        if (aceIndexs.Count > 0)
                        {
                            ((Ace)Cards[aceIndexs[0]]).ChangeAceValue((Ace)card);
                            
                            FindTotal(Cards);
                        }
                    }

                    total += card.CardValue;
                }
            }
            return total;
        }
    }
}
