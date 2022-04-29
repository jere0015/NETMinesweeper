using Microsoft.AspNetCore.Mvc;
using MineSweeper.Game;

[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly ILogger<ScoreController> _logger;
    private readonly IRepository<Score> _scoreRepository;

    public ScoreController(ILogger<ScoreController> logger, IRepository<Score> scoreRepository)
    {
        _logger = logger;
        _scoreRepository = scoreRepository;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Score>> Get()
    {
        return Ok(_scoreRepository.Items());
    }

    [HttpPost]
    public IActionResult Post(Score score)
    {
        _logger.LogInformation("New score received");

        _scoreRepository.Create(score);
        
        return Ok();
    }
}
