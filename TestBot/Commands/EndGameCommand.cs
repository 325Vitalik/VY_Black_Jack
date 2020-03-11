using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;
using Black_Jack;

namespace TestBot.Commands
{
    class EndGameCommand : Command
    {
        public override string Name => "/end_game";

        public override void Execute(MessageEventArgs e, TelegramBotClient Bot)
        {
            if (Program.Dealer.CountOfPlayer <= Program.Player.CountOfPlayer && Program.Dealer.CountOfPlayer <= 21)
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Перемога!!!");
                TelegramBotUtilities.Win();
            }
            else
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Поразка...");
            }

            TelegramBotUtilities.ShowCardsOfPlayer(e, Bot);
            TelegramBotUtilities.ShowCardsOfDealer(e, Bot);
            TelegramBotUtilities.ShowWallet(e, Bot);
        }
    }
}
