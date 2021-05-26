using System;
using System.Collections.Generic;
using System.Text;

namespace blackjack.classes
{
    public class Card
    {

        private string _faceValue { get; set; }
        public string FaceValue 
        {
            get
            {
                if (FaceDown)
                {
                    return "FaceDown";
                } else
                {
                    return _faceValue;
                }
            }
            set 
            {
                _faceValue = value;
            }
        }
        public int CardValue { get; }

        public int SoftCardValue { get; }

        public bool FaceDown { get; private set; } = false;
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
        
        public void Flip()
        {
            FaceDown = !FaceDown;
        }
        
    }
}
