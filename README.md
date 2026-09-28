# Games

A console video-game catalog built with **C#, .NET 8 and EF Core (SQL Server)**, with full CRUD for games through a service layer.

## Structure

- Models/Game.cs — game entity
- Services/Games/ — IGamesService + GamesService (CRUD)
- Data/DataContext.cs — EF Core DbContext

## Run

```bash
dotnet ef database update --project Games
dotnet run --project Games
```
