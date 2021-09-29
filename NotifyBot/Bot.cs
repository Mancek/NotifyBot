using DSharpPlus;
using DSharpPlus.CommandsNext;
using DSharpPlus.Entities;
using DSharpPlus.EventArgs;
using DSharpPlus.Interactivity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NotifyBot.Commands;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Victoria;

namespace NotifyBot
{
    public class Bot
    {
        public DiscordClient Client { get; private set; }
        public CommandsNextExtension Commands { get; private set; }

        public async Task RunAsync()
        {
            var json = string.Empty;

            using (var fs = File.OpenRead("config.json"))
            using (var sr = new StreamReader(fs, new UTF8Encoding(false)))
                json = await sr.ReadToEndAsync().ConfigureAwait(false);

            var configJson = JsonConvert.DeserializeObject<ConfigJson>(json);
            var config = new DiscordConfiguration
            {
                Token = configJson.Token,
                TokenType = TokenType.Bot,
                AutoReconnect = true,
                MinimumLogLevel = LogLevel.Debug,
            };

            Client = new DiscordClient(config);
            Client.Ready += OnClientReady;

            var commandsConfig = new CommandsNextConfiguration
            {
                StringPrefixes = new string[] { configJson.Prefix },
                EnableMentionPrefix = true,
                EnableDms = false,
                DmHelp = true,
                IgnoreExtraArguments = true,
                EnableDefaultHelp = false
            };

            Commands = Client.UseCommandsNext(commandsConfig);
            Commands.RegisterCommands<Giveaway>();


            await Client.ConnectAsync();

            await Task.Delay(-1);
        }

        private Task OnClientReady(DiscordClient sender, ReadyEventArgs e)
        {
            //Client.UpdateStatusAsync(new DiscordActivity("Thinking...", 0), (UserStatus)1,DateTimeOffset.Now);
            return Task.CompletedTask;
        }
    }
}
