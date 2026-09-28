using Games.Data;
using Games.Models;
using System.Linq;

namespace Games.Services.Games
{
    internal class GamesService : IGamesService
    {
        private DataContext _db = new DataContext();

        public void CreateGame()
        {
            Console.WriteLine("Enter game name: ");
            string name = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(name)) throw new Exception("Name cannot be empty");
            Console.WriteLine("Enter game description: ");
            string description = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(description)) throw new Exception("Description cannot be empty");
            Console.WriteLine("Enter game category: ");
            string category = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(category)) throw new Exception("Category cannot be empty");
            Console.WriteLine("Enter game price: ");
            double price = double.Parse(Console.ReadLine());
            if (price < 1 || price > 300_000) throw new Exception("Price must be between 1 and 300000");

            var gameObj = new Game
            {
                Name = name,
                Description = description,
                Category = category,
                Price = price
            };

            _db.Games.Add(gameObj);
            _db.SaveChanges();
            Console.WriteLine("Game created successfully!");
        }

        public void DeleteGame()
        {
            Console.WriteLine("Enter id to delete game: ");
            int id = int.Parse(Console.ReadLine());
            var game = _db.Games.Find(id);
            if (game == null) throw new Exception("Game not found");
            _db.Games.Remove(game);
            _db.SaveChanges();
            Console.WriteLine("Game deleted successfully!");
        }

        public void Filter()
        {
            Console.WriteLine("Filter by: 1) Category  2) Price range  3) Name contains");
            var choice = Console.ReadLine();

            IEnumerable<Game> results = Enumerable.Empty<Game>();

            if (choice == "1")
            {
                Console.WriteLine("Enter category: ");
                var category = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(category)) throw new Exception("Category cannot be empty");
                results = _db.Games.Where(g => g.Category == category).ToList();
            }
            else if (choice == "2")
            {
                Console.WriteLine("Enter minimum price: ");
                if (!double.TryParse(Console.ReadLine(), out var min)) throw new Exception("Invalid price");
                Console.WriteLine("Enter maximum price: ");
                if (!double.TryParse(Console.ReadLine(), out var max)) throw new Exception("Invalid price");
                if (min > max) throw new Exception("Minimum cannot be greater than maximum");
                results = _db.Games.Where(g => g.Price >= min && g.Price <= max).ToList();
            }
            else if (choice == "3")
            {
                Console.WriteLine("Enter text to search in name: ");
                var text = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(text)) throw new Exception("Search text cannot be empty");
                results = _db.Games.Where(g => g.Name.Contains(text)).ToList();
            }
            else
            {
                Console.WriteLine("Invalid choice");
                return;
            }

            if (!results.Any())
            {
                Console.WriteLine("No games found matching the filter.");
                return;
            }

            foreach (var game in results)
            {
                Console.WriteLine(game);
            }
        }

        public void GetAllGames()
        {
            var games = _db.Games.ToList();
            if (games == null || games.Count == 0)
            {
                Console.WriteLine("No games available.");
                return;
            }

            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
        }

        public void UpdateGame()
        {
            Console.WriteLine("Enter id to update game: ");
            if (!int.TryParse(Console.ReadLine(), out var id)) throw new Exception("Invalid id");
            var game = _db.Games.Find(id);
            if (game == null) throw new Exception("Game not found");

            Console.WriteLine($"Current name: {game.Name}. Enter new name (leave empty to keep): ");
            var name = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(name)) game.Name = name;

            Console.WriteLine($"Current description: {game.Description}. Enter new description (leave empty to keep): ");
            var description = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(description)) game.Description = description;

            Console.WriteLine($"Current category: {game.Category}. Enter new category (leave empty to keep): ");
            var category = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(category)) game.Category = category;

            Console.WriteLine($"Current price: {game.Price}. Enter new price (leave empty to keep): ");
            var priceInput = Console.ReadLine();
            if (!string.IsNullOrWhiteSpace(priceInput))
            {
                if (!double.TryParse(priceInput, out var price)) throw new Exception("Invalid price");
                if (price < 1 || price > 300_000) throw new Exception("Price must be between 1 and 300000");
                game.Price = price;
            }

            _db.Games.Update(game);
            _db.SaveChanges();
            Console.WriteLine("Game updated successfully!");
        }
    }
}
