using Discord.Commands;
using System;
using System.Collection.Generic;
using System.Text;

namespace TutorialBot.Modules
{
	public class Ping : ModuleBase<SocketCommandContext>
	{
		[Command("I like u")]
		public async Task PingAsync()
		{
			await ReplyAsync("I know, I like me too")
		}
	}
}
