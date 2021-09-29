using DSharpPlus.CommandsNext;
using DSharpPlus.CommandsNext.Attributes;
using DSharpPlus.Entities;
using DSharpPlus.Interactivity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace NotifyBot.Commands
{
    
    public class Giveaway : BaseCommandModule
    {
        [Command("gstart")]
        [RequireRoles(RoleCheckMode.Any, "Super Administrator")]
        public async Task Gstart(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync("@everyone").ConfigureAwait(false);
            //var eb = new DiscordEmbedBuilder { Description = "<@&762992138953687050>" };
            //await ctx.Channel.SendMessageAsync("", false, eb).ConfigureAwait(false);
            await ctx.Message.DeleteAsync();
        }

        [Command("introduce")]
        [RequireRoles(RoleCheckMode.Any, "Super Administrator")]
        public async Task Hello(CommandContext ctx)
        {
            //await ctx.Channel.SendMessageAsync("Bok! Ja sam novi CroHerze android kreiran ! :star2:").ConfigureAwait(false);
            var eb = new DiscordEmbedBuilder { 
                Title = ":star2: Pozdrav! :star2:",
                Description = "Ja sam novi android kreiran od strane Crozon corp. Ovdje sam kako bih Vam olakšao vođenje Discord servera.\nKako Vam mogu pomoći?", 
                Color = DiscordColor.Orange };
            await ctx.Channel.SendMessageAsync("", false, eb).ConfigureAwait(false);
        }

        [Command("reci")]
        [RequireRoles(RoleCheckMode.Any, "Super Administrator")]
        public async Task Say(CommandContext ctx)
        {
            await ctx.Channel.SendMessageAsync(ctx.RawArgumentString).ConfigureAwait(false);
            await ctx.Message.DeleteAsync();
        }
    }
}
