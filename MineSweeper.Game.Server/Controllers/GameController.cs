using Microsoft.AspNetCore.Mvc;
using MineSweeper.Game;
using System.Text.Json;

namespace MineSweeper.Game.Server.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameFactory _gameFactory;
    private readonly ILogger<GameController> _logger;

    public GameController(IGameFactory gameFactory, ILogger<GameController> logger)
    {
        _gameFactory = gameFactory;
        _logger = logger;
    }

    [HttpGet("get_state")]
    public ActionResult<State> GetState()
    {
        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    [HttpPost("start_game")]
    public ActionResult<State> StartGame(Config config)
    {
        Game = _gameFactory.Create(config);

        OnStateChanged();

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    [HttpPost("reveal_tile")]
    public ActionResult<State> RevealTile(int x, int y)
    {
        Game?.RevealTile(x, y);

        OnStateChanged();

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    [HttpPost("toggle_flag")]
    public ActionResult<State> ToggleFlag(int x, int y)
    {
        Game?.ToggleFlag(x, y);
        
        OnStateChanged();

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    private IGame? Game
    {
        get
        {
            var serialized = HttpContext.Session.GetString("game");

            if (serialized != null)
            {
                return JsonSerializer.Deserialize<Game>(serialized);
            }

            return null;
        }
        set
        {
            var serialized = JsonSerializer.Serialize(value);

            HttpContext.Session.SetString("game", serialized);
        }
    }

    private void OnStateChanged()
    {
        if (Game != null)
        {
            var serialized = JsonSerializer.Serialize(Game);

            HttpContext.Session.SetString("game", serialized);
        }
    }
}
