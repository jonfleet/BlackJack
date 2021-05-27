using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack.classes
{
    class Ace : Card
    {
        public Ace() : base("Ace", 11){}

        public void ChangeAceValue(Ace ace)
        {
            if(ace.CardValue  == 11)
            {
                ace.CardValue = 1;
            } else
            {
                ace.CardValue = 11;
            }
        }
    }
}
