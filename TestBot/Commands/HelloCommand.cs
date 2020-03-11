using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TestBot.Commands
{
    public class HelloCommand : Command
    {
        public override string Name => "/start";

        public override void Execute(MessageEventArgs e, TelegramBotClient Bot)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, "Hello, I`m alive");
        }
    }
}
