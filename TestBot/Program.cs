using System;
using System.Collections.Generic;
using Telegram.Bot;
using Telegram.Bot.Args;
using TestBot.Commands;
using Black_Jack;

namespace TestBot
{
    class Program
    {
        public static readonly TelegramBotClient Bot = new TelegramBotClient("1064711136:AAGCkmJ6sctFi1zmmRpS9rYQ1Pok14v01sU");
        private static List<Command> commandList = new List<Command>();
        public static PackOfCards cardPack { get; set; }
        public static Player Player = new Player("Vitalii");
        public static Player Dealer = new Player("Дилер");

        static void Main(string[] args)
        {
            commandList.Add(new HelloCommand());
            commandList.Add(new StartGameCommand());
            commandList.Add(new AddCommand());
            commandList.Add(new EndGameCommand());
            commandList.Add(new DoubleDownCommand());

            Bot.OnMessage += OnMesssage;
            Bot.OnMessage += TelegramBotUtilities.Bid;

            Bot.StartReceiving();
            Console.ReadLine();
            Bot.StopReceiving();
        }

        private static void OnMesssage(object sender, MessageEventArgs e)
        {
            foreach(var command in commandList)
            {
                if(e.Message.Text == command.Name)
                {
                    command.Execute(e, Bot);
                }
            }
        }
    }
}
