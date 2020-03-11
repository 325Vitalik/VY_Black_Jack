using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    public struct Card
    {
        private Suit _suit;
        private Value _value;

        public Suit CardSuit 
        {
            get
            {
                return this._suit;
            }
        }

        public Value CardValue
        {
            get
            {
                return this._value;
            }
        }

        public Card(Suit suitOfCard, Value valueOfCard)
        {
            this._suit = suitOfCard;
            this._value = valueOfCard;
        }

        public override string ToString()
        {
            return $"{_suit} | {_value}";
        }
    }
}
