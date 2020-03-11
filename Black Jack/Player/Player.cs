using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    public class Player : IPerson
    {
        public bool CanPlay { get; private set; } = false;
        public int CountOfPlayer { get; private set; } = 0;
        string IPerson.Name => _name;

        private List<Card> cardsOfPerson;
        private Wallet moneyOfPlayer;
        private string _name;
        public Player(string name)
        {
            cardsOfPerson = new List<Card>();
            this.moneyOfPlayer = new Wallet();
            this._name = name;
            this.CanPlay = true;
        }

        public Player(IPerson player)
        {
            cardsOfPerson = new List<Card>();
            this.moneyOfPlayer = new Wallet(player.ShowWallet());
            this._name = player.Name;
            this.CanPlay = true;
        }

        public int AddCard(Card newCard, int x = 11)
        {
            cardsOfPerson.Add(newCard);
            if (newCard.CardValue == Value.Туз)
            {
                count(x);
            }
            else
            {
                count(newCard);
            }
            return winCheck();
        }

        private int winCheck()
        {
            if (CountOfPlayer == 21) return 1;
            else if (CountOfPlayer < 21) return 0;
            else return -1;
        }

        private void count(Card card)
        {
            if(card.CardValue <= Value.Десять)
            {
                CountOfPlayer += (int)card.CardValue + 2;
            }
            else
            {
                CountOfPlayer += 10;
            }
        }

        private void count(int x)
        {
            CountOfPlayer += x;
        }

        public List<Card> ShowCards()
        {
            return this.cardsOfPerson.ToList();
        }

        // Обробка грошей
        void IPerson.AddMoney(int coins)
        {
            moneyOfPlayer.AddMoney(coins);
        }

        void IPerson.LoseMoney(int coins)
        {
            moneyOfPlayer.LoseMoney(coins);
            if(moneyOfPlayer.Money <= 0)
            {
                this.CanPlay = false;
            }
        }

        int IPerson.ShowWallet()
        {
            return moneyOfPlayer.Money;
        }
    }
}
