using Black_Jack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Args;

namespace TestBot
{
    public static class TelegramBotUtilities
    {
        public static int BidCoins { get; private set; }
        public static bool BidCoinsCheck { get; private set; } = false;
        public delegate void BidDelegate(MessageEventArgs e, TelegramBotClient Bot);
        public static BidDelegate BidDelege;

        public static void ShowCardsOfPlayer(MessageEventArgs e, TelegramBotClient Bot)
        {
            string result = (Program.Player as IPerson).Name + "\n";
            foreach (var card in Program.Player.ShowCards())
            {
                result += card.ToString() + "\n";
            }
            result += Program.Player.CountOfPlayer;
            Bot.SendTextMessageAsync(e.Message.Chat.Id, result);
        }

        public static void ShowCardsOfDealer(MessageEventArgs e, TelegramBotClient Bot)
        {
            string result = "Дилер\n";
            foreach (var card in Program.Dealer.ShowCards())
            {
                result += card.ToString() + "\n";
            }
            result += Program.Dealer.CountOfPlayer;
            Bot.SendTextMessageAsync(e.Message.Chat.Id, result);
        }

        public static void ShowOneDealerCard(MessageEventArgs e, TelegramBotClient Bot)
        {
            string result = "Дилер\n";
            result += Program.Dealer.ShowCards()[0] + "\n";
            result += "[Карта]";
            Bot.SendTextMessageAsync(e.Message.Chat.Id, result);
        }

        public static bool AddCardToPlayer(MessageEventArgs e, TelegramBotClient Bot)
        {
            Card randomCard = Program.cardPack.getCard();
            int winCheck = Program.Player.AddCard(randomCard);
            if (winCheck == 1)
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Перемога!!!");
                ShowCardsOfPlayer(e, Bot);
                ShowCardsOfDealer(e, Bot);
                Win();
                ShowWallet(e, Bot);
                return false;
            }
            else if (winCheck == -1)
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Поразка...");
                ShowCardsOfPlayer(e, Bot);
                ShowCardsOfDealer(e, Bot);
                ShowWallet(e, Bot);
                return false;
            }
            return true;
        }

        public static void AddCardToPlayerAtStart(MessageEventArgs e, TelegramBotClient Bot)
        {
            Card randomCard = Program.cardPack.getCard();
            int winCheck = Program.Player.AddCard(randomCard);
            if (winCheck == 1)
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Перемога!!!");
                ShowCardsOfPlayer(e, Bot);
                ShowCardsOfDealer(e, Bot);
                Win();
                ShowWallet(e, Bot);
            }
            else if (winCheck == -1)
            {
                Bot.SendTextMessageAsync(e.Message.Chat.Id, "Поразка...");
                ShowCardsOfPlayer(e, Bot);
                ShowCardsOfDealer(e, Bot);
                ShowWallet(e, Bot);
            }
        }

        public static void AddCardToDealer(MessageEventArgs e, TelegramBotClient Bot)
        {
            Card randomCard = Program.cardPack.getCard();
            Program.Dealer.AddCard(randomCard);
        }

        public static void ShowBid(MessageEventArgs e, TelegramBotClient Bot)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, $"Ставка: {BidCoins}\n Залишок: {(Program.Player as IPerson).ShowWallet()}");
        }

        public static void Bid(object sender, MessageEventArgs e)
        {
            if(e.Message.Text[0] != '/')
            {
                int number;
                if(Int32.TryParse(e.Message.Text.Trim(), out number))
                {
                    BidCoins = number;
                    BidCoinsCheck = true;
                    FirstBid(e, Program.Bot);
                    BidDelege(e, Program.Bot);
                }
                else
                {
                   Program.Bot.SendTextMessageAsync(e.Message.Chat.Id, "Введіть число");
                }
            }
        }

        public static void DoubleDownBid()
        {
            (Program.Player as IPerson).LoseMoney(TelegramBotUtilities.BidCoins);
            BidCoins *= 2;
        }

        public static void FirstBid(MessageEventArgs e, TelegramBotClient Bot)
        {
            (Program.Player as IPerson).LoseMoney(TelegramBotUtilities.BidCoins);
        }

        public static void Win()
        {
            (Program.Player as IPerson)?.AddMoney((int)Math.Floor(BidCoins*3/2.0));
        }

        public static void ShowWallet(MessageEventArgs e, TelegramBotClient Bot)
        {
            Bot.SendTextMessageAsync(e.Message.Chat.Id, $"Рахунок: {(Program.Player as IPerson)?.ShowWallet()}");
        }
    }
}
