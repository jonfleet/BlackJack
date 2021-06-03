using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack.classes
{
    public class Ace : Card
    {
        public Ace() : base("Ace", 11){}

        public void ChangeAceValue()
        {
            if(CardValue  == 11)
            {
                CardValue = 1;
            } else
            {
                CardValue = 11;
            }
        }
    }
}
