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
    class BidCommand : Command
    {
        public override string Name => "/bid";

        public override void Execute(MessageEventArgs e, TelegramBotClient Bot)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, "Введіть початкову ставку");

        }
    }
}
