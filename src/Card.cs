using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json.Linq;

namespace Nancy.Simple
{
    public enum CardRank
    {
        K,
        Q,
        J,
        Ten,
        Nine,
        Eight,
        Seven,
        Six,
        Five,
        Four,
        Three,
        Two,
        Ace
    }

    public enum CardSuit
    {
        Spades,
        Hearts,
        Clubs,
        Diamonds
    }

    public class Card
    {
        public string RankString { get; set; }
        public string SuitString { get; set; }
        public CardRank Rank { get; set; }
        public CardSuit Suit { get; set; }
        public double index { get; set;  }

        public void ParseCards(JObject cardObject)
        {
            RankString = (string)cardObject.SelectToken("rank");
            SuitString = (string)cardObject.SelectToken("suit");
            Rank = ToCardRank(RankString);
            Suit = ToCardSuit(SuitString);
        }

        public void getCardValue (Card card){
            switch (card.Rank) {
            case CardRank.Ace:
                index = 10;
                break;
            case CardRank.K:
                index = 8;
                break;
            case CardRank.Q:
                index = 7;
                break;
            case CardRank.J:
                index = 6;
                break;
            case CardRank.Ten:
                index = 5;
                break;
            case CardRank.Nine:
                index = 4.5;
                break;
            case CardRank.Eight:
                index = 4;
                break;
            case CardRank.Seven:
                index = 3.5;
                break;
            case CardRank.Six:
                index = 3;
                break;
            case CardRank.Five:
                index = 2.5;
                break;
            case CardRank.Four:
                index = 2;
                break;
            case CardRank.Three:
                index = 1.5;
                break;
            case CardRank.Two:
                index = 1;
                break;
            }
        }
        private CardRank ToCardRank(string rankString)
        {
            if (rankString == "A")
            {
                return CardRank.Ace;
            }
            if (rankString == "2")
            {
                return CardRank.Two;
            }
            if (rankString == "3")
            {
                return CardRank.Three;
            }
            if (rankString == "4")
            {
                return CardRank.Four;
            }
            if (rankString == "5")
            {
                return CardRank.Five;
            }
            if (rankString == "6")
            {
                return CardRank.Six;
            }
            if (rankString == "7")
            {
                return CardRank.Seven;
            }
            if (rankString == "8")
            {
                return CardRank.Eight;
            }
            if (rankString == "9")
            {
                return CardRank.Nine;
            }
            if (rankString == "10")
            {
                return CardRank.Ten;
            }
            if (rankString == "J")
            {
                return CardRank.J;
            }
            if (rankString == "Q")
            {
                return CardRank.Q;
            }
            if (rankString == "K")
            {
                return CardRank.K;
            }

            return CardRank.Ace;
        }

        private CardSuit ToCardSuit(string suitString)
        {
            if (suitString == "spades")
            {
                return CardSuit.Spades;
            }
            if (suitString == "hearts")
            {
                return CardSuit.Hearts;
            }
            if (suitString == "clubs")
            {
                return CardSuit.Clubs;
            }
            if (suitString == "diamonds")
            {
                return CardSuit.Diamonds;
            }

            return CardSuit.Diamonds;
        }
    }
}
