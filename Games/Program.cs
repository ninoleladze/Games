using Games.Services.Games;

GamesService gamesService = new GamesService();
while (true)
{
    try
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1) Create Game");
        Console.WriteLine("2) Delete Game");
        Console.WriteLine("3) Filter Games");
        Console.WriteLine("4) List All Games");
        Console.WriteLine("5) Update Game");
        Console.WriteLine("6) Exit");
        var input = Console.ReadLine();
        switch (input)
        {
            case "1":
                gamesService.CreateGame();
                break;
            case "2":
                gamesService.DeleteGame();
                break;
            case "3":
                gamesService.Filter();
                break;
            case "4":
                gamesService.GetAllGames();
                break;
            case "5":
                gamesService.UpdateGame();
                break;
            case "6":
                return;
            default:
                Console.WriteLine("Invalid option. Please try again.");
                break;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}
