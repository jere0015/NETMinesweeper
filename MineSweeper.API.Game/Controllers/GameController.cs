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
        _logger.LogInformation("User requested state");

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    [HttpPost("start_game")]
    public ActionResult<State> StartGame(Config config)
    {
        _logger.LogInformation("User requested StartGame");

        Game = _gameFactory.Create(config);

        OnStateChanged();

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    [HttpPost("reveal_tile")]
    public ActionResult<State> RevealTile(Point point)
    {
        _logger.LogInformation($"User requested RevealTile x: {point.X} y: {point.Y}");

        Game.RevealTile(point.X, point.Y);

        OnStateChanged();

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    [HttpPost("toggle_flag")]
    public ActionResult<State> ToggleFlag(Point point)
    {
        _logger.LogInformation($"User requested ToggleFlag x: {point.X} y: {point.Y}");

        Game.ToggleFlag(point.X, point.Y);
        
        OnStateChanged();

        if (Game?.State == null)
            return BadRequest("No state");

        return Game.State;
    }

    private IGame? _game = null;
    private IGame Game
    {
        get
        {
            if(_game == null)
			{
                var serialized = HttpContext.Session.GetString("game");

                if (serialized != null)
                {
                    var deserialized = JsonSerializer.Deserialize<Game>(serialized);

                    if (deserialized != null)
                        _game = deserialized;
                }
            }

            if(_game == null)
			{
                throw new InvalidOperationException("No 'Game' object in session");
			}

            return _game;
        }
        set
        {
            var serialized = JsonSerializer.Serialize(value);

            HttpContext.Session.SetString("game", serialized);
        }
    }
    private void OnStateChanged()
    {
        if (_game != null)
        {
            var serialized = JsonSerializer.Serialize(_game);

            HttpContext.Session.SetString("game", serialized);
        }
    }
}
