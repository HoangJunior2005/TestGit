using GameApi.DTOs;

namespace GameApi;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);



        var app = builder.Build();

        List<GameDTO> games = new List<GameDTO>()
        {
            new GameDTO(1,"Game 1","Action"),
            new GameDTO(2,"Game 2","Adventure"),
            new GameDTO(3,"Game 3","RPG"),
        };
        app.MapGet("/games", () => games);

        app.MapGet("/games/{id}", (int id) => games.Find(g => g.Id == id));

        app.MapGet("/games/info/{genre}",(String genre) => games.Find(b=>b.Genre.ToUpper() == genre.ToUpper()) );
        
        
        app.Run();
    }
}
