using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;



namespace MineSweeper.Blazor.Services
{
    public class ScoreService : IScoreService
    {

        private readonly HttpClient httpClient;

        public ScoreService(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<Score>> GetScore(int id)
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Score>>("api/score/{id}");
        }

        public async Task<IEnumerable<Score>> GetScores()
        {
            return await httpClient.GetFromJsonAsync<IEnumerable<Score>>("api/score");
        }

        public Task<IEnumerable<Score>> PostScore(Score score)
        {
            throw new NotImplementedException();
        }
    }
}

