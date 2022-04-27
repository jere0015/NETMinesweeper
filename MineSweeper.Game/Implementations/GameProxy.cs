using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Text.Json;
using System.Net.Http;
using System.Net.Http.Headers;
namespace MineSweeper.Game.Implementations
{
    public class GameProxy : IGame
    {
        public GameProxy(HttpClient httpClient)
        {
            HttpClient = httpClient;
        }

        public State State  { get; private set; }

        public HttpClient HttpClient { get; }

        public void RevealTile(int x, int y)
        {
            var content = new
            {
                x = x,
                y = y,
            };

            var resp = HttpClient.PostAsync("reveal_tile", JsonSerializer.Serialize(content));
            var response = client.PostAsync("api/AgentCollection", new StringContent(
                new JavaScriptSerializer().Serialize(user), Encoding.UTF8, "application/json")).Result;
            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;

                State = JsonSerializer.Deserialize<State>(content);
            }
        }

        public void ToggleFlag(int x, int y)
        {
            throw new NotImplementedException();
        }

        private async void Post()
        {
        }
    }
}
