using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TestBot.Commands
{
    class DoubleDownCommand : Command
    {
        public override string Name => "/double_down";

        public override void Execute(MessageEventArgs e, TelegramBotClient Bot)
        {
            TelegramBotUtilities.DoubleDownBid();
            TelegramBotUtilities.ShowBid(e, Bot);
        }
    }
}
