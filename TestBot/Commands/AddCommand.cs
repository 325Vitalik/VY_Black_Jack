using Black_Jack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TestBot.Commands
{
    class AddCommand : Command
    {
        public override string Name => "/add_card";

        public override void Execute(MessageEventArgs e, TelegramBotClient Bot)
        {
            if(TelegramBotUtilities.AddCardToPlayer(e, Bot))
            {
                TelegramBotUtilities.ShowBid(e, Bot);

                TelegramBotUtilities.ShowCardsOfPlayer(e, Bot);
                TelegramBotUtilities.ShowOneDealerCard(e, Bot);
            }
        }
    }
}
