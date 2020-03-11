using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TestBot
{
    public abstract class Command
    {
        public abstract string Name { get; }

        public abstract void Execute(MessageEventArgs e, TelegramBotClient Bot);
    }
}
