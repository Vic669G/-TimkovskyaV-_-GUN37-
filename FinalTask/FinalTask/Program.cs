using FinalTask.Casino;
using FinalTask.Game;
using System.Numerics;

public class Program
{
    static void Main()
    {
        Console.WriteLine("=== Welcome to Final Casino Game ===");
        Console.Write("Enter your name: ");
        string name = Console.ReadLine();

        var saveService = new FileSystemSaveLoadService("SaveData");
        Player player = saveService.LoadData(name) ?? new Player(name);

        if (player.Bank <= 0)
            player.Bank = 1000;

        Console.WriteLine($"Welcome, {player.Name}! Your bank: {player.Bank}");

        IGame casino = new Casino(player, saveService);
        casino.StartGame();
    }
}