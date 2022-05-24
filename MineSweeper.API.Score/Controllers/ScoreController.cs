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

    // GET: api/Score
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Score>>> GetScores()
    {
        return await _context.Scores.ToListAsync();
    }

    // POST: api/Score
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<Score>> PostScore(Score score)
    {
        _context.Scores.Add(score);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetScore", new { id = score.Id }, score);
    }
}
