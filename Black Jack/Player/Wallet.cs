using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    class Wallet
    {
        public int Money { get; private set; } = 0;

        public Wallet()
        {
            Money = 1000;
        }

        public Wallet(int coins)
        {
            Money = coins;
        }

        public void AddMoney(int coins)
        {
            Money += coins;
        }

        public void LoseMoney(int coins)
        {
            Money -= coins;
        }
    }
}
