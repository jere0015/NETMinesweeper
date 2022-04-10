using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MineSweeper.Blazor.Services
{
    public interface IScoreService
    {

        Task<IEnumerable<Score>> GetScores();

        Task<IEnumerable<Score>> GetScore(int id);

        Task<IEnumerable<Score>> PostScore(Score score);

    }
}
