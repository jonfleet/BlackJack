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
                int total = 0;
                foreach( Card card in Cards)
                {
                    if (!card.FaceDown)
                    {
                        total += card.CardValue;
                    }
                    
                }
                return total;
            }
        }
    }
}
