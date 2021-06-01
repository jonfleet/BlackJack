using blackjack.classes;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
 

namespace BlackjackTests
{
    [TestClass]
    public class testHand
    {
        // 2 A K A 2 2 A K
        [TestMethod]
        public void TwoAceKing()
        {
            Hand hand = new Hand();
            List<Card> cards = new List<Card>();

            cards.Add(new Card("Two", 2));
            cards.Add(new Ace());
            cards.Add(new Card("King", 10));

            Assert.AreEqual(13, hand.FindTotal(cards));
        }

        [TestMethod]
        public void TwoAceKingAceTwoTwo()
        {
            Hand hand = new Hand();
            List<Card> cards = new List<Card>();

            cards.Add(new Card("Two", 2));
            cards.Add(new Ace());
            cards.Add(new Card("King", 10));
            cards.Add(new Ace());
            cards.Add(new Card("Two", 2));
            cards.Add(new Card("Two", 2));

            Assert.AreEqual(18, hand.FindTotal(cards));
        }
        [TestMethod]
        public void TwoAceKingAceTwoTwoAce()
        {
            Hand hand = new Hand();
            List<Card> cards = new List<Card>();

            cards.Add(new Card("Two", 2));
            cards.Add(new Ace());
            cards.Add(new Card("King", 10));
            cards.Add(new Ace());
            cards.Add(new Card("Two", 2));
            cards.Add(new Card("Two", 2));
            cards.Add(new Ace());

            Assert.AreEqual(19, hand.FindTotal(cards));
        }

        [TestMethod]
        public void TwoAceKingAceTwoTwoAceKing()
        {
            Hand hand = new Hand();
            List<Card> cards = new List<Card>();

            cards.Add(new Card("Two", 2));
            cards.Add(new Ace());
            cards.Add(new Card("King", 10));
            cards.Add(new Ace());
            cards.Add(new Card("Two", 2));
            cards.Add(new Card("Two", 2));
            cards.Add(new Ace());
            cards.Add(new Card("King", 10));

            Assert.AreEqual(29, hand.FindTotal(cards));
        }

        [TestMethod]
        public void AceAceAce()
        {
            Hand hand = new Hand();
            List<Card> cards = new List<Card>();

            
            cards.Add(new Ace());
            cards.Add(new Ace());
            cards.Add(new Ace());
            

            Assert.AreEqual(13, hand.FindTotal(cards));
        }
        [TestMethod]
        public void AceAceAceKing()
        {
            Hand hand = new Hand();
            List<Card> cards = new List<Card>();


            cards.Add(new Ace());
            cards.Add(new Ace());
            cards.Add(new Ace());
            cards.Add(new Card("King", 10));

            Assert.AreEqual(13, hand.FindTotal(cards));
        }
    }
}
