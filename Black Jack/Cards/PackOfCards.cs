using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    public class PackOfCards
    {
        private Dictionary<Card, bool> Cards = new Dictionary<Card, bool>();
        private bool collected = false;

        public PackOfCards()
        {
            if (!collected)
            {
                collectCards();
                collected = true;
            }
        }

        private void collectCards()
        {
            for (Suit i = 0; i <= Suit.Хреста; i++)
            {
                for (Value j = 0; j <= Value.Туз; j++)
                {
                    Cards.Add(new Card(i, j), true);
                }
            }
        }

        public Card getCard()
        {
            Random randomizer = new Random();
            Suit suitOfCard = (Suit)randomizer.Next(4);
            Value valueOfCard = (Value)randomizer.Next(12);
            Card randomCard = new Card(suitOfCard, valueOfCard);
            if (Cards[randomCard])
            {
                Cards[randomCard] = false;
                return randomCard;
            }
            else
            {
                return getCard();
            }
        }
    }
}
