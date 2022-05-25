using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MineSweeper.API.Score.Context;
using MineSweeper.API.Score.Models;
using System.Linq;


[ApiController]
[Route("[controller]")]
public class ScoreController : ControllerBase
{
    private readonly ILogger<ScoreController> _logger;
    //private readonly IRepository<Score> _scoreRepository;
    private readonly ScoreContext _scoreContext;

    public ScoreController(ILogger<ScoreController> logger, ScoreContext scoreContext)
    {
        _logger = logger;
        //_scoreRepository = scoreRepository;
        _scoreContext = scoreContext;
    }

    // GET: api/Score
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Score>>> GetScores()
    {
        var scores = _scoreContext.Scores.ToList<Score>();
        return Ok(scores);
    }

    // POST: api/Score
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async void PostScore(Score score)
    {
        _scoreContext.Scores.Add(score);
        await _scoreContext.SaveChangesAsync();

        CreatedAtAction("GetScore", new { id = score.Id }, score);
    }
}
