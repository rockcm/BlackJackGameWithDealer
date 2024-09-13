using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project2
{
    public class Rank
    {

        public static int GetCardValue(Card card)
        {
            switch (card.Face)
            {
                case Face.Ace:
                    return 11; // Initially, treat Ace as 11
                case Face.Two: return 2;
                case Face.Three: return 3;
                case Face.Four: return 4;
                case Face.Five: return 5;
                case Face.Six: return 6;
                case Face.Seven: return 7;
                case Face.Eight: return 8;
                case Face.Nine: return 9;
                case Face.Ten:
                case Face.Jack:
                case Face.Queen:
                case Face.King:
                    return 10;
                default:
                    return 0;
            }
        }


        public static int CalculateHandValue(List<Card> hand)
        {
            int totalValue = 0;
            int aceCount = 0;


            foreach (Card card in hand)
            {
                int cardValue = GetCardValue(card);
                totalValue += cardValue;


                if (card.Face == Face.Ace)
                    aceCount++;
            }

            //for aces to be 1s
            while (totalValue > 21 && aceCount > 0)
            {
                totalValue -= 10;
                aceCount--;
            }

            return totalValue;
        }
    }
}
