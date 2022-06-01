using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MineSweeper.API.Score.Context;

[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly ILogger<ScoreController> _logger;
    private readonly MineSweeper.Game.IRepository<MineSweeper.Game.Score> _scoreRepository;

    public ScoreController(
        ILogger<ScoreController> logger,
        MineSweeper.Game.IRepository<MineSweeper.Game.Score> scoreRepository
    )
    {
        _logger = logger;
        _scoreRepository = scoreRepository;
    }

    // GET: api/Score
    [HttpGet]
    public ActionResult<IEnumerable<MineSweeper.Game.Score>> GetScores()
    {
        return Ok(_scoreRepository.Items());
    }

    // POST: api/Score
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public IActionResult PostScore(MineSweeper.Game.Score score)
    {
        _scoreRepository.Create(score);
        return Ok();
    }

    [HttpDelete]
    public ActionResult DeleteScore(MineSweeper.Game.Score score) 
    {
        _scoreRepository.Delete(score);

        return Ok();
    }
}
