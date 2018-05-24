using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Reflection;
using System.Threading.Tasks;

	namespace Lisbot
	{
		class Program
		{
			static void Main(string[] args) => new Program().RunBotAsync().GetAwaiter().GetResult();		
			private DiscordSocketClient _client;	
			private CommandService _commands;
			private IServiceProvider _services;	

			public async Task RunbotAsync()
			{
			 _client = new DiscordSocketClient();
			 _commands = new CommandService();
			
			 _services = new ServiceCollection()
				.AddSingleton(_client)
				.AddSingleton(_commands)
				.BuildServiceProvider();

			string botToken = "NDQ5MDg0NTM2MTg2MjA4MjY2.Defkxg.BTinv4WsQbU3gS4zdoND4a2i0kA";

			//event subscriptions
			_client.log += log;

			await RegisterCommandAsync();

			await _client.LoginAsync(TokenType.Bot, botToken);
			
			await _client.StartAsync();

			await Task.Delay(-1);

			}
			
			public asynsc Task RegisterCommandsAsync()
			{
				_client.MessageReceived += Handle CommandAsync;

				await _commands.AddModulesAsync(Assembly .GetEntryAssembly());

			}
			private Task Log(LogMessage arg)
			{
				Console.WriteLine(arg);

				return Task.CompletedTask;
			}
			private async Task HandleCommandAsync(SocketMessage arg)
			{
				var message = arg as SocketUserMessage;

				if (message is null || message.Author.IsBot) return;

				int argPos = 0;

				if (message.MasStringPrefix("gl!", ref argPos) || message.MasMentionPrefix(_client.CurrentUser, ref argPos))
			{
				var context = new SocketCommandContext(_client, message);

				var result = await _commands.ExecuteAsync(context, argPos, _services);
				if (!result.IsSuccess)
					Console.WriteLine(result.ErrorReason)
		}
	}
