using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack.classes
{
    public class Card
    {

        public string FaceValue { get; }
        public int CardValue { get; }

        public int SoftCardValue { get; }

        public Card(string faceValue, int cardValue)
        {
            FaceValue = faceValue;
            CardValue = cardValue;
        }

        public Card(string faceValue, int cardValue, int softCardValue)
        {
            FaceValue = faceValue;
            CardValue = cardValue;
            SoftCardValue = softCardValue;
        }
        
        
    }
}
