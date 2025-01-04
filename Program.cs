// Console UI
Console.WriteLine("Waveform Bot Builder | v1.1");
Console.WriteLine("=-=-=-=-=-=-=-=-=-=-=-=-=-=");
Console.WriteLine("");
Console.WriteLine("Welcome to Waveform. This program will create a bot template based on your input. Currently only discord.py is supported, discord.js will be added in the near future.");
Console.WriteLine("Press any key to continue...");
Console.ReadKey();
Console.WriteLine("");

// Inputs
Console.WriteLine("Enter your bot token: ");
string botToken = Console.ReadLine();
Console.WriteLine("Choose a command prefix for your bot: ");
string commandPrefix = Console.ReadLine();
Console.WriteLine("Choose a status for your bot (online/idle/dnd): ");
string botStatus = Console.ReadLine();
Console.WriteLine("Choose an idle presence for your bot (watching/playing/listening): ");
string idlePresence = Console.ReadLine();
Console.WriteLine("Enter the presence text: ");
string presenceText = Console.ReadLine();

Console.WriteLine("");
Console.WriteLine("Generating template...");

// Template
string botTemplate = $@"
import discord
from discord.ext import commands

intents = discord.Intents.default()
intents.message_content = True

bot = commands.Bot(command_prefix='{commandPrefix}', intents=intents)

@bot.event
async def on_ready():
    print(f'Logged in as ' + bot.user)
    
    # Set bot's status and activity
    await bot.change_presence(status=discord.Status.{botStatus}, activity=discord.Activity(type=discord.ActivityType.{idlePresence}, name='{presenceText}'))

bot.run('{botToken}')
";

Console.WriteLine("Enter the directory to save the template: ");
string filePath = Console.ReadLine();
System.IO.File.WriteAllText(filePath, botTemplate);
Console.WriteLine($"Template saved to {filePath}");

Console.WriteLine("Press any key to exit.");
Console.ReadKey();
