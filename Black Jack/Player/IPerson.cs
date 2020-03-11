using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Black_Jack
{
    public interface IPerson
    {
        string Name {get;}

        void AddMoney(int coins);

        void LoseMoney(int coins);

        int ShowWallet();
    }
}