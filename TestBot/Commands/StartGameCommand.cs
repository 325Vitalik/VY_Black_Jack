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
    class StartGameCommand : Command
    {
        public override string Name => "/start_game";

        public override void Execute(MessageEventArgs e, TelegramBotClient Bot)
        {
            Program.cardPack = new PackOfCards();
            Program.Player = new Player(Program.Player as IPerson);
            Program.Dealer = new Player(Program.Dealer as IPerson);

            Bot.SendTextMessageAsync(e.Message.Chat.Id, "Колоду потасовано");

            BidCommand startingBid = new BidCommand();
            startingBid.Execute(e, Bot);

            TelegramBotUtilities.BidDelege = TelegramBotUtilities.ShowBid;

            TelegramBotUtilities.BidDelege += TelegramBotUtilities.AddCardToPlayerAtStart;
            TelegramBotUtilities.BidDelege += TelegramBotUtilities.AddCardToPlayerAtStart;
            TelegramBotUtilities.BidDelege += TelegramBotUtilities.AddCardToDealer;
            TelegramBotUtilities.BidDelege += TelegramBotUtilities.AddCardToDealer;

            TelegramBotUtilities.BidDelege += TelegramBotUtilities.ShowCardsOfPlayer;
            TelegramBotUtilities.BidDelege += TelegramBotUtilities.ShowOneDealerCard;
        }
    }
}
